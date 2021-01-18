#if WINRT
using Windows.UI.Xaml;
#else
using System.Windows;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuroSpeech.UIAtoms.Controls.Buttons
{

    /// <summary>
    /// 
    /// </summary>
    [NeuroSpeech.UIAtoms.Core.AtomDesign(
        DisplayInToolbox = true,
        ToolboxTabName = "Atom Buttons"
        )]
    public class AtomSaveButton : BaseAtomImageButton
    {

    //    static AtomSaveButton()
    //    {
            
    //    }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public static RoutedEvent SaveEvent = EventManager.RegisterRoutedEvent(
    //        "Save",
    //        RoutingStrategy.Bubble,
    //        typeof(RoutedEventHandler),
    //        typeof(AtomSaveButton));

    //    ///<summary>
    //    /// Dependency Property FilePath
    //    ///</summary>
    //    #region Dependency Property FilePath
    //    [System.ComponentModel.Category("Atoms")]
    //    [System.ComponentModel.Bindable(true)]
    //    [System.ComponentModel.Description("FilePath")]
    //    [System.ComponentModel.Browsable(true)]
    //    public string FilePath
    //    {
    //        get { return (string)GetValue(FilePathProperty); }
    //        set { SetValue(FilePathProperty, value); }
    //    }

    //    ///<summary>
    //    /// Using a DependencyProperty as the backing store for FilePath.  This enables animation, styling, binding, etc...
    //    ///</summary>
    //    public static readonly DependencyProperty FilePathProperty =
    //        DependencyProperty.Register("FilePath", typeof(string), typeof(AtomSaveButton), new UIPropertyMetadata(null));

    //    #endregion




    //    ///<summary>
    //    ///Default, Shows Save dialog box, set None to just handle the click event.
    //    ///</summary>
    //    #region Dependency Property SaveMode
    //    [System.ComponentModel.Category("Atoms")]
    //    [System.ComponentModel.Bindable(true)]
    //    [System.ComponentModel.Description("SaveMode")]
    //    [System.ComponentModel.Browsable(true)]
    //    public AtomSaveButtonMode SaveMode
    //    {
    //        get { return (AtomSaveButtonMode)GetValue(SaveModeProperty); }
    //        set { SetValue(SaveModeProperty, value); }
    //    }

    //    ///<summary>
    //    /// Using a DependencyProperty as the backing store for SaveMode.  This enables animation, styling, binding, etc...
    //    ///</summary>
    //    public static readonly DependencyProperty SaveModeProperty =
    //        DependencyProperty.Register("SaveMode", typeof(AtomSaveButtonMode), typeof(AtomSaveButton), new UIPropertyMetadata(AtomSaveButtonMode.Save));

    //    #endregion



    //    ///<summary>
    //    /// Dependency Property DefaultFileName
    //    ///</summary>
    //    #region Dependency Property DefaultFileName
    //    [System.ComponentModel.Category("Atoms")]
    //    [System.ComponentModel.Bindable(true)]
    //    [System.ComponentModel.Description("DefaultFileName")]
    //    [System.ComponentModel.Browsable(true)]
    //    public string DefaultFileName
    //    {
    //        get { return (string)GetValue(DefaultFileNameProperty); }
    //        set { SetValue(DefaultFileNameProperty, value); }
    //    }

    //    ///<summary>
    //    /// Using a DependencyProperty as the backing store for DefaultFileName.  This enables animation, styling, binding, etc...
    //    ///</summary>
    //    public static readonly DependencyProperty DefaultFileNameProperty =
    //        DependencyProperty.Register("DefaultFileName", typeof(string), typeof(AtomSaveButton), new UIPropertyMetadata("Untitled"));


    //    #endregion



    //    ///<summary>
    //    /// Dependency Property DefaultExtension
    //    ///</summary>
    //    #region Dependency Property DefaultExtension
    //    [System.ComponentModel.Category("Atoms")]
    //    [System.ComponentModel.Bindable(true)]
    //    [System.ComponentModel.Description("DefaultExtension")]
    //    [System.ComponentModel.Browsable(true)]
    //    public string DefaultExtension
    //    {
    //        get { return (string)GetValue(DefaultExtensionProperty); }
    //        set { SetValue(DefaultExtensionProperty, value); }
    //    }

    //    ///<summary>
    //    /// Using a DependencyProperty as the backing store for DefaultExtension.  This enables animation, styling, binding, etc...
    //    ///</summary>
    //    public static readonly DependencyProperty DefaultExtensionProperty =
    //        DependencyProperty.Register("DefaultExtension", typeof(string), typeof(AtomSaveButton), new UIPropertyMetadata("txt"));


    //    #endregion



    //    ///<summary>
    //    /// Dependency Property InitialDirectory
    //    ///</summary>
    //    #region Dependency Property InitialDirectory
    //    [System.ComponentModel.Category("Atoms")]
    //    [System.ComponentModel.Bindable(true)]
    //    [System.ComponentModel.Description("InitialDirectory")]
    //    [System.ComponentModel.Browsable(true)]
    //    public string InitialDirectory
    //    {
    //        get { return (string)GetValue(InitialDirectoryProperty); }
    //        set { SetValue(InitialDirectoryProperty, value); }
    //    }

    //    ///<summary>
    //    /// Using a DependencyProperty as the backing store for InitialDirectory.  This enables animation, styling, binding, etc...
    //    ///</summary>
    //    public static readonly DependencyProperty InitialDirectoryProperty =
    //        DependencyProperty.Register("InitialDirectory", typeof(string), typeof(AtomSaveButton), new UIPropertyMetadata(null));


    //    #endregion



    //    ///<summary>
    //    /// Dependency Property FileFilter
    //    ///</summary>
    //    #region Dependency Property FileFilter
    //    [System.ComponentModel.Category("Atoms")]
    //    [System.ComponentModel.Bindable(true)]
    //    [System.ComponentModel.Description("FileFilter")]
    //    [System.ComponentModel.Browsable(true)]
    //    public string FileFilter
    //    {
    //        get { return (string)GetValue(FileFilterProperty); }
    //        set { SetValue(FileFilterProperty, value); }
    //    }

    //    ///<summary>
    //    /// Using a DependencyProperty as the backing store for FileFilter.  This enables animation, styling, binding, etc...
    //    ///</summary>
    //    public static readonly DependencyProperty FileFilterProperty =
    //        DependencyProperty.Register("FileFilter", typeof(string), typeof(AtomSaveButton), new UIPropertyMetadata("All files |*.*"));


    //    #endregion


    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public event RoutedEventHandler Save {
    //        add {
    //            base.AddHandler(SaveEvent, value);
    //        }
    //        remove {
    //            base.RemoveHandler(SaveEvent, value);
    //        }
    //    }
        

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    protected override void OnClick()
    //    {
    //        base.OnClick();

    //        if (!IsValidationSuccessful)
    //            return;

    //        // let the validation happen before...
    //        AtomSaveButtonMode mode = SaveMode;
    //        if (mode == AtomSaveButtonMode.None)
    //            return;

    //        if (mode == AtomSaveButtonMode.SaveAs || string.IsNullOrEmpty(FilePath)) {
    //            Microsoft.WindowsAPICodePack.Dialogs.CommonSaveFileDialog sfd = 
    //                new Microsoft.WindowsAPICodePack.Dialogs.CommonSaveFileDialog();
    //            sfd.DefaultExtension = DefaultExtension;
    //            sfd.DefaultFileName = DefaultFileName;
    //            sfd.InitialDirectory = InitialDirectory;

    //            string[] filters = FileFilter.Split('|');
    //            for (int i = 0; i < filters.Length/2; i+=2)
    //            {
    //                string display = filters[i];// +" (" + filters[1] + ")";
    //                string extensions = filters[i+1];
    //                sfd.Filters.Add( new Microsoft.WindowsAPICodePack.Dialogs.CommonFileDialogFilter(display,extensions) );
    //            }

                
    //            if (sfd.ShowDialog() != Microsoft.WindowsAPICodePack.Dialogs.CommonFileDialogResult.OK)
    //                return;
    //            FilePath = sfd.FileName;
    //        }

    //        RoutedEventArgs re = new RoutedEventArgs(SaveEvent, this);
    //        this.RaiseEvent(re);

    //    }
    //}

    ///// <summary>
    ///// 
    ///// </summary>
    //public enum AtomSaveButtonMode { 

    //    /// <summary>
    //    /// Does nothing
    //    /// </summary>
    //    None,

    //    /// <summary>
    //    /// Default, displays Save Dialog Box only if FilePath property is empty or null
    //    /// </summary>
    //    Save,

    //    /// <summary>
    //    /// Displays Save Dialog Box always, useful for "Save As" command...
    //    /// </summary>
    //    SaveAs

    }
}
