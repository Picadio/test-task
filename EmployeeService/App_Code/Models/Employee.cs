using System.Collections.Generic;
using System.Runtime.Serialization;
using EmployeeService.Utils;

namespace EmployeeService.Models
{
    [DataContract]
    public class Employee : INode
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

        public object GetId()
        {
            return Id;
        }

        public object GetParentId()
        {
            return ManagerId;
        }

        public void AddChild(INode node)
        {
            if (node.GetType() == typeof(Employee))
            {
                Employees.Add((Employee)node);
            }
        }
    }
}