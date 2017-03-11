using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.PlatformUI;

namespace VSDropAssist.Views
{
    public class ChooseAction : DialogWindow
    {
        private readonly IEnumerable<IGetActionResult> _matchingActionResults;

        public ChooseAction(IEnumerable<IGetActionResult> matchingActionResults )
        {
            _matchingActionResults = matchingActionResults;

            SelectedAction = null;
            var ctrl = new MatchingActionList();
            ctrl.Items = new ObservableCollection<IGetActionResult>(matchingActionResults);
            ctrl.OnCancel += (sender, args) =>
            {
                this.DialogResult = false;

            };
            ctrl.OnItemSelected += (sender, args) =>
            {
                SelectedAction = args.Selection.Action;
                this.DialogResult = true;
            };

            
            base.Content = ctrl;

            this.HasMinimizeButton = false;
            this.HasMaximizeButton = false;
        }

        

        public IDropAction SelectedAction { get; private set; }
    }
}
