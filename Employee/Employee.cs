using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

delegate void DepartmentUpdated(Employee.Department department);                            //Declared a delegate

namespace Employee
{
    enum Department
    {
        IT = 1,
        Accounts = 2
    }
    class Employee                                                                          //Custom Class
    {
        static int IDCounter = 101;                                                         //Field
        private string m_FirstName;                                                         //Field
        private string m_LastName;                                                          //Field
        private int m_id;                                                                   //Field
        private Department m_Department;                                                    //Field

        public string FirstName { get => m_FirstName; set => m_FirstName = value; }                                             //Property
        public string LastName { get => m_LastName; set => m_LastName = value; }                                                //Property
        internal Department Department { get => m_Department; set => m_Department = value; }                                    //Property
        public int ID { get => m_id; set => m_id = value; }                                                                     //Property

        public Employee(string fname, string lname)
        {
            m_FirstName = fname;
            m_LastName = lname;
            m_id = IDCounter++;
        }
        public void UpdateDepartment(Department department)
        {
            m_Department = department;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Employee added under {0} department.", department.ToString());
        }

        public void DisplayDetails()
        {
            Console.ResetColor();
            Console.WriteLine("Employee Name : {0} {1}\nEmployee ID : {2}\nEmployee Department : {3}", FirstName, LastName, ID, Department);
        }
    }
}
