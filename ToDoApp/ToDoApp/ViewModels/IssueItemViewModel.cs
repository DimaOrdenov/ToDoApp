using System;
using MvvmCross.ViewModels;
using ToDoApp.Definitions.Enums;

namespace ToDoApp.ViewModels
{
    public class IssueItemViewModel : MvxNotifyPropertyChanged
    {
        public string Title { get; set; }
        
        public string Description { get; set; }
        
        public IssueStatusType Status { get; set; }
        
        public DateTimeOffset CreatedAt { get; set; }
    }
}
