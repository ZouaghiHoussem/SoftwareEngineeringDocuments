using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ClubManager
{
    public sealed class DbSingleton
    {
        private static DbSingleton _instance = null;
        private static readonly object _lock = new object();

        private readonly string _cs;

        private DbSingleton()
        {
            _cs = ConfigurationManager.ConnectionStrings["ClubManagerDB"].ConnectionString;
        }

        public static DbSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new DbSingleton();
                        }
                    }
                }
                return _instance;
            }
        }

        public DataRow GetUser(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 Id, Username, Role FROM Utilisateurs WHERE Username=@u AND PasswordHash=@p", conn))
            {
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count == 1)
                    {
                        return dt.Rows[0];
                    }

                    return null;
                }
            }
        }

        public DataTable GetAllPlayers()
        {
            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Joueurs", conn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void AddPlayer(string nom, string prenom, int age, string poste, int numero, string etat)
        {
            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Joueurs (Nom, Prenom, Age, Poste, Numero, Etat) VALUES (@nom, @prenom, @age, @poste, @numero, @etat)", conn))
            {
                cmd.Parameters.AddWithValue("@nom", nom);
                cmd.Parameters.AddWithValue("@prenom", prenom);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.Parameters.AddWithValue("@poste", poste);
                cmd.Parameters.AddWithValue("@numero", numero);
                cmd.Parameters.AddWithValue("@etat", etat);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataRow GetPlayerById(int id)
        {
            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Joueurs WHERE Id=@id", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count == 1)
                    {
                        return dt.Rows[0];
                    }

                    return null;
                }
            }
        }

        public void UpdatePlayer(int id, string nom, string prenom, int age, string poste, int numero, string etat)
        {
            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand("UPDATE Joueurs SET Nom=@nom, Prenom=@prenom, Age=@age, Poste=@poste, Numero=@numero, Etat=@etat WHERE Id=@id", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nom", nom);
                cmd.Parameters.AddWithValue("@prenom", prenom);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.Parameters.AddWithValue("@poste", poste);
                cmd.Parameters.AddWithValue("@numero", numero);
                cmd.Parameters.AddWithValue("@etat", etat);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeletePlayer(int id)
        {
            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Joueurs WHERE Id=@id", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetAllCoaches()
        {
            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Entraineurs", conn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void AddCoach(string nom, string prenom, string specialite, int experience)
        {
            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand("INSERT INTO Entraineurs (Nom, Prenom, Specialite, Experience) VALUES (@nom, @prenom, @specialite, @experience)", conn))
            {
                cmd.Parameters.AddWithValue("@nom", nom);
                cmd.Parameters.AddWithValue("@prenom", prenom);
                cmd.Parameters.AddWithValue("@specialite", specialite);
                cmd.Parameters.AddWithValue("@experience", experience);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataRow GetCoachById(int id)
        {
            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Entraineurs WHERE Id=@id", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count == 1)
                    {
                        return dt.Rows[0];
                    }

                    return null;
                }
            }
        }

        public void UpdateCoach(int id, string nom, string prenom, string specialite, int experience)
        {
            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand("UPDATE Entraineurs SET Nom=@nom, Prenom=@prenom, Specialite=@specialite, Experience=@experience WHERE Id=@id", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nom", nom);
                cmd.Parameters.AddWithValue("@prenom", prenom);
                cmd.Parameters.AddWithValue("@specialite", specialite);
                cmd.Parameters.AddWithValue("@experience", experience);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteCoach(int id)
        {
            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Entraineurs WHERE Id=@id", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public DataTable GetAllTrainings()
        {
            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand(
                "SELECT E.Id, E.DateSeance, E.Heure, E.Lieu, E.TypeEntrainement, C.Nom AS Coach FROM Entrainements E LEFT JOIN Entraineurs C ON E.CoachId = C.Id", conn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void AddTraining(DateTime date, string heure, string lieu, string type, int coachId)
        {
            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand(
                "INSERT INTO Entrainements (DateSeance, Heure, Lieu, TypeEntrainement, CoachId) VALUES (@date, @heure, @lieu, @type, @coach)", conn))
            {
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@heure", heure);
                cmd.Parameters.AddWithValue("@lieu", lieu);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@coach", coachId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteTraining(int id)
        {
            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Entrainements WHERE Id=@id", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}