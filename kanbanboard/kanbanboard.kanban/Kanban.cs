using kanbanboard.contracts;

namespace kanbanboard.kanban
{
	public class Kanban : IKanban
    {

		public Board InsertItem(Board board, Item item)
		{
			board.Columns[0].Items.Add(item);

			return board;
		}

		public Board CheckWIPLimits(Board board)
		{
			foreach( var coloumn in board.Columns )
			{
				coloumn.WIPLimitExceeded = false;

				if ( coloumn.Items.Count > coloumn.WIPLimit )
				{
					coloumn.WIPLimitExceeded = true;
				}
			}

			return board;
		}
	}
}
