using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Editor.DragDrop;

namespace VSDropAssist.DropActions
{
    public interface IDropActionConfiguration
    {
        bool ShiftMustBeDown { get;  }
        bool ControlMustBeDown { get;  }
        bool AltMustBeDown { get;  }
        string FormatExpression { get;  }
        bool SelectAfterDrop { get;  }
        bool SupportsMembers { get;  }
        bool SupportsClasses { get;  }
        string Delimiter { get; }
        bool SupportsDroppingIntoMethod { get;  }
        bool SupportsDroppingIntoClass { get;  }
        string TokenToSelectAfterDrop { get; }
        int Match(IDropQuery qry);
    }

    public interface IDropActionProvider
    {
        IDropAction GetAction(DropQuery qry);
    }

    public class DropActionProvider : IDropActionProvider
    {
        private List<IDropAction> _actions;

        public DropActionProvider(IEnumerable<IDropAction> actions)
        {
            _actions = new List<IDropAction>(actions );
        }

        public IDropAction GetAction(DropQuery qry)
        {
            return _actions.Where(x => x.Match(qry )>0).OrderByDescending(x => x.Match(qry)).FirstOrDefault();


        }
    }
    public class DropActionConfiguration : IDropActionConfiguration {
        public bool ShiftMustBeDown { get; set; }
        public bool ControlMustBeDown { get; set; }
        public bool AltMustBeDown { get; set; }
        public string FormatExpression { get; set; }
        public bool SelectAfterDrop { get; set; }
        public bool SupportsMembers { get; set; }
        public bool SupportsClasses { get; set; }
        public bool SupportsDroppingIntoMethod { get; set; }
        public bool SupportsDroppingIntoClass { get; set; }
        public string TokenToSelectAfterDrop { get; set; }
        public string Delimiter { get; set; }
        public DropActionConfiguration()
        {
            SupportsClasses = true;
            SupportsMembers = true;
            SupportsDroppingIntoClass = true;
            SupportsDroppingIntoMethod = true;
            SelectAfterDrop = true;
            TokenToSelectAfterDrop = "%v%";
            Delimiter = "\n";
        }

        public int Match(IDropQuery qry)
        {
            var ret = 0;
            if (this.ShiftMustBeDown && qry.ShiftDown) ret += 1;
            if (this.AltMustBeDown  && qry.AltDown ) ret += 1;
            if (this.ControlMustBeDown && qry.ControlDown) ret += 1;


            if (this.SupportsClasses && qry.ContainsClasses) ret += 1;
            if (this.SupportsMembers && qry.ContainsMembers) ret += 1;

            if (this.SupportsDroppingIntoClass && qry.DroppingIntoClass) ret+=1;
            if (this.SupportsDroppingIntoMethod && qry.DroppingIntoMethod) ret += 1;

            if (!this.SupportsDroppingIntoClass && qry.DroppingIntoClass) return 0;
            if (!this.SupportsDroppingIntoMethod && qry.DroppingIntoMethod) return 0;

            return ret;
        }
    }
    public interface IDropQuery
    {
        bool ShiftDown { get; }
        bool ControlDown { get; }
        bool AltDown { get; }
        bool ContainsClasses { get;  }
        bool ContainsMembers { get; }
        bool DroppingIntoMethod { get;  }
        bool DroppingIntoClass { get; }
    }

    public class DropQuery : IDropQuery
    {
        public bool ShiftDown { get; set; }
        public bool ControlDown { get; set; }
        public bool AltDown { get; set; }
        public bool ContainsClasses { get; set; }
        public bool ContainsMembers { get; set; }
        public bool DroppingIntoMethod { get; set; }
        public bool DroppingIntoClass { get; set; }
        
    }
    public class ConfigurableDropAction : SimpleTextDropAction
    {
        private readonly IDropActionConfiguration _configuration;

        public ConfigurableDropAction(IFormatExpressionService formatExpressionService,
            IDropActionConfiguration configuration ) : base(formatExpressionService)
        {
            _configuration = configuration;
        }

        public override int Match(DropQuery qry)
        {
            return _configuration.Match(qry);
        }

        protected override string getDelimiter()
        {
            return _configuration.Delimiter;
        }

        public bool SupportsDrop(IDropQuery dropQuery )
        {
            
            if (!_configuration.SupportsDroppingIntoClass && dropQuery.DroppingIntoClass) return false;
            if (!_configuration.SupportsDroppingIntoMethod && dropQuery.DroppingIntoMethod) return false;

            if (!(_configuration.SupportsMembers && dropQuery.ContainsMembers ||
                  _configuration.SupportsClasses && dropQuery.ContainsClasses)) return false;

            if (!(_configuration.ControlMustBeDown && dropQuery.ControlDown)) return false;
            if (!(_configuration.ShiftMustBeDown && dropQuery.ShiftDown)) return false;
            if (!(_configuration.AltMustBeDown && dropQuery.AltDown)) return false;

            return true  ;
        }
        public override bool getNodeFilter(Node n)
        {
            
            if (!_configuration.SupportsClasses && n.IsClass) return false;
            if (!_configuration.SupportsMembers && !n.IsClass) return false;

            return true ;
        }

        protected override string getTokenToSelectAfterDrop()
        {
            return _configuration.TokenToSelectAfterDrop;
        }

        protected override bool getSelectAfterDrop()
        {
            return _configuration.SelectAfterDrop;
        }

        protected override string GetFormatString()
        {
            return _configuration.FormatExpression;
        }
    }

    
    internal class NewClassInstanceDropAction : ConfigurableDropAction
    {
        public NewClassInstanceDropAction(IFormatExpressionService formatExpressionService) : base(formatExpressionService,
            new DropActionConfiguration() { FormatExpression = "new %f%();", Delimiter="\n", AltMustBeDown=true })
        {
        }

        
        
    }
    internal  class ClassFullNameDropAction : ConfigurableDropAction
    {
        
        public ClassFullNameDropAction(IFormatExpressionService formatExpressionService) : base(formatExpressionService,
             new DropActionConfiguration() { FormatExpression = "%f%", Delimiter = "\n", ShiftMustBeDown  = true, TokenToSelectAfterDrop="%f%" })
        {
        }
       
    }
}