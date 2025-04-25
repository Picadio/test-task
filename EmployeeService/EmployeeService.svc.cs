using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.ServiceModel.Web;
using EmployeeService.Models;
using EmployeeService.Utils;

namespace EmployeeService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IEmployeeService
    {
        private readonly string _connectionString = 
            ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        
        public Employee GetEmployeeById(int id)
        {
            var employees = new List<Employee>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(SqlQueryReader.Read("GetEmployeeRecursive.sql"), connection))
                {
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var employeeId = reader.GetInt32(reader.GetOrdinal("ID"));
                            var employeeName = reader.GetString(reader.GetOrdinal("Name"));
                            var employeeManagerId = reader.IsDBNull(reader.GetOrdinal("ManagerID"))
                                ? (int?)null
                                : reader.GetInt32(reader.GetOrdinal("ManagerID"));
                            
                            employees.Add(new Employee(employeeId, employeeName, employeeManagerId));
                        }
                    }
                }
            }

            if (employees.Count == 0)
            {
                throw new WebFaultException<string>($"Employee with ID {id} not found", HttpStatusCode.NotFound);
            }
            
            return TreeUtil.BuildTree(id, employees);
        }
        
        public void EnableEmployee(int id, int enable)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = SqlQueryReader.Read("UpdateEmployeeEnable.sql");
                    command.Parameters.AddWithValue("@enable", enable);
                    command.Parameters.AddWithValue("@id", id);

                    var countOfUpdated = command.ExecuteNonQuery();
                    if (countOfUpdated == 0)
                    {
                        throw new WebFaultException<string>($"Employee with ID {id} not found", HttpStatusCode.NotFound);
                    }
                }
            }
        }
    }
}