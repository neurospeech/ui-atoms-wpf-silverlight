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
using System.Threading;
using UIAtomsDemo.DataService;

namespace UIAtomsDemo.Common
{
    public class Utils
    {
        public static void Execute<T>(
            ExecuteHandler<T> action,
            ResultHandler<T> resultAction
            ) 
        {
            ThreadPool.QueueUserWorkItem(
                (d) => {
                    try 
                    {
                        T result = action();
                        GenericResult gr = result as GenericResult;
                        if (gr != null) {
                            if (!gr.Successful)
                            {
                                throw new Exception(gr.Message);
                            }
                        }
                        System.Windows.Deployment.Current.Dispatcher.BeginInvoke(() =>
                        {
                            resultAction(result);
                        });
                    }
                    catch(Exception ex)
                    {
                        if (Error != null)
                        {
                            Error(null, new ExceptionEventArgs(ex));
                        }
                        else
                        {
                            System.Windows.Deployment.Current.Dispatcher.BeginInvoke(() =>
                            {
                                MessageBox.Show(ex.ToString(), ex.Message, MessageBoxButton.OK);
                            });
                        }
                    }
                });
        }

        public static event EventHandler<ExceptionEventArgs> Error;

        private static CookieContainer Cookies = new CookieContainer();
        private static UIAtomsDemo.DataService.EmployeeWebServiceSoapClient _Service = null;

        public static UIAtomsDemo.DataService.EmployeeWebServiceSoap WebService
        {
            get {
                if (_Service == null) {
                    _Service = new DataService.EmployeeWebServiceSoapClient();
                    //_Service.CookieContainer = Cookies;
                }
                return _Service;
            }
        }

    }

    public delegate T ExecuteHandler<T>();
    public delegate void ResultHandler<T>(T result);
    public class ExceptionEventArgs : EventArgs {

        public Exception Exception { get; set; }

        public ExceptionEventArgs(Exception ex) 
        {
            Exception = ex;
        }

    }
}
