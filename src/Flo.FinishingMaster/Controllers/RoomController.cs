using System;
using System.Threading.Tasks;
using Flo.FinishingMaster.Infrastructure.Entity;
using Flo.FinishingMaster.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Flo.FinishingMaster.Controllers
{
    [Route("api/room")]
    //  [Authorize]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService roomService;

        public RoomController(IRoomService roomService)
        {
            this.roomService = roomService;
        }

        [HttpPost]
        public async Task<ActionResult> Update([FromBody] Room room)
        {
            var result = await roomService.UpdateAsync(room);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Room>> GetById(Guid id)
        {
            var result = await roomService.FindByIdAsync(id);
            return result;
        }
    }
}