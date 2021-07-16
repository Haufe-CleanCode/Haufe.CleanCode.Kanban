namespace kanbanboard.contracts
{
    public interface IKanban
    {
        Board InsertItem(Board board, Item item);

        Board CheckWIPLimits(Board board);
    }
}