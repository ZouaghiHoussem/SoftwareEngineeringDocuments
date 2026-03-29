namespace ClubManager.State
{
    public class SuspendedState : IPlayerState
    {
        public string GetEtat()
        {
            return "Suspendu";
        }
    }
}