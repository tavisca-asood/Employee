using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    class Program
    {
        static void WriteErrorsToFile(Exception exception)
        {
            string path = @"C:\Users\Public\log.txt";
            if (!File.Exists(path))
                File.Create(path);
            using (TextWriter textWriter = new StreamWriter(path))                                                                  //Using keyword
            {
                textWriter.WriteLine("Error Message : {0}\nStack Trace : {1}\n", exception.Message, exception.StackTrace);
                textWriter.Close();
            }
        }
        static void AddEmployee(ref List<Employee> employeeList)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Adding an employee");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string fname;
            string lname;
            string qualification;
            Department department = Department.IT;
            Console.WriteLine("Enter employee first name");
            fname = Console.ReadLine().Trim();
            Console.WriteLine("Enter employee last name");
            lname = Console.ReadLine().Trim();
            int flag = 1;
            qualifiactionBlock:
            try                                                                                                                    //Exception handling
            {
                flag = 1;
                Console.WriteLine("Enter employee qualification");
                qualification = Console.ReadLine().Trim();
                if (qualification == "")
                {
                    throw new ArgumentNullException("Qualification cannot be empty");                                              //Throwing a Custom Exception
                }
                if (qualification == "BE" || qualification == "BCA" || qualification == "BSC")
                {
                    department = Department.IT;
                }
                else if (qualification == "BCom" || qualification == "MCom" || qualification == "CA")
                {
                    department = Department.Accounts;
                }
                else
                {
                    throw new InvalidOperationException("Please enter a valid value for qualification");                            //Throwing a Custom Exception
                }
                flag = 0;
            }
            catch (ArgumentNullException exc)
            {
                Console.WriteLine(exc.Message);
                WriteErrorsToFile(exc);
            }
            if (flag == 1)
                goto qualifiactionBlock;
            Employee employee = new Employee(fname, lname);
            DepartmentUpdated update = employee.UpdateDepartment;
            update(department);
            employeeList.Add(employee);
        }

        static void DisplayEmployees(ref List<Employee> employeeList)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Employee Details");
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (Employee employee in employeeList)
                employee.DisplayDetails();
        }
        static void Main(string[] args)
        {
            List<Employee> employeeList = new List<Employee>();                                                                      //Use of built out keyword and built-in try block in TryParse
            bool flag = true;
            while (flag)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                int choice;
                Console.WriteLine("\nEnter 1 to add an Employee.\nEnter 2 to show Employee list.\nEnter 0 to exit.");
                int.TryParse(Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        AddEmployee(ref employeeList);
                        break;
                    case 2:
                        DisplayEmployees(ref employeeList);
                        break;
                    case 0:
                        flag = false;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
