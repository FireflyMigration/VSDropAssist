using System.ComponentModel;
using System.Runtime.CompilerServices;
using VSDropAssist.Core.Properties;

namespace VSDropAssist.Core
{
    public abstract class CommandBase :INotifyPropertyChanged, ICommand 
    {
        private bool _enabled;

        public bool Enabled
        {
            get { return _enabled; }
            protected set
            {
                _enabled = value;
                OnPropertyChanged();
            }
        }

        public abstract void Execute();
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}