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

        public bool UserExists(string username)
        {
            return DbSingleton.Instance.UserExists(username);
        }

        public void AddUser(string username, string password, string role)
        {
            DbSingleton.Instance.AddUser(username, password, role);
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

        public void AddCoach(string nom, string prenom, string specialite, int experience, string username)
        {
            DbSingleton.Instance.AddCoach(nom, prenom, specialite, experience, username);
        }

        public DataRow GetCoachById(int id)
        {
            return DbSingleton.Instance.GetCoachById(id);
        }

        public void UpdateCoach(int id, string nom, string prenom, string specialite, int experience)
        {
            DbSingleton.Instance.UpdateCoach(id, nom, prenom, specialite, experience);
        }

        public bool CoachHasTrainings(int coachId)
        {
            return DbSingleton.Instance.CoachHasTrainings(coachId);
        }

        public void DeleteCoach(int id)
        {
            DbSingleton.Instance.DeleteCoach(id);
        }

        public int GetCoachIdByUsername(string username)
        {
            return DbSingleton.Instance.GetCoachIdByUsername(username);
        }

        public DataTable GetTrainings()
        {
            return DbSingleton.Instance.GetAllTrainings();
        }

        public DataTable GetTrainingsByCoach(int coachId)
        {
            return DbSingleton.Instance.GetTrainingsByCoach(coachId);
        }

        public void AddTraining(DateTime date, string heure, string lieu, string type, int coachId)
        {
            DbSingleton.Instance.AddTraining(date, heure, lieu, type, coachId);
        }

        public void DeleteTraining(int id)
        {
            DbSingleton.Instance.DeleteTraining(id);
        }
        public int GetPlayersCount()
        {
            return DbSingleton.Instance.CountPlayers();
        }

        public int GetCoachesCount()
        {
            return DbSingleton.Instance.CountCoaches();
        }

        public int GetTrainingsCount()
        {
            return DbSingleton.Instance.CountTrainings();
        }
        public bool HasTrainingConflict(DateTime date, string heure, int coachId)
        {
            return DbSingleton.Instance.TrainingConflictExists(date, heure, coachId);
        }
        public DataTable SearchPlayersByName(string keyword)
        {
            return DbSingleton.Instance.SearchPlayersByName(keyword);
        }
        public DataRow GetNextTraining()
        {
            return DbSingleton.Instance.GetNextTraining();
        }
        public int AddTrainingAndReturnId(DateTime date, string heure, string lieu, string type, int coachId)
        {
            return DbSingleton.Instance.AddTrainingAndReturnId(date, heure, lieu, type, coachId);
        }

        public void AssignPlayerToTraining(int trainingId, int playerId)
        {
            DbSingleton.Instance.AssignPlayerToTraining(trainingId, playerId);
        }
        public string GetCoachFullNameByUsername(string username)
        {
            return DbSingleton.Instance.GetCoachFullNameByUsername(username);
        }
    }
}