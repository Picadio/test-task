using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace EmployeeService.Models
{
    [DataContract]
    public class Employee
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int? ManagerId { get; set; }
        [DataMember]
        public List<Employee> Employees { get; private set; }

        public Employee(int id, string name, int? managerId) {
            Id = id;    
            Name = name;
            ManagerId = managerId;
            Employees = new List<Employee>();
        }
        
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