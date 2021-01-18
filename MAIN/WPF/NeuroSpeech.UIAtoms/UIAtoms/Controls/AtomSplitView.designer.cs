#if WINRT
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Ink;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Shapes;
#else
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
#endif

using System;
using System.Net;


      
		namespace NeuroSpeech.UIAtoms.Controls{

		public partial class AtomSplitView : System.Windows.Controls.Grid
		{
		
			
			public AtomSplitView(){
				
				Orientation = System.Windows.Controls.Orientation.Horizontal;
				
				OnCreated();
			}
			
			partial void OnCreated();
			
				partial void OnAfterOrientationPropertyChanged(DependencyPropertyChangedEventArgs e);
				
				private static void OnOrientationPropertyChangedCallback(object sender, DependencyPropertyChangedEventArgs e){
					AtomSplitView obj = sender as AtomSplitView;
					if(obj!=null){
						obj.OnOrientationPropertyChanged(e);
					}
				}
				
				protected virtual void OnOrientationPropertyChanged(DependencyPropertyChangedEventArgs e){
					OnAfterOrientationPropertyChanged(e);
					
										if(OrientationChanged!=null){
						OrientationChanged(this,e);
					}
										
				}
				
								
								public event PropertyChangedCallback OrientationChanged;
								
				
#if SILVERLIGHT
				public static DependencyProperty OrientationProperty 
				= DependencyProperty.Register("Orientation",typeof(System.Windows.Controls.Orientation), typeof(AtomSplitView),
										new PropertyMetadata(System.Windows.Controls.Orientation.Horizontal,OnOrientationPropertyChangedCallback));
										
				
#else
				public static DependencyProperty OrientationProperty 
				= DependencyProperty.Register("Orientation",typeof(System.Windows.Controls.Orientation), typeof(AtomSplitView),
										new FrameworkPropertyMetadata(System.Windows.Controls.Orientation.Horizontal,System.Windows.FrameworkPropertyMetadataOptions.None,OnOrientationPropertyChangedCallback));
					#endif
					
				

				
				public System.Windows.Controls.Orientation Orientation
				{
					get{
						return (System.Windows.Controls.Orientation)GetValue(OrientationProperty);
					}
					set{
						SetValue(OrientationProperty, value);
					}
				}
				
					
				partial void OnAfterItemsPropertyChanged(DependencyPropertyChangedEventArgs e);
				
				private static void OnItemsPropertyChangedCallback(object sender, DependencyPropertyChangedEventArgs e){
					AtomSplitView obj = sender as AtomSplitView;
					if(obj!=null){
						obj.OnItemsPropertyChanged(e);
					}
				}
				
				protected virtual void OnItemsPropertyChanged(DependencyPropertyChangedEventArgs e){
					OnAfterItemsPropertyChanged(e);
					
										if(ItemsChanged!=null){
						ItemsChanged(this,e);
					}
										
				}
				
								
								public event PropertyChangedCallback ItemsChanged;
								
				
#if SILVERLIGHT
				public static DependencyProperty ItemsProperty 
				= DependencyProperty.Register("Items",typeof(System.Collections.ObjectModel.ObservableCollection<UIElement>), typeof(AtomSplitView),
										new PropertyMetadata(default(System.Collections.ObjectModel.ObservableCollection<UIElement>),OnItemsPropertyChangedCallback));
										
				
#else
				public static DependencyProperty ItemsProperty 
				= DependencyProperty.Register("Items",typeof(System.Collections.ObjectModel.ObservableCollection<UIElement>), typeof(AtomSplitView),
										new FrameworkPropertyMetadata(default(System.Collections.ObjectModel.ObservableCollection<UIElement>),System.Windows.FrameworkPropertyMetadataOptions.None,OnItemsPropertyChangedCallback));
					#endif
					
				

				
				public System.Collections.ObjectModel.ObservableCollection<UIElement> Items
				{
					get{
						return (System.Collections.ObjectModel.ObservableCollection<UIElement>)GetValue(ItemsProperty);
					}
					set{
						SetValue(ItemsProperty, value);
					}
				}
				
					
			
			
			/// <summary>
			/// 
			/// </summary>
			public override void OnApplyTemplate()
			{
				base.OnApplyTemplate();
				
				
				OnAfterTemplateApplied();
				
			}			
			
			partial void OnAfterTemplateApplied();
			
			
		}
      }








