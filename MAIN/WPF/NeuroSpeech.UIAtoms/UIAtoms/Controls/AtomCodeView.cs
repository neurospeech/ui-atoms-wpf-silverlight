#if WINRT
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;
#else
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NeuroSpeech.UIAtoms.Core;

namespace NeuroSpeech.UIAtoms.Controls
{
 
    //[AtomDesign( 
    //    DisplayInToolbox=true
    //    )]
    //public class AtomCodeView : Control
    //{


    //    private TextBlock PART_TB;

    //    static AtomCodeView()
    //    {
    //        DefaultStyleKeyProperty.OverrideMetadata(typeof(AtomCodeView), new FrameworkPropertyMetadata(typeof(AtomCodeView)));
    //    }


    //    public override void OnApplyTemplate()
    //    {
    //        base.OnApplyTemplate();

    //        PART_TB = (TextBlock)GetTemplateChild("PART_TB");

    //        FormatText();
    //    }

    //    private void FormatText()
    //    {
    //        if (this.IsInDesignMode())
    //            return;
    //        if (PART_TB == null)
    //            return;
    //        AtomCodeFormatter acf = this.CodeFormatter;
    //        if (acf == null)
    //            return;
    //        string code = Code;

    //        PART_TB.Inlines.Clear();

    //        if (string.IsNullOrEmpty(code))
    //            return;
    //        acf.Format(PART_TB, Code);
    //    }



    //    ///<summary>
    //    ///DependencyProperty CodeFormatter
    //    ///</summary>
    //    #region Dependency Property CodeFormatter
    //    [AtomDesign(
    //        Bindable=true,
    //        BrowseMode=AtomPropertyBrowseMode.Default,
    //        Category="Atoms"
    //        )]
    //    public AtomCodeFormatter CodeFormatter
    //    {
    //        get { return (AtomCodeFormatter)GetValue(CodeFormatterProperty); }
    //        set { SetValue(CodeFormatterProperty, value); }
    //    }

    //    ///<summary>
    //    /// Using a DependencyProperty as the backing store for CodeFormatter.  This enables animation, styling, binding, etc...
    //    ///</summary>
    //    public static readonly DependencyProperty CodeFormatterProperty =
    //        DependencyProperty.Register("CodeFormatter", typeof(AtomCodeFormatter), typeof(AtomCodeView), new UIPropertyMetadata(null, OnCodeFormatterChangedCallback));

    //    private static void OnCodeFormatterChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
    //    {
    //        AtomCodeView obj = d as AtomCodeView;
    //        if (obj != null)
    //        {
    //            obj.OnCodeFormatterChanged(e);
    //        }
    //    }

    //    /// <summary>
    //    /// Fires CodeFormatterChanged event.
    //    /// </summary>
    //    /// <param name="e"></param>
    //    protected virtual void OnCodeFormatterChanged(DependencyPropertyChangedEventArgs e)
    //    {
    //        FormatText();
    //    }

    //    #endregion





    //    ///<summary>
    //    ///DependencyProperty Code
    //    ///</summary>
    //    #region Dependency Property Code
    //    [AtomDesign(
    //        Category="Atoms",
    //        BrowseMode= AtomPropertyBrowseMode.Default,
    //        Bindable=true,
    //        Description="Code to Format"
    //        )]
    //    public string Code
    //    {
    //        get { return (string)GetValue(CodeProperty); }
    //        set { SetValue(CodeProperty, value); }
    //    }

    //    ///<summary>
    //    /// Using a DependencyProperty as the backing store for Code.  This enables animation, styling, binding, etc...
    //    ///</summary>
    //    public static readonly DependencyProperty CodeProperty =
    //        DependencyProperty.Register("Code", typeof(string), typeof(AtomCodeView), new UIPropertyMetadata("", OnCodeChangedCallback));

    //    private static void OnCodeChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
    //    {
    //        AtomCodeView obj = d as AtomCodeView;
    //        if (obj != null)
    //        {
    //            obj.OnCodeChanged(e);
    //        }
    //    }

    //    /// <summary>
    //    /// Fires CodeChanged event.
    //    /// </summary>
    //    /// <param name="e"></param>
    //    protected virtual void OnCodeChanged(DependencyPropertyChangedEventArgs e)
    //    {
    //        FormatText();
    //        if (CodeChanged != null)
    //        {
    //            CodeChanged(this, EventArgs.Empty);
    //        }
    //    }

    //    ///<summary>
    //    ///
    //    ///</summary>
    //    public event EventHandler CodeChanged;

    //    #endregion



    //}
}
