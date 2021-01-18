using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using NSWebLib;
using UIAtomsDemo.Web.Data;
using Erp.Objects.CodeDOM;

namespace UIAtomsDemo.Web.Service
{
    /// <summary>
    /// Summary description for EmployeeWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class EmployeeWebService : BaseDataWebService
    {

        protected override void VerifyLogin()
        {
            
        }

        //#region WebMethod GetEmployees
        //[WebMethod(true)]
        ////public WSResult<Employee> GetEmployees(string name)
        ////{
        ////    //return WSProcess<Employee>(
        ////    //  delegate()
        ////    //  {
        ////    //      ErpExpression exp = null;
        ////    //      if (!string.IsNullOrEmpty(name)) {
        ////    //          exp = Employee.Schema.FirstName.Contains(name) | Employee.Schema.LastName.Contains(name);
        ////    //      }
        ////    //      return new WSResult<Employee>(Employee.Adapter.GetAllWithCount(exp, 0, -1));
        ////    //  }
        ////    //  );
        ////}
        //#endregion


    }
}
