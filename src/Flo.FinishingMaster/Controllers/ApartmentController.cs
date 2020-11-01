using System;
using System.Threading.Tasks;
using Flo.FinishingMaster.Infrastructure.Entity;
using Flo.FinishingMaster.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Flo.FinishingMaster.Controllers
{
    [Route("api/apartment")]
    [ApiController]
    public class ApartmentController : ControllerBase
    {
        private readonly IApartmentService apartmentService;

        public ApartmentController(IApartmentService apartmentService)
        {
            this.apartmentService = apartmentService;
        }

        [HttpPost]
        public async Task<ActionResult> Update([FromBody] Apartment apartment)
        {
            var result = await apartmentService.UpdateAsync(apartment);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Apartment>> GetById(Guid id)
        {
            var result = await apartmentService.FindByIdAsync(id);
            return result;
        }
    }
}