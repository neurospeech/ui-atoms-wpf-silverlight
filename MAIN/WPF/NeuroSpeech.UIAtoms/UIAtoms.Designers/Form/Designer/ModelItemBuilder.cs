
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Diagnostics;
using Microsoft.Windows.Design.Model;


namespace NeuroSpeech.UIAtoms.Designers.Form.Designer
{

		public partial class FormItemModel  : ItemHolder<ModelItem>, INotifyPropertyChanged{
		
	        public event PropertyChangedEventHandler PropertyChanged;
			
		
			public FormItemModel(ModelItem item, string prefix){
				this.Item = item;
				this.Prefix = prefix;
			}
			
			partial void OnPropertyChanged(PropertyChangedEventArgs e);
			
			partial void OnItemSet();
			
			protected override void OnItemSet(ModelItem oldItem,ModelItem newItem){
				if(oldItem!=null){
					oldItem.PropertyChanged -= item_PropertyChanged;
				}
				if(newItem!=null){
					newItem.PropertyChanged += item_PropertyChanged;
				}
				OnItemSet();
			}
		
			#region void  item_PropertyChanged(object sender, PropertyChangedEventArgs e)
			void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
			{
				string propertyName = e.PropertyName;
				//Trace.WriteLine(propertyName);
				
									
					if(propertyName.StartsWith("AtomForm.")){
						propertyName = propertyName.Substring(9);
					}
					
									
				OnPropertyChanged(e);
			
				if (PropertyChanged != null) {
					PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
				}
			}
			#endregion
			
			
			

				#region Property Label
				public string Label{
					get{
												string field = Prefix + "Label";
												ModelProperty v = Item.Properties[field];
						if(v.Value==null)
							return default(string);
						object objv = v.Value.GetCurrentValue();
						if(objv==null)
							return default(string);
						return (string)objv;
					}
					set{
												string field = Prefix + "Label";
												Item.Properties[field].SetValue(value);
					}
				}
				#endregion
				


				#region Property Description
				public string Description{
					get{
												string field = Prefix + "Description";
												ModelProperty v = Item.Properties[field];
						if(v.Value==null)
							return default(string);
						object objv = v.Value.GetCurrentValue();
						if(objv==null)
							return default(string);
						return (string)objv;
					}
					set{
												string field = Prefix + "Description";
												Item.Properties[field].SetValue(value);
					}
				}
				#endregion
				


				#region Property IsRequired
				public bool IsRequired{
					get{
												string field = Prefix + "IsRequired";
												ModelProperty v = Item.Properties[field];
						if(v.Value==null)
							return default(bool);
						object objv = v.Value.GetCurrentValue();
						if(objv==null)
							return default(bool);
						return (bool)objv;
					}
					set{
												string field = Prefix + "IsRequired";
												Item.Properties[field].SetValue(value);
					}
				}
				#endregion
				


				#region Property Title
				public string Title{
					get{
												string field = Prefix + "Title";
												ModelProperty v = Item.Properties[field];
						if(v.Value==null)
							return default(string);
						object objv = v.Value.GetCurrentValue();
						if(objv==null)
							return default(string);
						return (string)objv;
					}
					set{
												string field = Prefix + "Title";
												Item.Properties[field].SetValue(value);
					}
				}
				#endregion
				


				#region Property InvalidValueMessage
				public string InvalidValueMessage{
					get{
												string field = Prefix + "InvalidValueMessage";
												ModelProperty v = Item.Properties[field];
						if(v.Value==null)
							return default(string);
						object objv = v.Value.GetCurrentValue();
						if(objv==null)
							return default(string);
						return (string)objv;
					}
					set{
												string field = Prefix + "InvalidValueMessage";
												Item.Properties[field].SetValue(value);
					}
				}
				#endregion
				


				#region Property MissingValueMessage
				public string MissingValueMessage{
					get{
												string field = Prefix + "MissingValueMessage";
												ModelProperty v = Item.Properties[field];
						if(v.Value==null)
							return default(string);
						object objv = v.Value.GetCurrentValue();
						if(objv==null)
							return default(string);
						return (string)objv;
					}
					set{
												string field = Prefix + "MissingValueMessage";
												Item.Properties[field].SetValue(value);
					}
				}
				#endregion
				


				#region Property HorizontalAlignment
				public System.Windows.HorizontalAlignment HorizontalAlignment{
					get{
												string field = "HorizontalAlignment";
												ModelProperty v = Item.Properties[field];
						if(v.Value==null)
							return default(System.Windows.HorizontalAlignment);
						object objv = EnumValueConverter.ConvertTo(typeof(System.Windows.HorizontalAlignment),v.Value.GetCurrentValue());
						if(objv==null)
							return default(System.Windows.HorizontalAlignment);
						return (System.Windows.HorizontalAlignment)objv;
					}
					set{
												string field = "HorizontalAlignment";
												Item.Properties[field].SetValue(
							EnumValueConverter.ConvertTo(Item.Properties[field].PropertyType, value)
						);
					}
				}
				#endregion
				


