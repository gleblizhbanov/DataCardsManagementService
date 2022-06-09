using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Models;

namespace Services
{
    /// <summary>
    /// Represents a cards management service.
    /// </summary>
    public interface ICardsManagementService
    {
        /// <summary>
        /// Returns the list of all stored cards.
        /// </summary>
        /// <returns></returns>
        Task<IList<Card>> GetCardsAsync();

        /// <summary>
        /// Returns the card with given identifier.
        /// </summary>
        /// <param name="id">A card identifier.</param>
        /// <returns>Card with given identifier.</returns>
        Task<Card> GetCardAsync(int id);

        /// <summary>
        /// Adds a new card to the storage.
        /// </summary>
        /// <param name="card">A card to add.</param>
        /// <returns>An identifier of the added card.</returns>
        Task<int> CreateAsync(Card card);

        /// <summary>
        /// Updated the card with the given identifier.
        /// </summary>
        /// <param name="id">An identifier of the card to update.</param>
        /// <param name="card">A card data to replace with.</param>
        /// <returns>True if the card was updated successfully, false otherwise.</returns>
        Task<bool> UpdateAsync(int id, Card card);

        /// <summary>
        /// Deleted the card with the given identifier.
        /// </summary>
        /// <param name="id">An identifier of the card to delete.</param>
        /// <returns>True if the card was deleted successfully, false otherwise.</returns>
        Task<bool> DeleteAsync(int id);
    }
}
