using System.Threading.Tasks;
using Flo.FinishingMaster.Infrastructure.Entity;
using Flo.FinishingMaster.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Flo.FinishingMaster.Controllers
{
    [Route("api/room")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private IRoomService roomService;

        public RoomController(IRoomService roomService)
        {

        }
        [HttpPost]
        public async Task<ActionResult> Update([FromBody] Room room)
        {
            var result = await roomService.UpdateAsync(room);
            return Ok(result);
        }
    }
}