using MvvmCross.ViewModels;
using ToDoApp.Definitions.Entities;
using ToDoApp.Definitions.Enums;
using ToDoApp.Extensions;

namespace ToDoApp.ViewModels
{
    public class IssueItemViewModel : MvxNotifyPropertyChanged
    {
        public IssueItemViewModel(Issue item)
        {
            Item = item;
        }

        public Issue Item { get; }

        public IssueStatusType Status => (IssueStatusType)Item.Status;

        public string StatusStr => Status.GetEnumString();
        
        public string CreatedAtStr => Item.CreatedAt.ToString("HH:mm dd.MM.yyyy");
    }
}
