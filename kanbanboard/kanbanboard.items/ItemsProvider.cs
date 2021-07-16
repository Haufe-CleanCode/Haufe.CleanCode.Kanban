using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using kanbanboard.contracts;


namespace kanbanboard.items
{
    public class ItemsProvider : IItemsProvider
    {
        const string ItemsFileName = "items.json";

        public List<List<Item>> LoadItems()
        {
            if( !System.IO.File.Exists( ItemsFileName ) )
            {
                return new List<List<Item>>();
            }

            var json = System.IO.File.ReadAllText( ItemsFileName );

            var allItems = JsonConvert.DeserializeObject<List<List<Item>>>( json );

            return allItems;
        }

        public void SaveItems( Board board )
        {
            if( board == null )
            {
                throw new NullReferenceException( "Board" );
            }

            List<List<Item>> allItems = new();

            foreach( var column in board.Columns )
            {
                allItems.Add( column.Items );
            }

            var json = JsonConvert.SerializeObject( allItems, Formatting.Indented );

            System.IO.File.WriteAllText( ItemsFileName, json );
        }
    }
}
