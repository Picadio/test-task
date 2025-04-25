using System;
using System.IO;

namespace EmployeeService.Utils
{
    public static class SqlQueryReader
    {
        private static readonly string FileLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, 
            "App_Data", "SqlQueries");

        public static string Read(string filename)
        {
            var path = Path.Combine(FileLocation, filename);
            if (!File.Exists(path))
            {
                throw new FileNotFoundException();
            }
            return File.ReadAllText(path);
        }
    }
}