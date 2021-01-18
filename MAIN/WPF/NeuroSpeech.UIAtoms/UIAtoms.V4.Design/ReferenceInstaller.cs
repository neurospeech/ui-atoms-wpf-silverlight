using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using Microsoft.Win32;
using System.Reflection;
using System.IO;
using System.Windows;


namespace NeuroSpeech.UIAtoms.Design
{
    [RunInstaller(true)]
    public partial class ReferenceInstaller : System.Configuration.Install.Installer
    {
        public ReferenceInstaller()
        {
            InitializeComponent();
        }

        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);

            try
            {
                string folder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                if (folder.ToLower().EndsWith("\\design"))
                    folder = folder.Substring(0, folder.Length - 7);
#if DesignSL
                RegistryKey key = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Microsoft SDKs\\Silverlight\\v4.0\\AssemblyFoldersEx");
#else
                RegistryKey key = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\.NETFramework\\v2.0.50727\\AssemblyFoldersEx");
#endif

                key = key.CreateSubKey("UI Atoms 1.0");
                key.SetValue(null, folder);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }

        }

        public override void Uninstall(IDictionary savedState)
        {

            try
            {
#if DesignSL
                RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Microsoft SDKs\\Silverlight\\v4.0\\AssemblyFoldersEx");
#else
                RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\.NETFramework\\v2.0.50727\\AssemblyFoldersEx");
#endif

                key.DeleteSubKeyTree("UI Atoms 1.0");
            }
            catch {
                //MessageBox.Show(ex.ToString());
            }
            
            base.Uninstall(savedState);
        }
    }
}
