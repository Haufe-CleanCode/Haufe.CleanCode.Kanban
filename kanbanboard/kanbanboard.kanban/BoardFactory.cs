using kanbanboard.contracts;
using System.Collections.Generic;

namespace kanbanboard.kanban
{
	public class BoardFactory : IBoardFactory
	{
		public Board CreateBoard(BoardConfig boardConfig, List<List<Item>> items)
		{
			var board = new Board();
			
			for(int i = 0; i< boardConfig.Columns.Count; i++)
			{
				AddColumn(board);

				CopyHeader(boardConfig, board, i);

				CopyItems(items, board, i);
			}

			return board;
		}

		private static void AddColumn(Board board)
		{
			board.Columns.Add(new Column());
		}

		private static void CopyItems(List<List<Item>> items, Board board, int i)
		{
			foreach (Item item in items[i])
			{
				board.Columns[i].Items.Add(item);
			}
		}

		static void CopyHeader(BoardConfig boardConfig, Board board, int i)
		{
			board.Columns[i].Header = boardConfig.Columns[i].Header;
		}
	}
}
