using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Models;

namespace Services.EntityFrameworkCore
{
    public class CardsManagementService : ICardsManagementService
    {
        public CardsManagementService()
        {
            
        }

        public async Task<IList<Card>> GetCardsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Card> GetCardAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CreateAsync(Card card)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(int id, Card card)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
