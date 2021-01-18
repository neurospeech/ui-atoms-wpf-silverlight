using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Diagnostics;
using System.Windows;

namespace NeuroSpeech.UIAtoms.Designers.Form.Designer
{
    public class BaseImageButton : Button
    {

        public BaseImageButton()
        {
            try
            {
                this.BeginInit();

                Image img = new Image();
                img.ImageFailed += (s, e) => {
                    Trace.WriteLine(e.ErrorException.ToString());
                };
                string url = "/NeuroSpeech.UIAtoms.Designers;component/Icons/Atom" + this.GetType().Name + ".Icon.png";
                Trace.WriteLine(url);
                img.Source = new BitmapImage(
                    new Uri(url, UriKind.RelativeOrAbsolute)
                    );
                img.Width = 16;
                img.Height = 16;
                this.Content = img;
                this.EndInit();
            }
            catch (Exception ex) {
                Trace.WriteLine(ex.ToString());
            }
        }

    }

    public class AddButton : BaseImageButton
    {
    }
    public class DeleteButton : BaseImageButton
    {
    }
    public class MoveUpButton : BaseImageButton
    {
    }
    public class MoveDownButton : BaseImageButton
    {
    }
    public class SaveButton : BaseImageButton
    {
    }

}
