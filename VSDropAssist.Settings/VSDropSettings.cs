using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using log4net;
using VSDropAssist.Settings.Annotations;

namespace VSDropAssist.Settings
{
    [XmlRoot("options")]
    public class VSDropSettings : INotifyPropertyChanged
    {
        private bool _normaliseProjectNamespace;
        private List<DropActionConfiguration> _settings;


        public VSDropSettings()
        {
            this.Settings = new List<DropActionConfiguration>();
            this.NormaliseProjectNamespace = true;
        }
      
        public string ToXml()
        {
            var xs = new XmlSerializer(GetType()) ;
            using (var sw = new StringWriter())
            {
                xs.Serialize(sw, this);
                return sw.ToString();
            }
                
        }

        public static VSDropSettings FromXml(string xml)
        {
            var log = LogManager.GetLogger(typeof (VSDropSettings));

            var xs = new XmlSerializer(typeof(VSDropSettings));
            try
            {
                using (var sr = new StringReader(xml))
                {
                    return (VSDropSettings) xs.Deserialize(sr);

                }
            }
            catch (InvalidOperationException e)
            {
                log.Error(string.Format("Failed to deserialize xml: {0}",xml),e );
            }

            return null;
        }


        [XmlArray("SETTINGS")]
        [XmlArrayItem("SETTING", typeof (DropActionConfiguration))]
        public List<DropActionConfiguration> Settings
        {
            get { return _settings; }
            set
            {
                if (Equals(value, _settings)) return;
                _settings = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<DropActionConfiguration> ObservableSettings => new ObservableCollection<DropActionConfiguration>(_settings);

        public bool NormaliseProjectNamespace
        {
            get { return _normaliseProjectNamespace; }
            set
            {
                if (value == _normaliseProjectNamespace) return;
                _normaliseProjectNamespace = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}