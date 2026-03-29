using ClubManager.State;

namespace ClubManager.State
{
    public class PlayerStateFactory
    {
        public static IPlayerState GetState(string etat)
        {
            switch (etat)
            {
                case "Actif":
                    return new ActiveState();
                case "Blesse":
                    return new InjuredState();
                case "Suspendu":
                    return new SuspendedState();
                case "Indisponible":
                    return new UnavailableState();
                default:
                    return new ActiveState();
            }
        }
    }
}