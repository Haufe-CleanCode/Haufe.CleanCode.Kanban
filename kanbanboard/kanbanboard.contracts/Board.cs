using System.Collections.Generic;

namespace kanbanboard.contracts
{
    public class Board
    {
        public List<Column> Columns { get; } = new List<Column>();
    }
}