				#region Property VerticalAlignment
				public System.Windows.VerticalAlignment VerticalAlignment{
					get{
												string field = "VerticalAlignment";
												ModelProperty v = Item.Properties[field];
						if(v.Value==null)
							return default(System.Windows.VerticalAlignment);
						object objv = EnumValueConverter.ConvertTo(typeof(System.Windows.VerticalAlignment),v.Value.GetCurrentValue());
						if(objv==null)
							return default(System.Windows.VerticalAlignment);
						return (System.Windows.VerticalAlignment)objv;
					}
					set{
												string field = "VerticalAlignment";
												Item.Properties[field].SetValue(
							EnumValueConverter.ConvertTo(Item.Properties[field].PropertyType, value)
						);
					}
				}
				#endregion
				


				#region Property Width
				public double Width{
					get{
												string field = "Width";
												ModelProperty v = Item.Properties[field];
						if(v.Value==null)
							return default(double);
						object objv = v.Value.GetCurrentValue();
						if(objv==null)
							return default(double);
						return (double)objv;
					}
					set{
												string field = "Width";
												Item.Properties[field].SetValue(value);
					}
				}
				#endregion
				
			
		}
		public partial class FormModel  : ItemHolder<ModelItem>, INotifyPropertyChanged{
		
	        public event PropertyChangedEventHandler PropertyChanged;
			
		
			public FormModel(ModelItem item, string prefix){
				this.Item = item;
				this.Prefix = prefix;
			}
			
			partial void OnPropertyChanged(PropertyChangedEventArgs e);
			
			partial void OnItemSet();
			
			protected override void OnItemSet(ModelItem oldItem,ModelItem newItem){
				if(oldItem!=null){
					oldItem.PropertyChanged -= item_PropertyChanged;
				}
				if(newItem!=null){
					newItem.PropertyChanged += item_PropertyChanged;
				}
				OnItemSet();
			}
		
			#region void  item_PropertyChanged(object sender, PropertyChangedEventArgs e)
			void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
			{
				string propertyName = e.PropertyName;
				//Trace.WriteLine(propertyName);
				
							
				OnPropertyChanged(e);
			
				if (PropertyChanged != null) {
					PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
				}
			}
			#endregion
			
			
			

				#region Property Header
				public string Header{
					get{
												string field = "Header";
												ModelProperty v = Item.Properties[field];
						if(v.Value==null)
							return default(string);
						object objv = v.Value.GetCurrentValue();
						if(objv==null)
							return default(string);
						return (string)objv;
					}
					set{
												string field = "Header";
												Item.Properties[field].SetValue(value);
					}
				}
				#endregion
				


				#region Property RowLayout
				public string RowLayout{
					get{
												string field = "RowLayout";
												ModelProperty v = Item.Properties[field];
						if(v.Value==null)
							return default(string);
						object objv = v.Value.GetCurrentValue();
						if(objv==null)
							return default(string);
						return (string)objv;
					}
					set{
												string field = "RowLayout";
												Item.Properties[field].SetValue(value);
					}
				}
				#endregion
				


				#region Property LabelWidth
				public double LabelWidth{
					get{
												string field = "LabelWidth";
												ModelProperty v = Item.Properties[field];
						if(v.Value==null)
							return default(double);
						object objv = v.Value.GetCurrentValue();
						if(objv==null)
							return default(double);
						return (double)objv;
					}
					set{
												string field = "LabelWidth";
												Item.Properties[field].SetValue(value);
					}
				}
				#endregion
				


				#region Property ActualHeight
				public double ActualHeight{
					get{
												string field = "ActualHeight";
												ModelProperty v = Item.Properties[field];
						if(v.Value==null)
							return default(double);
						object objv = v.Value.GetCurrentValue();
						if(objv==null)
							return default(double);
						return (double)objv;
					}
					set{
												string field = "ActualHeight";
												Item.Properties[field].SetValue(value);
					}
				}
				#endregion
				


				#region Property ActualWidth
				public double ActualWidth{
					get{
												string field = "ActualWidth";
												ModelProperty v = Item.Properties[field];
						if(v.Value==null)
							return default(double);
						object objv = v.Value.GetCurrentValue();
						if(objv==null)
							return default(double);
						return (double)objv;
					}
					set{
												string field = "ActualWidth";
												Item.Properties[field].SetValue(value);
					}
				}
				#endregion
				
			
		}

}

