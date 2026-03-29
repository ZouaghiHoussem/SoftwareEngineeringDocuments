namespace ClubManager.State
{
	public class ActiveState : IPlayerState
	{
		public string GetEtat()
		{
			return "Actif";
		}
	}
}