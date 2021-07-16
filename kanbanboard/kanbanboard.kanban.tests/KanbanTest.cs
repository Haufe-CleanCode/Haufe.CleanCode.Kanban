using kanbanboard.contracts;
using NUnit.Framework;
using System.Collections.Generic;

namespace kanbanboard.kanban.tests
{
	[TestFixture]
	public class KanbanTest
	{
		[Test]
		public void CreateBoard()
		{
			var boardFactory = new BoardFactory();

			var boardConfig = new BoardConfig();
			var boardConfigColoumn = new BoardConfigColumn();
			boardConfigColoumn.Header = "Nummer 1";
			var items = new List<List<Item>>();
			items.Add(new List<Item>());

			boardConfig.Columns.Add(boardConfigColoumn);
			Board board = boardFactory.CreateBoard(boardConfig, items);

			Assert.That(board.Columns.Count, Is.EqualTo(1));
			Assert.That(board.Columns[0].Header, Is.EqualTo(boardConfigColoumn.Header));
			Assert.That(board.Columns[0].Items.Count, Is.EqualTo(0));
		}

		[Test]
		public void AddItemToBoard()
		{
			var boardFactory = new BoardFactory();
			var kanbanInst = new Kanban();

			var boardConfig = new BoardConfig();
			var boardConfigColoumn = new BoardConfigColumn();
			boardConfigColoumn.Header = "Nummer 1";
			var items = new List<List<Item>>();
			items.Add(new List<Item>());

			boardConfig.Columns.Add(boardConfigColoumn);
			Board board = boardFactory.CreateBoard(boardConfig, items);

			var item = new Item("text", "id");

			kanbanInst.InsertItem(board, item);

			Assert.That(board.Columns[0].Items.Count, Is.EqualTo(1));
			Assert.That(board.Columns[0].Items[0].Id, Is.EqualTo("id"));
			Assert.That(board.Columns[0].Items[0].Text, Is.EqualTo("text"));
		}

		[Test]
		public void IdGenerator()
		{
			var x = new IdGenerator();

			var guid = x.CreateId();

			var guidPart = guid.Split("-");

			//check for format 8-4-4-4-12
			Assert.That(guidPart.Length, Is.EqualTo(5));

			Assert.That(guidPart[0].Length, Is.EqualTo(8));
			Assert.That(guidPart[1].Length, Is.EqualTo(4));
			Assert.That(guidPart[2].Length, Is.EqualTo(4));
			Assert.That(guidPart[3].Length, Is.EqualTo(4));
			Assert.That(guidPart[4].Length, Is.EqualTo(12));

		}
	}
}
