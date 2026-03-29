namespace ClubManager.Command
{
    public class AddPlayerCommand : ICommand
    {
        private ClubFacade facade;
        private string nom;
        private string prenom;
        private int age;
        private string poste;
        private int numero;
        private string etat;

        public AddPlayerCommand(ClubFacade facade, string nom, string prenom, int age, string poste, int numero, string etat)
        {
            this.facade = facade;
            this.nom = nom;
            this.prenom = prenom;
            this.age = age;
            this.poste = poste;
            this.numero = numero;
            this.etat = etat;
        }

        public void Execute()
        {
            facade.AddPlayer(nom, prenom, age, poste, numero, etat);
        }
    }
}