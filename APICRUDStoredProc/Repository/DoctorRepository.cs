using APICRUDStoredProc.Interface;
using APICRUDStoredProc.Models;
using System.Data;
using System.Data.SqlClient;

namespace APICRUDStoredProc.Repository
{
    public class DoctorRepository : IDoctor
    {
        private readonly IConfiguration configuration;

        public DoctorRepository(IConfiguration iConfig)
        {
            configuration = iConfig;
        }

        //To Get all user details   
        public List<Doctor> GetDoctorDetails()
        {
            string dbConnection = configuration.GetSection("ConnectionStrings").GetSection("dbConnection").Value;
            try
            {
                SqlConnection sqlConnection = new(dbConnection);
                sqlConnection.Open();
                SqlCommand sqlCommand = new("GetDoctorDetails", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Action", "DoctorDetails");
                SqlDataAdapter sqlDataAdapter = new(sqlCommand);
                DataTable dataTable = new();
                sqlDataAdapter.Fill(dataTable);
                sqlConnection.Close();
                return (from DataRow dataRow in dataTable.Rows
                        select new Doctor()
                        {
                            Id = Convert.ToInt32(dataRow["Id"]),
                            Name = dataRow["Name"].ToString(),
                            Email = dataRow["Email"].ToString(),
                            Password = dataRow["Password"].ToString(),
                            Registration = dataRow["Registration"].ToString(),
                            DateofIssue = dataRow["DateofIssue"].ToString(),
                            DateofValid = dataRow["DateofValid"].ToString()
                        }).ToList();
            }
            catch
            {
                throw;
            }
        }

        //To Add new user record     
        public void AddDoctor(Doctor doctor)
        {
            string dbConnection = configuration.GetSection("ConnectionStrings").GetSection("dbConnection").Value;
            try
            {
                using (SqlConnection sqlConnection = new(dbConnection))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new("GetDoctorDetails", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@Action", "AddDoctor");
                        sqlCommand.Parameters.AddWithValue("@Id", doctor.Id);
                        sqlCommand.Parameters.AddWithValue("@Name", doctor.Name);
                        sqlCommand.Parameters.AddWithValue("@Email", doctor.Email);
                        sqlCommand.Parameters.AddWithValue("@Password", doctor.Password);
                        sqlCommand.Parameters.AddWithValue("@Registration", doctor.Registration);
                        sqlCommand.Parameters.AddWithValue("@DateofIssue", doctor.DateofIssue);
                        sqlCommand.Parameters.AddWithValue("@DateofValid", doctor.DateofValid);
                        sqlCommand.ExecuteNonQuery();
                        sqlCommand.Dispose();
                    }
                    sqlConnection.Close();
                }
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar user    
        public void UpdateDoctorDetails(Doctor doctor)
        {
            string dbConnection = configuration.GetSection("ConnectionStrings").GetSection("dbConnection").Value;
            try
            {
                using (SqlConnection sqlConnection = new(dbConnection))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new("GetDoctorDetails", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@Action", "UpdateDoctor");
                        sqlCommand.Parameters.AddWithValue("@Id", doctor.Id);
                        sqlCommand.Parameters.AddWithValue("@Name", doctor.Name);
                        sqlCommand.Parameters.AddWithValue("@Email", doctor.Email);
                        sqlCommand.Parameters.AddWithValue("@Password", doctor.Password);
                        sqlCommand.Parameters.AddWithValue("@Registration", doctor.Registration);
                        sqlCommand.Parameters.AddWithValue("@DateofIssue", Convert.ToDateTime(doctor.DateofIssue));
                        sqlCommand.Parameters.AddWithValue("@DateofValid", Convert.ToDateTime(doctor.DateofValid));
                        sqlCommand.ExecuteNonQuery();
                        sqlCommand.Dispose();
                    }
                    sqlConnection.Close();
                }
            }
            catch
            {
                throw;
            }
        }

        //Get the details of a particular user    
        public Doctor GetDoctorData(int id)
        {
            string dbConnection = configuration.GetSection("ConnectionStrings").GetSection("dbConnection").Value;
            try
            {
                SqlConnection sqlConnection = new(dbConnection);
                sqlConnection.Open();
                SqlCommand sqlCommand = new("GetDoctorDetails", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Action", "DoctorData");
                sqlCommand.Parameters.AddWithValue("@Id", id);
                SqlDataAdapter sqlDataAdapter = new(sqlCommand);
                DataTable dataTable = new();
                sqlDataAdapter.Fill(dataTable);
                sqlConnection.Close();
                return (from DataRow dataRow in dataTable.Rows
                        select new Doctor()
                        {
                            Id = Convert.ToInt32(dataRow["Id"]),
                            Name = dataRow["Name"].ToString(),
                            Email = dataRow["Email"].ToString(),
                            Password = dataRow["Password"].ToString(),
                            Registration = dataRow["Registration"].ToString(),
                            DateofIssue = dataRow["DateofIssue"].ToString(),
                            DateofValid = dataRow["DateofValid"].ToString()
                        }).FirstOrDefault();
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record of a particular user    
        public void DeleteDoctor(int id)
        {
            string dbConnection = configuration.GetSection("ConnectionStrings").GetSection("dbConnection").Value;
            try
            {
                using (SqlConnection sqlConnection = new(dbConnection))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new("GetDoctorDetails", sqlConnection))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddWithValue("@Action", "DeleteDoctor");
                        sqlCommand.Parameters.AddWithValue("@Id", id);
                        sqlCommand.ExecuteNonQuery();
                        sqlCommand.Dispose();
                    }
                    sqlConnection.Close();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
