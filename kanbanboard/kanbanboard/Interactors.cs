using System;
using kanbanboard.contracts;

namespace kanbanboard
{
    public class Interactors : IInteractors
    {
        private readonly Board _board = new Board();

        public Interactors() {
            _board.Columns.Add(new Column());
        }
        public void Start(Action<Board> onBoard) {
            onBoard(_board);
        }

        public Board NewItem(string text) {
            var item = new Item(text, Guid.NewGuid().ToString());
            _board.Columns[0].Items.Add(item);
            return _board;
        }

        public Board UpdateItem(string id, string text) {
            throw new NotImplementedException();
        }

        public Board DeleteItem(string id) {
            throw new NotImplementedException();
        }

        public Board MoveItem(string id, Direction direction) {
            throw new NotImplementedException();
        }
    }
}