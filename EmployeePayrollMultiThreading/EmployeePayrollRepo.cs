using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeePayrollMultiThreading
{
    public class EmployeePayrollRepo
    {
        /// Specifying the connection string from the sql server connection.
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=payroll_service;Integrated Security=True";
        /// Establishing the connection using the Sql Connection.
        public SqlConnection sqlConnection = new SqlConnection(connectionString);
        List<EmployeePayrollModel> employeeModelList = new List<EmployeePayrollModel>();
        /// Mutex is a synchronization primitive to implement interthread execution synchronization.
        private static Mutex mutex = new Mutex();
        /// <summary>
        /// Adds the employee.
        /// </summary>
        /// <param name="employeeModel">The employee model.</param>
        /// <returns></returns>
        public bool AddEmployee(EmployeePayrollModel employeeModel)
        {
            try
            {
                using (this.sqlConnection)
                {
                    /// Impementing the command on the connection to add data to database table.
                    SqlCommand sqlCommand = new SqlCommand("spAddEmployee", this.sqlConnection);
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@Name", employeeModel.Name);
                    sqlCommand.Parameters.AddWithValue("@Start_Date", employeeModel.start_date);
                    sqlCommand.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                    sqlCommand.Parameters.AddWithValue("@Address", employeeModel.EmployeeAddress);
                    sqlCommand.Parameters.AddWithValue("@Department", employeeModel.Department);
                    sqlCommand.Parameters.AddWithValue("@Phone_Number", employeeModel.PhoneNumber);
                    sqlCommand.Parameters.AddWithValue("@Basic_Pay", employeeModel.Basic_Pay);
                    sqlCommand.Parameters.AddWithValue("@Deductions", employeeModel.Deductions);
                    sqlCommand.Parameters.AddWithValue("@Taxable_Pay", employeeModel.Taxable_Pay);
                    sqlCommand.Parameters.AddWithValue("@Income_Tax", employeeModel.Income_Tax);
                    sqlCommand.Parameters.AddWithValue("@Net_Pay", employeeModel.Net_Pay);
                    this.sqlConnection.Open();
                    var result = sqlCommand.ExecuteNonQuery();
                    this.sqlConnection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            /// Catching the null record exception.
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            /// Alway ensuring the closing of the connection.
            finally
            {
                this.sqlConnection.Close();
            }
            return false;
        }
        /// <summary>
        /// UC1
        /// Adds the employee list to employee payroll data base.
        /// </summary>
        /// <param name="employeeModelList">The employee model list.</param>
        public void AddEmployeeListToEmployeePayrollDataBase(List<EmployeePayrollModel> employeeModelList)
        {
            employeeModelList.ForEach(employeeData =>
            {
                Console.WriteLine("Employee being added: " + employeeData.Name);
                this.AddEmployee(employeeData);
                Console.WriteLine("Employee added: "+ employeeData.Name);
            });
            Console.WriteLine(this.employeeModelList.ToString());
        }
        /// <summary>
        /// UC2
        /// Adding Multiple Employee Using thread
        /// </summary>
        /// <param name="employeeModelList"></param>
        public void AddMultipleEmployeeUsingThread(List<EmployeePayrollModel> employeeModelList)
        {
            employeeModelList.ForEach(employeeData =>
            {
                Task task = new Task(() =>
                {
                    Console.WriteLine("Employee being added: " + employeeData.Name);
                    Console.WriteLine("Current thread Id: " + Thread.CurrentThread.ManagedThreadId);
                    this.AddEmployee(employeeData);
                    Console.WriteLine("Employee Added:  " + employeeData.Name);
                });
                task.Start();
            });
        }
        /// <summary>
        /// UC3
        /// Adds the multiple employee with thread syncronization.
        /// </summary>
        /// <param name="employeeModelList">The employee model list.</param>
        public void AddMultipleEmployeeWithThreadSyncronization(List<EmployeePayrollModel> employeeModelList)
        {
            employeeModelList.ForEach(employeeData =>
            {
                Task task = new Task(() =>
                {
                    /// This will block any incoming thread unless the thread execution completes
                    mutex.WaitOne();
                    Console.WriteLine("Employee Being Added: " + employeeData.Name);
                    Console.WriteLine("Current thread Id: " + Thread.CurrentThread.ManagedThreadId);
                    this.AddEmployee(employeeData);
                    Console.WriteLine("Employee Added: " + employeeData.Name);
                    mutex.ReleaseMutex();
                });
                task.Start();
                task.Wait();
            });
        }
    }
}
