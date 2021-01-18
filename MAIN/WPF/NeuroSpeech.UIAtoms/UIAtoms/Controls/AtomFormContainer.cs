#if WINRT
#else
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuroSpeech.UIAtoms.Controls
{

    /// <summary>
    /// 
    /// </summary>
    public class AtomFormContainer : AtomFormLayout , IFormContainer
    {

        #region internal void SetLabelWidth(double p)
        private double lastWidth = 0;
        void IFormContainer.SetLabelWidth(double p)
        {
            lastWidth = Math.Max(lastWidth, p);
            if (this.LabelWidth < lastWidth)
                LabelWidth = lastWidth;
        }
        #endregion




        #region public void  BindField(AtomFormContainer container, System.Windows.Controls.Control field)
        void IFormContainer.BindField(AtomFormItemContainer container, System.Windows.Controls.Control field)
        {
            BindField(container, field);
        }

        #endregion

        #region private void BindField(AtomFormContainer container,System.Windows.Controls.Control field)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        /// <param name="field"></param>
        protected virtual void BindField(AtomFormItemContainer container, System.Windows.Controls.Control field)
        {
        }
        #endregion

    }
}
