namespace EmployeeService.Utils
{
    public interface INode
    {
        object GetId();
        
        object GetParentId();
        
        void AddChild(INode node);
    }
}