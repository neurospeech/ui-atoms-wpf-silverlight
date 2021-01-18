using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Windows.Design.Interaction;
using System.Windows;
using Microsoft.Windows.Design.Model;
using NeuroSpeech.UIAtoms.Designers.Form.Designer;
using NeuroSpeech.UIAtoms.Designers.Form.Generator;

namespace NeuroSpeech.UIAtoms.Design.Form
{
    public class AtomFormMenuProvider : PrimarySelectionContextMenuProvider
    {

        private MenuAction startFormDesignerAction;

        public AtomFormMenuProvider()
        {
            startFormDesignerAction = new MenuAction("Start Form Designer");
            startFormDesignerAction.Execute += new EventHandler<MenuActionEventArgs>(showMessageAction_Execute);

            /*MenuGroup mg = new MenuGroup("Form Designer", "Form Designer");
            mg.HasDropDown = true;
            mg.Items.Add(showMessageAction);

            this.Items.Add(mg);*/

            this.Items.Add(startFormDesignerAction);

            UpdateItemStatus += new EventHandler<MenuActionEventArgs>(AtomFormMenuProvider_UpdateItemStatus);
        }

        void AtomFormMenuProvider_UpdateItemStatus(object sender, MenuActionEventArgs e)
        {
            
        }

        public virtual string Prefix {
            get {
                return "AtomForm.";
            }
        }

        void showMessageAction_Execute(object sender, MenuActionEventArgs e)
        {
            if (e.Selection == null)
                return;
            ModelItem item = e.Selection.SelectedObjects.FirstOrDefault();
            if (item != null) {
                ModelEditingScope scope = item.BeginEdit();
                AtomFormGenerator form = new AtomFormGenerator(Prefix);
                FormGeneratorViewModel vm = form.DataContext as FormGeneratorViewModel;
                vm.FormModel = new FormModel(item,Prefix);
                vm.Context = item.Context;
                if (form.ShowDialog() == true)
                {
                    scope.Complete();
                }
                else {
                    scope.Revert();
                }
            }
        }

    }


    public class AtomEntityFormMenuProvider : AtomFormMenuProvider
    {

        public override string Prefix
        {
            get
            {
                return "AtomEntityForm.";
            }
        }
    
    }
}
