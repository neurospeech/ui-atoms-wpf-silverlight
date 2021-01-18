#if WINRT
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;
#else
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuroSpeech.UIAtoms.Core;
using System.ComponentModel;
using System.Threading;

namespace NeuroSpeech.UIAtoms.Controls
{
//    /// <summary>
//    /// </summary>

//    [TemplateVisualState(Name = "Normal")]
//    [TemplateVisualState(Name = "Running")]
//    [TemplateVisualState(Name = "Cancelled")]
//    [TemplateVisualState(Name = "Failed")]
//    [TemplateVisualState(Name = "Successful")]
//    public class AtomTask : Control
//    {


//#if SILVERLIGHT
//        public AtomTask()
//        {
//            DefaultStyleKey = typeof(AtomTask);
//        }
//#else
//        static AtomTask()
//        {
//            DefaultStyleKeyProperty.OverrideMetadata(typeof(AtomTask), new FrameworkPropertyMetadata(typeof(AtomTask)));
//        }
//#endif

//        ///<summary>
//        /// Dependency Property RunInNewThread
//        ///</summary>
//        #region Dependency Property RunInNewThread
//        [AtomDesign(
//          Category = "Atoms",
//          Bindable = true,
//          BrowseMode = AtomPropertyBrowseMode.Default
//        )]
//        public bool RunInNewThread
//        {
//            get { return (bool)GetValue(RunInNewThreadProperty); }
//            set { SetValue(RunInNewThreadProperty, value); }
//        }

//        ///<summary>
//        /// Using a DependencyProperty as the backing store for RunInNewThread.  This enables animation, styling, binding, etc...
//        ///</summary>
//#if SILVERLIGHT
//        public static readonly DependencyProperty RunInNewThreadProperty = 
//            DependencyProperty.Register("RunInNewThread", typeof(bool), typeof(AtomTask), new PropertyMetadata(true));
//#else
//        public static readonly DependencyProperty RunInNewThreadProperty =
//            DependencyProperty.Register("RunInNewThread", typeof(bool), typeof(AtomTask), new FrameworkPropertyMetadata(true));
//#endif

//        #endregion



//        ///<summary>
//        /// Dependency Property TaskStatus
//        ///</summary>
//        #region Dependency Property TaskStatus
//        [AtomDesign(
//          Category = "Atoms",
//          Bindable = true,
//          BrowseMode = AtomPropertyBrowseMode.Default
//        )]
//        public AtomTaskStatus TaskStatus
//        {
//            get { return (AtomTaskStatus)GetValue(TaskStatusProperty); }
//            set { SetValue(TaskStatusProperty, value); }
//        }

//        ///<summary>
//        /// Using a DependencyProperty as the backing store for TaskStatus.  This enables animation, styling, binding, etc...
//        ///</summary>
//#if SILVERLIGHT
//public static readonly DependencyProperty TaskStatusProperty = 
//    DependencyProperty.Register("TaskStatus", typeof(AtomTaskStatus), typeof(AtomTask), new PropertyMetadata(AtomTaskStatus.Idle, OnTaskStatusChangedCallback));
    
//private static void OnTaskStatusChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e){
//  AtomTask obj = d as AtomTask;
//}
    
//#else
//        public static readonly DependencyProperty TaskStatusProperty =
//            DependencyProperty.Register("TaskStatus", typeof(AtomTaskStatus), typeof(AtomTask), new FrameworkPropertyMetadata(AtomTaskStatus.Idle));
//#endif

//        #endregion



//        ///<summary>
//        /// Dependency Property LastError
//        ///</summary>
//        #region Dependency Property LastError
//        [AtomDesign(
//          Category = "Atoms",
//          Bindable = true,
//          BrowseMode = AtomPropertyBrowseMode.Never
//        )]
//        public Exception LastError
//        {
//            get { return (Exception)GetValue(LastErrorProperty); }
//            set { SetValue(LastErrorProperty, value); }
//        }

//        ///<summary>
//        /// Using a DependencyProperty as the backing store for LastError.  This enables animation, styling, binding, etc...
//        ///</summary>
//#if SILVERLIGHT
//public static readonly DependencyProperty LastErrorProperty = 
//    DependencyProperty.Register("LastError", typeof(Exception), typeof(AtomTask), new PropertyMetadata(null, OnLastErrorChangedCallback));
    
//private static void OnLastErrorChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e){
//  AtomTask obj = d as AtomTask;
//}
    
//#else
//        public static readonly DependencyProperty LastErrorProperty =
//            DependencyProperty.Register("LastError", typeof(Exception), typeof(AtomTask), new FrameworkPropertyMetadata(null));
//#endif

//        #endregion



//        ///<summary>
//        /// Dependency Property LastResult
//        ///</summary>
//        #region Dependency Property LastResult
//        [AtomDesign(
//          Category = "Atoms",
//          Bindable = true,
//          BrowseMode = AtomPropertyBrowseMode.Default
//        )]
//        public object LastResult
//        {
//            get { return (object)GetValue(LastResultProperty); }
//            set { SetValue(LastResultProperty, value); }
//        }

//        ///<summary>
//        /// Using a DependencyProperty as the backing store for LastResult.  This enables animation, styling, binding, etc...
//        ///</summary>
//#if SILVERLIGHT
//public static readonly DependencyProperty LastResultProperty = 
//    DependencyProperty.Register("LastResult", typeof(object), typeof(AtomTask), new PropertyMetadata(null, OnLastResultChangedCallback));
    
//private static void OnLastResultChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e){
//  AtomTask obj = d as AtomTask;
//}
    
//#else
//        public static readonly DependencyProperty LastResultProperty =
//            DependencyProperty.Register("LastResult", typeof(object), typeof(AtomTask), new FrameworkPropertyMetadata(null));
//#endif

//        #endregion






//        /// <summary>
//        /// 
//        /// </summary>
//        #region Method InvokeTask
//        public void InvokeTask()
//        {
//            // always invoke async...

//            if (RunInNewThread)
//            {
//                ThreadPool.QueueUserWorkItem(t => InvokeExcuteTask());
//            }
//            else
//            {
//                Dispatcher.BeginInvoke((Action)delegate()
//                {
//                    InvokeExcuteTask();
//                });
//            }
//        }

//        private void InvokeExcuteTask()
//        {
//            // enter in running state..
//            SetTaskStatus(AtomTaskStatus.Running, null, null);

//            AtomTaskEventArgs ce = new AtomTaskEventArgs();
//            try
//            {
//                ExecuteTask(this, ce);

//                if (ce.Cancel == true)
//                {
//                    SetTaskStatus(AtomTaskStatus.Cancelled, null, null);
//                    return;
//                }
//                SetTaskStatus(AtomTaskStatus.Finished, ce.Result, null);
//            }
//            catch (Exception ex)
//            {
//                SetTaskStatus(AtomTaskStatus.Failed, null, ex);
//            }
//        }

//        private void SetTaskStatus(AtomTaskStatus status, object result, Exception ex)
//        {
//            Dispatcher.BeginInvoke((Action)delegate()
//            {
//                TaskStatus = status;
//                LastError = ex;
//                LastResult = result;
//            });
//        } 
//        #endregion


//        /// <summary>
//        /// 
//        /// </summary>
//        public event EventHandler<AtomTaskEventArgs> ExecuteTask;

//    }

//    /// <summary>
//    /// 
//    /// </summary>
//    public class AtomTaskEventArgs : CancelEventArgs {

//        /// <summary>
//        /// 
//        /// </summary>
//        public object Result { get; set; }

//    }

//    /// <summary>
//    /// 
//    /// </summary>
//    public enum AtomTaskStatus { 

//        /// <summary>
//        /// 
//        /// </summary>
//        Idle,

//        /// <summary>
//        /// 
//        /// </summary>
//        Running,

//        /// <summary>
//        /// 
//        /// </summary>
//        Failed,

//        /// <summary>
//        /// 
//        /// </summary>
//        Cancelled,

//        /// <summary>
//        /// 
//        /// </summary>
//        Finished
//    }
}
