using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using NSWebLib;
using Erp.Objects.CodeDOM;
using UIAtomsDemo.Web.Data;

namespace UIAtomsDemo.Web.Service
{
    /// <summary>
    /// Summary description for EmployeeService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class EmployeeService : BaseDataWebService
    {

        [WebMethod(true)]
        public WSResult<Employee> GetEmployees(string name)
        {
            return WSProcessSkipLogin<Employee>(() =>
            {
                ErpExpression exp = null;
                if (string.IsNullOrEmpty(name)) {
                    exp &= Employee.Schema.FirstName.Contains(name) | Employee.Schema.LastName.Contains(name);
                }
                return new WSResult<Employee>(Employee.Adapter.GetAll(exp));
            });
        }
    }
}
