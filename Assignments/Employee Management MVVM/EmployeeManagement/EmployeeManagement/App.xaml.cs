using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EmployeeManagement
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static private string dbName = "Employee-DB";
        static private string subFolder = "C#Assignments";
        static private string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        static public string DBPath = System.IO.Path.Combine(folderPath, subFolder, dbName);

    }
}
