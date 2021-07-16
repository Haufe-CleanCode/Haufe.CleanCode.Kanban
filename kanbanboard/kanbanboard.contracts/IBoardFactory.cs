using System.Collections.Generic;

namespace kanbanboard.contracts
{
    public interface IBoardFactory
    {
        Board CreateBoard(BoardConfig boardConfig, List<List<Item>> items);
    }
}