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
            using (SqlCommand cmd = new SqlCommand(
                "SELECT TOP 1 Id, Username, Role FROM Utilisateurs WHERE Username=@u AND PasswordHash=@p", conn))
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

        public bool UserExists(string username)
        {
            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand(
                "SELECT COUNT(*) FROM Utilisateurs WHERE Username=@u", conn))
            {
                cmd.Parameters.AddWithValue("@u", username);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();

                return count > 0;
            }
        }

        public void AddUser(string username, string password, string role)
        {
            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand(
                "INSERT INTO Utilisateurs (Username, PasswordHash, Role) VALUES (@u, @p, @r)", conn))
            {
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);
                cmd.Parameters.AddWithValue("@r", role);

                conn.Open();
                cmd.ExecuteNonQuery();
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
            using (SqlCommand cmd = new SqlCommand(
                "INSERT INTO Joueurs (Nom, Prenom, Age, Poste, Numero, Etat) VALUES (@nom, @prenom, @age, @poste, @numero, @etat)", conn))
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
            using (SqlCommand cmd = new SqlCommand(
                "UPDATE Joueurs SET Nom=@nom, Prenom=@prenom, Age=@age, Poste=@poste, Numero=@numero, Etat=@etat WHERE Id=@id", conn))
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

        public void AddCoach(string nom, string prenom, string specialite, int experience, string username)
        {
            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand(
                "INSERT INTO Entraineurs (Nom, Prenom, Specialite, Experience, Username) VALUES (@nom, @prenom, @specialite, @experience, @username)", conn))
            {
                cmd.Parameters.AddWithValue("@nom", nom);
                cmd.Parameters.AddWithValue("@prenom", prenom);
                cmd.Parameters.AddWithValue("@specialite", specialite);
                cmd.Parameters.AddWithValue("@experience", experience);
                cmd.Parameters.AddWithValue("@username", username);

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
            using (SqlCommand cmd = new SqlCommand(
                "UPDATE Entraineurs SET Nom=@nom, Prenom=@prenom, Specialite=@specialite, Experience=@experience WHERE Id=@id", conn))
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

        public bool CoachHasTrainings(int coachId)
        {
            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand(
                "SELECT COUNT(*) FROM Entrainements WHERE CoachId=@id", conn))
            {
                cmd.Parameters.AddWithValue("@id", coachId);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();

                return count > 0;
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

        public int GetCoachIdByUsername(string username)
        {
            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand(
                "SELECT Id FROM Entraineurs WHERE Username=@username", conn))
            {
                cmd.Parameters.AddWithValue("@username", username);

                conn.Open();
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    return Convert.ToInt32(result);
                }

                return -1;
            }
        }

        public DataTable GetAllTrainings()
        {
            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT E.Id, E.DateSeance, E.Heure, E.Lieu, E.TypeEntrainement, C.Nom AS Coach
                  FROM Entrainements E
                  LEFT JOIN Entraineurs C ON E.CoachId = C.Id", conn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable GetTrainingsByCoach(int coachId)
        {
            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT E.Id, E.DateSeance, E.Heure, E.Lieu, E.TypeEntrainement, C.Nom AS Coach
                  FROM Entrainements E
                  LEFT JOIN Entraineurs C ON E.CoachId = C.Id
                  WHERE E.CoachId=@coachId", conn))
            {
                cmd.Parameters.AddWithValue("@coachId", coachId);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
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
            {
                conn.Open();

                using (SqlCommand cmd1 = new SqlCommand(
                    "DELETE FROM EntrainementJoueurs WHERE EntrainementId=@id", conn))
                {
                    cmd1.Parameters.AddWithValue("@id", id);
                    cmd1.ExecuteNonQuery();
                }

                using (SqlCommand cmd2 = new SqlCommand(
                    "DELETE FROM Entrainements WHERE Id=@id", conn))
                {
                    cmd2.Parameters.AddWithValue("@id", id);
                    cmd2.ExecuteNonQuery();
                }
            }
        }
        public int CountPlayers()
        {
            using (SqlConnection con = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Joueurs", con))
            {
                con.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        public int CountCoaches()
        {
            using (SqlConnection con = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Entraineurs", con))
            {
                con.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        public int CountTrainings()
        {
            using (SqlConnection con = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Entrainements", con))
            {
                con.Open();
                return (int)cmd.ExecuteScalar();
            }
        }
        public bool TrainingConflictExists(DateTime date, string heure, int coachId)
        {
            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT COUNT(*) FROM Entrainements 
          WHERE CoachId = @coachId 
          AND DateSeance = @date 
          AND Heure = @heure", conn))
            {
                cmd.Parameters.AddWithValue("@coachId", coachId);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@heure", heure);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();

                return count > 0;
            }
        }
        public DataTable SearchPlayersByName(string keyword)
        {
            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand(
                "SELECT * FROM Joueurs WHERE Nom LIKE @keyword OR Prenom LIKE @keyword", conn))
            {
                cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public DataRow GetNextTraining()
        {
            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT TOP 1 DateSeance, Heure, Lieu 
          FROM Entrainements 
          WHERE DateSeance >= GETDATE() 
          ORDER BY DateSeance ASC", conn))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                        return dt.Rows[0];

                    return null;
                }
            }
        }
        public int AddTrainingAndReturnId(DateTime date, string heure, string lieu, string type, int coachId)
        {
            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand(
                @"INSERT INTO Entrainements (DateSeance, Heure, Lieu, TypeEntrainement, CoachId)
          OUTPUT INSERTED.Id
          VALUES (@date, @heure, @lieu, @type, @coach)", conn))
            {
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@heure", heure);
                cmd.Parameters.AddWithValue("@lieu", lieu);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@coach", coachId);

                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public void AssignPlayerToTraining(int trainingId, int playerId)
        {
            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand(
                "INSERT INTO EntrainementJoueurs (EntrainementId, JoueurId) VALUES (@trainingId, @playerId)", conn))
            {
                cmd.Parameters.AddWithValue("@trainingId", trainingId);
                cmd.Parameters.AddWithValue("@playerId", playerId);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public string GetCoachFullNameByUsername(string username)
        {
            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand(
                "SELECT Nom, Prenom FROM Entraineurs WHERE Username=@username", conn))
            {
                cmd.Parameters.AddWithValue("@username", username);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count == 1)
                    {
                        return dt.Rows[0]["Nom"].ToString() + " " + dt.Rows[0]["Prenom"].ToString();
                    }

                    return "";
                }
            }
        }
        public DataTable GetPlayers()
        {
            using (SqlConnection conn = new SqlConnection(_cs))
            using (SqlCommand cmd = new SqlCommand(
                "SELECT Id, Nom, Etat FROM Joueurs", conn))
            {
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
    }
}