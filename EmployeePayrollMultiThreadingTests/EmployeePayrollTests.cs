using EmployeePayrollMultiThreading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EmployeePayrollMultiThreadingTests
{
    [TestClass]
    public class EmployeePayrollTests
    {
        /// <summary>
        /// UC1
        /// Addings the multiple data wiithout threads and getting time.
        /// </summary>
        [TestMethod]
        public void AddingMultipleDataWiithoutThreads_GettingTime()
        {
            //Arrange
            /// Creating the list of the employee records with data attributes
            List<EmployeePayrollModel> employeeList = new List<EmployeePayrollModel>();
            employeeList.Add(new EmployeePayrollModel { Name = "Mukesh", start_date = new System.DateTime(2018 - 08 - 12), Gender = "M", EmployeeAddress = "Vasai", Department = "Sales", PhoneNumber = "7894586954", Basic_Pay = 10000, Deductions = 500, Taxable_Pay = 500, Income_Tax = 500, Net_Pay = 11500});
            employeeList.Add(new EmployeePayrollModel { Name = "Rajesh", start_date = new System.DateTime(2020 - 04 - 22), Gender = "M", EmployeeAddress = "Delhi", Department = "Delivery", PhoneNumber = "8547253695", Basic_Pay = 11000, Deductions = 500, Taxable_Pay = 500, Income_Tax = 500, Net_Pay = 12500 });
            employeeList.Add(new EmployeePayrollModel { Name = "Pooja", start_date = new System.DateTime(2019 - 12 - 11), Gender = "F", EmployeeAddress = "Mumbai", Department = "HR", PhoneNumber = "9856320124", Basic_Pay = 12000, Deductions = 500, Taxable_Pay = 500, Income_Tax = 500, Net_Pay = 13500 });
            employeeList.Add(new EmployeePayrollModel { Name = "Amey", start_date = new System.DateTime(2018 - 07 - 08), Gender = "M", EmployeeAddress = "Bangalore", Department = "Operations", PhoneNumber = "7855496315", Basic_Pay = 9000, Deductions = 500, Taxable_Pay = 500, Income_Tax = 500, Net_Pay = 10500 });
            employeeList.Add(new EmployeePayrollModel { Name = "Punam", start_date = new System.DateTime(2019 - 08 - 17), Gender = "F", EmployeeAddress = "Chennai", Department = "Sales", PhoneNumber = "8456903257", Basic_Pay = 10000, Deductions = 500, Taxable_Pay = 500, Income_Tax = 500, Net_Pay = 11500 });
            
            EmployeePayrollRepo repo = new EmployeePayrollRepo();
            DateTime startTime = DateTime.Now;
            repo.AddEmployeeListToEmployeePayrollDataBase(employeeList);
            DateTime endTime = DateTime.Now;
            Console.WriteLine("Duration without thread: " + (startTime - endTime));
        }
        /// <summary>
        /// UC2
        /// Addings the multiple data with threads and getting time.
        /// </summary>
        [TestMethod]
        public void AddingMultipleDataWithThreads_GettingTime()
        {
            /// Creating the list of the employee records with data attributes
            List<EmployeePayrollModel> employeeList = new List<EmployeePayrollModel>();
            employeeList.Add(new EmployeePayrollModel { Name = "Mukesh", start_date = new System.DateTime(2018 - 08 - 12), Gender = "M", EmployeeAddress = "Vasai", Department = "Sales", PhoneNumber = "7894586954", Basic_Pay = 10000, Deductions = 500, Taxable_Pay = 500, Income_Tax = 500, Net_Pay = 11500 });
            employeeList.Add(new EmployeePayrollModel { Name = "Rajesh", start_date = new System.DateTime(2020 - 04 - 22), Gender = "M", EmployeeAddress = "Delhi", Department = "Delivery", PhoneNumber = "8547253695", Basic_Pay = 11000, Deductions = 500, Taxable_Pay = 500, Income_Tax = 500, Net_Pay = 12500 });
            employeeList.Add(new EmployeePayrollModel { Name = "Pooja", start_date = new System.DateTime(2019 - 12 - 11), Gender = "F", EmployeeAddress = "Mumbai", Department = "HR", PhoneNumber = "9856320124", Basic_Pay = 12000, Deductions = 500, Taxable_Pay = 500, Income_Tax = 500, Net_Pay = 13500 });
            employeeList.Add(new EmployeePayrollModel { Name = "Amey", start_date = new System.DateTime(2018 - 07 - 08), Gender = "M", EmployeeAddress = "Bangalore", Department = "Operations", PhoneNumber = "7855496315", Basic_Pay = 9000, Deductions = 500, Taxable_Pay = 500, Income_Tax = 500, Net_Pay = 10500 });
            employeeList.Add(new EmployeePayrollModel { Name = "Punam", start_date = new System.DateTime(2019 - 08 - 17), Gender = "F", EmployeeAddress = "Chennai", Department = "Sales", PhoneNumber = "8456903257", Basic_Pay = 10000, Deductions = 500, Taxable_Pay = 500, Income_Tax = 500, Net_Pay = 11500 });

            EmployeePayrollRepo repo = new EmployeePayrollRepo();
            DateTime startTime = DateTime.Now;
            repo.AddMultipleEmployeeUsingThread(employeeList);
            DateTime endTime = DateTime.Now;
            Console.WriteLine("Duration without thread: " + (startTime - endTime));
        }
    }
}
