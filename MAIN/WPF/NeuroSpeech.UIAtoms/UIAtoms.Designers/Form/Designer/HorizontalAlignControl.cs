using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Data;

namespace NeuroSpeech.UIAtoms.Designers.Form.Designer
{
    public class HorizontalListBox : ListBox {

        static HorizontalListBox()
        {
            ItemsPanelProperty.OverrideMetadata(typeof(HorizontalListBox),
                new FrameworkPropertyMetadata(CreateItemsPanel()));
            ItemTemplateProperty.OverrideMetadata(typeof(HorizontalListBox),
                new FrameworkPropertyMetadata(CreateItemTemplate()));
            SelectedValuePathProperty.OverrideMetadata(typeof(HorizontalListBox),
                new FrameworkPropertyMetadata("Value"));
        }

        #region private static PropertyChangedCallback CreateItemTemplate()
        private static DataTemplate CreateItemTemplate()
        {
            DataTemplate dt = new DataTemplate();
            FrameworkElementFactory root = new FrameworkElementFactory(typeof(Image));
            Binding b = new Binding("Source");
            root.SetBinding(Image.SourceProperty, b);
            root.SetValue(Image.MarginProperty, new Thickness(1));
            root.SetValue(Image.WidthProperty, (double)20);
            root.SetValue(Image.HeightProperty, (double)20);
            dt.VisualTree = root;
            return dt;
        }
        #endregion


        private static ItemsPanelTemplate CreateItemsPanel() {
            ItemsPanelTemplate t = new ItemsPanelTemplate();
            FrameworkElementFactory root = new FrameworkElementFactory(typeof(StackPanel));
            root.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);
            t.VisualTree = root;
            return t;
        }

        public HorizontalListBox()
        {
               
        }
    }

    public class HorizontalAlignControl : HorizontalListBox
    {
        public HorizontalAlignControl()
        {

            string root = "/NeuroSpeech.UIAtoms.Designers;component/Images/Alignment/";

            this.ItemsSource = new[] { 
                new {
                    Source = root + "HLeft.png",
                    Value = HorizontalAlignment.Left
                },
                new {
                    Source = root + "HCenter.png",
                    Value = HorizontalAlignment.Center
                },
                new {
                    Source = root + "HRight.png",
                    Value = HorizontalAlignment.Right
                },
                new {
                    Source = root + "HStretch.png",
                    Value = HorizontalAlignment.Stretch
                }
            };
        }
    }

    public class VerticalAlignControl : HorizontalListBox
    {
        public VerticalAlignControl()
        {

            string root = "/NeuroSpeech.UIAtoms.Designers;component/Images/Alignment/";
            this.ItemsSource = new[] { 
                new {
                    Source = root + "VTop.png",
                    Value = VerticalAlignment.Top
                },
                new {
                    Source = root + "VCenter.png",
                    Value = VerticalAlignment.Center
                },
                new {
                    Source = root + "VBottom.png",
                    Value = VerticalAlignment.Bottom
                },
                new {
                    Source = root + "VStretch.png",
                    Value = VerticalAlignment.Stretch
                }
            };
        }
    }

}
