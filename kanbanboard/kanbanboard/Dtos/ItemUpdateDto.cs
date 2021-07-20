using Microsoft.AspNetCore.Mvc;

namespace kanbanboard.Controllers
{
    public class ItemUpdateDto
    {
        [FromRoute]
        public string Id { get; set; }

        [FromBody]
        public string Text { get; set; }
    }
}