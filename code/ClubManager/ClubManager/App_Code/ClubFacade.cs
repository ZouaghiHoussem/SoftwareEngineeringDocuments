using System;
using System.Data;

namespace ClubManager
{
    public class ClubFacade
    {
        public DataRow LoginUser(string username, string password)
        {
            return DbSingleton.Instance.GetUser(username, password);
        }

        public DataTable GetPlayers()
        {
            return DbSingleton.Instance.GetAllPlayers();
        }

        public void AddPlayer(string nom, string prenom, int age, string poste, int numero, string etat)
        {
            DbSingleton.Instance.AddPlayer(nom, prenom, age, poste, numero, etat);
        }

        public DataRow GetPlayerById(int id)
        {
            return DbSingleton.Instance.GetPlayerById(id);
        }

        public void UpdatePlayer(int id, string nom, string prenom, int age, string poste, int numero, string etat)
        {
            DbSingleton.Instance.UpdatePlayer(id, nom, prenom, age, poste, numero, etat);
        }

        public void DeletePlayer(int id)
        {
            DbSingleton.Instance.DeletePlayer(id);
        }

        public DataTable GetCoaches()
        {
            return DbSingleton.Instance.GetAllCoaches();
        }

        public void AddCoach(string nom, string prenom, string specialite, int experience)
        {
            DbSingleton.Instance.AddCoach(nom, prenom, specialite, experience);
        }

        public DataRow GetCoachById(int id)
        {
            return DbSingleton.Instance.GetCoachById(id);
        }

        public void UpdateCoach(int id, string nom, string prenom, string specialite, int experience)
        {
            DbSingleton.Instance.UpdateCoach(id, nom, prenom, specialite, experience);
        }

        public void DeleteCoach(int id)
        {
            DbSingleton.Instance.DeleteCoach(id);
        }
        public DataTable GetTrainings()
        {
            return DbSingleton.Instance.GetAllTrainings();
        }

        public void AddTraining(DateTime date, string heure, string lieu, string type, int coachId)
        {
            DbSingleton.Instance.AddTraining(date, heure, lieu, type, coachId);
        }

        public void DeleteTraining(int id)
        {
            DbSingleton.Instance.DeleteTraining(id);
        }
    }
}