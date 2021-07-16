using System.Collections.Generic;

namespace kanbanboard.contracts
{
    public class BoardConfig
    {
        public List<BoardConfigColumn> Columns { get; } = new List<BoardConfigColumn>();
    }
}