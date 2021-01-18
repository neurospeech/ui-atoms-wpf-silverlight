

// This code was generated using T4 template with AtomControlSet, do not use this code for reference and formatting.

using System;
using System.Collections.ObjectModel;

#if NETFX_CORE
	using Windows.UI.Xaml;
	using Windows.UI.Xaml.Markup;
	using Windows.UI.Xaml.Controls;	
#else
	using System.Net;
	using System.Windows;
	using System.Windows.Controls;
	using System.Windows.Controls.Primitives;
	using System.Windows.Documents;
	using System.Windows.Ink;
	using System.Windows.Input;
	using System.Windows.Media;
	using System.Windows.Media.Animation;
	using System.Windows.Shapes;
#endif


using NeuroSpeech.UIAtoms.Core;
using NeuroSpeech.UIAtoms.Validation;

	namespace NeuroSpeech.UIAtoms.Controls{

	

					[TemplatePart(Name="selector",Type=typeof(Control))]
				public partial class AtomForm : AtomFormContainer {

			
			public AtomForm(){
			
				#if NETFX_CORE || SILVERLIGHT
									this.DefaultStyleKey = typeof(AtomForm);
								#endif
				OnCreate();
			}
			
			static AtomForm(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								DefaultStyleKeyProperty.OverrideMetadata(
					typeof(AtomForm),
					new FrameworkPropertyMetadata(typeof(AtomForm)));
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
							protected Control selector;
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

									selector = GetTemplateChild("PART_Selector") as Control;
											if(selector == null)
							throw new InvalidOperationException("Part PART_Selector(Control) is not defined in template of AtomForm");
									
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty TabsProperty = DependencyProperty.Register("Tabs",typeof(System.Collections.IList),typeof(AtomForm), new PropertyMetadata(null));
				#else
				public static DependencyProperty TabsProperty = DependencyProperty.Register("Tabs",typeof(System.Collections.IList),typeof(AtomForm), new FrameworkPropertyMetadata(null));
								#endif
				
				public System.Collections.IList Tabs{
					get{
						return (System.Collections.IList)GetValue(TabsProperty);
					}
					set{
						SetValue(TabsProperty,value);
					}
				}

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty ValidationModeProperty = DependencyProperty.Register("ValidationMode",typeof(AtomFormValidationMode),typeof(AtomForm), new PropertyMetadata((AtomFormValidationMode)AtomFormValidationMode.OnLostFocus,OnValidationModeChanged));
					#else
					public static DependencyProperty ValidationModeProperty = DependencyProperty.Register("ValidationMode",typeof(AtomFormValidationMode),typeof(AtomForm), new FrameworkPropertyMetadata((AtomFormValidationMode)AtomFormValidationMode.OnLostFocus,OnValidationModeChanged));
					#endif

					private static void OnValidationModeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomForm)sender).OnValidationModeChanged(e);
					}

					protected virtual void OnValidationModeChanged(DependencyPropertyChangedEventArgs e){
																if(ValidationModeChanged!=null)
							ValidationModeChanged(this,e);
										}

															#if NETFX_CORE || SILVERLIGHT
						public event EventHandler<DependencyPropertyChangedEventArgs> ValidationModeChanged;
					#else
						public event DependencyPropertyChangedEventHandler ValidationModeChanged;
					#endif
					
				
				public AtomFormValidationMode ValidationMode{
					get{
						return (AtomFormValidationMode)GetValue(ValidationModeProperty);
					}
					set{
						SetValue(ValidationModeProperty,value);
					}
				}

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty DisplayErrorsProperty = DependencyProperty.Register("DisplayErrors",typeof(Boolean),typeof(AtomForm), new PropertyMetadata((bool)true,OnDisplayErrorsChanged));
					#else
					public static DependencyProperty DisplayErrorsProperty = DependencyProperty.Register("DisplayErrors",typeof(Boolean),typeof(AtomForm), new FrameworkPropertyMetadata((bool)true,OnDisplayErrorsChanged));
					#endif

					private static void OnDisplayErrorsChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomForm)sender).OnDisplayErrorsChanged(e);
					}

					protected virtual void OnDisplayErrorsChanged(DependencyPropertyChangedEventArgs e){
																if(DisplayErrorsChanged!=null)
							DisplayErrorsChanged(this,e);
										}

															#if NETFX_CORE || SILVERLIGHT
						public event EventHandler<DependencyPropertyChangedEventArgs> DisplayErrorsChanged;
					#else
						public event DependencyPropertyChangedEventHandler DisplayErrorsChanged;
					#endif
					
				
				public Boolean DisplayErrors{
					get{
						return (Boolean)GetValue(DisplayErrorsProperty);
					}
					set{
						SetValue(DisplayErrorsProperty,value);
					}
				}

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty HasErrorsProperty = DependencyProperty.Register("HasErrors",typeof(Boolean),typeof(AtomForm), new PropertyMetadata((bool)false,OnHasErrorsChanged));
					#else
					public static DependencyProperty HasErrorsProperty = DependencyProperty.Register("HasErrors",typeof(Boolean),typeof(AtomForm), new FrameworkPropertyMetadata((bool)false,OnHasErrorsChanged));
					#endif

					private static void OnHasErrorsChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomForm)sender).OnHasErrorsChanged(e);
					}

					protected virtual void OnHasErrorsChanged(DependencyPropertyChangedEventArgs e){
											OnAfterHasErrorsChanged(e);
															}

										partial void OnAfterHasErrorsChanged(DependencyPropertyChangedEventArgs e);
										
				
				public Boolean HasErrors{
					get{
						return (Boolean)GetValue(HasErrorsProperty);
					}
					set{
						SetValue(HasErrorsProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty AutoGenerateFieldsProperty = DependencyProperty.Register("AutoGenerateFields",typeof(Boolean),typeof(AtomForm), new PropertyMetadata((bool)false));
				#else
				public static DependencyProperty AutoGenerateFieldsProperty = DependencyProperty.Register("AutoGenerateFields",typeof(Boolean),typeof(AtomForm), new FrameworkPropertyMetadata((bool)false));
								#endif
				
				public Boolean AutoGenerateFields{
					get{
						return (Boolean)GetValue(AutoGenerateFieldsProperty);
					}
					set{
						SetValue(AutoGenerateFieldsProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty ErrorTitleProperty = DependencyProperty.Register("ErrorTitle",typeof(String),typeof(AtomForm), new PropertyMetadata("Errors"));
				#else
				public static DependencyProperty ErrorTitleProperty = DependencyProperty.Register("ErrorTitle",typeof(String),typeof(AtomForm), new FrameworkPropertyMetadata("Errors"));
								#endif
				
				public String ErrorTitle{
					get{
						return (String)GetValue(ErrorTitleProperty);
					}
					set{
						SetValue(ErrorTitleProperty,value);
					}
				}

			
											#if NETFX_CORE || SILVERLIGHT
				public static DependencyProperty MissingValueMessageProperty = DependencyProperty.RegisterAttached("MissingValueMessage",typeof(String),typeof(AtomForm), new PropertyMetadata("Field is required"));
				#else
				public static DependencyProperty MissingValueMessageProperty = DependencyProperty.RegisterAttached("MissingValueMessage",typeof(String),typeof(AtomForm), new FrameworkPropertyMetadata("Field is required"));
				#endif
				
				public static String GetMissingValueMessage(DependencyObject owner){
					return 	(String)owner.GetValue(MissingValueMessageProperty);
				}
				public static void SetMissingValueMessage(DependencyObject owner, String value){
					owner.SetValue(MissingValueMessageProperty,value);
				}
											#if NETFX_CORE || SILVERLIGHT
				public static DependencyProperty InvalidValueMessageProperty = DependencyProperty.RegisterAttached("InvalidValueMessage",typeof(String),typeof(AtomForm), new PropertyMetadata("Value is Invalid"));
				#else
				public static DependencyProperty InvalidValueMessageProperty = DependencyProperty.RegisterAttached("InvalidValueMessage",typeof(String),typeof(AtomForm), new FrameworkPropertyMetadata("Value is Invalid"));
				#endif
				
				public static String GetInvalidValueMessage(DependencyObject owner){
					return 	(String)owner.GetValue(InvalidValueMessageProperty);
				}
				public static void SetInvalidValueMessage(DependencyObject owner, String value){
					owner.SetValue(InvalidValueMessageProperty,value);
				}
												
					#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty AtomValidatorProperty = DependencyProperty.RegisterAttached("AtomValidator",typeof(AtomPropertyValidator),typeof(AtomForm), new PropertyMetadata(null,OnAtomValidatorChanged));
					#else
					public static DependencyProperty AtomValidatorProperty = DependencyProperty.RegisterAttached("AtomValidator",typeof(AtomPropertyValidator),typeof(AtomForm), new FrameworkPropertyMetadata(null,OnAtomValidatorChanged));
					#endif

					private static void OnAtomValidatorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						OnAfterAtomValidatorChanged(sender, e);
					}

										static partial void OnAfterAtomValidatorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e);
					

				
				public static AtomPropertyValidator GetAtomValidator(DependencyObject owner){
					return 	(AtomPropertyValidator)owner.GetValue(AtomValidatorProperty);
				}
				public static void SetAtomValidator(DependencyObject owner, AtomPropertyValidator value){
					owner.SetValue(AtomValidatorProperty,value);
				}
											#if NETFX_CORE || SILVERLIGHT
				public static DependencyProperty LabelProperty = DependencyProperty.RegisterAttached("Label",typeof(Object),typeof(AtomForm), new PropertyMetadata(null));
				#else
				public static DependencyProperty LabelProperty = DependencyProperty.RegisterAttached("Label",typeof(Object),typeof(AtomForm), new FrameworkPropertyMetadata(null));
				#endif
				
				public static Object GetLabel(DependencyObject owner){
					return 	(Object)owner.GetValue(LabelProperty);
				}
				public static void SetLabel(DependencyObject owner, Object value){
					owner.SetValue(LabelProperty,value);
				}
											#if NETFX_CORE || SILVERLIGHT
				public static DependencyProperty TitleProperty = DependencyProperty.RegisterAttached("Title",typeof(String),typeof(AtomForm), new PropertyMetadata(null));
				#else
				public static DependencyProperty TitleProperty = DependencyProperty.RegisterAttached("Title",typeof(String),typeof(AtomForm), new FrameworkPropertyMetadata(null));
				#endif
				
				public static String GetTitle(DependencyObject owner){
					return 	(String)owner.GetValue(TitleProperty);
				}
				public static void SetTitle(DependencyObject owner, String value){
					owner.SetValue(TitleProperty,value);
				}
											#if NETFX_CORE || SILVERLIGHT
				public static DependencyProperty DescriptionProperty = DependencyProperty.RegisterAttached("Description",typeof(Object),typeof(AtomForm), new PropertyMetadata(null));
				#else
				public static DependencyProperty DescriptionProperty = DependencyProperty.RegisterAttached("Description",typeof(Object),typeof(AtomForm), new FrameworkPropertyMetadata(null));
				#endif
				
				public static Object GetDescription(DependencyObject owner){
					return 	(Object)owner.GetValue(DescriptionProperty);
				}
				public static void SetDescription(DependencyObject owner, Object value){
					owner.SetValue(DescriptionProperty,value);
				}
											#if NETFX_CORE || SILVERLIGHT
				public static DependencyProperty IsRequiredProperty = DependencyProperty.RegisterAttached("IsRequired",typeof(Boolean),typeof(AtomForm), new PropertyMetadata((bool)false));
				#else
				public static DependencyProperty IsRequiredProperty = DependencyProperty.RegisterAttached("IsRequired",typeof(Boolean),typeof(AtomForm), new FrameworkPropertyMetadata((bool)false));
				#endif
				
				public static Boolean GetIsRequired(DependencyObject owner){
					return 	(Boolean)owner.GetValue(IsRequiredProperty);
				}
				public static void SetIsRequired(DependencyObject owner, Boolean value){
					owner.SetValue(IsRequiredProperty,value);
				}
											#if NETFX_CORE || SILVERLIGHT
				public static DependencyProperty HasErrorProperty = DependencyProperty.RegisterAttached("HasError",typeof(Boolean),typeof(AtomForm), new PropertyMetadata((bool)false));
				#else
				public static DependencyProperty HasErrorProperty = DependencyProperty.RegisterAttached("HasError",typeof(Boolean),typeof(AtomForm), new FrameworkPropertyMetadata((bool)false));
				#endif
				
				public static Boolean GetHasError(DependencyObject owner){
					return 	(Boolean)owner.GetValue(HasErrorProperty);
				}
				public static void SetHasError(DependencyObject owner, Boolean value){
					owner.SetValue(HasErrorProperty,value);
				}
											#if NETFX_CORE || SILVERLIGHT
				public static DependencyProperty ErrorMessageProperty = DependencyProperty.RegisterAttached("ErrorMessage",typeof(String),typeof(AtomForm), new PropertyMetadata(null));
				#else
				public static DependencyProperty ErrorMessageProperty = DependencyProperty.RegisterAttached("ErrorMessage",typeof(String),typeof(AtomForm), new FrameworkPropertyMetadata(null));
				#endif
				
				public static String GetErrorMessage(DependencyObject owner){
					return 	(String)owner.GetValue(ErrorMessageProperty);
				}
				public static void SetErrorMessage(DependencyObject owner, String value){
					owner.SetValue(ErrorMessageProperty,value);
				}
											#if NETFX_CORE || SILVERLIGHT
				public static DependencyProperty ValidationPropertyProperty = DependencyProperty.RegisterAttached("ValidationProperty",typeof(String),typeof(AtomForm), new PropertyMetadata(null));
				#else
				public static DependencyProperty ValidationPropertyProperty = DependencyProperty.RegisterAttached("ValidationProperty",typeof(String),typeof(AtomForm), new FrameworkPropertyMetadata(null));
				#endif
				
				public static String GetValidationProperty(DependencyObject owner){
					return 	(String)owner.GetValue(ValidationPropertyProperty);
				}
				public static void SetValidationProperty(DependencyObject owner, String value){
					owner.SetValue(ValidationPropertyProperty,value);
				}
											#if NETFX_CORE || SILVERLIGHT
				public static DependencyProperty ValidationRuleProperty = DependencyProperty.RegisterAttached("ValidationRule",typeof(AtomValidationRule),typeof(AtomForm), new PropertyMetadata(null));
				#else
				public static DependencyProperty ValidationRuleProperty = DependencyProperty.RegisterAttached("ValidationRule",typeof(AtomValidationRule),typeof(AtomForm), new FrameworkPropertyMetadata(null));
				#endif
				
				public static AtomValidationRule GetValidationRule(DependencyObject owner){
					return 	(AtomValidationRule)owner.GetValue(ValidationRuleProperty);
				}
				public static void SetValidationRule(DependencyObject owner, AtomValidationRule value){
					owner.SetValue(ValidationRuleProperty,value);
				}
												
					#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty ValidationErrorProperty = DependencyProperty.RegisterAttached("ValidationError",typeof(AtomValidationError),typeof(AtomForm), new PropertyMetadata(null,OnValidationErrorChanged));
					#else
					public static DependencyProperty ValidationErrorProperty = DependencyProperty.RegisterAttached("ValidationError",typeof(AtomValidationError),typeof(AtomForm), new FrameworkPropertyMetadata(null,OnValidationErrorChanged));
					#endif

					private static void OnValidationErrorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						OnAfterValidationErrorChanged(sender, e);
					}

										static partial void OnAfterValidationErrorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e);
					

				
				public static AtomValidationError GetValidationError(DependencyObject owner){
					return 	(AtomValidationError)owner.GetValue(ValidationErrorProperty);
				}
				public static void SetValidationError(DependencyObject owner, AtomValidationError value){
					owner.SetValue(ValidationErrorProperty,value);
				}
											#if NETFX_CORE || SILVERLIGHT
				public static DependencyProperty ShowLabelProperty = DependencyProperty.RegisterAttached("ShowLabel",typeof(Boolean),typeof(AtomForm), new PropertyMetadata((bool)true));
				#else
				public static DependencyProperty ShowLabelProperty = DependencyProperty.RegisterAttached("ShowLabel",typeof(Boolean),typeof(AtomForm), new FrameworkPropertyMetadata((bool)true));
				#endif
				
				public static Boolean GetShowLabel(DependencyObject owner){
					return 	(Boolean)owner.GetValue(ShowLabelProperty);
				}
				public static void SetShowLabel(DependencyObject owner, Boolean value){
					owner.SetValue(ShowLabelProperty,value);
				}
											#if NETFX_CORE || SILVERLIGHT
				public static DependencyProperty CommandBoxProperty = DependencyProperty.RegisterAttached("CommandBox",typeof(Object),typeof(AtomForm), new PropertyMetadata(null));
				#else
				public static DependencyProperty CommandBoxProperty = DependencyProperty.RegisterAttached("CommandBox",typeof(Object),typeof(AtomForm), new FrameworkPropertyMetadata(null));
				#endif
				
				public static Object GetCommandBox(DependencyObject owner){
					return 	(Object)owner.GetValue(CommandBoxProperty);
				}
				public static void SetCommandBox(DependencyObject owner, Object value){
					owner.SetValue(CommandBoxProperty,value);
				}
					}
	

				public partial class AtomButton : Button {

			
			public AtomButton(){
			
				#if NETFX_CORE || SILVERLIGHT
								#endif
				OnCreate();
			}
			
			static AtomButton(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

				
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty VerifyProperty = DependencyProperty.Register("Verify",typeof(Boolean),typeof(AtomButton), new PropertyMetadata((bool)false));
				#else
				public static DependencyProperty VerifyProperty = DependencyProperty.Register("Verify",typeof(Boolean),typeof(AtomButton), new FrameworkPropertyMetadata((bool)false));
								#endif
				
				public Boolean Verify{
					get{
						return (Boolean)GetValue(VerifyProperty);
					}
					set{
						SetValue(VerifyProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty VerificationMessageProperty = DependencyProperty.Register("VerificationMessage",typeof(String),typeof(AtomButton), new PropertyMetadata("Are you sure?"));
				#else
				public static DependencyProperty VerificationMessageProperty = DependencyProperty.Register("VerificationMessage",typeof(String),typeof(AtomButton), new FrameworkPropertyMetadata("Are you sure?"));
								#endif
				
				public String VerificationMessage{
					get{
						return (String)GetValue(VerificationMessageProperty);
					}
					set{
						SetValue(VerificationMessageProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty VerificationTitleProperty = DependencyProperty.Register("VerificationTitle",typeof(String),typeof(AtomButton), new PropertyMetadata("Confirmation"));
				#else
				public static DependencyProperty VerificationTitleProperty = DependencyProperty.Register("VerificationTitle",typeof(String),typeof(AtomButton), new FrameworkPropertyMetadata("Confirmation"));
								#endif
				
				public String VerificationTitle{
					get{
						return (String)GetValue(VerificationTitleProperty);
					}
					set{
						SetValue(VerificationTitleProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty ValidationRootElementProperty = DependencyProperty.Register("ValidationRootElement",typeof(Object),typeof(AtomButton), new PropertyMetadata(null));
				#else
				public static DependencyProperty ValidationRootElementProperty = DependencyProperty.Register("ValidationRootElement",typeof(Object),typeof(AtomButton), new FrameworkPropertyMetadata(null));
								#endif
				
				public Object ValidationRootElement{
					get{
						return (Object)GetValue(ValidationRootElementProperty);
					}
					set{
						SetValue(ValidationRootElementProperty,value);
					}
				}

			
					}
	

				public partial class AtomCalculator : Control {

			
			public AtomCalculator(){
			
				#if NETFX_CORE || SILVERLIGHT
									this.DefaultStyleKey = typeof(AtomCalculator);
								#endif
				OnCreate();
			}
			
			static AtomCalculator(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								DefaultStyleKeyProperty.OverrideMetadata(
					typeof(AtomCalculator),
					new FrameworkPropertyMetadata(typeof(AtomCalculator)));
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

				
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty ValueProperty = DependencyProperty.Register("Value",typeof(Decimal),typeof(AtomCalculator), new PropertyMetadata((Decimal)0,OnValueChanged));
					#else
					public static DependencyProperty ValueProperty = DependencyProperty.Register("Value",typeof(Decimal),typeof(AtomCalculator), new FrameworkPropertyMetadata((Decimal)0,OnValueChanged));
					#endif

					private static void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomCalculator)sender).OnValueChanged(e);
					}

					protected virtual void OnValueChanged(DependencyPropertyChangedEventArgs e){
											OnAfterValueChanged(e);
																if(ValueChanged!=null)
							ValueChanged(this,e);
										}

										partial void OnAfterValueChanged(DependencyPropertyChangedEventArgs e);
															#if NETFX_CORE || SILVERLIGHT
						public event EventHandler<DependencyPropertyChangedEventArgs> ValueChanged;
					#else
						public event DependencyPropertyChangedEventHandler ValueChanged;
					#endif
					
				
				public Decimal Value{
					get{
						return (Decimal)GetValue(ValueProperty);
					}
					set{
						SetValue(ValueProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty ExpressionHistoryProperty = DependencyProperty.Register("ExpressionHistory",typeof(String),typeof(AtomCalculator), new PropertyMetadata(""));
				#else
				public static DependencyProperty ExpressionHistoryProperty = DependencyProperty.Register("ExpressionHistory",typeof(String),typeof(AtomCalculator), new FrameworkPropertyMetadata(""));
								#endif
				
				public String ExpressionHistory{
					get{
						return (String)GetValue(ExpressionHistoryProperty);
					}
					set{
						SetValue(ExpressionHistoryProperty,value);
					}
				}

			
					}
	

				public partial class AtomListBox : ListBox {

			
			public AtomListBox(){
			
				#if NETFX_CORE || SILVERLIGHT
									this.DefaultStyleKey = typeof(AtomListBox);
								#endif
				OnCreate();
			}
			
			static AtomListBox(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								DefaultStyleKeyProperty.OverrideMetadata(
					typeof(AtomListBox),
					new FrameworkPropertyMetadata(typeof(AtomListBox)));
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

				
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty IsFilterVisibleProperty = DependencyProperty.Register("IsFilterVisible",typeof(Boolean),typeof(AtomListBox), new PropertyMetadata((bool)false));
				#else
				public static DependencyProperty IsFilterVisibleProperty = DependencyProperty.Register("IsFilterVisible",typeof(Boolean),typeof(AtomListBox), new FrameworkPropertyMetadata((bool)false));
								#endif
				
				public Boolean IsFilterVisible{
					get{
						return (Boolean)GetValue(IsFilterVisibleProperty);
					}
					set{
						SetValue(IsFilterVisibleProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty FilterTextProperty = DependencyProperty.Register("FilterText",typeof(String),typeof(AtomListBox), new PropertyMetadata(""));
				#else
				public static DependencyProperty FilterTextProperty = DependencyProperty.Register("FilterText",typeof(String),typeof(AtomListBox), new FrameworkPropertyMetadata(""));
								#endif
				
				public String FilterText{
					get{
						return (String)GetValue(FilterTextProperty);
					}
					set{
						SetValue(FilterTextProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty FilterModeProperty = AtomFilterTextBox.FilterModeProperty;
				#else
				public static DependencyProperty FilterModeProperty = AtomFilterTextBox.FilterModeProperty.AddOwner(typeof(AtomListBox));
								#endif
				
				public AtomTextFilterMode FilterMode{
					get{
						return (AtomTextFilterMode)GetValue(FilterModeProperty);
					}
					set{
						SetValue(FilterModeProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty FilterComparisonProperty = AtomFilterTextBox.FilterComparisonProperty;
				#else
				public static DependencyProperty FilterComparisonProperty = AtomFilterTextBox.FilterComparisonProperty.AddOwner(typeof(AtomListBox));
								#endif
				
				public StringComparison FilterComparison{
					get{
						return (StringComparison)GetValue(FilterComparisonProperty);
					}
					set{
						SetValue(FilterComparisonProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty FilterProviderParameterProperty = AtomFilterTextBox.FilterProviderParameterProperty;
				#else
				public static DependencyProperty FilterProviderParameterProperty = AtomFilterTextBox.FilterProviderParameterProperty.AddOwner(typeof(AtomListBox));
								#endif
				
				public Object FilterProviderParameter{
					get{
						return (Object)GetValue(FilterProviderParameterProperty);
					}
					set{
						SetValue(FilterProviderParameterProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty FilterProviderProperty = AtomFilterTextBox.FilterProviderProperty;
				#else
				public static DependencyProperty FilterProviderProperty = AtomFilterTextBox.FilterProviderProperty.AddOwner(typeof(AtomListBox));
								#endif
				
				public IAtomItemsFilter FilterProvider{
					get{
						return (IAtomItemsFilter)GetValue(FilterProviderProperty);
					}
					set{
						SetValue(FilterProviderProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty InvalidIndicesProperty = AtomSelectionValidationRule.InvalidIndicesProperty;
				#else
				public static DependencyProperty InvalidIndicesProperty = AtomSelectionValidationRule.InvalidIndicesProperty.AddOwner(typeof(AtomListBox));
								#endif
				
				public Int32[] InvalidIndices{
					get{
						return (Int32[])GetValue(InvalidIndicesProperty);
					}
					set{
						SetValue(InvalidIndicesProperty,value);
					}
				}

			
					}
	

				public partial class AtomTextBox : TextBox {

			
			public AtomTextBox(){
			
				#if NETFX_CORE || SILVERLIGHT
									this.DefaultStyleKey = typeof(AtomTextBox);
								#endif
				OnCreate();
			}
			
			static AtomTextBox(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								DefaultStyleKeyProperty.OverrideMetadata(
					typeof(AtomTextBox),
					new FrameworkPropertyMetadata(typeof(AtomTextBox)));
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

				
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty HasTextProperty = DependencyProperty.Register("HasText",typeof(Boolean),typeof(AtomTextBox), new PropertyMetadata((bool)false));
				#else
				public static DependencyProperty HasTextProperty = DependencyProperty.Register("HasText",typeof(Boolean),typeof(AtomTextBox), new FrameworkPropertyMetadata((bool)false));
								#endif
				
				public Boolean HasText{
					get{
						return (Boolean)GetValue(HasTextProperty);
					}
					set{
						SetValue(HasTextProperty,value);
					}
				}

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty WatermarkTextProperty = DependencyProperty.Register("WatermarkText",typeof(String),typeof(AtomTextBox), new PropertyMetadata(null,OnWatermarkTextChanged));
					#else
					public static DependencyProperty WatermarkTextProperty = DependencyProperty.Register("WatermarkText",typeof(String),typeof(AtomTextBox), new FrameworkPropertyMetadata(null,OnWatermarkTextChanged));
					#endif

					private static void OnWatermarkTextChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomTextBox)sender).OnWatermarkTextChanged(e);
					}

					protected virtual void OnWatermarkTextChanged(DependencyPropertyChangedEventArgs e){
											OnAfterWatermarkTextChanged(e);
																if(WatermarkTextChanged!=null)
							WatermarkTextChanged(this,e);
										}

										partial void OnAfterWatermarkTextChanged(DependencyPropertyChangedEventArgs e);
															#if NETFX_CORE || SILVERLIGHT
						public event EventHandler<DependencyPropertyChangedEventArgs> WatermarkTextChanged;
					#else
						public event DependencyPropertyChangedEventHandler WatermarkTextChanged;
					#endif
					
				
				public String WatermarkText{
					get{
						return (String)GetValue(WatermarkTextProperty);
					}
					set{
						SetValue(WatermarkTextProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty WatermarkColorProperty = DependencyProperty.Register("WatermarkColor",typeof(Brush),typeof(AtomTextBox), new PropertyMetadata(Brushes.LightGray));
				#else
				public static DependencyProperty WatermarkColorProperty = DependencyProperty.Register("WatermarkColor",typeof(Brush),typeof(AtomTextBox), new FrameworkPropertyMetadata(Brushes.LightGray));
								#endif
				
				public Brush WatermarkColor{
					get{
						return (Brush)GetValue(WatermarkColorProperty);
					}
					set{
						SetValue(WatermarkColorProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty WatermarkAlignProperty = DependencyProperty.Register("WatermarkAlign",typeof(HorizontalAlignment),typeof(AtomTextBox), new PropertyMetadata((HorizontalAlignment)HorizontalAlignment.Left));
				#else
				public static DependencyProperty WatermarkAlignProperty = DependencyProperty.Register("WatermarkAlign",typeof(HorizontalAlignment),typeof(AtomTextBox), new FrameworkPropertyMetadata((HorizontalAlignment)HorizontalAlignment.Left));
								#endif
				
				public HorizontalAlignment WatermarkAlign{
					get{
						return (HorizontalAlignment)GetValue(WatermarkAlignProperty);
					}
					set{
						SetValue(WatermarkAlignProperty,value);
					}
				}

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty FormattedTextProperty = DependencyProperty.Register("FormattedText",typeof(String),typeof(AtomTextBox), new PropertyMetadata(null,OnFormattedTextChanged));
					#else
					public static DependencyProperty FormattedTextProperty = DependencyProperty.Register("FormattedText",typeof(String),typeof(AtomTextBox), new FrameworkPropertyMetadata(null,OnFormattedTextChanged));
					#endif

					private static void OnFormattedTextChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomTextBox)sender).OnFormattedTextChanged(e);
					}

					protected virtual void OnFormattedTextChanged(DependencyPropertyChangedEventArgs e){
											OnAfterFormattedTextChanged(e);
																if(FormattedTextChanged!=null)
							FormattedTextChanged(this,e);
										}

										partial void OnAfterFormattedTextChanged(DependencyPropertyChangedEventArgs e);
															#if NETFX_CORE || SILVERLIGHT
						public event EventHandler<DependencyPropertyChangedEventArgs> FormattedTextChanged;
					#else
						public event DependencyPropertyChangedEventHandler FormattedTextChanged;
					#endif
					
				
				public String FormattedText{
					get{
						return (String)GetValue(FormattedTextProperty);
					}
					set{
						SetValue(FormattedTextProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty HasFormattedTextProperty = DependencyProperty.Register("HasFormattedText",typeof(Boolean),typeof(AtomTextBox), new PropertyMetadata((bool)false));
				#else
				public static DependencyProperty HasFormattedTextProperty = DependencyProperty.Register("HasFormattedText",typeof(Boolean),typeof(AtomTextBox), new FrameworkPropertyMetadata((bool)false));
								#endif
				
				public Boolean HasFormattedText{
					get{
						return (Boolean)GetValue(HasFormattedTextProperty);
					}
					set{
						SetValue(HasFormattedTextProperty,value);
					}
				}

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty MinimumLengthProperty = DependencyProperty.Register("MinimumLength",typeof(Int32),typeof(AtomTextBox), new PropertyMetadata((int)0,OnMinimumLengthChanged));
					#else
					public static DependencyProperty MinimumLengthProperty = DependencyProperty.Register("MinimumLength",typeof(Int32),typeof(AtomTextBox), new FrameworkPropertyMetadata((int)0,OnMinimumLengthChanged));
					#endif

					private static void OnMinimumLengthChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomTextBox)sender).OnMinimumLengthChanged(e);
					}

					protected virtual void OnMinimumLengthChanged(DependencyPropertyChangedEventArgs e){
																if(MinimumLengthChanged!=null)
							MinimumLengthChanged(this,e);
										}

															#if NETFX_CORE || SILVERLIGHT
						public event EventHandler<DependencyPropertyChangedEventArgs> MinimumLengthChanged;
					#else
						public event DependencyPropertyChangedEventHandler MinimumLengthChanged;
					#endif
					
				
				public Int32 MinimumLength{
					get{
						return (Int32)GetValue(MinimumLengthProperty);
					}
					set{
						SetValue(MinimumLengthProperty,value);
					}
				}

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty MinimumLengthErrorMessageProperty = DependencyProperty.Register("MinimumLengthErrorMessage",typeof(String),typeof(AtomTextBox), new PropertyMetadata("Text should have more then {0} characters",OnMinimumLengthErrorMessageChanged));
					#else
					public static DependencyProperty MinimumLengthErrorMessageProperty = DependencyProperty.Register("MinimumLengthErrorMessage",typeof(String),typeof(AtomTextBox), new FrameworkPropertyMetadata("Text should have more then {0} characters",OnMinimumLengthErrorMessageChanged));
					#endif

					private static void OnMinimumLengthErrorMessageChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomTextBox)sender).OnMinimumLengthErrorMessageChanged(e);
					}

					protected virtual void OnMinimumLengthErrorMessageChanged(DependencyPropertyChangedEventArgs e){
																if(MinimumLengthErrorMessageChanged!=null)
							MinimumLengthErrorMessageChanged(this,e);
										}

															#if NETFX_CORE || SILVERLIGHT
						public event EventHandler<DependencyPropertyChangedEventArgs> MinimumLengthErrorMessageChanged;
					#else
						public event DependencyPropertyChangedEventHandler MinimumLengthErrorMessageChanged;
					#endif
					
				
				public String MinimumLengthErrorMessage{
					get{
						return (String)GetValue(MinimumLengthErrorMessageProperty);
					}
					set{
						SetValue(MinimumLengthErrorMessageProperty,value);
					}
				}

			
					}
	

					[TemplatePart(Name="PART_DeleteButton",Type=typeof(Button))]
				public partial class AtomFilterTextBox : AtomTextBox {

			
			public AtomFilterTextBox(){
			
				#if NETFX_CORE || SILVERLIGHT
									this.DefaultStyleKey = typeof(AtomFilterTextBox);
								#endif
				OnCreate();
			}
			
			static AtomFilterTextBox(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								DefaultStyleKeyProperty.OverrideMetadata(
					typeof(AtomFilterTextBox),
					new FrameworkPropertyMetadata(typeof(AtomFilterTextBox)));
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
							protected Button PART_DeleteButton;
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

									PART_DeleteButton = GetTemplateChild("PART_DeleteButton") as Button;
									
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty ItemsControlProperty = DependencyProperty.Register("ItemsControl",typeof(ItemsControl),typeof(AtomFilterTextBox), new PropertyMetadata(null,OnItemsControlChanged));
					#else
					public static DependencyProperty ItemsControlProperty = DependencyProperty.Register("ItemsControl",typeof(ItemsControl),typeof(AtomFilterTextBox), new FrameworkPropertyMetadata(null,OnItemsControlChanged));
					#endif

					private static void OnItemsControlChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomFilterTextBox)sender).OnItemsControlChanged(e);
					}

					protected virtual void OnItemsControlChanged(DependencyPropertyChangedEventArgs e){
											OnAfterItemsControlChanged(e);
																if(ItemsControlChanged!=null)
							ItemsControlChanged(this,e);
										}

										partial void OnAfterItemsControlChanged(DependencyPropertyChangedEventArgs e);
															#if NETFX_CORE || SILVERLIGHT
						public event EventHandler<DependencyPropertyChangedEventArgs> ItemsControlChanged;
					#else
						public event DependencyPropertyChangedEventHandler ItemsControlChanged;
					#endif
					
				
				public ItemsControl ItemsControl{
					get{
						return (ItemsControl)GetValue(ItemsControlProperty);
					}
					set{
						SetValue(ItemsControlProperty,value);
					}
				}

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty FilterModeProperty = DependencyProperty.Register("FilterMode",typeof(AtomTextFilterMode),typeof(AtomFilterTextBox), new PropertyMetadata((AtomTextFilterMode)AtomTextFilterMode.StartsWith,OnFilterModeChanged));
					#else
					public static DependencyProperty FilterModeProperty = DependencyProperty.Register("FilterMode",typeof(AtomTextFilterMode),typeof(AtomFilterTextBox), new FrameworkPropertyMetadata((AtomTextFilterMode)AtomTextFilterMode.StartsWith,OnFilterModeChanged));
					#endif

					private static void OnFilterModeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomFilterTextBox)sender).OnFilterModeChanged(e);
					}

					protected virtual void OnFilterModeChanged(DependencyPropertyChangedEventArgs e){
											OnAfterFilterModeChanged(e);
																if(FilterModeChanged!=null)
							FilterModeChanged(this,e);
										}

										partial void OnAfterFilterModeChanged(DependencyPropertyChangedEventArgs e);
															#if NETFX_CORE || SILVERLIGHT
						public event EventHandler<DependencyPropertyChangedEventArgs> FilterModeChanged;
					#else
						public event DependencyPropertyChangedEventHandler FilterModeChanged;
					#endif
					
				
				public AtomTextFilterMode FilterMode{
					get{
						return (AtomTextFilterMode)GetValue(FilterModeProperty);
					}
					set{
						SetValue(FilterModeProperty,value);
					}
				}

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty FilterComparisonProperty = DependencyProperty.Register("FilterComparison",typeof(StringComparison),typeof(AtomFilterTextBox), new PropertyMetadata((StringComparison)StringComparison.CurrentCultureIgnoreCase,OnFilterComparisonChanged));
					#else
					public static DependencyProperty FilterComparisonProperty = DependencyProperty.Register("FilterComparison",typeof(StringComparison),typeof(AtomFilterTextBox), new FrameworkPropertyMetadata((StringComparison)StringComparison.CurrentCultureIgnoreCase,OnFilterComparisonChanged));
					#endif

					private static void OnFilterComparisonChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomFilterTextBox)sender).OnFilterComparisonChanged(e);
					}

					protected virtual void OnFilterComparisonChanged(DependencyPropertyChangedEventArgs e){
											OnAfterFilterComparisonChanged(e);
																if(FilterComparisonChanged!=null)
							FilterComparisonChanged(this,e);
										}

										partial void OnAfterFilterComparisonChanged(DependencyPropertyChangedEventArgs e);
															#if NETFX_CORE || SILVERLIGHT
						public event EventHandler<DependencyPropertyChangedEventArgs> FilterComparisonChanged;
					#else
						public event DependencyPropertyChangedEventHandler FilterComparisonChanged;
					#endif
					
				
				public StringComparison FilterComparison{
					get{
						return (StringComparison)GetValue(FilterComparisonProperty);
					}
					set{
						SetValue(FilterComparisonProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty FilterProviderProperty = DependencyProperty.Register("FilterProvider",typeof(IAtomItemsFilter),typeof(AtomFilterTextBox), new PropertyMetadata(null));
				#else
				public static DependencyProperty FilterProviderProperty = DependencyProperty.Register("FilterProvider",typeof(IAtomItemsFilter),typeof(AtomFilterTextBox), new FrameworkPropertyMetadata(null));
								#endif
				
				public IAtomItemsFilter FilterProvider{
					get{
						return (IAtomItemsFilter)GetValue(FilterProviderProperty);
					}
					set{
						SetValue(FilterProviderProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty FilterProviderParameterProperty = DependencyProperty.Register("FilterProviderParameter",typeof(Object),typeof(AtomFilterTextBox), new PropertyMetadata(null));
				#else
				public static DependencyProperty FilterProviderParameterProperty = DependencyProperty.Register("FilterProviderParameter",typeof(Object),typeof(AtomFilterTextBox), new FrameworkPropertyMetadata(null));
								#endif
				
				public Object FilterProviderParameter{
					get{
						return (Object)GetValue(FilterProviderParameterProperty);
					}
					set{
						SetValue(FilterProviderParameterProperty,value);
					}
				}

			
					}
	

				public partial class AtomImageButton : AtomButton {

			
			public AtomImageButton(){
			
				#if NETFX_CORE || SILVERLIGHT
									this.DefaultStyleKey = typeof(AtomImageButton);
								#endif
				OnCreate();
			}
			
			static AtomImageButton(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								DefaultStyleKeyProperty.OverrideMetadata(
					typeof(AtomImageButton),
					new FrameworkPropertyMetadata(typeof(AtomImageButton)));
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

				
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty ImageSourceProperty = DependencyProperty.Register("ImageSource",typeof(ImageSource),typeof(AtomImageButton), new PropertyMetadata(null));
				#else
				public static DependencyProperty ImageSourceProperty = DependencyProperty.Register("ImageSource",typeof(ImageSource),typeof(AtomImageButton), new FrameworkPropertyMetadata(null));
								#endif
				
				public ImageSource ImageSource{
					get{
						return (ImageSource)GetValue(ImageSourceProperty);
					}
					set{
						SetValue(ImageSourceProperty,value);
					}
				}

			
					}
	

				public partial class AtomValueDialogButton : AtomImageButton {

			
			public AtomValueDialogButton(){
			
				#if NETFX_CORE || SILVERLIGHT
								#endif
				OnCreate();
			}
			
			static AtomValueDialogButton(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

				
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty DialogTypeProperty = DependencyProperty.Register("DialogType",typeof(Type),typeof(AtomValueDialogButton), new PropertyMetadata(null));
				#else
				public static DependencyProperty DialogTypeProperty = DependencyProperty.Register("DialogType",typeof(Type),typeof(AtomValueDialogButton), new FrameworkPropertyMetadata(null));
								#endif
				
				public Type DialogType{
					get{
						return (Type)GetValue(DialogTypeProperty);
					}
					set{
						SetValue(DialogTypeProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty ValueProperty = DependencyProperty.Register("Value",typeof(Object),typeof(AtomValueDialogButton), new PropertyMetadata(null));
				#else
				public static DependencyProperty ValueProperty = DependencyProperty.Register("Value",typeof(Object),typeof(AtomValueDialogButton), new FrameworkPropertyMetadata(null));
								#endif
				
				public Object Value{
					get{
						return (Object)GetValue(ValueProperty);
					}
					set{
						SetValue(ValueProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty TitleProperty = DependencyProperty.Register("Title",typeof(String),typeof(AtomValueDialogButton), new PropertyMetadata(""));
				#else
				public static DependencyProperty TitleProperty = DependencyProperty.Register("Title",typeof(String),typeof(AtomValueDialogButton), new FrameworkPropertyMetadata(""));
								#endif
				
				public String Title{
					get{
						return (String)GetValue(TitleProperty);
					}
					set{
						SetValue(TitleProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty DialogTypeNameProperty = DependencyProperty.Register("DialogTypeName",typeof(String),typeof(AtomValueDialogButton), new PropertyMetadata(""));
				#else
				public static DependencyProperty DialogTypeNameProperty = DependencyProperty.Register("DialogTypeName",typeof(String),typeof(AtomValueDialogButton), new FrameworkPropertyMetadata(""));
								#endif
				
				public String DialogTypeName{
					get{
						return (String)GetValue(DialogTypeNameProperty);
					}
					set{
						SetValue(DialogTypeNameProperty,value);
					}
				}

			
					}
	

				public partial class AtomAccordion : AtomListBox {

			
			public AtomAccordion(){
			
				#if NETFX_CORE || SILVERLIGHT
								#endif
				OnCreate();
			}
			
			static AtomAccordion(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

				
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

			
											#if NETFX_CORE || SILVERLIGHT
				public static DependencyProperty HeaderProperty = DependencyProperty.RegisterAttached("Header",typeof(Object),typeof(AtomAccordion), new PropertyMetadata(""));
				#else
				public static DependencyProperty HeaderProperty = DependencyProperty.RegisterAttached("Header",typeof(Object),typeof(AtomAccordion), new FrameworkPropertyMetadata(""));
				#endif
				
				public static Object GetHeader(DependencyObject owner){
					return 	(Object)owner.GetValue(HeaderProperty);
				}
				public static void SetHeader(DependencyObject owner, Object value){
					owner.SetValue(HeaderProperty,value);
				}
					}
	

					[TemplatePart(Name="contentPresenter",Type=typeof(ContentPresenter))]
					[TemplatePart(Name="headerButton",Type=typeof(ToggleButton))]
				public partial class AtomAccordionItem : ListBoxItem {

			
			public AtomAccordionItem(){
			
				#if NETFX_CORE || SILVERLIGHT
									this.DefaultStyleKey = typeof(AtomAccordionItem);
								#endif
				OnCreate();
			}
			
			static AtomAccordionItem(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								DefaultStyleKeyProperty.OverrideMetadata(
					typeof(AtomAccordionItem),
					new FrameworkPropertyMetadata(typeof(AtomAccordionItem)));
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
							protected ContentPresenter contentPresenter;
							protected ToggleButton headerButton;
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

									contentPresenter = GetTemplateChild("PART_Content") as ContentPresenter;
											if(contentPresenter == null)
							throw new InvalidOperationException("Part PART_Content(ContentPresenter) is not defined in template of AtomAccordionItem");
														headerButton = GetTemplateChild("PART_Header") as ToggleButton;
											if(headerButton == null)
							throw new InvalidOperationException("Part PART_Header(ToggleButton) is not defined in template of AtomAccordionItem");
									
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty HeaderProperty = DependencyProperty.Register("Header",typeof(Object),typeof(AtomAccordionItem), new PropertyMetadata((Object)0));
				#else
				public static DependencyProperty HeaderProperty = DependencyProperty.Register("Header",typeof(Object),typeof(AtomAccordionItem), new FrameworkPropertyMetadata((Object)0));
								#endif
				
				public Object Header{
					get{
						return (Object)GetValue(HeaderProperty);
					}
					set{
						SetValue(HeaderProperty,value);
					}
				}

			
					}
	

				public partial class AtomRadioButtonList : AtomListBox {

			
			public AtomRadioButtonList(){
			
				#if NETFX_CORE || SILVERLIGHT
								#endif
				OnCreate();
			}
			
			static AtomRadioButtonList(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

				
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty GroupNameProperty = DependencyProperty.Register("GroupName",typeof(String),typeof(AtomRadioButtonList), new PropertyMetadata(null));
				#else
				public static DependencyProperty GroupNameProperty = DependencyProperty.Register("GroupName",typeof(String),typeof(AtomRadioButtonList), new FrameworkPropertyMetadata(null));
								#endif
				
				public String GroupName{
					get{
						return (String)GetValue(GroupNameProperty);
					}
					set{
						SetValue(GroupNameProperty,value);
					}
				}

			
					}
	

				public partial class AtomRadioButtonListItem : ListBoxItem {

			
			public AtomRadioButtonListItem(){
			
				#if NETFX_CORE || SILVERLIGHT
									this.DefaultStyleKey = typeof(AtomRadioButtonListItem);
								#endif
				OnCreate();
			}
			
			static AtomRadioButtonListItem(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								DefaultStyleKeyProperty.OverrideMetadata(
					typeof(AtomRadioButtonListItem),
					new FrameworkPropertyMetadata(typeof(AtomRadioButtonListItem)));
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

				
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty GroupNameProperty = DependencyProperty.Register("GroupName",typeof(String),typeof(AtomRadioButtonListItem), new PropertyMetadata(null));
				#else
				public static DependencyProperty GroupNameProperty = DependencyProperty.Register("GroupName",typeof(String),typeof(AtomRadioButtonListItem), new FrameworkPropertyMetadata(null));
								#endif
				
				public String GroupName{
					get{
						return (String)GetValue(GroupNameProperty);
					}
					set{
						SetValue(GroupNameProperty,value);
					}
				}

			
					}
	

				public partial class AtomComboBox : ComboBox {

			
			public AtomComboBox(){
			
				#if NETFX_CORE || SILVERLIGHT
									this.DefaultStyleKey = typeof(AtomComboBox);
								#endif
				OnCreate();
			}
			
			static AtomComboBox(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								DefaultStyleKeyProperty.OverrideMetadata(
					typeof(AtomComboBox),
					new FrameworkPropertyMetadata(typeof(AtomComboBox)));
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

				
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty InvalidIndicesProperty = AtomSelectionValidationRule.InvalidIndicesProperty;
				#else
				public static DependencyProperty InvalidIndicesProperty = AtomSelectionValidationRule.InvalidIndicesProperty.AddOwner(typeof(AtomComboBox));
								#endif
				
				public Int32[] InvalidIndices{
					get{
						return (Int32[])GetValue(InvalidIndicesProperty);
					}
					set{
						SetValue(InvalidIndicesProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty IsFilterVisibleProperty = DependencyProperty.Register("IsFilterVisible",typeof(Boolean),typeof(AtomComboBox), new PropertyMetadata((bool)false));
				#else
				public static DependencyProperty IsFilterVisibleProperty = DependencyProperty.Register("IsFilterVisible",typeof(Boolean),typeof(AtomComboBox), new FrameworkPropertyMetadata((bool)false));
								#endif
				
				public Boolean IsFilterVisible{
					get{
						return (Boolean)GetValue(IsFilterVisibleProperty);
					}
					set{
						SetValue(IsFilterVisibleProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty FilterTextProperty = DependencyProperty.Register("FilterText",typeof(String),typeof(AtomComboBox), new PropertyMetadata(""));
				#else
				public static DependencyProperty FilterTextProperty = DependencyProperty.Register("FilterText",typeof(String),typeof(AtomComboBox), new FrameworkPropertyMetadata(""));
								#endif
				
				public String FilterText{
					get{
						return (String)GetValue(FilterTextProperty);
					}
					set{
						SetValue(FilterTextProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty FilterModeProperty = DependencyProperty.Register("FilterMode",typeof(AtomTextFilterMode),typeof(AtomComboBox), new PropertyMetadata((AtomTextFilterMode)AtomTextFilterMode.StartsWith));
				#else
				public static DependencyProperty FilterModeProperty = DependencyProperty.Register("FilterMode",typeof(AtomTextFilterMode),typeof(AtomComboBox), new FrameworkPropertyMetadata((AtomTextFilterMode)AtomTextFilterMode.StartsWith));
								#endif
				
				public AtomTextFilterMode FilterMode{
					get{
						return (AtomTextFilterMode)GetValue(FilterModeProperty);
					}
					set{
						SetValue(FilterModeProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty FilterComparisonProperty = DependencyProperty.Register("FilterComparison",typeof(StringComparison),typeof(AtomComboBox), new PropertyMetadata((StringComparison)StringComparison.CurrentCultureIgnoreCase));
				#else
				public static DependencyProperty FilterComparisonProperty = DependencyProperty.Register("FilterComparison",typeof(StringComparison),typeof(AtomComboBox), new FrameworkPropertyMetadata((StringComparison)StringComparison.CurrentCultureIgnoreCase));
								#endif
				
				public StringComparison FilterComparison{
					get{
						return (StringComparison)GetValue(FilterComparisonProperty);
					}
					set{
						SetValue(FilterComparisonProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty FilterProviderProperty = DependencyProperty.Register("FilterProvider",typeof(IAtomItemsFilter),typeof(AtomComboBox), new PropertyMetadata(null));
				#else
				public static DependencyProperty FilterProviderProperty = DependencyProperty.Register("FilterProvider",typeof(IAtomItemsFilter),typeof(AtomComboBox), new FrameworkPropertyMetadata(null));
								#endif
				
				public IAtomItemsFilter FilterProvider{
					get{
						return (IAtomItemsFilter)GetValue(FilterProviderProperty);
					}
					set{
						SetValue(FilterProviderProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty FilterProviderParameterProperty = DependencyProperty.Register("FilterProviderParameter",typeof(Object),typeof(AtomComboBox), new PropertyMetadata(null));
				#else
				public static DependencyProperty FilterProviderParameterProperty = DependencyProperty.Register("FilterProviderParameter",typeof(Object),typeof(AtomComboBox), new FrameworkPropertyMetadata(null));
								#endif
				
				public Object FilterProviderParameter{
					get{
						return (Object)GetValue(FilterProviderParameterProperty);
					}
					set{
						SetValue(FilterProviderParameterProperty,value);
					}
				}

			
					}
	

				public partial class AtomErrorDisplay : Control {

			
			public AtomErrorDisplay(){
			
				#if NETFX_CORE || SILVERLIGHT
									this.DefaultStyleKey = typeof(AtomErrorDisplay);
								#endif
				OnCreate();
			}
			
			static AtomErrorDisplay(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								DefaultStyleKeyProperty.OverrideMetadata(
					typeof(AtomErrorDisplay),
					new FrameworkPropertyMetadata(typeof(AtomErrorDisplay)));
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

				
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty ValidationErrorProperty = DependencyProperty.Register("ValidationError",typeof(AtomValidationError),typeof(AtomErrorDisplay), new PropertyMetadata(null));
				#else
				public static DependencyProperty ValidationErrorProperty = DependencyProperty.Register("ValidationError",typeof(AtomValidationError),typeof(AtomErrorDisplay), new FrameworkPropertyMetadata(null));
								#endif
				
				public AtomValidationError ValidationError{
					get{
						return (AtomValidationError)GetValue(ValidationErrorProperty);
					}
					set{
						SetValue(ValidationErrorProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty IsPressedProperty = DependencyProperty.Register("IsPressed",typeof(Boolean),typeof(AtomErrorDisplay), new PropertyMetadata((bool)false));
				#else
				public static DependencyProperty IsPressedProperty = DependencyProperty.Register("IsPressed",typeof(Boolean),typeof(AtomErrorDisplay), new FrameworkPropertyMetadata((bool)false));
								#endif
				
				public Boolean IsPressed{
					get{
						return (Boolean)GetValue(IsPressedProperty);
					}
					set{
						SetValue(IsPressedProperty,value);
					}
				}

			
					}
	

				public partial class AtomUsernameTextBox : AtomTextBox {

			
			public AtomUsernameTextBox(){
			
				#if NETFX_CORE || SILVERLIGHT
								#endif
				OnCreate();
			}
			
			static AtomUsernameTextBox(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

				
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty InvalidUsernameErrorMessageProperty = AtomUsernameValidationRule.InvalidUsernameErrorMessageProperty;
				#else
				public static DependencyProperty InvalidUsernameErrorMessageProperty = AtomUsernameValidationRule.InvalidUsernameErrorMessageProperty.AddOwner(typeof(AtomUsernameTextBox));
								#endif
				
				public String InvalidUsernameErrorMessage{
					get{
						return (String)GetValue(InvalidUsernameErrorMessageProperty);
					}
					set{
						SetValue(InvalidUsernameErrorMessageProperty,value);
					}
				}

			
					}
	

				public partial class AtomRangeBase<T,StepT> : AtomNumberContainerControl {

			
			public AtomRangeBase(){
			
				#if NETFX_CORE || SILVERLIGHT
								#endif
				OnCreate();
			}
			
			static AtomRangeBase(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

				
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty MinimumProperty = DependencyProperty.Register("Minimum",typeof(T),typeof(AtomRangeBase<T,StepT>), new PropertyMetadata(default(T),OnMinimumChanged));
					#else
					public static DependencyProperty MinimumProperty = DependencyProperty.Register("Minimum",typeof(T),typeof(AtomRangeBase<T,StepT>), new FrameworkPropertyMetadata(default(T),OnMinimumChanged));
					#endif

					private static void OnMinimumChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomRangeBase<T,StepT>)sender).OnMinimumChanged(e);
					}

					protected virtual void OnMinimumChanged(DependencyPropertyChangedEventArgs e){
											OnAfterMinimumChanged(e);
															}

										partial void OnAfterMinimumChanged(DependencyPropertyChangedEventArgs e);
										
				
				public T Minimum{
					get{
						return (T)GetValue(MinimumProperty);
					}
					set{
						SetValue(MinimumProperty,value);
					}
				}

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty MaximumProperty = DependencyProperty.Register("Maximum",typeof(T),typeof(AtomRangeBase<T,StepT>), new PropertyMetadata(default(T),OnMaximumChanged));
					#else
					public static DependencyProperty MaximumProperty = DependencyProperty.Register("Maximum",typeof(T),typeof(AtomRangeBase<T,StepT>), new FrameworkPropertyMetadata(default(T),OnMaximumChanged));
					#endif

					private static void OnMaximumChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomRangeBase<T,StepT>)sender).OnMaximumChanged(e);
					}

					protected virtual void OnMaximumChanged(DependencyPropertyChangedEventArgs e){
											OnAfterMaximumChanged(e);
															}

										partial void OnAfterMaximumChanged(DependencyPropertyChangedEventArgs e);
										
				
				public T Maximum{
					get{
						return (T)GetValue(MaximumProperty);
					}
					set{
						SetValue(MaximumProperty,value);
					}
				}

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty ValueProperty = DependencyProperty.Register("Value",typeof(T),typeof(AtomRangeBase<T,StepT>), new PropertyMetadata(default(T),OnValueChanged));
					#else
					public static DependencyProperty ValueProperty = DependencyProperty.Register("Value",typeof(T),typeof(AtomRangeBase<T,StepT>), new FrameworkPropertyMetadata(default(T),OnValueChanged));
					#endif

					private static void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomRangeBase<T,StepT>)sender).OnValueChanged(e);
					}

					protected virtual void OnValueChanged(DependencyPropertyChangedEventArgs e){
											OnAfterValueChanged(e);
															}

										partial void OnAfterValueChanged(DependencyPropertyChangedEventArgs e);
										
				
				public T Value{
					get{
						return (T)GetValue(ValueProperty);
					}
					set{
						SetValue(ValueProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty StepProperty = DependencyProperty.Register("Step",typeof(StepT),typeof(AtomRangeBase<T,StepT>), new PropertyMetadata(default(StepT)));
				#else
				public static DependencyProperty StepProperty = DependencyProperty.Register("Step",typeof(StepT),typeof(AtomRangeBase<T,StepT>), new FrameworkPropertyMetadata(default(StepT)));
								#endif
				
				public StepT Step{
					get{
						return (StepT)GetValue(StepProperty);
					}
					set{
						SetValue(StepProperty,value);
					}
				}

			
					}
	

					[TemplatePart(Name="TB",Type=typeof(AtomTextBox))]
				public partial class AtomDoubleTextBox : AtomRangeBase<double,double> {

			
			public AtomDoubleTextBox(){
			
				#if NETFX_CORE || SILVERLIGHT
								#endif
				OnCreate();
			}
			
			static AtomDoubleTextBox(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
							protected AtomTextBox TB;
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

									TB = GetTemplateChild("PART_TextBox") as AtomTextBox;
									
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty StringFormatProperty = DependencyProperty.Register("StringFormat",typeof(String),typeof(AtomDoubleTextBox), new PropertyMetadata("{0:N2}",OnStringFormatChanged));
					#else
					public static DependencyProperty StringFormatProperty = DependencyProperty.Register("StringFormat",typeof(String),typeof(AtomDoubleTextBox), new FrameworkPropertyMetadata("{0:N2}",OnStringFormatChanged));
					#endif

					private static void OnStringFormatChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomDoubleTextBox)sender).OnStringFormatChanged(e);
					}

					protected virtual void OnStringFormatChanged(DependencyPropertyChangedEventArgs e){
											OnAfterStringFormatChanged(e);
																if(StringFormatChanged!=null)
							StringFormatChanged(this,e);
										}

										partial void OnAfterStringFormatChanged(DependencyPropertyChangedEventArgs e);
															#if NETFX_CORE || SILVERLIGHT
						public event EventHandler<DependencyPropertyChangedEventArgs> StringFormatChanged;
					#else
						public event DependencyPropertyChangedEventHandler StringFormatChanged;
					#endif
					
				
				public String StringFormat{
					get{
						return (String)GetValue(StringFormatProperty);
					}
					set{
						SetValue(StringFormatProperty,value);
					}
				}

			
					}
	

				public partial class AtomEnumComboBox : AtomComboBox {

			
			public AtomEnumComboBox(){
			
				#if NETFX_CORE || SILVERLIGHT
								#endif
				OnCreate();
			}
			
			static AtomEnumComboBox(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

				
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty EnumTypeProperty = DependencyProperty.Register("EnumType",typeof(Type),typeof(AtomEnumComboBox), new PropertyMetadata(null,OnEnumTypeChanged));
					#else
					public static DependencyProperty EnumTypeProperty = DependencyProperty.Register("EnumType",typeof(Type),typeof(AtomEnumComboBox), new FrameworkPropertyMetadata(null,OnEnumTypeChanged));
					#endif

					private static void OnEnumTypeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomEnumComboBox)sender).OnEnumTypeChanged(e);
					}

					protected virtual void OnEnumTypeChanged(DependencyPropertyChangedEventArgs e){
											OnAfterEnumTypeChanged(e);
																if(EnumTypeChanged!=null)
							EnumTypeChanged(this,e);
										}

										partial void OnAfterEnumTypeChanged(DependencyPropertyChangedEventArgs e);
															#if NETFX_CORE || SILVERLIGHT
						public event EventHandler<DependencyPropertyChangedEventArgs> EnumTypeChanged;
					#else
						public event DependencyPropertyChangedEventHandler EnumTypeChanged;
					#endif
					
				
				public Type EnumType{
					get{
						return (Type)GetValue(EnumTypeProperty);
					}
					set{
						SetValue(EnumTypeProperty,value);
					}
				}

			
					}
	

				public partial class AtomFormItemContainer : ContentControl {

			
			public AtomFormItemContainer(){
			
				#if NETFX_CORE || SILVERLIGHT
									this.DefaultStyleKey = typeof(AtomFormItemContainer);
								#endif
				OnCreate();
			}
			
			static AtomFormItemContainer(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								DefaultStyleKeyProperty.OverrideMetadata(
					typeof(AtomFormItemContainer),
					new FrameworkPropertyMetadata(typeof(AtomFormItemContainer)));
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

				
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty PropertyValueProperty = DependencyProperty.Register("PropertyValue",typeof(Object),typeof(AtomFormItemContainer), new PropertyMetadata(null));
				#else
				public static DependencyProperty PropertyValueProperty = DependencyProperty.Register("PropertyValue",typeof(Object),typeof(AtomFormItemContainer), new FrameworkPropertyMetadata(null));
								#endif
				
				public Object PropertyValue{
					get{
						return (Object)GetValue(PropertyValueProperty);
					}
					set{
						SetValue(PropertyValueProperty,value);
					}
				}

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty IsContentInvalidProperty = DependencyProperty.Register("IsContentInvalid",typeof(Boolean),typeof(AtomFormItemContainer), new PropertyMetadata((bool)false,OnIsContentInvalidChanged));
					#else
					public static DependencyProperty IsContentInvalidProperty = DependencyProperty.Register("IsContentInvalid",typeof(Boolean),typeof(AtomFormItemContainer), new FrameworkPropertyMetadata((bool)false,OnIsContentInvalidChanged));
					#endif

					private static void OnIsContentInvalidChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomFormItemContainer)sender).OnIsContentInvalidChanged(e);
					}

					protected virtual void OnIsContentInvalidChanged(DependencyPropertyChangedEventArgs e){
											OnAfterIsContentInvalidChanged(e);
															}

										partial void OnAfterIsContentInvalidChanged(DependencyPropertyChangedEventArgs e);
										
				
				public Boolean IsContentInvalid{
					get{
						return (Boolean)GetValue(IsContentInvalidProperty);
					}
					set{
						SetValue(IsContentInvalidProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty ErrorMessageProperty = DependencyProperty.Register("ErrorMessage",typeof(String),typeof(AtomFormItemContainer), new PropertyMetadata(null));
				#else
				public static DependencyProperty ErrorMessageProperty = DependencyProperty.Register("ErrorMessage",typeof(String),typeof(AtomFormItemContainer), new FrameworkPropertyMetadata(null));
								#endif
				
				public String ErrorMessage{
					get{
						return (String)GetValue(ErrorMessageProperty);
					}
					set{
						SetValue(ErrorMessageProperty,value);
					}
				}

			
					}
	

				public partial class AtomPrompt : Window {

			
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

				
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty PromptTitleProperty = DependencyProperty.Register("PromptTitle",typeof(String),typeof(AtomPrompt), new PropertyMetadata("Please Enter The Text"));
				#else
				public static DependencyProperty PromptTitleProperty = DependencyProperty.Register("PromptTitle",typeof(String),typeof(AtomPrompt), new FrameworkPropertyMetadata("Please Enter The Text"));
								#endif
				
				public String PromptTitle{
					get{
						return (String)GetValue(PromptTitleProperty);
					}
					set{
						SetValue(PromptTitleProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty PromptDescriptionProperty = DependencyProperty.Register("PromptDescription",typeof(String),typeof(AtomPrompt), new PropertyMetadata("Please Enter The Text"));
				#else
				public static DependencyProperty PromptDescriptionProperty = DependencyProperty.Register("PromptDescription",typeof(String),typeof(AtomPrompt), new FrameworkPropertyMetadata("Please Enter The Text"));
								#endif
				
				public String PromptDescription{
					get{
						return (String)GetValue(PromptDescriptionProperty);
					}
					set{
						SetValue(PromptDescriptionProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty PromptValueProperty = DependencyProperty.Register("PromptValue",typeof(String),typeof(AtomPrompt), new PropertyMetadata("Undefined.."));
				#else
				public static DependencyProperty PromptValueProperty = DependencyProperty.Register("PromptValue",typeof(String),typeof(AtomPrompt), new FrameworkPropertyMetadata("Undefined.."));
								#endif
				
				public String PromptValue{
					get{
						return (String)GetValue(PromptValueProperty);
					}
					set{
						SetValue(PromptValueProperty,value);
					}
				}

			
					}
	

					[TemplatePart(Name="TB",Type=typeof(AtomTextBox))]
				public partial class AtomCurrencyTextBox : AtomRangeBase<decimal,decimal> {

			
			public AtomCurrencyTextBox(){
			
				#if NETFX_CORE || SILVERLIGHT
									this.DefaultStyleKey = typeof(AtomCurrencyTextBox);
								#endif
				OnCreate();
			}
			
			static AtomCurrencyTextBox(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								DefaultStyleKeyProperty.OverrideMetadata(
					typeof(AtomCurrencyTextBox),
					new FrameworkPropertyMetadata(typeof(AtomCurrencyTextBox)));
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
							protected AtomTextBox TB;
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

									TB = GetTemplateChild("PART_TextBox") as AtomTextBox;
											if(TB == null)
							throw new InvalidOperationException("Part PART_TextBox(AtomTextBox) is not defined in template of AtomCurrencyTextBox");
									
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty StringFormatProperty = DependencyProperty.Register("StringFormat",typeof(String),typeof(AtomCurrencyTextBox), new PropertyMetadata("$ {0:#,###,##0.00}",OnStringFormatChanged));
					#else
					public static DependencyProperty StringFormatProperty = DependencyProperty.Register("StringFormat",typeof(String),typeof(AtomCurrencyTextBox), new FrameworkPropertyMetadata("$ {0:#,###,##0.00}",OnStringFormatChanged));
					#endif

					private static void OnStringFormatChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomCurrencyTextBox)sender).OnStringFormatChanged(e);
					}

					protected virtual void OnStringFormatChanged(DependencyPropertyChangedEventArgs e){
											OnAfterStringFormatChanged(e);
																if(StringFormatChanged!=null)
							StringFormatChanged(this,e);
										}

										partial void OnAfterStringFormatChanged(DependencyPropertyChangedEventArgs e);
															#if NETFX_CORE || SILVERLIGHT
						public event EventHandler<DependencyPropertyChangedEventArgs> StringFormatChanged;
					#else
						public event DependencyPropertyChangedEventHandler StringFormatChanged;
					#endif
					
				
				public String StringFormat{
					get{
						return (String)GetValue(StringFormatProperty);
					}
					set{
						SetValue(StringFormatProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty CalculatorVisibilityProperty = DependencyProperty.Register("CalculatorVisibility",typeof(Visibility),typeof(AtomCurrencyTextBox), new PropertyMetadata((Visibility)Visibility.Visible));
				#else
				public static DependencyProperty CalculatorVisibilityProperty = DependencyProperty.Register("CalculatorVisibility",typeof(Visibility),typeof(AtomCurrencyTextBox), new FrameworkPropertyMetadata((Visibility)Visibility.Visible));
								#endif
				
				public Visibility CalculatorVisibility{
					get{
						return (Visibility)GetValue(CalculatorVisibilityProperty);
					}
					set{
						SetValue(CalculatorVisibilityProperty,value);
					}
				}

			
					}
	

				public partial class AtomEmailTextBox : AtomTextBox {

			
			public AtomEmailTextBox(){
			
				#if NETFX_CORE || SILVERLIGHT
								#endif
				OnCreate();
			}
			
			static AtomEmailTextBox(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

				
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty AllowMultipleProperty = AtomEmailValidationRule.AllowMultipleProperty;
				#else
				public static DependencyProperty AllowMultipleProperty = AtomEmailValidationRule.AllowMultipleProperty.AddOwner(typeof(AtomEmailTextBox));
								#endif
				
				public Boolean AllowMultiple{
					get{
						return (Boolean)GetValue(AllowMultipleProperty);
					}
					set{
						SetValue(AllowMultipleProperty,value);
					}
				}

			
					}
	

					[TemplatePart(Name="TB",Type=typeof(AtomTextBox))]
				public partial class AtomIntegerTextBox : AtomRangeBase<int,int> {

			
			public AtomIntegerTextBox(){
			
				#if NETFX_CORE || SILVERLIGHT
								#endif
				OnCreate();
			}
			
			static AtomIntegerTextBox(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
							protected AtomTextBox TB;
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

									TB = GetTemplateChild("PART_TextBox") as AtomTextBox;
											if(TB == null)
							throw new InvalidOperationException("Part PART_TextBox(AtomTextBox) is not defined in template of AtomIntegerTextBox");
									
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty StringFormatProperty = DependencyProperty.Register("StringFormat",typeof(String),typeof(AtomIntegerTextBox), new PropertyMetadata("{0:#,###,##0}",OnStringFormatChanged));
					#else
					public static DependencyProperty StringFormatProperty = DependencyProperty.Register("StringFormat",typeof(String),typeof(AtomIntegerTextBox), new FrameworkPropertyMetadata("{0:#,###,##0}",OnStringFormatChanged));
					#endif

					private static void OnStringFormatChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomIntegerTextBox)sender).OnStringFormatChanged(e);
					}

					protected virtual void OnStringFormatChanged(DependencyPropertyChangedEventArgs e){
											OnAfterStringFormatChanged(e);
																if(StringFormatChanged!=null)
							StringFormatChanged(this,e);
										}

										partial void OnAfterStringFormatChanged(DependencyPropertyChangedEventArgs e);
															#if NETFX_CORE || SILVERLIGHT
						public event EventHandler<DependencyPropertyChangedEventArgs> StringFormatChanged;
					#else
						public event DependencyPropertyChangedEventHandler StringFormatChanged;
					#endif
					
				
				public String StringFormat{
					get{
						return (String)GetValue(StringFormatProperty);
					}
					set{
						SetValue(StringFormatProperty,value);
					}
				}

			
					}
	

				public partial class AtomNumberComboBox : AtomComboBox {

			
			public AtomNumberComboBox(){
			
				#if NETFX_CORE || SILVERLIGHT
								#endif
				OnCreate();
			}
			
			static AtomNumberComboBox(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

				
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty StartNumberProperty = DependencyProperty.Register("StartNumber",typeof(Decimal),typeof(AtomNumberComboBox), new PropertyMetadata((Decimal)0,OnStartNumberChanged));
					#else
					public static DependencyProperty StartNumberProperty = DependencyProperty.Register("StartNumber",typeof(Decimal),typeof(AtomNumberComboBox), new FrameworkPropertyMetadata((Decimal)0,OnStartNumberChanged));
					#endif

					private static void OnStartNumberChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomNumberComboBox)sender).OnStartNumberChanged(e);
					}

					protected virtual void OnStartNumberChanged(DependencyPropertyChangedEventArgs e){
											OnAfterStartNumberChanged(e);
																if(StartNumberChanged!=null)
							StartNumberChanged(this,e);
										}

										partial void OnAfterStartNumberChanged(DependencyPropertyChangedEventArgs e);
															#if NETFX_CORE || SILVERLIGHT
						public event EventHandler<DependencyPropertyChangedEventArgs> StartNumberChanged;
					#else
						public event DependencyPropertyChangedEventHandler StartNumberChanged;
					#endif
					
				
				public Decimal StartNumber{
					get{
						return (Decimal)GetValue(StartNumberProperty);
					}
					set{
						SetValue(StartNumberProperty,value);
					}
				}

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty EndNumberProperty = DependencyProperty.Register("EndNumber",typeof(Decimal),typeof(AtomNumberComboBox), new PropertyMetadata((Decimal)10.0,OnEndNumberChanged));
					#else
					public static DependencyProperty EndNumberProperty = DependencyProperty.Register("EndNumber",typeof(Decimal),typeof(AtomNumberComboBox), new FrameworkPropertyMetadata((Decimal)10.0,OnEndNumberChanged));
					#endif

					private static void OnEndNumberChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomNumberComboBox)sender).OnEndNumberChanged(e);
					}

					protected virtual void OnEndNumberChanged(DependencyPropertyChangedEventArgs e){
											OnAfterEndNumberChanged(e);
																if(EndNumberChanged!=null)
							EndNumberChanged(this,e);
										}

										partial void OnAfterEndNumberChanged(DependencyPropertyChangedEventArgs e);
															#if NETFX_CORE || SILVERLIGHT
						public event EventHandler<DependencyPropertyChangedEventArgs> EndNumberChanged;
					#else
						public event DependencyPropertyChangedEventHandler EndNumberChanged;
					#endif
					
				
				public Decimal EndNumber{
					get{
						return (Decimal)GetValue(EndNumberProperty);
					}
					set{
						SetValue(EndNumberProperty,value);
					}
				}

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty NumberStepProperty = DependencyProperty.Register("NumberStep",typeof(Decimal),typeof(AtomNumberComboBox), new PropertyMetadata((Decimal)1.0,OnNumberStepChanged));
					#else
					public static DependencyProperty NumberStepProperty = DependencyProperty.Register("NumberStep",typeof(Decimal),typeof(AtomNumberComboBox), new FrameworkPropertyMetadata((Decimal)1.0,OnNumberStepChanged));
					#endif

					private static void OnNumberStepChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomNumberComboBox)sender).OnNumberStepChanged(e);
					}

					protected virtual void OnNumberStepChanged(DependencyPropertyChangedEventArgs e){
											OnAfterNumberStepChanged(e);
																if(NumberStepChanged!=null)
							NumberStepChanged(this,e);
										}

										partial void OnAfterNumberStepChanged(DependencyPropertyChangedEventArgs e);
															#if NETFX_CORE || SILVERLIGHT
						public event EventHandler<DependencyPropertyChangedEventArgs> NumberStepChanged;
					#else
						public event DependencyPropertyChangedEventHandler NumberStepChanged;
					#endif
					
				
				public Decimal NumberStep{
					get{
						return (Decimal)GetValue(NumberStepProperty);
					}
					set{
						SetValue(NumberStepProperty,value);
					}
				}

			
					}
	

				public partial class AtomTextBoxWithRegEx : AtomTextBox {

			
			public AtomTextBoxWithRegEx(){
			
				#if NETFX_CORE || SILVERLIGHT
								#endif
				OnCreate();
			}
			
			static AtomTextBoxWithRegEx(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

				
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty ValidationRegExProperty = AtomRegExValidationRule.ValidationRegExProperty;
				#else
				public static DependencyProperty ValidationRegExProperty = AtomRegExValidationRule.ValidationRegExProperty.AddOwner(typeof(AtomTextBoxWithRegEx));
								#endif
				
				public String ValidationRegEx{
					get{
						return (String)GetValue(ValidationRegExProperty);
					}
					set{
						SetValue(ValidationRegExProperty,value);
					}
				}

			
					}
	

				public partial class AtomTitleTextBox : AtomTextBox {

			
			public AtomTitleTextBox(){
			
				#if NETFX_CORE || SILVERLIGHT
								#endif
				OnCreate();
			}
			
			static AtomTitleTextBox(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

				
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty CapitalizeAllProperty = DependencyProperty.Register("CapitalizeAll",typeof(Boolean),typeof(AtomTitleTextBox), new PropertyMetadata((bool)false,OnCapitalizeAllChanged));
					#else
					public static DependencyProperty CapitalizeAllProperty = DependencyProperty.Register("CapitalizeAll",typeof(Boolean),typeof(AtomTitleTextBox), new FrameworkPropertyMetadata((bool)false,OnCapitalizeAllChanged));
					#endif

					private static void OnCapitalizeAllChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomTitleTextBox)sender).OnCapitalizeAllChanged(e);
					}

					protected virtual void OnCapitalizeAllChanged(DependencyPropertyChangedEventArgs e){
											OnAfterCapitalizeAllChanged(e);
															}

										partial void OnAfterCapitalizeAllChanged(DependencyPropertyChangedEventArgs e);
										
				
				public Boolean CapitalizeAll{
					get{
						return (Boolean)GetValue(CapitalizeAllProperty);
					}
					set{
						SetValue(CapitalizeAllProperty,value);
					}
				}

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty IgnoreWordsProperty = DependencyProperty.Register("IgnoreWords",typeof(String),typeof(AtomTitleTextBox), new PropertyMetadata("of, at, in, with, is, a, an, the",OnIgnoreWordsChanged));
					#else
					public static DependencyProperty IgnoreWordsProperty = DependencyProperty.Register("IgnoreWords",typeof(String),typeof(AtomTitleTextBox), new FrameworkPropertyMetadata("of, at, in, with, is, a, an, the",OnIgnoreWordsChanged));
					#endif

					private static void OnIgnoreWordsChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomTitleTextBox)sender).OnIgnoreWordsChanged(e);
					}

					protected virtual void OnIgnoreWordsChanged(DependencyPropertyChangedEventArgs e){
																if(IgnoreWordsChanged!=null)
							IgnoreWordsChanged(this,e);
										}

															#if NETFX_CORE || SILVERLIGHT
						public event EventHandler<DependencyPropertyChangedEventArgs> IgnoreWordsChanged;
					#else
						public event DependencyPropertyChangedEventHandler IgnoreWordsChanged;
					#endif
					
				
				public String IgnoreWords{
					get{
						return (String)GetValue(IgnoreWordsProperty);
					}
					set{
						SetValue(IgnoreWordsProperty,value);
					}
				}

			
					}
	

				public partial class AtomEditorConverter : Control {

			
			public AtomEditorConverter(){
			
				#if NETFX_CORE || SILVERLIGHT
								#endif
				OnCreate();
			}
			
			static AtomEditorConverter(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

				
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty ValueProperty = DependencyProperty.Register("Value",typeof(Double),typeof(AtomEditorConverter), new PropertyMetadata(null));
				#else
				public static DependencyProperty ValueProperty = DependencyProperty.Register("Value",typeof(Double),typeof(AtomEditorConverter), new FrameworkPropertyMetadata(null));
								#endif
				
				public Double Value{
					get{
						return (Double)GetValue(ValueProperty);
					}
					set{
						SetValue(ValueProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty ValueUnitIDProperty = DependencyProperty.Register("ValueUnitID",typeof(String),typeof(AtomEditorConverter), new PropertyMetadata(null));
				#else
				public static DependencyProperty ValueUnitIDProperty = DependencyProperty.Register("ValueUnitID",typeof(String),typeof(AtomEditorConverter), new FrameworkPropertyMetadata(null));
								#endif
				
				public String ValueUnitID{
					get{
						return (String)GetValue(ValueUnitIDProperty);
					}
					set{
						SetValue(ValueUnitIDProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty DisplayValueProperty = DependencyProperty.Register("DisplayValue",typeof(Double),typeof(AtomEditorConverter), new PropertyMetadata(null));
				#else
				public static DependencyProperty DisplayValueProperty = DependencyProperty.Register("DisplayValue",typeof(Double),typeof(AtomEditorConverter), new FrameworkPropertyMetadata(null));
								#endif
				
				public Double DisplayValue{
					get{
						return (Double)GetValue(DisplayValueProperty);
					}
					set{
						SetValue(DisplayValueProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty DisplayUnitIDProperty = DependencyProperty.Register("DisplayUnitID",typeof(String),typeof(AtomEditorConverter), new PropertyMetadata(null));
				#else
				public static DependencyProperty DisplayUnitIDProperty = DependencyProperty.Register("DisplayUnitID",typeof(String),typeof(AtomEditorConverter), new FrameworkPropertyMetadata(null));
								#endif
				
				public String DisplayUnitID{
					get{
						return (String)GetValue(DisplayUnitIDProperty);
					}
					set{
						SetValue(DisplayUnitIDProperty,value);
					}
				}

			
					}
	

					[TemplatePart(Name="listPresenter",Type=typeof(ContentControl))]
					[TemplatePart(Name="popup",Type=typeof(Popup))]
					[TemplatePart(Name="watermark",Type=typeof(TextBlock))]
					[TemplatePart(Name="toggleButton",Type=typeof(ToggleButton))]
				public partial class AtomComboTextBox : TextBox {

			
			public AtomComboTextBox(){
			
				#if NETFX_CORE || SILVERLIGHT
									this.DefaultStyleKey = typeof(AtomComboTextBox);
								#endif
				OnCreate();
			}
			
			static AtomComboTextBox(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								DefaultStyleKeyProperty.OverrideMetadata(
					typeof(AtomComboTextBox),
					new FrameworkPropertyMetadata(typeof(AtomComboTextBox)));
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
							protected ContentControl listPresenter;
							protected Popup popup;
							protected TextBlock watermark;
							protected ToggleButton toggleButton;
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

									listPresenter = GetTemplateChild("listPresenter") as ContentControl;
											if(listPresenter == null)
							throw new InvalidOperationException("Part listPresenter(ContentControl) is not defined in template of AtomComboTextBox");
														popup = GetTemplateChild("popup") as Popup;
											if(popup == null)
							throw new InvalidOperationException("Part popup(Popup) is not defined in template of AtomComboTextBox");
														watermark = GetTemplateChild("watermark") as TextBlock;
											if(watermark == null)
							throw new InvalidOperationException("Part watermark(TextBlock) is not defined in template of AtomComboTextBox");
														toggleButton = GetTemplateChild("toggleButton") as ToggleButton;
											if(toggleButton == null)
							throw new InvalidOperationException("Part toggleButton(ToggleButton) is not defined in template of AtomComboTextBox");
									
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty SelectedIndexProperty = DependencyProperty.Register("SelectedIndex",typeof(Int32),typeof(AtomComboTextBox), new PropertyMetadata((int)-1,OnSelectedIndexChanged));
					#else
					public static DependencyProperty SelectedIndexProperty = DependencyProperty.Register("SelectedIndex",typeof(Int32),typeof(AtomComboTextBox), new FrameworkPropertyMetadata((int)-1,OnSelectedIndexChanged));
					#endif

					private static void OnSelectedIndexChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomComboTextBox)sender).OnSelectedIndexChanged(e);
					}

					protected virtual void OnSelectedIndexChanged(DependencyPropertyChangedEventArgs e){
											OnAfterSelectedIndexChanged(e);
																if(SelectedIndexChanged!=null)
							SelectedIndexChanged(this,e);
										}

										partial void OnAfterSelectedIndexChanged(DependencyPropertyChangedEventArgs e);
															#if NETFX_CORE || SILVERLIGHT
						public event EventHandler<DependencyPropertyChangedEventArgs> SelectedIndexChanged;
					#else
						public event DependencyPropertyChangedEventHandler SelectedIndexChanged;
					#endif
					
				
				public Int32 SelectedIndex{
					get{
						return (Int32)GetValue(SelectedIndexProperty);
					}
					set{
						SetValue(SelectedIndexProperty,value);
					}
				}

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty SelectedItemProperty = DependencyProperty.Register("SelectedItem",typeof(Object),typeof(AtomComboTextBox), new PropertyMetadata(null,OnSelectedItemChanged));
					#else
					public static DependencyProperty SelectedItemProperty = DependencyProperty.Register("SelectedItem",typeof(Object),typeof(AtomComboTextBox), new FrameworkPropertyMetadata(null,OnSelectedItemChanged));
					#endif

					private static void OnSelectedItemChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomComboTextBox)sender).OnSelectedItemChanged(e);
					}

					protected virtual void OnSelectedItemChanged(DependencyPropertyChangedEventArgs e){
											OnAfterSelectedItemChanged(e);
															}

										partial void OnAfterSelectedItemChanged(DependencyPropertyChangedEventArgs e);
										
				
				public Object SelectedItem{
					get{
						return (Object)GetValue(SelectedItemProperty);
					}
					set{
						SetValue(SelectedItemProperty,value);
					}
				}

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty SelectedValueProperty = DependencyProperty.Register("SelectedValue",typeof(Object),typeof(AtomComboTextBox), new PropertyMetadata(null,OnSelectedValueChanged));
					#else
					public static DependencyProperty SelectedValueProperty = DependencyProperty.Register("SelectedValue",typeof(Object),typeof(AtomComboTextBox), new FrameworkPropertyMetadata(null,OnSelectedValueChanged));
					#endif

					private static void OnSelectedValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomComboTextBox)sender).OnSelectedValueChanged(e);
					}

					protected virtual void OnSelectedValueChanged(DependencyPropertyChangedEventArgs e){
											OnAfterSelectedValueChanged(e);
															}

										partial void OnAfterSelectedValueChanged(DependencyPropertyChangedEventArgs e);
										
				
				public Object SelectedValue{
					get{
						return (Object)GetValue(SelectedValueProperty);
					}
					set{
						SetValue(SelectedValueProperty,value);
					}
				}

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty ItemsSourceProperty = DependencyProperty.Register("ItemsSource",typeof(System.Collections.IEnumerable),typeof(AtomComboTextBox), new PropertyMetadata(null,OnItemsSourceChanged));
					#else
					public static DependencyProperty ItemsSourceProperty = DependencyProperty.Register("ItemsSource",typeof(System.Collections.IEnumerable),typeof(AtomComboTextBox), new FrameworkPropertyMetadata(null,OnItemsSourceChanged));
					#endif

					private static void OnItemsSourceChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomComboTextBox)sender).OnItemsSourceChanged(e);
					}

					protected virtual void OnItemsSourceChanged(DependencyPropertyChangedEventArgs e){
											OnAfterItemsSourceChanged(e);
															}

										partial void OnAfterItemsSourceChanged(DependencyPropertyChangedEventArgs e);
										
				
				public System.Collections.IEnumerable ItemsSource{
					get{
						return (System.Collections.IEnumerable)GetValue(ItemsSourceProperty);
					}
					set{
						SetValue(ItemsSourceProperty,value);
					}
				}

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty IsPopupOpenProperty = DependencyProperty.Register("IsPopupOpen",typeof(Boolean),typeof(AtomComboTextBox), new PropertyMetadata(false,OnIsPopupOpenChanged));
					#else
					public static DependencyProperty IsPopupOpenProperty = DependencyProperty.Register("IsPopupOpen",typeof(Boolean),typeof(AtomComboTextBox), new FrameworkPropertyMetadata(false,OnIsPopupOpenChanged));
					#endif

					private static void OnIsPopupOpenChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomComboTextBox)sender).OnIsPopupOpenChanged(e);
					}

					protected virtual void OnIsPopupOpenChanged(DependencyPropertyChangedEventArgs e){
											OnAfterIsPopupOpenChanged(e);
															}

										partial void OnAfterIsPopupOpenChanged(DependencyPropertyChangedEventArgs e);
										
				
				public Boolean IsPopupOpen{
					get{
						return (Boolean)GetValue(IsPopupOpenProperty);
					}
					set{
						SetValue(IsPopupOpenProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty DisplayMemberPathProperty = DependencyProperty.Register("DisplayMemberPath",typeof(String),typeof(AtomComboTextBox), new PropertyMetadata(null));
				#else
				public static DependencyProperty DisplayMemberPathProperty = DependencyProperty.Register("DisplayMemberPath",typeof(String),typeof(AtomComboTextBox), new FrameworkPropertyMetadata(null));
								#endif
				
				public String DisplayMemberPath{
					get{
						return (String)GetValue(DisplayMemberPathProperty);
					}
					set{
						SetValue(DisplayMemberPathProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty SelectedValuePathProperty = DependencyProperty.Register("SelectedValuePath",typeof(String),typeof(AtomComboTextBox), new PropertyMetadata(null));
				#else
				public static DependencyProperty SelectedValuePathProperty = DependencyProperty.Register("SelectedValuePath",typeof(String),typeof(AtomComboTextBox), new FrameworkPropertyMetadata(null));
								#endif
				
				public String SelectedValuePath{
					get{
						return (String)GetValue(SelectedValuePathProperty);
					}
					set{
						SetValue(SelectedValuePathProperty,value);
					}
				}

			
					}
	

				public partial class AtomFormLayout : HeaderedItemsControl {

			
			public AtomFormLayout(){
			
				#if NETFX_CORE || SILVERLIGHT
									this.DefaultStyleKey = typeof(AtomFormLayout);
								#endif
				OnCreate();
			}
			
			static AtomFormLayout(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								DefaultStyleKeyProperty.OverrideMetadata(
					typeof(AtomFormLayout),
					new FrameworkPropertyMetadata(typeof(AtomFormLayout)));
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

				
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty ShowHeaderProperty = DependencyProperty.Register("ShowHeader",typeof(Boolean),typeof(AtomFormLayout), new PropertyMetadata((bool)true));
				#else
				public static DependencyProperty ShowHeaderProperty = DependencyProperty.Register("ShowHeader",typeof(Boolean),typeof(AtomFormLayout), new FrameworkPropertyMetadata((bool)true));
								#endif
				
				public Boolean ShowHeader{
					get{
						return (Boolean)GetValue(ShowHeaderProperty);
					}
					set{
						SetValue(ShowHeaderProperty,value);
					}
				}

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty LabelWidthProperty = DependencyProperty.Register("LabelWidth",typeof(Double),typeof(AtomFormLayout), new PropertyMetadata((Double)75,OnLabelWidthChanged));
					#else
					public static DependencyProperty LabelWidthProperty = DependencyProperty.Register("LabelWidth",typeof(Double),typeof(AtomFormLayout), new FrameworkPropertyMetadata((Double)75,OnLabelWidthChanged));
					#endif

					private static void OnLabelWidthChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomFormLayout)sender).OnLabelWidthChanged(e);
					}

					protected virtual void OnLabelWidthChanged(DependencyPropertyChangedEventArgs e){
											OnAfterLabelWidthChanged(e);
															}

										partial void OnAfterLabelWidthChanged(DependencyPropertyChangedEventArgs e);
										
				
				public Double LabelWidth{
					get{
						return (Double)GetValue(LabelWidthProperty);
					}
					set{
						SetValue(LabelWidthProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty LabelHorizontalAlignmentProperty = DependencyProperty.Register("LabelHorizontalAlignment",typeof(HorizontalAlignment),typeof(AtomFormLayout), new PropertyMetadata((HorizontalAlignment)HorizontalAlignment.Right));
				#else
				public static DependencyProperty LabelHorizontalAlignmentProperty = DependencyProperty.Register("LabelHorizontalAlignment",typeof(HorizontalAlignment),typeof(AtomFormLayout), new FrameworkPropertyMetadata((HorizontalAlignment)HorizontalAlignment.Right));
								#endif
				
				public HorizontalAlignment LabelHorizontalAlignment{
					get{
						return (HorizontalAlignment)GetValue(LabelHorizontalAlignmentProperty);
					}
					set{
						SetValue(LabelHorizontalAlignmentProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty LabelVerticalAlignmentProperty = DependencyProperty.Register("LabelVerticalAlignment",typeof(VerticalAlignment),typeof(AtomFormLayout), new PropertyMetadata((VerticalAlignment)VerticalAlignment.Center));
				#else
				public static DependencyProperty LabelVerticalAlignmentProperty = DependencyProperty.Register("LabelVerticalAlignment",typeof(VerticalAlignment),typeof(AtomFormLayout), new FrameworkPropertyMetadata((VerticalAlignment)VerticalAlignment.Center));
								#endif
				
				public VerticalAlignment LabelVerticalAlignment{
					get{
						return (VerticalAlignment)GetValue(LabelVerticalAlignmentProperty);
					}
					set{
						SetValue(LabelVerticalAlignmentProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty RowLayoutProperty = DependencyProperty.Register("RowLayout",typeof(String),typeof(AtomFormLayout), new PropertyMetadata(""));
				#else
				public static DependencyProperty RowLayoutProperty = DependencyProperty.Register("RowLayout",typeof(String),typeof(AtomFormLayout), new FrameworkPropertyMetadata(""));
								#endif
				
				public String RowLayout{
					get{
						return (String)GetValue(RowLayoutProperty);
					}
					set{
						SetValue(RowLayoutProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty HorizontalGapProperty = DependencyProperty.Register("HorizontalGap",typeof(Double),typeof(AtomFormLayout), new PropertyMetadata((Double)2));
				#else
				public static DependencyProperty HorizontalGapProperty = DependencyProperty.Register("HorizontalGap",typeof(Double),typeof(AtomFormLayout), new FrameworkPropertyMetadata((Double)2));
								#endif
				
				public Double HorizontalGap{
					get{
						return (Double)GetValue(HorizontalGapProperty);
					}
					set{
						SetValue(HorizontalGapProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty VerticalGapProperty = DependencyProperty.Register("VerticalGap",typeof(Double),typeof(AtomFormLayout), new PropertyMetadata((Double)2));
				#else
				public static DependencyProperty VerticalGapProperty = DependencyProperty.Register("VerticalGap",typeof(Double),typeof(AtomFormLayout), new FrameworkPropertyMetadata((Double)2));
								#endif
				
				public Double VerticalGap{
					get{
						return (Double)GetValue(VerticalGapProperty);
					}
					set{
						SetValue(VerticalGapProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty HeaderBackgroundProperty = DependencyProperty.Register("HeaderBackground",typeof(Brush),typeof(AtomFormLayout), new PropertyMetadata(null));
				#else
				public static DependencyProperty HeaderBackgroundProperty = DependencyProperty.Register("HeaderBackground",typeof(Brush),typeof(AtomFormLayout), new FrameworkPropertyMetadata(null));
								#endif
				
				public Brush HeaderBackground{
					get{
						return (Brush)GetValue(HeaderBackgroundProperty);
					}
					set{
						SetValue(HeaderBackgroundProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty FooterProperty = DependencyProperty.Register("Footer",typeof(Object),typeof(AtomFormLayout), new PropertyMetadata(null));
				#else
				public static DependencyProperty FooterProperty = DependencyProperty.Register("Footer",typeof(Object),typeof(AtomFormLayout), new FrameworkPropertyMetadata(null));
								#endif
				
				public Object Footer{
					get{
						return (Object)GetValue(FooterProperty);
					}
					set{
						SetValue(FooterProperty,value);
					}
				}

			
					}
	

				public partial class AtomTabContent : ContentControl {

			
			public AtomTabContent(){
			
				#if NETFX_CORE || SILVERLIGHT
								#endif
				OnCreate();
			}
			
			static AtomTabContent(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

				
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty HeaderProperty = DependencyProperty.Register("Header",typeof(Object),typeof(AtomTabContent), new PropertyMetadata(null));
				#else
				public static DependencyProperty HeaderProperty = DependencyProperty.Register("Header",typeof(Object),typeof(AtomTabContent), new FrameworkPropertyMetadata(null));
								#endif
				
				public Object Header{
					get{
						return (Object)GetValue(HeaderProperty);
					}
					set{
						SetValue(HeaderProperty,value);
					}
				}

			
					}
	

				public partial class AtomDataForm : AtomFormContainer {

			
			public AtomDataForm(){
			
				#if NETFX_CORE || SILVERLIGHT
									this.DefaultStyleKey = typeof(AtomDataForm);
								#endif
				OnCreate();
			}
			
			static AtomDataForm(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								DefaultStyleKeyProperty.OverrideMetadata(
					typeof(AtomDataForm),
					new FrameworkPropertyMetadata(typeof(AtomDataForm)));
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

				
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty ErrorsProperty = DependencyProperty.Register("Errors",typeof(System.Collections.IList),typeof(AtomDataForm), new PropertyMetadata(null));
				#else
				public static DependencyProperty ErrorsProperty = DependencyProperty.Register("Errors",typeof(System.Collections.IList),typeof(AtomDataForm), new FrameworkPropertyMetadata(null));
								#endif
				
				public System.Collections.IList Errors{
					get{
						return (System.Collections.IList)GetValue(ErrorsProperty);
					}
					set{
						SetValue(ErrorsProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty AutoGenerateFieldsProperty = DependencyProperty.Register("AutoGenerateFields",typeof(Boolean),typeof(AtomDataForm), new PropertyMetadata((bool)false));
				#else
				public static DependencyProperty AutoGenerateFieldsProperty = DependencyProperty.Register("AutoGenerateFields",typeof(Boolean),typeof(AtomDataForm), new FrameworkPropertyMetadata((bool)false));
								#endif
				
				public Boolean AutoGenerateFields{
					get{
						return (Boolean)GetValue(AutoGenerateFieldsProperty);
					}
					set{
						SetValue(AutoGenerateFieldsProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty SaveCommandProperty = DependencyProperty.Register("SaveCommand",typeof(ICommand),typeof(AtomDataForm), new PropertyMetadata(null));
				#else
				public static DependencyProperty SaveCommandProperty = DependencyProperty.Register("SaveCommand",typeof(ICommand),typeof(AtomDataForm), new FrameworkPropertyMetadata(null));
								#endif
				
				public ICommand SaveCommand{
					get{
						return (ICommand)GetValue(SaveCommandProperty);
					}
					set{
						SetValue(SaveCommandProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty EditCommandProperty = DependencyProperty.Register("EditCommand",typeof(ICommand),typeof(AtomDataForm), new PropertyMetadata(null));
				#else
				public static DependencyProperty EditCommandProperty = DependencyProperty.Register("EditCommand",typeof(ICommand),typeof(AtomDataForm), new FrameworkPropertyMetadata(null));
								#endif
				
				public ICommand EditCommand{
					get{
						return (ICommand)GetValue(EditCommandProperty);
					}
					set{
						SetValue(EditCommandProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty CancelCommandProperty = DependencyProperty.Register("CancelCommand",typeof(ICommand),typeof(AtomDataForm), new PropertyMetadata(null));
				#else
				public static DependencyProperty CancelCommandProperty = DependencyProperty.Register("CancelCommand",typeof(ICommand),typeof(AtomDataForm), new FrameworkPropertyMetadata(null));
								#endif
				
				public ICommand CancelCommand{
					get{
						return (ICommand)GetValue(CancelCommandProperty);
					}
					set{
						SetValue(CancelCommandProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty IsReadOnlyProperty = DependencyProperty.Register("IsReadOnly",typeof(Boolean),typeof(AtomDataForm), new PropertyMetadata((bool)true));
				#else
				public static DependencyProperty IsReadOnlyProperty = DependencyProperty.Register("IsReadOnly",typeof(Boolean),typeof(AtomDataForm), new FrameworkPropertyMetadata((bool)true));
								#endif
				
				public Boolean IsReadOnly{
					get{
						return (Boolean)GetValue(IsReadOnlyProperty);
					}
					set{
						SetValue(IsReadOnlyProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty ErrorTitleProperty = DependencyProperty.Register("ErrorTitle",typeof(String),typeof(AtomDataForm), new PropertyMetadata("Errors"));
				#else
				public static DependencyProperty ErrorTitleProperty = DependencyProperty.Register("ErrorTitle",typeof(String),typeof(AtomDataForm), new FrameworkPropertyMetadata("Errors"));
								#endif
				
				public String ErrorTitle{
					get{
						return (String)GetValue(ErrorTitleProperty);
					}
					set{
						SetValue(ErrorTitleProperty,value);
					}
				}

			
					}
	

				public partial class AtomFileSizeLabel : BaseAtomTextBlock {

			
			public AtomFileSizeLabel(){
			
				#if NETFX_CORE || SILVERLIGHT
								#endif
				OnCreate();
			}
			
			static AtomFileSizeLabel(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

				
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty FileSizeTextProperty = DependencyProperty.Register("FileSizeText",typeof(String),typeof(AtomFileSizeLabel), new PropertyMetadata("",OnFileSizeTextChanged));
					#else
					public static DependencyProperty FileSizeTextProperty = DependencyProperty.Register("FileSizeText",typeof(String),typeof(AtomFileSizeLabel), new FrameworkPropertyMetadata("",OnFileSizeTextChanged));
					#endif

					private static void OnFileSizeTextChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomFileSizeLabel)sender).OnFileSizeTextChanged(e);
					}

					protected virtual void OnFileSizeTextChanged(DependencyPropertyChangedEventArgs e){
											OnAfterFileSizeTextChanged(e);
																if(FileSizeTextChanged!=null)
							FileSizeTextChanged(this,e);
										}

										partial void OnAfterFileSizeTextChanged(DependencyPropertyChangedEventArgs e);
															#if NETFX_CORE || SILVERLIGHT
						public event EventHandler<DependencyPropertyChangedEventArgs> FileSizeTextChanged;
					#else
						public event DependencyPropertyChangedEventHandler FileSizeTextChanged;
					#endif
					
				
				public String FileSizeText{
					get{
						return (String)GetValue(FileSizeTextProperty);
					}
					set{
						SetValue(FileSizeTextProperty,value);
					}
				}

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty FileSizeProperty = DependencyProperty.Register("FileSize",typeof(UInt64),typeof(AtomFileSizeLabel), new PropertyMetadata((ulong)0,OnFileSizeChanged));
					#else
					public static DependencyProperty FileSizeProperty = DependencyProperty.Register("FileSize",typeof(UInt64),typeof(AtomFileSizeLabel), new FrameworkPropertyMetadata((ulong)0,OnFileSizeChanged));
					#endif

					private static void OnFileSizeChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomFileSizeLabel)sender).OnFileSizeChanged(e);
					}

					protected virtual void OnFileSizeChanged(DependencyPropertyChangedEventArgs e){
											OnAfterFileSizeChanged(e);
																if(FileSizeChanged!=null)
							FileSizeChanged(this,e);
										}

										partial void OnAfterFileSizeChanged(DependencyPropertyChangedEventArgs e);
															#if NETFX_CORE || SILVERLIGHT
						public event EventHandler<DependencyPropertyChangedEventArgs> FileSizeChanged;
					#else
						public event DependencyPropertyChangedEventHandler FileSizeChanged;
					#endif
					
				
				public UInt64 FileSize{
					get{
						return (UInt64)GetValue(FileSizeProperty);
					}
					set{
						SetValue(FileSizeProperty,value);
					}
				}

			
					}
	

				public partial class AtomPasswordBox : Border {

			
			public AtomPasswordBox(){
			
				#if NETFX_CORE || SILVERLIGHT
								#endif
				OnCreate();
			}
			
			static AtomPasswordBox(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

				
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty PasswordProperty = DependencyProperty.Register("Password",typeof(String),typeof(AtomPasswordBox), new PropertyMetadata(null,OnPasswordChanged));
					#else
					public static DependencyProperty PasswordProperty = DependencyProperty.Register("Password",typeof(String),typeof(AtomPasswordBox), new FrameworkPropertyMetadata(null,OnPasswordChanged));
					#endif

					private static void OnPasswordChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomPasswordBox)sender).OnPasswordChanged(e);
					}

					protected virtual void OnPasswordChanged(DependencyPropertyChangedEventArgs e){
											OnAfterPasswordChanged(e);
																if(PasswordChanged!=null)
							PasswordChanged(this,e);
										}

										partial void OnAfterPasswordChanged(DependencyPropertyChangedEventArgs e);
															#if NETFX_CORE || SILVERLIGHT
						public event EventHandler<DependencyPropertyChangedEventArgs> PasswordChanged;
					#else
						public event DependencyPropertyChangedEventHandler PasswordChanged;
					#endif
					
				
				public String Password{
					get{
						return (String)GetValue(PasswordProperty);
					}
					set{
						SetValue(PasswordProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty MinimumLengthProperty = AtomStringValidationRule.MinimumLengthProperty;
				#else
				public static DependencyProperty MinimumLengthProperty = AtomStringValidationRule.MinimumLengthProperty.AddOwner(typeof(AtomPasswordBox));
								#endif
				
				public Int32 MinimumLength{
					get{
						return (Int32)GetValue(MinimumLengthProperty);
					}
					set{
						SetValue(MinimumLengthProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty MinimumLengthErrorMessageProperty = AtomStringValidationRule.MinimumLengthErrorMessageProperty;
				#else
				public static DependencyProperty MinimumLengthErrorMessageProperty = AtomStringValidationRule.MinimumLengthErrorMessageProperty.AddOwner(typeof(AtomPasswordBox));
								#endif
				
				public String MinimumLengthErrorMessage{
					get{
						return (String)GetValue(MinimumLengthErrorMessageProperty);
					}
					set{
						SetValue(MinimumLengthErrorMessageProperty,value);
					}
				}

			
					}
	

				public partial class AtomPasswordBoxAgain : AtomPasswordBox {

			
			public AtomPasswordBoxAgain(){
			
				#if NETFX_CORE || SILVERLIGHT
								#endif
				OnCreate();
			}
			
			static AtomPasswordBoxAgain(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

				
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty FirstPasswordBoxNameProperty = DependencyProperty.Register("FirstPasswordBoxName",typeof(String),typeof(AtomPasswordBoxAgain), new PropertyMetadata(null));
				#else
				public static DependencyProperty FirstPasswordBoxNameProperty = DependencyProperty.Register("FirstPasswordBoxName",typeof(String),typeof(AtomPasswordBoxAgain), new FrameworkPropertyMetadata(null));
								#endif
				
				public String FirstPasswordBoxName{
					get{
						return (String)GetValue(FirstPasswordBoxNameProperty);
					}
					set{
						SetValue(FirstPasswordBoxNameProperty,value);
					}
				}

			
					}
	

				public partial class AtomViewPanel : Panel {

			
			public AtomViewPanel(){
			
				#if NETFX_CORE || SILVERLIGHT
								#endif
				OnCreate();
			}
			
			static AtomViewPanel(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

				
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty SelectedIndexProperty = DependencyProperty.Register("SelectedIndex",typeof(Int32),typeof(AtomViewPanel), new PropertyMetadata((int)-1,OnSelectedIndexChanged));
					#else
					public static DependencyProperty SelectedIndexProperty = DependencyProperty.Register("SelectedIndex",typeof(Int32),typeof(AtomViewPanel), new FrameworkPropertyMetadata((int)-1,OnSelectedIndexChanged));
					#endif

					private static void OnSelectedIndexChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomViewPanel)sender).OnSelectedIndexChanged(e);
					}

					protected virtual void OnSelectedIndexChanged(DependencyPropertyChangedEventArgs e){
											OnAfterSelectedIndexChanged(e);
																if(SelectedIndexChanged!=null)
							SelectedIndexChanged(this,e);
										}

										partial void OnAfterSelectedIndexChanged(DependencyPropertyChangedEventArgs e);
															#if NETFX_CORE || SILVERLIGHT
						public event EventHandler<DependencyPropertyChangedEventArgs> SelectedIndexChanged;
					#else
						public event DependencyPropertyChangedEventHandler SelectedIndexChanged;
					#endif
					
				
				public Int32 SelectedIndex{
					get{
						return (Int32)GetValue(SelectedIndexProperty);
					}
					set{
						SetValue(SelectedIndexProperty,value);
					}
				}

			
					}
	

				public partial class BaseAtomTextBlock : TextBlock {

			
			public BaseAtomTextBlock(){
			
				#if NETFX_CORE || SILVERLIGHT
								#endif
				OnCreate();
			}
			
			static BaseAtomTextBlock(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

				
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty IsRequiredProperty = DependencyProperty.Register("IsRequired",typeof(Boolean),typeof(BaseAtomTextBlock), new PropertyMetadata(null));
				#else
				public static DependencyProperty IsRequiredProperty = DependencyProperty.Register("IsRequired",typeof(Boolean),typeof(BaseAtomTextBlock), new FrameworkPropertyMetadata(null));
								#endif
				
				public Boolean IsRequired{
					get{
						return (Boolean)GetValue(IsRequiredProperty);
					}
					set{
						SetValue(IsRequiredProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty LabelProperty = DependencyProperty.Register("Label",typeof(String),typeof(BaseAtomTextBlock), new PropertyMetadata(null));
				#else
				public static DependencyProperty LabelProperty = DependencyProperty.Register("Label",typeof(String),typeof(BaseAtomTextBlock), new FrameworkPropertyMetadata(null));
								#endif
				
				public String Label{
					get{
						return (String)GetValue(LabelProperty);
					}
					set{
						SetValue(LabelProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty DescriptionProperty = DependencyProperty.Register("Description",typeof(String),typeof(BaseAtomTextBlock), new PropertyMetadata(null));
				#else
				public static DependencyProperty DescriptionProperty = DependencyProperty.Register("Description",typeof(String),typeof(BaseAtomTextBlock), new FrameworkPropertyMetadata(null));
								#endif
				
				public String Description{
					get{
						return (String)GetValue(DescriptionProperty);
					}
					set{
						SetValue(DescriptionProperty,value);
					}
				}

											#if NETFX_CORE || SILVERLIGHT
								public static DependencyProperty TitleProperty = DependencyProperty.Register("Title",typeof(String),typeof(BaseAtomTextBlock), new PropertyMetadata(null));
				#else
				public static DependencyProperty TitleProperty = DependencyProperty.Register("Title",typeof(String),typeof(BaseAtomTextBlock), new FrameworkPropertyMetadata(null));
								#endif
				
				public String Title{
					get{
						return (String)GetValue(TitleProperty);
					}
					set{
						SetValue(TitleProperty,value);
					}
				}

			
					}
	

				public partial class AtomSplitView : Grid {

			
			public AtomSplitView(){
			
				#if NETFX_CORE || SILVERLIGHT
								#endif
				OnCreate();
			}
			
			static AtomSplitView(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

				
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty OrientationProperty = DependencyProperty.Register("Orientation",typeof(Orientation),typeof(AtomSplitView), new PropertyMetadata((Orientation)Orientation.Horizontal,OnOrientationChanged));
					#else
					public static DependencyProperty OrientationProperty = DependencyProperty.Register("Orientation",typeof(Orientation),typeof(AtomSplitView), new FrameworkPropertyMetadata((Orientation)Orientation.Horizontal,OnOrientationChanged));
					#endif

					private static void OnOrientationChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomSplitView)sender).OnOrientationChanged(e);
					}

					protected virtual void OnOrientationChanged(DependencyPropertyChangedEventArgs e){
											OnAfterOrientationChanged(e);
																if(OrientationChanged!=null)
							OrientationChanged(this,e);
										}

										partial void OnAfterOrientationChanged(DependencyPropertyChangedEventArgs e);
															#if NETFX_CORE || SILVERLIGHT
						public event EventHandler<DependencyPropertyChangedEventArgs> OrientationChanged;
					#else
						public event DependencyPropertyChangedEventHandler OrientationChanged;
					#endif
					
				
				public Orientation Orientation{
					get{
						return (Orientation)GetValue(OrientationProperty);
					}
					set{
						SetValue(OrientationProperty,value);
					}
				}

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty ItemsProperty = DependencyProperty.Register("Items",typeof(ObservableCollection<UIElement>),typeof(AtomSplitView), new PropertyMetadata(null,OnItemsChanged));
					#else
					public static DependencyProperty ItemsProperty = DependencyProperty.Register("Items",typeof(ObservableCollection<UIElement>),typeof(AtomSplitView), new FrameworkPropertyMetadata(null,OnItemsChanged));
					#endif

					private static void OnItemsChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomSplitView)sender).OnItemsChanged(e);
					}

					protected virtual void OnItemsChanged(DependencyPropertyChangedEventArgs e){
											OnAfterItemsChanged(e);
																if(ItemsChanged!=null)
							ItemsChanged(this,e);
										}

										partial void OnAfterItemsChanged(DependencyPropertyChangedEventArgs e);
															#if NETFX_CORE || SILVERLIGHT
						public event EventHandler<DependencyPropertyChangedEventArgs> ItemsChanged;
					#else
						public event DependencyPropertyChangedEventHandler ItemsChanged;
					#endif
					
				
				public ObservableCollection<UIElement> Items{
					get{
						return (ObservableCollection<UIElement>)GetValue(ItemsProperty);
					}
					set{
						SetValue(ItemsProperty,value);
					}
				}

			
					}
	

				public partial class AtomWrapPanel : Panel {

			
			public AtomWrapPanel(){
			
				#if NETFX_CORE || SILVERLIGHT
								#endif
				OnCreate();
			}
			
			static AtomWrapPanel(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

				
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty HorizontalGapProperty = DependencyProperty.Register("HorizontalGap",typeof(Int32),typeof(AtomWrapPanel), new PropertyMetadata((int)4,OnHorizontalGapChanged));
					#else
					public static DependencyProperty HorizontalGapProperty = DependencyProperty.Register("HorizontalGap",typeof(Int32),typeof(AtomWrapPanel), new FrameworkPropertyMetadata((int)4,OnHorizontalGapChanged));
					#endif

					private static void OnHorizontalGapChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomWrapPanel)sender).OnHorizontalGapChanged(e);
					}

					protected virtual void OnHorizontalGapChanged(DependencyPropertyChangedEventArgs e){
											OnAfterHorizontalGapChanged(e);
																if(HorizontalGapChanged!=null)
							HorizontalGapChanged(this,e);
										}

										partial void OnAfterHorizontalGapChanged(DependencyPropertyChangedEventArgs e);
															#if NETFX_CORE || SILVERLIGHT
						public event EventHandler<DependencyPropertyChangedEventArgs> HorizontalGapChanged;
					#else
						public event DependencyPropertyChangedEventHandler HorizontalGapChanged;
					#endif
					
				
				public Int32 HorizontalGap{
					get{
						return (Int32)GetValue(HorizontalGapProperty);
					}
					set{
						SetValue(HorizontalGapProperty,value);
					}
				}

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty VerticalGapProperty = DependencyProperty.Register("VerticalGap",typeof(Int32),typeof(AtomWrapPanel), new PropertyMetadata((int)4,OnVerticalGapChanged));
					#else
					public static DependencyProperty VerticalGapProperty = DependencyProperty.Register("VerticalGap",typeof(Int32),typeof(AtomWrapPanel), new FrameworkPropertyMetadata((int)4,OnVerticalGapChanged));
					#endif

					private static void OnVerticalGapChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomWrapPanel)sender).OnVerticalGapChanged(e);
					}

					protected virtual void OnVerticalGapChanged(DependencyPropertyChangedEventArgs e){
											OnAfterVerticalGapChanged(e);
																if(VerticalGapChanged!=null)
							VerticalGapChanged(this,e);
										}

										partial void OnAfterVerticalGapChanged(DependencyPropertyChangedEventArgs e);
															#if NETFX_CORE || SILVERLIGHT
						public event EventHandler<DependencyPropertyChangedEventArgs> VerticalGapChanged;
					#else
						public event DependencyPropertyChangedEventHandler VerticalGapChanged;
					#endif
					
				
				public Int32 VerticalGap{
					get{
						return (Int32)GetValue(VerticalGapProperty);
					}
					set{
						SetValue(VerticalGapProperty,value);
					}
				}

			
					}
	

				public partial class AtomFlexibleGrid : Panel {

			
			public AtomFlexibleGrid(){
			
				#if NETFX_CORE || SILVERLIGHT
								#endif
				OnCreate();
			}
			
			static AtomFlexibleGrid(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

				
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty RowLayoutProperty = DependencyProperty.Register("RowLayout",typeof(String),typeof(AtomFlexibleGrid), new PropertyMetadata("",OnRowLayoutChanged));
					#else
					public static DependencyProperty RowLayoutProperty = DependencyProperty.Register("RowLayout",typeof(String),typeof(AtomFlexibleGrid), new FrameworkPropertyMetadata("",OnRowLayoutChanged));
					#endif

					private static void OnRowLayoutChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomFlexibleGrid)sender).OnRowLayoutChanged(e);
					}

					protected virtual void OnRowLayoutChanged(DependencyPropertyChangedEventArgs e){
											OnAfterRowLayoutChanged(e);
															}

										partial void OnAfterRowLayoutChanged(DependencyPropertyChangedEventArgs e);
										
				
				public String RowLayout{
					get{
						return (String)GetValue(RowLayoutProperty);
					}
					set{
						SetValue(RowLayoutProperty,value);
					}
				}

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty HorizontalGapProperty = DependencyProperty.Register("HorizontalGap",typeof(Double),typeof(AtomFlexibleGrid), new PropertyMetadata((Double)2,OnHorizontalGapChanged));
					#else
					public static DependencyProperty HorizontalGapProperty = DependencyProperty.Register("HorizontalGap",typeof(Double),typeof(AtomFlexibleGrid), new FrameworkPropertyMetadata((Double)2,OnHorizontalGapChanged));
					#endif

					private static void OnHorizontalGapChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomFlexibleGrid)sender).OnHorizontalGapChanged(e);
					}

					protected virtual void OnHorizontalGapChanged(DependencyPropertyChangedEventArgs e){
											OnAfterHorizontalGapChanged(e);
															}

										partial void OnAfterHorizontalGapChanged(DependencyPropertyChangedEventArgs e);
										
				
				public Double HorizontalGap{
					get{
						return (Double)GetValue(HorizontalGapProperty);
					}
					set{
						SetValue(HorizontalGapProperty,value);
					}
				}

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty VerticalGapProperty = DependencyProperty.Register("VerticalGap",typeof(Double),typeof(AtomFlexibleGrid), new PropertyMetadata((Double)2,OnVerticalGapChanged));
					#else
					public static DependencyProperty VerticalGapProperty = DependencyProperty.Register("VerticalGap",typeof(Double),typeof(AtomFlexibleGrid), new FrameworkPropertyMetadata((Double)2,OnVerticalGapChanged));
					#endif

					private static void OnVerticalGapChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomFlexibleGrid)sender).OnVerticalGapChanged(e);
					}

					protected virtual void OnVerticalGapChanged(DependencyPropertyChangedEventArgs e){
											OnAfterVerticalGapChanged(e);
															}

										partial void OnAfterVerticalGapChanged(DependencyPropertyChangedEventArgs e);
										
				
				public Double VerticalGap{
					get{
						return (Double)GetValue(VerticalGapProperty);
					}
					set{
						SetValue(VerticalGapProperty,value);
					}
				}

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty SelectedIndexProperty = DependencyProperty.Register("SelectedIndex",typeof(Int32),typeof(AtomFlexibleGrid), new PropertyMetadata((int)-1,OnSelectedIndexChanged));
					#else
					public static DependencyProperty SelectedIndexProperty = DependencyProperty.Register("SelectedIndex",typeof(Int32),typeof(AtomFlexibleGrid), new FrameworkPropertyMetadata((int)-1,OnSelectedIndexChanged));
					#endif

					private static void OnSelectedIndexChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomFlexibleGrid)sender).OnSelectedIndexChanged(e);
					}

					protected virtual void OnSelectedIndexChanged(DependencyPropertyChangedEventArgs e){
											OnAfterSelectedIndexChanged(e);
																if(SelectedIndexChanged!=null)
							SelectedIndexChanged(this,e);
										}

										partial void OnAfterSelectedIndexChanged(DependencyPropertyChangedEventArgs e);
															#if NETFX_CORE || SILVERLIGHT
						public event EventHandler<DependencyPropertyChangedEventArgs> SelectedIndexChanged;
					#else
						public event DependencyPropertyChangedEventHandler SelectedIndexChanged;
					#endif
					
				
				public Int32 SelectedIndex{
					get{
						return (Int32)GetValue(SelectedIndexProperty);
					}
					set{
						SetValue(SelectedIndexProperty,value);
					}
				}

			
					}
	

				public partial class AtomStackPanel : Panel {

			
			public AtomStackPanel(){
			
				#if NETFX_CORE || SILVERLIGHT
								#endif
				OnCreate();
			}
			
			static AtomStackPanel(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

				
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty HorizontalGapProperty = DependencyProperty.Register("HorizontalGap",typeof(Double),typeof(AtomStackPanel), new PropertyMetadata((Double)2,OnHorizontalGapChanged));
					#else
					public static DependencyProperty HorizontalGapProperty = DependencyProperty.Register("HorizontalGap",typeof(Double),typeof(AtomStackPanel), new FrameworkPropertyMetadata((Double)2,OnHorizontalGapChanged));
					#endif

					private static void OnHorizontalGapChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomStackPanel)sender).OnHorizontalGapChanged(e);
					}

					protected virtual void OnHorizontalGapChanged(DependencyPropertyChangedEventArgs e){
											OnAfterHorizontalGapChanged(e);
																if(HorizontalGapChanged!=null)
							HorizontalGapChanged(this,e);
										}

										partial void OnAfterHorizontalGapChanged(DependencyPropertyChangedEventArgs e);
															#if NETFX_CORE || SILVERLIGHT
						public event EventHandler<DependencyPropertyChangedEventArgs> HorizontalGapChanged;
					#else
						public event DependencyPropertyChangedEventHandler HorizontalGapChanged;
					#endif
					
				
				public Double HorizontalGap{
					get{
						return (Double)GetValue(HorizontalGapProperty);
					}
					set{
						SetValue(HorizontalGapProperty,value);
					}
				}

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty VerticalGapProperty = DependencyProperty.Register("VerticalGap",typeof(Double),typeof(AtomStackPanel), new PropertyMetadata((Double)2,OnVerticalGapChanged));
					#else
					public static DependencyProperty VerticalGapProperty = DependencyProperty.Register("VerticalGap",typeof(Double),typeof(AtomStackPanel), new FrameworkPropertyMetadata((Double)2,OnVerticalGapChanged));
					#endif

					private static void OnVerticalGapChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomStackPanel)sender).OnVerticalGapChanged(e);
					}

					protected virtual void OnVerticalGapChanged(DependencyPropertyChangedEventArgs e){
											OnAfterVerticalGapChanged(e);
																if(VerticalGapChanged!=null)
							VerticalGapChanged(this,e);
										}

										partial void OnAfterVerticalGapChanged(DependencyPropertyChangedEventArgs e);
															#if NETFX_CORE || SILVERLIGHT
						public event EventHandler<DependencyPropertyChangedEventArgs> VerticalGapChanged;
					#else
						public event DependencyPropertyChangedEventHandler VerticalGapChanged;
					#endif
					
				
				public Double VerticalGap{
					get{
						return (Double)GetValue(VerticalGapProperty);
					}
					set{
						SetValue(VerticalGapProperty,value);
					}
				}

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty OrientationProperty = DependencyProperty.Register("Orientation",typeof(Orientation),typeof(AtomStackPanel), new PropertyMetadata((Orientation)Orientation.Horizontal,OnOrientationChanged));
					#else
					public static DependencyProperty OrientationProperty = DependencyProperty.Register("Orientation",typeof(Orientation),typeof(AtomStackPanel), new FrameworkPropertyMetadata((Orientation)Orientation.Horizontal,OnOrientationChanged));
					#endif

					private static void OnOrientationChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomStackPanel)sender).OnOrientationChanged(e);
					}

					protected virtual void OnOrientationChanged(DependencyPropertyChangedEventArgs e){
											OnAfterOrientationChanged(e);
																if(OrientationChanged!=null)
							OrientationChanged(this,e);
										}

										partial void OnAfterOrientationChanged(DependencyPropertyChangedEventArgs e);
															#if NETFX_CORE || SILVERLIGHT
						public event EventHandler<DependencyPropertyChangedEventArgs> OrientationChanged;
					#else
						public event DependencyPropertyChangedEventHandler OrientationChanged;
					#endif
					
				
				public Orientation Orientation{
					get{
						return (Orientation)GetValue(OrientationProperty);
					}
					set{
						SetValue(OrientationProperty,value);
					}
				}

			
					}
	

				public partial class AtomUniformGrid : Panel {

			
			public AtomUniformGrid(){
			
				#if NETFX_CORE || SILVERLIGHT
								#endif
				OnCreate();
			}
			
			static AtomUniformGrid(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

				
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty FirstColumnProperty = DependencyProperty.Register("FirstColumn",typeof(Int32),typeof(AtomUniformGrid), new PropertyMetadata((int)0,OnFirstColumnChanged));
					#else
					public static DependencyProperty FirstColumnProperty = DependencyProperty.Register("FirstColumn",typeof(Int32),typeof(AtomUniformGrid), new FrameworkPropertyMetadata((int)0,OnFirstColumnChanged));
					#endif

					private static void OnFirstColumnChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomUniformGrid)sender).OnFirstColumnChanged(e);
					}

					protected virtual void OnFirstColumnChanged(DependencyPropertyChangedEventArgs e){
											OnAfterFirstColumnChanged(e);
															}

										partial void OnAfterFirstColumnChanged(DependencyPropertyChangedEventArgs e);
										
				
				public Int32 FirstColumn{
					get{
						return (Int32)GetValue(FirstColumnProperty);
					}
					set{
						SetValue(FirstColumnProperty,value);
					}
				}

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty ColumnsProperty = DependencyProperty.Register("Columns",typeof(Int32),typeof(AtomUniformGrid), new PropertyMetadata((int)0,OnColumnsChanged));
					#else
					public static DependencyProperty ColumnsProperty = DependencyProperty.Register("Columns",typeof(Int32),typeof(AtomUniformGrid), new FrameworkPropertyMetadata((int)0,OnColumnsChanged));
					#endif

					private static void OnColumnsChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomUniformGrid)sender).OnColumnsChanged(e);
					}

					protected virtual void OnColumnsChanged(DependencyPropertyChangedEventArgs e){
											OnAfterColumnsChanged(e);
															}

										partial void OnAfterColumnsChanged(DependencyPropertyChangedEventArgs e);
										
				
				public Int32 Columns{
					get{
						return (Int32)GetValue(ColumnsProperty);
					}
					set{
						SetValue(ColumnsProperty,value);
					}
				}

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty RowsProperty = DependencyProperty.Register("Rows",typeof(Int32),typeof(AtomUniformGrid), new PropertyMetadata((int)0,OnRowsChanged));
					#else
					public static DependencyProperty RowsProperty = DependencyProperty.Register("Rows",typeof(Int32),typeof(AtomUniformGrid), new FrameworkPropertyMetadata((int)0,OnRowsChanged));
					#endif

					private static void OnRowsChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomUniformGrid)sender).OnRowsChanged(e);
					}

					protected virtual void OnRowsChanged(DependencyPropertyChangedEventArgs e){
											OnAfterRowsChanged(e);
															}

										partial void OnAfterRowsChanged(DependencyPropertyChangedEventArgs e);
										
				
				public Int32 Rows{
					get{
						return (Int32)GetValue(RowsProperty);
					}
					set{
						SetValue(RowsProperty,value);
					}
				}

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty HorizontalGapProperty = DependencyProperty.Register("HorizontalGap",typeof(Int32),typeof(AtomUniformGrid), new PropertyMetadata((int)4,OnHorizontalGapChanged));
					#else
					public static DependencyProperty HorizontalGapProperty = DependencyProperty.Register("HorizontalGap",typeof(Int32),typeof(AtomUniformGrid), new FrameworkPropertyMetadata((int)4,OnHorizontalGapChanged));
					#endif

					private static void OnHorizontalGapChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomUniformGrid)sender).OnHorizontalGapChanged(e);
					}

					protected virtual void OnHorizontalGapChanged(DependencyPropertyChangedEventArgs e){
											OnAfterHorizontalGapChanged(e);
															}

										partial void OnAfterHorizontalGapChanged(DependencyPropertyChangedEventArgs e);
										
				
				public Int32 HorizontalGap{
					get{
						return (Int32)GetValue(HorizontalGapProperty);
					}
					set{
						SetValue(HorizontalGapProperty,value);
					}
				}

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty VerticalGapProperty = DependencyProperty.Register("VerticalGap",typeof(Int32),typeof(AtomUniformGrid), new PropertyMetadata((int)4,OnVerticalGapChanged));
					#else
					public static DependencyProperty VerticalGapProperty = DependencyProperty.Register("VerticalGap",typeof(Int32),typeof(AtomUniformGrid), new FrameworkPropertyMetadata((int)4,OnVerticalGapChanged));
					#endif

					private static void OnVerticalGapChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomUniformGrid)sender).OnVerticalGapChanged(e);
					}

					protected virtual void OnVerticalGapChanged(DependencyPropertyChangedEventArgs e){
											OnAfterVerticalGapChanged(e);
															}

										partial void OnAfterVerticalGapChanged(DependencyPropertyChangedEventArgs e);
										
				
				public Int32 VerticalGap{
					get{
						return (Int32)GetValue(VerticalGapProperty);
					}
					set{
						SetValue(VerticalGapProperty,value);
					}
				}

			
					}
	

				public partial class AtomToggleButtonBar : AtomListBox {

			
			public AtomToggleButtonBar(){
			
				#if NETFX_CORE || SILVERLIGHT
									this.DefaultStyleKey = typeof(AtomToggleButtonBar);
								#endif
				OnCreate();
			}
			
			static AtomToggleButtonBar(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								DefaultStyleKeyProperty.OverrideMetadata(
					typeof(AtomToggleButtonBar),
					new FrameworkPropertyMetadata(typeof(AtomToggleButtonBar)));
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

				
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

			
					}
	

				public partial class AtomToggleButtonBarItem : ListBoxItem {

			
			public AtomToggleButtonBarItem(){
			
				#if NETFX_CORE || SILVERLIGHT
									this.DefaultStyleKey = typeof(AtomToggleButtonBarItem);
								#endif
				OnCreate();
			}
			
			static AtomToggleButtonBarItem(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								DefaultStyleKeyProperty.OverrideMetadata(
					typeof(AtomToggleButtonBarItem),
					new FrameworkPropertyMetadata(typeof(AtomToggleButtonBarItem)));
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

				
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

			
					}
	

				public partial class AtomCountryCheckBoxList : Control {

			
			public AtomCountryCheckBoxList(){
			
				#if NETFX_CORE || SILVERLIGHT
									this.DefaultStyleKey = typeof(AtomCountryCheckBoxList);
								#endif
				OnCreate();
			}
			
			static AtomCountryCheckBoxList(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								DefaultStyleKeyProperty.OverrideMetadata(
					typeof(AtomCountryCheckBoxList),
					new FrameworkPropertyMetadata(typeof(AtomCountryCheckBoxList)));
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

				
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

			
					}
	

				public partial class AtomComboBoxItemWithFilter : ComboBoxItem {

			
			public AtomComboBoxItemWithFilter(){
			
				#if NETFX_CORE || SILVERLIGHT
									this.DefaultStyleKey = typeof(AtomComboBoxItemWithFilter);
								#endif
				OnCreate();
			}
			
			static AtomComboBoxItemWithFilter(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								DefaultStyleKeyProperty.OverrideMetadata(
					typeof(AtomComboBoxItemWithFilter),
					new FrameworkPropertyMetadata(typeof(AtomComboBoxItemWithFilter)));
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

				
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

			
					}
	

				public partial class AtomCountryComboBox : AtomComboBox {

			
			public AtomCountryComboBox(){
			
				#if NETFX_CORE || SILVERLIGHT
									this.DefaultStyleKey = typeof(AtomCountryComboBox);
								#endif
				OnCreate();
			}
			
			static AtomCountryComboBox(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								DefaultStyleKeyProperty.OverrideMetadata(
					typeof(AtomCountryComboBox),
					new FrameworkPropertyMetadata(typeof(AtomCountryComboBox)));
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

				
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

			
					}
	

				public partial class AtomNumberContainerControl : AtomContainerControl {

			
			public AtomNumberContainerControl(){
			
				#if NETFX_CORE || SILVERLIGHT
									this.DefaultStyleKey = typeof(AtomNumberContainerControl);
								#endif
				OnCreate();
			}
			
			static AtomNumberContainerControl(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								DefaultStyleKeyProperty.OverrideMetadata(
					typeof(AtomNumberContainerControl),
					new FrameworkPropertyMetadata(typeof(AtomNumberContainerControl)));
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

				
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

			
					}
	

					[TemplatePart(Name="PART_Code",Type=typeof(RichTextBox))]
				public partial class AtomCodeViewer : Control {

			
			public AtomCodeViewer(){
			
				#if NETFX_CORE || SILVERLIGHT
									this.DefaultStyleKey = typeof(AtomCodeViewer);
								#endif
				OnCreate();
			}
			
			static AtomCodeViewer(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								DefaultStyleKeyProperty.OverrideMetadata(
					typeof(AtomCodeViewer),
					new FrameworkPropertyMetadata(typeof(AtomCodeViewer)));
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
							protected RichTextBox PART_Code;
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

									PART_Code = GetTemplateChild("PART_Code") as RichTextBox;
											if(PART_Code == null)
							throw new InvalidOperationException("Part PART_Code(RichTextBox) is not defined in template of AtomCodeViewer");
									
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty TextProperty = DependencyProperty.Register("Text",typeof(String),typeof(AtomCodeViewer), new PropertyMetadata("",OnTextChanged));
					#else
					public static DependencyProperty TextProperty = DependencyProperty.Register("Text",typeof(String),typeof(AtomCodeViewer), new FrameworkPropertyMetadata("",OnTextChanged));
					#endif

					private static void OnTextChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomCodeViewer)sender).OnTextChanged(e);
					}

					protected virtual void OnTextChanged(DependencyPropertyChangedEventArgs e){
											OnAfterTextChanged(e);
																if(TextChanged!=null)
							TextChanged(this,e);
										}

										partial void OnAfterTextChanged(DependencyPropertyChangedEventArgs e);
															#if NETFX_CORE || SILVERLIGHT
						public event EventHandler<DependencyPropertyChangedEventArgs> TextChanged;
					#else
						public event DependencyPropertyChangedEventHandler TextChanged;
					#endif
					
				
				public String Text{
					get{
						return (String)GetValue(TextProperty);
					}
					set{
						SetValue(TextProperty,value);
					}
				}

												#if NETFX_CORE || SILVERLIGHT
					public static DependencyProperty FormatterProperty = DependencyProperty.Register("Formatter",typeof(AtomCodeFormatter),typeof(AtomCodeViewer), new PropertyMetadata(null,OnFormatterChanged));
					#else
					public static DependencyProperty FormatterProperty = DependencyProperty.Register("Formatter",typeof(AtomCodeFormatter),typeof(AtomCodeViewer), new FrameworkPropertyMetadata(null,OnFormatterChanged));
					#endif

					private static void OnFormatterChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e){
						((AtomCodeViewer)sender).OnFormatterChanged(e);
					}

					protected virtual void OnFormatterChanged(DependencyPropertyChangedEventArgs e){
											OnAfterFormatterChanged(e);
																if(FormatterChanged!=null)
							FormatterChanged(this,e);
										}

										partial void OnAfterFormatterChanged(DependencyPropertyChangedEventArgs e);
															#if NETFX_CORE || SILVERLIGHT
						public event EventHandler<DependencyPropertyChangedEventArgs> FormatterChanged;
					#else
						public event DependencyPropertyChangedEventHandler FormatterChanged;
					#endif
					
				
				public AtomCodeFormatter Formatter{
					get{
						return (AtomCodeFormatter)GetValue(FormatterProperty);
					}
					set{
						SetValue(FormatterProperty,value);
					}
				}

			
					}
	

				public partial class AtomTraceView : Control {

			
			public AtomTraceView(){
			
				#if NETFX_CORE || SILVERLIGHT
									this.DefaultStyleKey = typeof(AtomTraceView);
								#endif
				OnCreate();
			}
			
			static AtomTraceView(){
				#if NETFX_CORE || SILVERLIGHT
				#else
								DefaultStyleKeyProperty.OverrideMetadata(
					typeof(AtomTraceView),
					new FrameworkPropertyMetadata(typeof(AtomTraceView)));
								#endif
				OnCreateStatic();
			}
			
			static partial void OnCreateStatic();
			
			partial void OnCreate();
			
			
			public override void OnApplyTemplate(){
				base.OnApplyTemplate();

				
				OnAfterTemplateApplied();

			}

			partial void OnAfterTemplateApplied();

			
					}
		}
