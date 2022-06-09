using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Exceptions;
using Services.Models;

namespace WebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly ICardsManagementService cardsManagementService;

        public CardsController(ICardsManagementService cardsManagementService)
        {
            this.cardsManagementService = cardsManagementService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Card>>> GetCardsAsync()
        {
            if (!(await this.cardsManagementService.GetCardsAsync().ConfigureAwait(false) is List<Card> cards))
            {
                return this.BadRequest();
            }

            return cards;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Card>> GetCardAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            try
            {
                return await this.cardsManagementService.GetCardAsync(id).ConfigureAwait(false);
            }
            catch (CardNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCardAsync(Card card)
        {
            if (card is null)
            {
                return BadRequest();
            }

            if (await this.cardsManagementService.CreateAsync(card) > 0)
            {
                return CreatedAtAction("CreateCard", new { id = card.Id });
            }

            return BadRequest();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCardAsync(int id, Card card)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            try
            {
                if (await this.cardsManagementService.UpdateAsync(id, card))
                {
                    return NoContent();
                }

                return BadRequest();
            }
            catch (CardNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCardAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            if (await this.cardsManagementService.DeleteAsync(id).ConfigureAwait(false))
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
