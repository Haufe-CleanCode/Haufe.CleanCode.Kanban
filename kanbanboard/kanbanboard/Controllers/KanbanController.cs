using kanbanboard.contracts;
using Microsoft.AspNetCore.Mvc;

namespace kanbanboard.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KanbanController : ControllerBase
    {
        private readonly IInteractors _interactors;

        public KanbanController(IInteractors interactors) {
            _interactors = interactors;
        }

        [HttpGet("/board")]
        public Board GetBoard() {
            Board result = null;
            _interactors.Start(board => { result = board; });
            return result;
        }

        [HttpPost("/items")]
        public Board PostItem([FromQuery] string text) {
            var board = _interactors.NewItem(text);
            return board;
        }
    }
}