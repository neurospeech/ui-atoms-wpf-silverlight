using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Windows.Design.Interaction;
using NeuroSpeech.UIAtoms.Design.About;

namespace NeuroSpeech.UIAtoms.Design.Form
{
    public class AtomAboutMenuProvider : PrimarySelectionContextMenuProvider
    {
        private MenuAction aboutMenuAction;

        public AtomAboutMenuProvider()
        {
            aboutMenuAction = new MenuAction("About UI Atoms 2011");
            aboutMenuAction.Execute += new EventHandler<MenuActionEventArgs>(aboutMenuAction_Execute);

            this.Items.Add(aboutMenuAction);

        }

        #region void  aboutMenuAction_Execute(object sender, MenuActionEventArgs e)
        void aboutMenuAction_Execute(object sender, MenuActionEventArgs e)
        {
#if DEMO
            AboutWindow.ShowAboutDialog(true);
#else
            AboutWindow.ShowAboutDialog(false);
#endif
        }
        #endregion

    }
}
