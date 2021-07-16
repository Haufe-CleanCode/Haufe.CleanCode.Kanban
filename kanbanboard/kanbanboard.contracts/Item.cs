namespace kanbanboard.contracts
{
    public class Item
    {
        public Item(string text, string id) {
            Text = text;
            Id = id;
        }

        public string Text { get; set; }

        public string Id { get; set; }
    }
}