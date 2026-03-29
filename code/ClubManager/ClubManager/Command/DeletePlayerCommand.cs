namespace ClubManager.Command
{
    public class DeletePlayerCommand : ICommand
    {
        private ClubFacade facade;
        private int id;

        public DeletePlayerCommand(ClubFacade facade, int id)
        {
            this.facade = facade;
            this.id = id;
        }

        public void Execute()
        {
            facade.DeletePlayer(id);
        }
    }
}