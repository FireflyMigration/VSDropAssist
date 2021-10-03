using System.ComponentModel;
using System.Runtime.CompilerServices;
using VSDropAssist.Core.Properties;

namespace VSDropAssist.Core
{
    public abstract class ViewModelBase : IViewModel {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}