using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services;
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
    }
}
