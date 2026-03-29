namespace ClubManager.Command
{
	public class UpdatePlayerCommand : ICommand
	{
		private ClubFacade facade;
		private int id;
		private string nom;
		private string prenom;
		private int age;
		private string poste;
		private int numero;
		private string etat;

		public UpdatePlayerCommand(ClubFacade facade, int id, string nom, string prenom, int age, string poste, int numero, string etat)
		{
			this.facade = facade;
			this.id = id;
			this.nom = nom;
			this.prenom = prenom;
			this.age = age;
			this.poste = poste;
			this.numero = numero;
			this.etat = etat;
		}

		public void Execute()
		{
			facade.UpdatePlayer(id, nom, prenom, age, poste, numero, etat);
		}
	}
}