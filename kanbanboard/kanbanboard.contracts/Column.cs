using System.Collections.Generic;

namespace kanbanboard.contracts
{
    public class Column
    {
        public string Header { get; set; }

        public int WIPLimit { get; set; }

        public bool WIPLimitExceeded { get; set; }

        public List<Item> Items { get; } = new List<Item>();
    }
}