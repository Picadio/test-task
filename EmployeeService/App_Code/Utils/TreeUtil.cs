using System.Collections.Generic;
using System.Linq;
using EmployeeService.Models;

namespace EmployeeService.Utils
{
    public class TreeUtil
    {
        public static Employee BuildTree(int rootId, List<Employee> employees)
        {
            Employee root = null;
            var dict = employees.ToDictionary(e => e.Id);
            foreach (var employee in employees)
            {
                if (employee.Id == rootId || employee.ManagerId == null)
                {
                    root = employee;
                }
                else if (dict.ContainsKey((int)employee.ManagerId))
                {
                    var manager = dict[(int)employee.ManagerId];
                    manager.Employees.Add(employee);
                }
            }

            return root;
        }
    }
}