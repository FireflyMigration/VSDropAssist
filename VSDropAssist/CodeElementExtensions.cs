using System;
using System.Diagnostics;
using EnvDTE;
using log4net;

namespace VSDropAssist
{
    public static class CodeElementExtensions
    {
        private static ILog _log = LogManager.GetLogger("CodeElementExtensions");

        public static string SafeNamespace(this CodeElement ce)
        {
            if (ce.Kind == vsCMElement.vsCMElementClass)
            {
                var clazz = ce as CodeClass;

                var fullname = ce.FullName;
                var ns = fullname.Substring(0,fullname.LastIndexOf('.'));
                return ns;
            }

            return null;
        }
        public static string SafeName(this CodeElement ce)
        {
            try
            {
                return ce.Name;
            }
            
            catch (Exception e)
            {
                _log.Info("Failed to get Name (this can be ignored): " + e.ToString());
            }
            return null;
        }
        public static string KindAsString(this CodeElement ce)
        {
            try
            {
                var k = Enum.GetName(typeof (vsCMElement), ce.Kind);
                if (k != null)
                {
                    return k.ToString();
                }

            }
            catch (Exception e)
            {
                _log.Info("Failed to parse kind: " + e.ToString());
            }
            return null;
        }
    }
}