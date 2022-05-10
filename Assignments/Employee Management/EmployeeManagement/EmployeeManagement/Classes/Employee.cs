using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Classes
{
    class Employee
    {
        [PrimaryKey,AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhotoPath { get; set; }
        public string Gender { get; set; }
        public string IsMarried { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailID { get; set; }
        public string Position { get; set; }
        public string Project { get; set; }
        public string ReportsTo { get; set; }

        public override string ToString()
        {
            return $"{this.Name}\nAddress: {this.Address}\nPhoto Path: {this.PhotoPath}\nGender: {this.Gender}\nMarried: {this.IsMarried}\nPhone Number: {this.PhoneNumber}\nMaild Id: {this.EmailID}" +
                $"\nPosition: {this.Position}\nProjects: {this.Project}\nReport To: {this.ReportsTo}";

        }
    }
}
