using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Windows.Design.Interaction;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using Microsoft.Windows.Design.Model;
using System.Diagnostics;
using System.Windows.Data;
using NeuroSpeech.UIAtoms.Designers.Form.Designer;
using NeuroSpeech.UIAtoms.Designers.Form.Generator;

namespace NeuroSpeech.UIAtoms.Design.Form
{
    public class AtomFormAdornerProvider : PrimarySelectionAdornerProvider
    {

        private AdornerPanel dropPanel;

        private Grid canvas = new Grid();

        private Button designButton = new Button();

        public AtomFormAdornerProvider()
        {
            CreateDesignButton();
            CreateCanvas();
            CreateDropPanel();
            dropPanel.HorizontalAlignment = HorizontalAlignment.Stretch;
            dropPanel.VerticalAlignment = VerticalAlignment.Stretch;
            dropPanel.Width = double.NaN;
            dropPanel.Height = double.NaN;
            Adorners.Add(dropPanel);
        }


        #region Method CreateDesignButton
        private void CreateDesignButton()
        {
            TextBlock tb = new TextBlock();
            tb.Text = "Design Form";
            tb.Foreground = Brushes.Blue;
            designButton.Content = tb;
            DefaultButtonBackground = designButton.Background;
            designButton.Background = new SolidColorBrush(Color.FromArgb(50,188,188,188));
            designButton.HorizontalAlignment = HorizontalAlignment.Center;
            designButton.VerticalAlignment = VerticalAlignment.Center;
            designButton.Cursor = Cursors.Hand;
            tb.TextDecorations.Add(TextDecorations.Underline);
            designButton.Click += new RoutedEventHandler(designButton_Click);
        } 
        #endregion

        #region Method CreateCavnas
        private void CreateCanvas()
        {
            canvas.HorizontalAlignment = HorizontalAlignment.Stretch;
            canvas.VerticalAlignment = VerticalAlignment.Stretch;
            canvas.Width = double.NaN;
            canvas.Height = double.NaN;

            canvas.PreviewDragEnter += new DragEventHandler(canvas_PreviewDragEnter);
            canvas.PreviewDrop += new DragEventHandler(canvas_PreviewDrop);
            canvas.Children.Add(designButton);

            canvas.DragEnter += new DragEventHandler(canvas_DragEnter);
            canvas.Drop += new DragEventHandler(on_Drop);
        }

        #region void  canvas_PreviewDrop(object sender, DragEventArgs e)
        void canvas_PreviewDrop(object sender, DragEventArgs e)
        {
            Trace.WriteLine("Preview Drop");
        }
        #endregion


        #region void  canvas_PreviewDragEnter(object sender, DragEventArgs e)
        void canvas_PreviewDragEnter(object sender, DragEventArgs e)
        {
            Trace.WriteLine("Preview Drag Enter");
        }
        #endregion
 
        #endregion

        #region Method CreateDropPanel
        private void CreateDropPanel()
        {
            dropPanel = new AdornerPanel();
            dropPanel.IsContentFocusable = true;
            dropPanel.Children.Add(canvas);
        }

        #endregion


        ModelItemCollection mc = null;

        private ModelItem formModelItem;

        private FormModel FormModel;

        #region Method protected override void  Activate(Microsoft.Windows.Design.Model.ModelItem item)
        protected override void Activate(Microsoft.Windows.Design.Model.ModelItem item)
        {
            Trace.WriteLine("Activated");
            base.Activate(item);
            formModelItem = item;
            FormModel = new FormModel(item, Prefix);
            Trace.WriteLine(string.Format("{0},{1}",FormModel.ActualWidth,FormModel.ActualHeight));
            Binding b = new Binding("ActualWidth");
            b.Source = FormModel;
            canvas.SetBinding(Control.WidthProperty, b);
            b = new Binding("ActualHeight");
            b.Source = FormModel;
            canvas.SetBinding(Control.HeightProperty, b);

            ModelProperty property = item.Properties["Items"];
            if (property != null && property.Value != null)
            {
                mc = item.Properties["Items"].Value as ModelItemCollection;
                if (mc != null) {
                    mc.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(mc_CollectionChanged);
                    mc_CollectionChanged(this, null);
                }
            }
        }

        private Brush DefaultButtonBackground;

        #region void  mc_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        void mc_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (mc.Count > 0)
            {
                designButton.HorizontalAlignment = HorizontalAlignment.Right;
                designButton.VerticalAlignment = VerticalAlignment.Top;
                designButton.Background = DefaultButtonBackground;
            }
            else {
                designButton.HorizontalAlignment = HorizontalAlignment.Center;
                designButton.VerticalAlignment = VerticalAlignment.Center;
                designButton.Background = new SolidColorBrush(Color.FromArgb(50, 188, 188, 188));
            }
        }
        #endregion

        #endregion

        #region protected override void  Deactivate()
        protected override void Deactivate()
        {
            Trace.WriteLine("Deactivated");
            base.Deactivate();
            if(mc!=null)
                mc.CollectionChanged -= new System.Collections.Specialized.NotifyCollectionChangedEventHandler(mc_CollectionChanged);
            formModelItem = null;
            dropPanel.ClearValue(Control.HeightProperty);
            dropPanel.ClearValue(Control.WidthProperty);
        }
        #endregion

        public virtual string Prefix {
            get {
                return "AtomForm.";
            }
        }

        void designButton_Click(object sender, RoutedEventArgs e)
        {
            if (formModelItem != null) {
                AtomFormGenerator designer = new AtomFormGenerator(Prefix);
                FormGeneratorViewModel vm = designer.DataContext as FormGeneratorViewModel;
                vm.FormModel = new FormModel(formModelItem, Prefix);
                vm.Context = formModelItem.Context;
                ModelEditingScope scope = formModelItem.BeginEdit();
                if (designer.ShowDialog() == true)
                {
                    scope.Complete();
                }
                else {
                    scope.Revert();
                }
            }
        }


        void canvas_DragEnter(object sender, DragEventArgs e)
        {
            Trace.WriteLine("Drag Enter");
            e.Effects = DragDropEffects.All;
        }

        void on_Drop(object sender, System.Windows.DragEventArgs e)
        {
            Trace.WriteLine("Drop");
            StringBuilder sb = new StringBuilder();
            foreach (string s in e.Data.GetFormats()) {
                sb.AppendFormat("{0}:{1}",s,e.Data.GetData(s));
            }
            MessageBox.Show(sb.ToString());
        }
    }

    public class AtomEntityFormAdornerProvider : AtomFormAdornerProvider
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
