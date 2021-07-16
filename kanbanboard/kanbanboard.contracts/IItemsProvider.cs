using System.Collections.Generic;

namespace kanbanboard.contracts
{
    public interface IItemsProvider
    {
        List<List<Item>> LoadItems();

        void SaveItems(Board board);
    }
}