using System.ComponentModel;

namespace ToDoApp.Definitions.Enums
{
    public enum IssueStatusType
    {
        Open,
        
        [Description("In progress")]
        InProgress,
        
        Done,
    }
}