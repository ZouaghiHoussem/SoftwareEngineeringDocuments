namespace ClubManager.State
{
    public class UnavailableState : IPlayerState
    {
        public string GetEtat()
        {
            return "Indisponible";
        }
    }
}