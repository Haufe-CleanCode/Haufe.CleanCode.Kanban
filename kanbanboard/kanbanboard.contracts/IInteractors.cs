using System;

namespace kanbanboard.contracts
{
    public interface IInteractors
    {
        void Start(Action<Board> onBoard);

        Board NewItem(string text);

        Board UpdateItem(string id, string text);

        Board DeleteItem(string id);

        Board MoveItem(string id, Direction direction);
    }
}