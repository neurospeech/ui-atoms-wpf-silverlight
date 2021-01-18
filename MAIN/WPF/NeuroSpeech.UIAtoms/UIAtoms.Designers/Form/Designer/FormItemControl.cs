using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows;
using System.IO;

namespace NeuroSpeech.UIAtoms.Designers.Form.Designer
{
    public class FormItemControl : HeaderedContentControl
    {

        static FormItemControl()
        {
        }


        private static readonly string template = 
"<ControlTemplate " 
+"            xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'"
+"            xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'"
+ "    xmlns:local='clr-namespace:NeuroSpeech.UIAtoms.Designers.Form.Designer;assembly=NeuroSpeech.UIAtoms.Designers'"
+"    TargetType='{x:Type local:FormItemControl}'"
+"             >"
+"    <Grid Margin='2'>"
+"        <Grid.ColumnDefinitions>"
+"            <ColumnDefinition Width='90'/>"
+"            <ColumnDefinition Width='5'/>"
+"            <ColumnDefinition/>"
+"        </Grid.ColumnDefinitions>"
+"        <ContentPresenter ContentSource='Header' HorizontalAlignment='Right'/>"
+"        <TextBlock Grid.Column='1'>:</TextBlock>"
+"        <ContentPresenter ContentSource='Content' Grid.Column='2' HorizontalAlignment='Stretch'/>"
+"    </Grid>"
+"</ControlTemplate>"  ;

        public FormItemControl()
        {

            string t = template;

#if DesignSL
            t = t.Replace("NeuroSpeech.UIAtoms.Designers.Form.Designer", "NeuroSpeech.UIAtoms.Silverlight.VisualStudio.Design");
#endif

            MemoryStream ms = new MemoryStream(System.Text.Encoding.Default.GetBytes(t));
            this.Template = XamlReader.Load(ms) as ControlTemplate;
        }


        ///<summary>
        /// Dependency Property LabelWidth
        ///</summary>
        #region Dependency Property LabelWidth
        public double LabelWidth
        {
            get { return (double)GetValue(LabelWidthProperty); }
            set { SetValue(LabelWidthProperty, value); }
        }

        ///<summary>
        /// Using a DependencyProperty as the backing store for LabelWidth.  This enables animation, styling, binding, etc...
        ///</summary>
        public static readonly DependencyProperty LabelWidthProperty =
            DependencyProperty.Register("LabelWidth", typeof(double), typeof(FormItemControl), new FrameworkPropertyMetadata((double)20));

        #endregion



    }
}
