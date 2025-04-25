using System.Collections.Generic;
using System.Linq;

namespace EmployeeService.Utils
{
    public static class TreeUtil
    {
        public static INode BuildTree(int rootId, List<INode> employees)
        {
            INode root = null;
            var dict = employees.ToDictionary(e => e.GetId());
            foreach (var employee in employees)
            {
                if (employee.GetId().Equals(rootId) || employee.GetParentId() == null)
                {
                    root = employee;
                }
                else if (dict.ContainsKey(employee.GetParentId()))
                {
                    var manager = dict[employee.GetParentId()];
                    manager.AddChild(employee);
                }
            }

            return root;
        }
    }
}