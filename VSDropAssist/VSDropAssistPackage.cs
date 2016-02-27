//------------------------------------------------------------------------------
// <copyright file="VSDropAssistPackage.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.Win32;

namespace VSDropAssist
{
    /// <summary>
    /// This is the class that implements the package exposed by this assembly.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The minimum requirement for a class to be considered a valid package for Visual Studio
    /// is to implement the IVsPackage interface and register itself with the shell.
    /// This package uses the helper classes defined inside the Managed Package Framework (MPF)
    /// to do it: it derives from the Package class that provides the implementation of the
    /// IVsPackage interface and uses the registration attributes defined in the framework to
    /// register itself and its components with the shell. These attributes tell the pkgdef creation
    /// utility what data to put into .pkgdef file.
    /// </para>
    /// <para>
    /// To get loaded into VS, the package must be referred by &lt;Asset Type="Microsoft.VisualStudio.VsPackage" ...&gt; in .vsixmanifest file.
    /// </para>
    /// </remarks>
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)] // Info on this package for Help/About
    [Guid(VSDropAssistPackage.PackageGuidString)]
    [ProvideOptionPage(typeof(VSDropAssistOptionsPage),
    "Firefly Community", "VS DropAssist",
    1000, 1001, false)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
    public sealed class VSDropAssistPackage : Package
    {
        /// <summary>
        /// VSDropAssistPackage GUID string.
        /// </summary>
        public const string PackageGuidString = "a649f5b6-e940-4c53-940e-bec1539167cd";

        /// <summary>
        /// Initializes a new instance of the <see cref="VSDropAssistPackage"/> class.
        /// </summary>
        public VSDropAssistPackage()
        {
            // Inside this method you can place any initialization code that does not require
            // any Visual Studio service because at this point the package object is created but
            // not sited yet inside Visual Studio environment. The place to do all the other
            // initialization is the Initialize method.
        }

        #region Package Members

        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initialization code that rely on services provided by VisualStudio.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
            setupVSDRopAssistDefaults();
        }

        private void setupVSDRopAssistDefaults()
        {
            var options = GetDialogPage(typeof (VSDropAssistOptionsPage)) as VSDropAssistOptionsPage;
            if (options != null)
            {
                if (options.Settings != null && options.Settings.Any())
                {
                    Debug.WriteLine("Found some settings!");
                }
            }
        }

        #endregion
    }

    public class VSDropAssistSetting
    {
        public string Key { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }

    }
    class VSDropAssistSettingListConverter : TypeConverter
    {
        private string delimiter = "@**@";
   
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(string[]) || base.CanConvertTo(context, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            string v = value as string;

            return v == null ? base.ConvertFrom(context, culture, value) : v.Split(new[] { delimiter }, StringSplitOptions.RemoveEmptyEntries);

        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            string[] v = value as string[];
            if (destinationType != typeof(string) || v == null)
            {
                return base.ConvertTo(context, culture, value, destinationType);
            }
            return string.Join(delimiter, v);

        }
    }

    
    public class VSDropAssistOptionsPage : DialogPage
    {
      
        [Category("General")]
        [DisplayName("Settings")]
        [TypeConverter(typeof(VSDropAssistSettingListConverter))]
        public string[] Settings { get; set; }
    }
}
