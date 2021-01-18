

// This code was generated using T4 template with AtomControlSet, do not use this code for reference and formatting.

using System;

#if NETFX_CORE
	using Windows.UI.Xaml;
	using Windows.UI.Xaml.Markup;
	using Windows.UI.Xaml.Controls;	
#else
	using System;
	using System.Net;
	using System.Windows;
	using System.Windows.Controls;
	using System.Windows.Documents;
	using System.Windows.Ink;
	using System.Windows.Input;
	using System.Windows.Media;
	using System.Windows.Media.Animation;
	using System.Windows.Shapes;
#endif

using NeuroSpeech.UIAtoms.Core;

	namespace NeuroSpeech.UIAtoms.Controls{

	

					[TemplatePart(Name="selector",Type=typeof(Control))]
				public partial class AtomForm : Control {

			public AtomForm(){
									this.DefaultStyleKey = typeof(AtomForm);
							}

							protected Control selector;
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

									selector = GetTemplateChild("PART_Selector") as Control;
						if(selector == null)
							throw new InvalidOperationException("Part PART_Selector(Control) is not defined in template of AtomForm");
				
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

			
					}
	

				public partial class AtomButton : Button {

			public AtomButton(){
							}

			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

				
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

											#if NETFX_CORE || SILVERLIGHT
				public static DependencyProperty VerifyProperty = DependencyProperty.Register("Verify",typeof(bool),typeof(AtomButton), new PropertyMetadata(null));
				#else
				public static DependencyProperty VerifyProperty = DependencyProperty.Register("Verify",typeof(bool),typeof(AtomButton), new FrameworkPropertyMetadata(null));
				#endif
				
				public bool Verify{
					get{
						return (bool)GetValue(VerifyProperty);
					}
					set{
						SetValue(VerifyProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
				public static DependencyProperty VerificationMessageProperty = DependencyProperty.Register("VerificationMessage",typeof(string),typeof(AtomButton), new PropertyMetadata(null));
				#else
				public static DependencyProperty VerificationMessageProperty = DependencyProperty.Register("VerificationMessage",typeof(string),typeof(AtomButton), new FrameworkPropertyMetadata(null));
				#endif
				
				public string VerificationMessage{
					get{
						return (string)GetValue(VerificationMessageProperty);
					}
					set{
						SetValue(VerificationMessageProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
				public static DependencyProperty VerificationTitleProperty = DependencyProperty.Register("VerificationTitle",typeof(string),typeof(AtomButton), new PropertyMetadata(null));
				#else
				public static DependencyProperty VerificationTitleProperty = DependencyProperty.Register("VerificationTitle",typeof(string),typeof(AtomButton), new FrameworkPropertyMetadata(null));
				#endif
				
				public string VerificationTitle{
					get{
						return (string)GetValue(VerificationTitleProperty);
					}
					set{
						SetValue(VerificationTitleProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
				public static DependencyProperty ValidationRootElementProperty = DependencyProperty.Register("ValidationRootElement",typeof(string),typeof(AtomButton), new PropertyMetadata(null));
				#else
				public static DependencyProperty ValidationRootElementProperty = DependencyProperty.Register("ValidationRootElement",typeof(string),typeof(AtomButton), new FrameworkPropertyMetadata(null));
				#endif
				
				public string ValidationRootElement{
					get{
						return (string)GetValue(ValidationRootElementProperty);
					}
					set{
						SetValue(ValidationRootElementProperty,value);
					}
				}

			
					}
		}
