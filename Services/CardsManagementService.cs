using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Services.Exceptions;
using Services.Models;

namespace Services
{
    /// <summary>
    /// Provides a cards management service using json file for storage.
    /// </summary>
    public class CardsManagementService : ICardsManagementService
    {
        private readonly string jsonFilePath;
        private int count;

        /// <summary>
        /// Initializes a new instance of the <see cref="CardsManagementService"/> class.
        /// </summary>
        /// <param name="jsonFilePath">A path of the json file.</param>
        public CardsManagementService(string jsonFilePath)
        {
            this.jsonFilePath = jsonFilePath;
            if (!File.Exists(jsonFilePath))
            {
                var directory = Path.GetDirectoryName(jsonFilePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                using var file = File.Create(jsonFilePath);
                using var writer = new StreamWriter(file);
                using var jsonWriter = new JsonTextWriter(writer);
                jsonWriter.WriteStartArray();
                jsonWriter.WriteEndArray();
                this.count = 0;
            }
            else
            {
                using var reader = new StreamReader(jsonFilePath);
                var json = reader.ReadToEnd();
                var cards = JsonConvert.DeserializeObject<List<Card>>(json)!;
                this.count = cards.LastOrDefault()?.Id ?? 0;
            }
        }

        /// <inheritdoc/>
        public async Task<IList<Card>> GetCardsAsync()
        {
            using var reader = new StreamReader(this.jsonFilePath);
            var json = await reader.ReadToEndAsync().ConfigureAwait(false);
            var cards = JsonConvert.DeserializeObject<List<Card>>(json);
            return cards;
        }

        /// <exception cref="CardNotFoundException">Thrown if the card with given identifier doesn't exist.</exception>
        /// <inheritdoc/>
        public async Task<Card> GetCardAsync(int id)
        {
            var cards = await GetCardsAsync().ConfigureAwait(false);
            var card = cards.FirstOrDefault(x => x.Id == id);
            return card ?? throw new CardNotFoundException(id);
        }

        /// <inheritdoc/>
        public async Task<int> CreateAsync(Card card)
        {
            var cards = await GetCardsAsync().ConfigureAwait(false);
            card.Id = ++count;
            
            cards.Add(card);
            await WriteFileAsync(cards);

            return card.Id;
        }

        /// <exception cref="CardNotFoundException">Thrown if the card with given identifier doesn't exist.</exception>
        /// <inheritdoc/>
        public async Task<bool> UpdateAsync(int id, Card card)
        {
            var cards = await GetCardsAsync().ConfigureAwait(false);
            var foundCard = cards.FirstOrDefault(x => x.Id == id);
            if (foundCard is null)
            {
                throw new CardNotFoundException(id);
            }

            if (foundCard.Name == card.Name && foundCard.Image.SequenceEqual(card.Image))
            {
                return false;
            }

            foundCard.Name = card.Name;
            foundCard.Image = card.Image;

            await WriteFileAsync(cards);

            return true;
        }
        
        /// <inheritdoc/>
        public async Task<bool> DeleteAsync(int id)
        {
            var cards = await GetCardsAsync().ConfigureAwait(false);
            for (int i = 0; i < cards.Count; i++)
            {
                if (cards[i].Id == id)
                {
                    cards.RemoveAt(i);
                    await WriteFileAsync(cards);
                    return true;
                }
            }

            return false;
        }

        private async Task WriteFileAsync(IList<Card> cards)
        {
            var json = JsonConvert.SerializeObject(cards);
            await using var writer = new StreamWriter(this.jsonFilePath);
            using var jsonWriter = new JsonTextWriter(writer);
            await jsonWriter.WriteRawAsync(json);
        }
    }
}
