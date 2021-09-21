using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Nomina2018.Core.Entities;
using Nomina2018.Core.Interfaces;
using Nomina2018.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nomina2018.Infrastructure.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(BDNOMINA2018Context context, IConfiguration configuration) : base(context, configuration) { }
        public async Task<IEnumerable<Employee>> GetEmployeesByDepartment(int departmentId)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllEmployeeByDepartment", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@iDepartment", departmentId));
                    var response = new List<Employee>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(new Employee
                            {
                                SName = reader["sName"].ToString(),
                                SLastName = reader["sLastName"].ToString(),
                                Id = (int)reader["iIdEmployee"],
                                DSalary = (decimal)reader["dSalary"]
                            });
                        }
                    }
                    return response;
                }
            }
        }
        public async Task<Employee> GetEmployeeById(int id)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllEmployeeById", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    var response = new Employee();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = (new Employee
                            {
                                SName = reader["sName"].ToString(),
                                SLastName = reader["sLastName"].ToString(),
                                Id = (int)reader["iIdEmployee"],
                                DSalary = (decimal)reader["dSalary"],
                                IZipCode = (int)reader["iZipCode"],
                                SCity = reader["SCity"].ToString(),
                                SCountry = reader["sCountry"].ToString(),
                                SStreet = reader["sStreet"].ToString(),
                                IIdDepartment = (int)reader["iIdDepartment"]
                            });
                        }
                    }
                    return response;
                }
            }
        }
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllEmployee", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<Employee>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(new Employee
                            {
                                SName = reader["sName"].ToString(),
                                SLastName = reader["sLastName"].ToString(),
                                Id = (int)reader["iIdEmployee"],
                                DSalary = (decimal)reader["dSalary"],
                                SDepartmentName = reader["sDepartmentName"].ToString()
                            });
                        }
                    }
                    return response;
                }
            }
        }
        public async Task<int> CreateEmployee(Employee employee)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("CreateEmployee", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@sName", employee.SName));
                    cmd.Parameters.Add(new SqlParameter("@sLastName", employee.SLastName));
                    cmd.Parameters.Add(new SqlParameter("@dSalary", employee.DSalary));
                    cmd.Parameters.Add(new SqlParameter("@CreatedDate", DateTime.Now));
                    cmd.Parameters.Add(new SqlParameter("@bEnabled", true));
                    cmd.Parameters.Add(new SqlParameter("@bDisabled", false));
                    cmd.Parameters.Add(new SqlParameter("@idDepartment", employee.IIdDepartment));
                    cmd.Parameters.Add(new SqlParameter("@sStreet", employee.SStreet));
                    cmd.Parameters.Add(new SqlParameter("@iZipCode", employee.IZipCode));
                    cmd.Parameters.Add(new SqlParameter("@sCity", employee.SCity));
                    cmd.Parameters.Add(new SqlParameter("@sCountry", employee.SCountry));
                    var id = 0;
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            id = (int)reader["id"];
                        }
                    }
                    return id;
                }
            }
        }
        public async Task<bool> UpdateEmployee(Employee employee)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UpdateEmployee", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", employee.Id));
                    cmd.Parameters.Add(new SqlParameter("@sName", employee.SName));
                    cmd.Parameters.Add(new SqlParameter("@sLastName", employee.SLastName));
                    cmd.Parameters.Add(new SqlParameter("@dSalary", employee.DSalary));
                    cmd.Parameters.Add(new SqlParameter("@ModifiedDate", DateTime.Now));
                    cmd.Parameters.Add(new SqlParameter("@idDepartment", employee.IIdDepartment));
                    cmd.Parameters.Add(new SqlParameter("@sStreet", employee.SStreet));
                    cmd.Parameters.Add(new SqlParameter("@iZipCode", employee.IZipCode));
                    cmd.Parameters.Add(new SqlParameter("@sCity", employee.SCity));
                    cmd.Parameters.Add(new SqlParameter("@sCountry", employee.SCountry));
                    var response = new List<Employee>();
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteEmployee", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    cmd.Parameters.Add(new SqlParameter("@bEnabled", false));
                    cmd.Parameters.Add(new SqlParameter("@bDisabled", true));
                    cmd.Parameters.Add(new SqlParameter("@deleteDate", DateTime.Now));
                    var response = new List<Employee>();
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                    return true;
                }
            }
        }
    }
}
