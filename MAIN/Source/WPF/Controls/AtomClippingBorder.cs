#if NETFX_CORE
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml;
#else
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeuroSpeech.UIAtoms.Controls
{
    
    
    /// <summary>    
    /// Clips the child and makes it visible only inside the border, useful in rounded corner borderes.
    /// </summary>    
    public class AtomClippingBorder : Border {    
    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dc"></param>
        protected override void OnRender(DrawingContext dc) 
        {            
            OnApplyChildClip();                        
            base.OnRender(dc);        
        }   
     
        /// <summary>
        /// 
        /// </summary>
        public override UIElement Child         
        {            
            get{                
                return base.Child;
            }
            set            
            {                
                if (this.Child != value)                
                {                    
                    if(this.Child != null)                    
                    {                        
                        // Restore original clipping                        
                        this.Child.SetValue(UIElement.ClipProperty, _oldClip);                    
                    }                    
                    if(value != null)                    
                    {                        
                        _oldClip = value.ReadLocalValue(UIElement.ClipProperty);                    
                    }                   
                    else                 
                    {                    
                        // If we dont set it to null we could leak a Geometry object  
                        _oldClip = null;                   
                    }                 
                    base.Child = value;     
                }          
            }      
        }       

        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnApplyChildClip()        
        {          
            UIElement child = this.Child;   
            if(child != null)         
            {               
                _clipRect.RadiusX = _clipRect.RadiusY = Math.Max(0.0, this.CornerRadius.TopLeft - (this.BorderThickness.Left * 0.5));
                _clipRect.Rect = new Rect(Child.RenderSize);       
                child.Clip = _clipRect;     
            }   
        }      
        
        private RectangleGeometry _clipRect = new RectangleGeometry();
        private object _oldClip;    
    }
}
