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
        private static int count = 0;

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
            
            var oldId = card.Id;
            card.Id = ++count;
            
            cards.Add(card);
            
            var newId = card.Id;
            card.Id = oldId;
            
            return newId;
        }

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
                    return true;
                }
            }

            return false;
        }
    }
}
