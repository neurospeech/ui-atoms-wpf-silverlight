#if WINRT
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
#else
using System.Windows.Controls;
using System.Windows;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuroSpeech.UIAtoms.Controls;

namespace NeuroSpeech.UIAtoms.Core
{
    /// <summary>
    /// Supports atom label.
    /// </summary>
    public abstract class BaseAtomTextBlock : TextBlock
    {

        /// <summary>
        /// 
        /// </summary>
        #region Dependency Property IsRequired
        [System.ComponentModel.Category("Atoms")]
        [System.ComponentModel.Bindable(true)]
        public bool IsRequired
        {
            get { return (bool)GetValue(IsRequiredProperty); }
            set { SetValue(IsRequiredProperty, value); }
        }

        ///<summary>
        ///Using a DependencyProperty as the backing store for IsRequired.  This enables animation, styling, binding, etc...
        ///</summary>
        public static readonly DependencyProperty IsRequiredProperty =
            AtomForm.IsRequiredProperty.AddOwner(typeof(BaseAtomTextBlock), new UIPropertyMetadata(false));

        #endregion

        /// <summary>
        /// 
        /// </summary>
        #region Dependency Property Label
        [System.ComponentModel.Category("Atoms")]
        [System.ComponentModel.Bindable(true)]
        [System.ComponentModel.Description("Label")]
        [System.ComponentModel.Browsable(true)]
        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        ///<summary> Using a DependencyProperty as the backing store for Label.  This enables animation, styling, binding, etc...</summary>
        public static readonly DependencyProperty LabelProperty =
            AtomForm.LabelProperty.AddOwner(typeof(BaseAtomTextBlock));


        #endregion

        /// <summary>
        /// 
        /// </summary>
        #region Dependency Property Description
        [System.ComponentModel.Category("Atoms")]
        [System.ComponentModel.Bindable(true)]
        [System.ComponentModel.Description("Description")]
        [System.ComponentModel.Browsable(true)]
        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        ///<summary> Using a DependencyProperty as the backing store for Description.  This enables animation, styling, binding, etc...</summary>
        public static readonly DependencyProperty DescriptionProperty =
            AtomForm.DescriptionProperty.AddOwner(typeof(BaseAtomTextBlock));


        #endregion

        /// <summary>
        /// 
        /// </summary>
        #region Dependency Property Title
        [System.ComponentModel.Category("Atoms")]
        [System.ComponentModel.Bindable(true)]
        [System.ComponentModel.Description("Title")]
        [System.ComponentModel.Browsable(true)]
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        ///<summary> Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...</summary>
        public static readonly DependencyProperty TitleProperty =
            AtomForm.TitleProperty.AddOwner(typeof(BaseAtomTextBlock));


        #endregion
    }
}
