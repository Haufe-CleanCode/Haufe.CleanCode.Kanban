using NUnit.Framework;
using System.Text.RegularExpressions;
using kanbanboard.contracts;

namespace kanbanboard.items.Tests
{
    [TestFixture()]
    public class ItemsProviderTests
    {
        const string ItemsFileName = "items.json";

        [Test()]
        public void SaveItemsTest()
        {
            System.IO.File.Delete( ItemsFileName );


            var board = new Board();
            board.Columns.Clear();

            var column = new Column()
            {
                Header = "hdr1",
                WIPLimit = 1,
            };
            column.Items.Clear();
            column.Items.Add( new Item( "Item11", "Id11" ) );
            column.Items.Add( new Item( "Item12", "Id12" ) );
            column.Items.Add( new Item( "Item13", "Id13" ) );

            board.Columns.Add( column );

            column = new Column()
            {
                Header = "hdr2",
                WIPLimit = 1,
            };
            column.Items.Clear();
            column.Items.Add( new Item( "Item21", "Id21" ) );
            column.Items.Add( new Item( "Item22", "Id22" ) );
            column.Items.Add( new Item( "Item23", "Id23" ) );

            board.Columns.Add( column );

            var provider = new ItemsProvider();
            provider.SaveItems( board );

            var jsonLines = System.IO.File.ReadAllLines( ItemsFileName );

            var linesOfInterest = new int[] { 3, 7, 11, 17, 21, 25, -1 };

            var idx = 0;
            int lineNo = 0;
            var columnIndex = 0;
            var itemIndex = 0;
            foreach( var line in jsonLines )
            {
                if( lineNo == linesOfInterest[idx] )
                {
                    var m = Regex.Match( line, "\"Text\":\\s*\"(.*)\"" );
                    var itemText = string.Format( "Item{0}{1}", columnIndex + 1, itemIndex + 1 );

                    Assert.IsTrue( m.Success );
                    Assert.AreEqual( m.Groups[1].Value, itemText );
                }
                if( lineNo == linesOfInterest[idx]+1 )
                {
                    var m = Regex.Match( line, "\"Id\":\\s*\"(.*)\"" );
                    var idText = string.Format( "Id{0}{1}", columnIndex + 1, itemIndex + 1 );

                    Assert.IsTrue( m.Success );
                    Assert.AreEqual( m.Groups[1].Value, idText );

                    itemIndex++;
                    idx++;
                }

                if( idx == 3 )
                {
                    columnIndex = 1;
                    itemIndex = 0;
                }
                lineNo++;
            }
        }
    }
}