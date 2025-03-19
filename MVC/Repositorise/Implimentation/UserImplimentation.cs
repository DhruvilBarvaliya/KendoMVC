using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC.Models;
using MVC.Repositorise.Interfaces;
using Npgsql;

namespace MVC.Repositorise.Implimentation
{
    public class UserImplimentation : UserInterface
    {
        private readonly NpgsqlConnection _connection;
        public UserImplimentation(NpgsqlConnection connection)
        {
            _connection = new NpgsqlConnection("Server=cipg01;Port=5432;Database=Group_C_2025;User Id=postgres;Password=123456;");
        }
        public async Task<int> Add(t_Employee emp)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO t_ems_employee(c_empName,c_empEmail,c_empPwd) VALUES(@c_empName,@c_empEmail,@c_empPwd)", _connection))
            {
                cmd.Parameters.AddWithValue("@c_empName", emp.c_empName);
                cmd.Parameters.AddWithValue("@c_empEmail", emp.c_empEmail);
                cmd.Parameters.AddWithValue("@c_empPwd", emp.c_empPwd);

                _connection.Open();
                cmd.ExecuteNonQuery();

                _connection.Close();
            }
            return 1;
        }

        public async Task<t_Employee> Get(int id)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM t_ems_employee WHERE c_empId = @c_empId", _connection))
            {
                cmd.Parameters.AddWithValue("@c_empId", id);

                await _connection.OpenAsync();
                NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();

                t_Employee emp = new t_Employee();
                while (await reader.ReadAsync())
                {
                    emp.c_empId = reader.GetInt32(0);
                    emp.c_empName = reader.GetString(1);
                    emp.c_empEmail = reader.GetString(2);
                    emp.c_empPwd = reader.GetString(3);
                }

                await _connection.CloseAsync();
                return emp;
            }
        }

        public async Task<int> Update(t_Employee emp)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("UPDATE t_ems_employee SET c_empName = @c_empName, c_empEmail = @c_empEmail, c_empPwd = @c_empPwd WHERE c_empId = @c_empId", _connection))
            {
                cmd.Parameters.AddWithValue("@c_empId", emp.c_empId);
                cmd.Parameters.AddWithValue("@c_empName", emp.c_empName);
                cmd.Parameters.AddWithValue("@c_empEmail", emp.c_empEmail);
                cmd.Parameters.AddWithValue("@c_empPwd", emp.c_empPwd);

                await _connection.OpenAsync();
                await cmd.ExecuteNonQueryAsync();

                await _connection.CloseAsync();
            }
            return 1;
        }

        public async Task<int> Delete(int id)
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM t_ems_employee WHERE c_empId = @c_empId", _connection))
            {
                cmd.Parameters.AddWithValue("@c_empId", id);

                await _connection.OpenAsync();
                await cmd.ExecuteNonQueryAsync();

                await _connection.CloseAsync();
            }
            return 1;
        }

        public async Task<List<t_Employee>> GetAll()
        {
            using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM t_ems_employee", _connection))
            {
                await _connection.OpenAsync();
                NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();

                List<t_Employee> employees = new List<t_Employee>();
                while (await reader.ReadAsync())
                {
                    t_Employee emp = new t_Employee();
                    emp.c_empId = reader.GetInt32(0);
                    emp.c_empName = reader.GetString(1);
                    emp.c_empEmail = reader.GetString(2);
                    emp.c_empPwd = reader.GetString(3);
                    employees.Add(emp);
                }

                await _connection.CloseAsync();
                return employees;
            }
        }

        public async Task<List<t_task>> GetAllTask()
        {
            var tasks = new List<t_task>();

            try
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM t_task", _connection))
                {
                    _connection.Close();
                    _connection.Open();
                    await using var reader = await cmd.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        tasks.Add(new t_task
                        {
                            c_tid = reader.GetInt32(0),
                            c_uid = reader.GetInt32(1),
                            c_task_title = reader.GetString(2),
                            c_description = reader.GetString(3),
                            c_start_date = reader.GetDateTime(4),
                            c_end_date = reader.GetDateTime(5),
                            c_task_status = reader.GetString(6)
                        });
                    }

                    _connection.Close();
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return tasks;
        }
    }
}