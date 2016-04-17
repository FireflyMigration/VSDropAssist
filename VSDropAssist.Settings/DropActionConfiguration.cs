using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using VSDropAssist.Settings.Annotations;

namespace VSDropAssist.Settings
{
    [XmlRoot("DropActionConfiguration")]
    public class DropActionConfiguration : IDropActionConfiguration, INotifyPropertyChanged, ICloneable
    {
        private bool _altMustBeDown;
        private bool _controlMustBeDown;
        private string _delimiter;
        private string _formatExpression;
        private string _name;
        private string _prefix;
        private bool _selectAfterDrop;
        private bool _selectFirstLineOnly;
        private bool _shiftMustBeDown;
        private string _suffix;
        private bool _supportsClasses;
        private bool _supportsDroppingIntoClass;
        private bool _supportsDroppingIntoMethod;
        private bool _supportsMembers;
        private string _tokenToSelectAfterDrop;

        public override string ToString()
        {
            return $"Name: {Name},\nShiftMustBeDown: {ShiftMustBeDown},\nControlMustBeDown: {ControlMustBeDown},\nAltMustBeDown: {AltMustBeDown},\nFormatExpression: {FormatExpression},\nSelectAfterDrop: {SelectAfterDrop},\nSupportsMembers: {SupportsMembers},\nSupportsClasses: {SupportsClasses},\nSupportsDroppingIntoMethod: {SupportsDroppingIntoMethod},\nSupportsDroppingIntoClass: {SupportsDroppingIntoClass},\nTokenToSelectAfterDrop: {TokenToSelectAfterDrop},\nPrefix: {Prefix},\nSuffix: {Suffix},\nDelimiter: {Delimiter},\nSelectFirstLineOnly: {SelectFirstLineOnly}";
        }

        public DropActionConfiguration()
        {
            SupportsClasses = true;
            SupportsMembers = true;
            SupportsDroppingIntoClass = true;
            SupportsDroppingIntoMethod = true;
            SelectAfterDrop = true;
            TokenToSelectAfterDrop = "%v%";
            Delimiter = "\n";
            Prefix = "\n";
            SelectFirstLineOnly = true;
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged();
            }
        }

        object ICloneable.Clone()
        {
            return MemberwiseClone();
        }

        public void CopyFrom(IDropActionConfiguration src)
        {
            foreach (var propertyInfo in src.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public ))
            {
                propertyInfo.SetValue(this, propertyInfo.GetValue(src));

            }
        }

        public bool ShiftMustBeDown
        {
            get { return _shiftMustBeDown; }
            set
            {
                if (value == _shiftMustBeDown) return;
                _shiftMustBeDown = value;
                OnPropertyChanged();
            }
        }

        public bool ControlMustBeDown
        {
            get { return _controlMustBeDown; }
            set
            {
                if (value == _controlMustBeDown) return;
                _controlMustBeDown = value;
                OnPropertyChanged();
            }
        }

        public bool AltMustBeDown
        {
            get { return _altMustBeDown; }
            set
            {
                if (value == _altMustBeDown) return;
                _altMustBeDown = value;
                OnPropertyChanged();
            }
        }

        public string FormatExpression
        {
            get { return _formatExpression; }
            set
            {
                if (value == _formatExpression) return;
                _formatExpression = value;
                OnPropertyChanged();
            }
        }

        public bool SelectAfterDrop
        {
            get { return _selectAfterDrop; }
            set
            {
                if (value == _selectAfterDrop) return;
                _selectAfterDrop = value;
                OnPropertyChanged();
            }
        }

        public bool SupportsMembers
        {
            get { return _supportsMembers; }
            set
            {
                if (value == _supportsMembers) return;
                _supportsMembers = value;
                OnPropertyChanged();
            }
        }

        public bool SupportsClasses
        {
            get { return _supportsClasses; }
            set
            {
                if (value == _supportsClasses) return;
                _supportsClasses = value;
                OnPropertyChanged();
            }
        }

        public bool SupportsDroppingIntoMethod
        {
            get { return _supportsDroppingIntoMethod; }
            set
            {
                if (value == _supportsDroppingIntoMethod) return;
                _supportsDroppingIntoMethod = value;
                OnPropertyChanged();
            }
        }

        public bool SupportsDroppingIntoClass
        {
            get { return _supportsDroppingIntoClass; }
            set
            {
                if (value == _supportsDroppingIntoClass) return;
                _supportsDroppingIntoClass = value;
                OnPropertyChanged();
            }
        }

        public string TokenToSelectAfterDrop
        {
            get { return _tokenToSelectAfterDrop; }
            set
            {
                if (value == _tokenToSelectAfterDrop) return;
                _tokenToSelectAfterDrop = value;
                OnPropertyChanged();
            }
        }

        public string Prefix
        {
            get { return _prefix; }
            set
            {
                if (value == _prefix) return;
                _prefix = value;
                OnPropertyChanged();
            }
        }

        public string Suffix
        {
            get { return _suffix; }
            set
            {
                if (value == _suffix) return;
                _suffix = value;
                OnPropertyChanged();
            }
        }

        IDropActionConfiguration IDropActionConfiguration.Clone()
        {
            return Clone();
        }

        public string Delimiter
        {
            get { return _delimiter; }
            set
            {
                if (value == _delimiter) return;
                _delimiter = value;
                OnPropertyChanged();
            }
        }

        public bool SelectFirstLineOnly
        {
            get { return _selectFirstLineOnly; }
            set
            {
                if (value == _selectFirstLineOnly) return;
                _selectFirstLineOnly = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public DropActionConfiguration Clone()
        {
            return (DropActionConfiguration) ((ICloneable) this).Clone();
        }
    }
}