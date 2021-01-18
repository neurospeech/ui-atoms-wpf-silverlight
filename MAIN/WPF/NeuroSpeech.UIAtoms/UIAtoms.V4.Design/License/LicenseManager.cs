using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LicenseLibrary;
using System.IO;
using System.Windows;
#if DesignSL
using UIAtoms.Silverlight.VisualStudio.Design.License;
#endif

namespace NeuroSpeech.UIAtoms.Design.License
{
    class AtomLicenseManager
    {


        private static NSLicense GetLicense() {
			NSLicense lic = null;
			try
			{
				lic = NSLicense.LoadFrom(FilePath, Strings.NSLM_Public);
			}
			catch (Exception ex) {
				MessageBox.Show(ex.ToString());
			}

            if (lic == null)
            {
                // show dialog..
                ActivateLicenseWindow alw = new ActivateLicenseWindow();
                alw.FilePath = FilePath;
                if (alw.ShowDialog() == true) { 
                    // save key...
                    return NSLicense.LoadFrom(FilePath, Strings.NSLM_Public);
                }
            }
            return lic;
        }


        #region internal static bool IsValid()
        internal static bool IsValid()
        {
            NSLicense lic = GetLicense();

            if (lic == null)
            {
                return false;
            }

            if (lic.FeatureSet.ComputerName != System.Environment.MachineName)
            {
                Delete(lic);
                return false;
            }

#if DesignSL
            if (!lic.FeatureSet.Features.Any(x => x == "uiatoms.silverlight"))
            {
                Delete(lic);
                return false;
            }
#else
            if (!lic.FeatureSet.Features.Any(x => x == "uiatoms.wpf"))
            {
                Delete(lic);
                return false;
            }
#endif

            return true;
        }

        #region private static void Delete(NSLicense lic)
        private static void Delete(NSLicense lic)
        {
            if (File.Exists(FilePath))
                File.Delete(FilePath);
            System.Windows.MessageBox.Show("Invalid License....");
        }
        #endregion

        #endregion

        static string FilePath
        {
            get
            {
                string folder = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\NeuroSpeech UIAtoms";
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);
                return folder + "\\License.xml";
            }
        }
    }
}
