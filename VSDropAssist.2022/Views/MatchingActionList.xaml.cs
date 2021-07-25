using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VSDropAssist.Views
{
    /// <summary>
    /// Interaction logic for MatchingActionList.xaml
    /// </summary>
    public partial class MatchingActionList : Window
    {
        private ObservableCollection<IGetActionResult> _items;

        public class SelectedEventArgs : EventArgs
        {
            public IGetActionResult Selection { get; set; }

            public SelectedEventArgs(IGetActionResult selection)
            {
                Selection = selection;
            }
        }

        public EventHandler<SelectedEventArgs> OnItemSelected;
        public EventHandler<EventArgs> OnCancel;

        public ObservableCollection<IGetActionResult> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                this.DataContext = _items;
                this.GrdActions.DataContext = _items;
            }
        }

        public MatchingActionList()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            OnItemSelected.Invoke(this, new SelectedEventArgs((IGetActionResult) GrdActions.SelectedItem));
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            OnCancel.Invoke(this, null);

        }
    }
}
