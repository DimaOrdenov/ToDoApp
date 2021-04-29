using System;
using MvvmCross.ViewModels;
using ToDoApp.Definitions.Enums;
using ToDoApp.Extensions;

namespace ToDoApp.ViewModels
{
    public class IssueItemViewModel : MvxNotifyPropertyChanged
    {
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public IssueStatusType Status { get; set; }
        
        public DateTimeOffset CreatedAt { get; set; }

        public string StatusStr => Status.GetEnumString();
        public string CreatedAtStr => CreatedAt.ToString("HH:mm dd.MM.yyyy");
    }
}
