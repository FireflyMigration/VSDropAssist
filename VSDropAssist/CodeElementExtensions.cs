using System;
using System.Diagnostics;
using EnvDTE;

namespace VSDropAssist
{
    public static class CodeElementExtensions
    {
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
                Debug.WriteLine("Failed to get Name: " + e.ToString());
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
                Debug.WriteLine("Failed to parse kind: " + e.ToString());
            }
            return null;
        }
    }
}