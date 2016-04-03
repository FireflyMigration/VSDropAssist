using System;
using System.Collections.Generic;
using System.Linq;
using VSDropAssist.Entities;

namespace VSDropAssist.DropActions
{
    public class ConfigurableDropAction : SimpleTextDropAction, IConfigurableDropAction 
    {
        private readonly IDropActionConfiguration _configuration;

        public ConfigurableDropAction(IFormatExpressionService formatExpressionService,
            IDropActionConfiguration configuration ) : base(formatExpressionService)
        {
            _configuration = configuration;
        }

        public override int Match(DropQuery qry)
        {
            return qry.Match(_configuration);
        }

        protected override string getDelimiter()
        {
            return _configuration.Delimiter;
        }

        protected override int getSelectionHeight(IEnumerable<CodeLine> lines)
        {
            if (_configuration.SelectFirstLineOnly) return Math.Min(1, lines.Count());

            return lines.Count();
        }

        protected override int getSelectionWidth(IEnumerable<CodeLine> lines)
        {
            if (lines == null || !lines.Any()) return 0;

            if (_configuration.SelectFirstLineOnly) return lines.First().TokenLength;

            return base.getSelectionWidth(lines);
        }

        public bool SupportsDrop(IDropQuery dropQuery )
        {
            
            if (!_configuration.SupportsDroppingIntoClass && dropQuery.DroppingIntoClass && !dropQuery.DroppingIntoMethod) return false;
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
}