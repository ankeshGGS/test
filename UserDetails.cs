using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TMPro;
using UnityEngine;

public class UserDetails : MonoBehaviour
{
    public TextMeshProUGUI UsernameDisplay;
    public static int user;
    public static string getusername;
    public static string connectionString = "data source=DESKTOP-HEHO5PK\\SQLEXPRESS01;Database=TVS_MixedReality;Trusted_Connection=True";

    public static SqlConnection connection;
    public List<GameObject> createdToggles;

    public void Start()
    {
        //user = LoginController.userID;
       // DisplayUsername();
       // getjobdetails();
       // user = LoginController.userID;
       // DisplayUsername();
        //getjobdetails();
        getTaskDetails();
    }
   /* public void DisplayUsername()
    {
        connection = new SqlConnection(connectionString);
        using (connection)
        {
            connection.Open();
            if (connection.State == ConnectionState.Open)
                Debug.Log("Connected to database DisplayUsername");
            string query = $"SELECT * FROM userDetails WHERE cuid =@user";
            using SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@user", user);
            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
                while (reader.Read())
                {
                    getusername = reader.GetString(reader.GetOrdinal("cUserName"));
                    UsernameDisplay.text = getusername;
                }
        }
    }

    public void getjobdetails()
    {
        connection = new SqlConnection(connectionString);
        using (connection)
        {
            connection.Open();
            if (connection.State == ConnectionState.Open)
                Debug.Log("Connected to database getjobdetails");
            //string query = $"SELECT csomething FROM jobdetails WHERE cuid =@user";
            string query = $"exec getjobdetails @user";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@user", user);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Debug.Log(reader);
                    if (reader.HasRows)
                        while (reader.Read())
                            Debug.Log("jobdetails = " + reader.GetString(reader.GetOrdinal("csomething")));
                }
            }
        }
    }*/
    public void getTaskDetails()
    {
        connection = new SqlConnection(connectionString);
        using (connection)
        {
            connection.Open();
            if (connection.State == ConnectionState.Open)
                Debug.Log("Connected to database getTaskDetails");

            string query = $"SELECT * FROM [dbo].[tbl_UserTaskAssigned]";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Debug.Log(reader);
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            // Adjust the column names based on your actual table structure
                            string cEmpID = reader.GetString(reader.GetOrdinal("cEmpID"));
                            string cPlantName = reader.GetString(reader.GetOrdinal("cPlantName"));

                            // ... (add more fields as needed)

                            Debug.Log($"Task ID: {cEmpID}, Task Name: {cPlantName}");
                            /* Debug.Log($"Task ID: {taskId}, Task Name: {taskName}");
                            Debug.Log($"Task ID: {taskId}, Task Name: {taskName}");
                            Debug.Log($"Task ID: {taskId}, Task Name: {taskName}");
                            Debug.Log($"Task ID: {taskId}, Task Name: {taskName}"); */
                        }
                    }
                }
            }
        }
    }

    // Call this method in your Start() or wherever appropriate

}