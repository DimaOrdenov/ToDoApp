using System.Threading.Tasks;
using ToDoApp.Definitions.Options;

namespace ToDoApp.Services
{
    public interface IDialogService
    {
        Task DisplayAlertAsync(DisplayAlertOptions options);
    }
}