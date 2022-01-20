using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ECards.ViewModels
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string callerName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(callerName));
        }
    }
}
