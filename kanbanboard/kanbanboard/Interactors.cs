using System;
using kanbanboard.boardconfig;
using kanbanboard.contracts;
using kanbanboard.items;
using kanbanboard.kanban;

namespace kanbanboard
{
    public class Interactors : IInteractors
    {
        private Board _board = new Board();

        public Interactors() {
            _board.Columns.Add(new Column());
        }
        public void Start(Action<Board> onBoard) {
            var boardConfigProvider = new BoardConfigProvider();
            var boardConfig = boardConfigProvider.LoadBoardConfig();
            var itemsProvider = new ItemsProvider();
            var items = itemsProvider.LoadItems();
            _board = new BoardFactory().CreateBoard(boardConfig, items);
            onBoard(_board);
        }

        public Board NewItem(string text) {
            var id = new IdGenerator().CreateId();
            var item = new Item(text, id);
            _board = new Kanban().InsertItem(_board, item);
            new ItemsProvider().SaveItems(_board);
            _board = new Kanban().CheckWIPLimits(_board);
            
            return _board;
        }

        public Board UpdateItem(string id, string text) {
            return _board;
        }

        public Board DeleteItem(string id) {
            return _board;
        }

        public Board MoveItem(string id, Direction direction) {
            return _board;
        }
    }
}