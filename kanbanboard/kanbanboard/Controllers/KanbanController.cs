using kanbanboard.contracts;
using Microsoft.AspNetCore.Mvc;

namespace kanbanboard.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KanbanController : ControllerBase
    {
        private readonly IInteractors _interactors;

        public KanbanController(IInteractors interactors)
        {
            _interactors = interactors;
        }

        [HttpGet("/board")]
        public Board GetBoard()
        {
            Board result = null;
            _interactors.Start(board => { result = board; });
            return result;
        }

        [HttpPost("/items")]
        public Board PostItem([FromBody] ItemCreateDto createDto)
        {
            var board = _interactors.NewItem(createDto.Text);
            return board;
        }

        [HttpDelete("/items/{id}")]
        public Board DeleteItem([FromRoute] string id)
        {
            var board = _interactors.DeleteItem(id);
            return board;
        }

        [HttpPut("/items/{id}")]
        public Board UpdateItem(ItemUpdateDto updateDto)
        {
            var board = _interactors.UpdateItem(updateDto.Id, updateDto.Text);
            return board;
        }

        [HttpPut("/items/{id}/move/{direction}")]
        public Board MoveItem([FromRoute] string id, [FromRoute] Direction direction)
        {
            var board = _interactors.MoveItem(id, direction);
            return board;
        }
    }
}
