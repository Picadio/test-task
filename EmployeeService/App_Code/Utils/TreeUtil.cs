using System.Collections.Generic;
using System.Linq;

namespace EmployeeService.Utils
{
    public static class TreeUtil
    {
        public static INode BuildTree(object rootId, List<INode> nodes)
        {
            INode root = null;
            var dict = nodes.ToDictionary(e => e.GetId());
            foreach (var node in nodes)
            {
                if (node.GetId().Equals(rootId) || node.GetParentId() == null)
                {
                    root = node;
                }
                else if (dict.ContainsKey(node.GetParentId()))
                {
                    var parent = dict[node.GetParentId()];
                    parent.AddChild(node);
                }
            }

            return root;
        }
    }
}