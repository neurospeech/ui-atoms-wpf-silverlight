namespace UIAtomsDemo.Web.Data {
    using System;
    using System.Data;
    using System.ComponentModel;
    using System.Collections;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using Erp.Objects;
    using Erp.Objects.Schema;
    using Erp.Objects.CodeDOM;
    using Erp.Objects.CodeDOM.Provider;
    using Erp.Objects.Attributes;
    
    
    [ErpObjectAttribute(TableName="Employees", ObjectName="Employee")]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Erp.Objects.Schema.Generator.SchemaObjectSetGenerator", "3.84.3521.40227")]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class Employee : Erp.Objects.ErpObject {
        
        private long _EmployeeID = 0;
        
        [DataObjectField(true, true)]
        [XmlAttribute()]
        public virtual long EmployeeID {
            get {
                return this._EmployeeID;
            }
            set {
                this._EmployeeID = value;
            }
        }
        
        private string _LastName = "";
        
        [DataObjectField(false, false)]
        public virtual string LastName {
            get {
                return this._LastName;
            }
            set {
                this._LastName = value;
                base.Modified[Employee.Schema.LastName] = value;
            }
        }
        
        private string _FirstName = "";
        
        [DataObjectField(false, false)]
        public virtual string FirstName {
            get {
                return this._FirstName;
            }
            set {
                this._FirstName = value;
                base.Modified[Employee.Schema.FirstName] = value;
            }
        }
        
        private string _Title = "";
        
        [DataObjectField(false, false)]
        public virtual string Title {
            get {
                return this._Title;
            }
            set {
                this._Title = value;
                base.Modified[Employee.Schema.Title] = value;
            }
        }
        
        private string _TitleOfCourtesy = "";
        
        [DataObjectField(false, false)]
        public virtual string TitleOfCourtesy {
            get {
                return this._TitleOfCourtesy;
            }
            set {
                this._TitleOfCourtesy = value;
                base.Modified[Employee.Schema.TitleOfCourtesy] = value;
            }
        }
        
        private System.DateTime _BirthDate = DateTime.MinValue;
        
        [DataObjectField(false, false)]
        [XmlAttribute()]
        public virtual System.DateTime BirthDate {
            get {
                return this._BirthDate;
            }
            set {
                this._BirthDate = value;
                base.Modified[Employee.Schema.BirthDate] = value;
            }
        }
        
        private System.DateTime _HireDate = DateTime.MinValue;
        
        [DataObjectField(false, false)]
        [XmlAttribute()]
        public virtual System.DateTime HireDate {
            get {
                return this._HireDate;
            }
            set {
                this._HireDate = value;
                base.Modified[Employee.Schema.HireDate] = value;
            }
        }
        
        private string _Address = "";
        
        [DataObjectField(false, false)]
        public virtual string Address {
            get {
                return this._Address;
            }
            set {
                this._Address = value;
                base.Modified[Employee.Schema.Address] = value;
            }
        }
        
        private string _City = "";
        
        [DataObjectField(false, false)]
        public virtual string City {
            get {
                return this._City;
            }
            set {
                this._City = value;
                base.Modified[Employee.Schema.City] = value;
            }
        }
        
        private string _Region = "";
        
        [DataObjectField(false, false)]
        public virtual string Region {
            get {
                return this._Region;
            }
            set {
                this._Region = value;
                base.Modified[Employee.Schema.Region] = value;
            }
        }
        
        private string _PostalCode = "";
        
        [DataObjectField(false, false)]
        public virtual string PostalCode {
            get {
                return this._PostalCode;
            }
            set {
                this._PostalCode = value;
                base.Modified[Employee.Schema.PostalCode] = value;
            }
        }
        
        private string _Country = "";
        
        [DataObjectField(false, false)]
        public virtual string Country {
            get {
                return this._Country;
            }
            set {
                this._Country = value;
                base.Modified[Employee.Schema.Country] = value;
            }
        }
        
        private string _HomePhone = "";
        
        [DataObjectField(false, false)]
        public virtual string HomePhone {
            get {
                return this._HomePhone;
            }
            set {
                this._HomePhone = value;
                base.Modified[Employee.Schema.HomePhone] = value;
            }
        }
        
        private string _Extension = "";
        
        [DataObjectField(false, false)]
        public virtual string Extension {
            get {
                return this._Extension;
            }
            set {
                this._Extension = value;
                base.Modified[Employee.Schema.Extension] = value;
            }
        }
        
        private string _Notes = "";
        
        [DataObjectField(false, false)]
        public virtual string Notes {
            get {
                return this._Notes;
            }
            set {
                this._Notes = value;
                base.Modified[Employee.Schema.Notes] = value;
            }
        }
        
        private string _ReportsTo = "";
        
        [DataObjectField(false, false)]
        public virtual string ReportsTo {
            get {
                return this._ReportsTo;
            }
            set {
                this._ReportsTo = value;
                base.Modified[Employee.Schema.ReportsTo] = value;
            }
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public override object ID {
            get {
                return this._EmployeeID;
            }
            set {
                this._EmployeeID = ((long)(value));
            }
        }
        
        public class EmployeeSchema : Erp.Objects.ErpObjectSchema {
            
            public TableFieldReferenceExpression EmployeeID;
            
            private object GetValue_EmployeeID(object obj) {
                return ((Employee)(obj)).EmployeeID;
            }
            
            private void SetValue_EmployeeID(object obj, object val) {
                ((Employee)(obj)).EmployeeID = ((long)(System.Convert.ChangeType(val, typeof(long))));
            }
            
            public StringTableFieldReferenceExpression LastName;
            
            private object GetValue_LastName(object obj) {
                return ((Employee)(obj)).LastName;
            }
            
            private void SetValue_LastName(object obj, object val) {
                ((Employee)(obj)).LastName = ((string)(System.Convert.ChangeType(val, typeof(string))));
            }
            
            public StringTableFieldReferenceExpression FirstName;
            
            private object GetValue_FirstName(object obj) {
                return ((Employee)(obj)).FirstName;
            }
            
            private void SetValue_FirstName(object obj, object val) {
                ((Employee)(obj)).FirstName = ((string)(System.Convert.ChangeType(val, typeof(string))));
            }
            
            public StringTableFieldReferenceExpression Title;
            
            private object GetValue_Title(object obj) {
                return ((Employee)(obj)).Title;
            }
            
            private void SetValue_Title(object obj, object val) {
                ((Employee)(obj)).Title = ((string)(System.Convert.ChangeType(val, typeof(string))));
            }
            
            public StringTableFieldReferenceExpression TitleOfCourtesy;
            
            private object GetValue_TitleOfCourtesy(object obj) {
                return ((Employee)(obj)).TitleOfCourtesy;
            }
            
            private void SetValue_TitleOfCourtesy(object obj, object val) {
                ((Employee)(obj)).TitleOfCourtesy = ((string)(System.Convert.ChangeType(val, typeof(string))));
            }
            
            public TableFieldReferenceExpression BirthDate;
            
            private object GetValue_BirthDate(object obj) {
                System.DateTime dt = ((Employee)(obj)).BirthDate;
                if ((dt == System.DateTime.MinValue)) {
                    return System.DBNull.Value;
                }
                return ((Employee)(obj)).BirthDate;
            }
            
            private void SetValue_BirthDate(object obj, object val) {
                ((Employee)(obj)).BirthDate = ((System.DateTime)(System.Convert.ChangeType(val, typeof(System.DateTime))));
            }
            
            public TableFieldReferenceExpression HireDate;
            
            private object GetValue_HireDate(object obj) {
                System.DateTime dt = ((Employee)(obj)).HireDate;
                if ((dt == System.DateTime.MinValue)) {
                    return System.DBNull.Value;
                }
                return ((Employee)(obj)).HireDate;
            }
            
            private void SetValue_HireDate(object obj, object val) {
                ((Employee)(obj)).HireDate = ((System.DateTime)(System.Convert.ChangeType(val, typeof(System.DateTime))));
            }
            
            public StringTableFieldReferenceExpression Address;
            
            private object GetValue_Address(object obj) {
                return ((Employee)(obj)).Address;
            }
            
            private void SetValue_Address(object obj, object val) {
                ((Employee)(obj)).Address = ((string)(System.Convert.ChangeType(val, typeof(string))));
            }
            
            public StringTableFieldReferenceExpression City;
            
            private object GetValue_City(object obj) {
                return ((Employee)(obj)).City;
            }
            
            private void SetValue_City(object obj, object val) {
                ((Employee)(obj)).City = ((string)(System.Convert.ChangeType(val, typeof(string))));
            }
            
            public StringTableFieldReferenceExpression Region;
            
            private object GetValue_Region(object obj) {
                return ((Employee)(obj)).Region;
            }
            
            private void SetValue_Region(object obj, object val) {
                ((Employee)(obj)).Region = ((string)(System.Convert.ChangeType(val, typeof(string))));
            }
            
            public StringTableFieldReferenceExpression PostalCode;
            
            private object GetValue_PostalCode(object obj) {
                return ((Employee)(obj)).PostalCode;
            }
            
            private void SetValue_PostalCode(object obj, object val) {
                ((Employee)(obj)).PostalCode = ((string)(System.Convert.ChangeType(val, typeof(string))));
            }
            
            public StringTableFieldReferenceExpression Country;
            
            private object GetValue_Country(object obj) {
                return ((Employee)(obj)).Country;
            }
            
            private void SetValue_Country(object obj, object val) {
                ((Employee)(obj)).Country = ((string)(System.Convert.ChangeType(val, typeof(string))));
            }
            
            public StringTableFieldReferenceExpression HomePhone;
            
            private object GetValue_HomePhone(object obj) {
                return ((Employee)(obj)).HomePhone;
            }
            
            private void SetValue_HomePhone(object obj, object val) {
                ((Employee)(obj)).HomePhone = ((string)(System.Convert.ChangeType(val, typeof(string))));
            }
            
            public StringTableFieldReferenceExpression Extension;
            
            private object GetValue_Extension(object obj) {
                return ((Employee)(obj)).Extension;
            }
            
            private void SetValue_Extension(object obj, object val) {
                ((Employee)(obj)).Extension = ((string)(System.Convert.ChangeType(val, typeof(string))));
            }
            
            public StringTableFieldReferenceExpression Notes;
            
            private object GetValue_Notes(object obj) {
                return ((Employee)(obj)).Notes;
            }
            
            private void SetValue_Notes(object obj, object val) {
                ((Employee)(obj)).Notes = ((string)(System.Convert.ChangeType(val, typeof(string))));
            }
            
            public StringTableFieldReferenceExpression ReportsTo;
            
            private object GetValue_ReportsTo(object obj) {
                return ((Employee)(obj)).ReportsTo;
            }
            
            private void SetValue_ReportsTo(object obj, object val) {
                ((Employee)(obj)).ReportsTo = ((string)(System.Convert.ChangeType(val, typeof(string))));
            }
            
            public override Erp.Objects.CodeDOM.TableFieldReferenceExpression ID {
                get {
                    return this.EmployeeID;
                }
            }
            
            #region Initialization
            public EmployeeSchema() {
                this._IdentityInsert = false;
                this.EmployeeID = new TableFieldReferenceExpression("Employees", "EmployeeID", "Employee", "EmployeeID", -1, true, true, new Erp.Objects.CodeDOM.GetObjectValueHandler(this.GetValue_EmployeeID), new Erp.Objects.CodeDOM.SetObjectValueHandler(this.SetValue_EmployeeID));
                this.LastName = new StringTableFieldReferenceExpression("Employees", "LastName", "Employee", "LastName", 50, false, false, new Erp.Objects.CodeDOM.GetObjectValueHandler(this.GetValue_LastName), new Erp.Objects.CodeDOM.SetObjectValueHandler(this.SetValue_LastName));
                this.FirstName = new StringTableFieldReferenceExpression("Employees", "FirstName", "Employee", "FirstName", 50, false, false, new Erp.Objects.CodeDOM.GetObjectValueHandler(this.GetValue_FirstName), new Erp.Objects.CodeDOM.SetObjectValueHandler(this.SetValue_FirstName));
                this.Title = new StringTableFieldReferenceExpression("Employees", "Title", "Employee", "Title", 50, false, false, new Erp.Objects.CodeDOM.GetObjectValueHandler(this.GetValue_Title), new Erp.Objects.CodeDOM.SetObjectValueHandler(this.SetValue_Title));
                this.TitleOfCourtesy = new StringTableFieldReferenceExpression("Employees", "TitleOfCourtesy", "Employee", "TitleOfCourtesy", 50, false, false, new Erp.Objects.CodeDOM.GetObjectValueHandler(this.GetValue_TitleOfCourtesy), new Erp.Objects.CodeDOM.SetObjectValueHandler(this.SetValue_TitleOfCourtesy));
                this.BirthDate = new TableFieldReferenceExpression("Employees", "BirthDate", "Employee", "BirthDate", -1, false, false, new Erp.Objects.CodeDOM.GetObjectValueHandler(this.GetValue_BirthDate), new Erp.Objects.CodeDOM.SetObjectValueHandler(this.SetValue_BirthDate));
                this.HireDate = new TableFieldReferenceExpression("Employees", "HireDate", "Employee", "HireDate", -1, false, false, new Erp.Objects.CodeDOM.GetObjectValueHandler(this.GetValue_HireDate), new Erp.Objects.CodeDOM.SetObjectValueHandler(this.SetValue_HireDate));
                this.Address = new StringTableFieldReferenceExpression("Employees", "Address", "Employee", "Address", 200, false, false, new Erp.Objects.CodeDOM.GetObjectValueHandler(this.GetValue_Address), new Erp.Objects.CodeDOM.SetObjectValueHandler(this.SetValue_Address));
                this.City = new StringTableFieldReferenceExpression("Employees", "City", "Employee", "City", 50, false, false, new Erp.Objects.CodeDOM.GetObjectValueHandler(this.GetValue_City), new Erp.Objects.CodeDOM.SetObjectValueHandler(this.SetValue_City));
                this.Region = new StringTableFieldReferenceExpression("Employees", "Region", "Employee", "Region", 50, false, false, new Erp.Objects.CodeDOM.GetObjectValueHandler(this.GetValue_Region), new Erp.Objects.CodeDOM.SetObjectValueHandler(this.SetValue_Region));
                this.PostalCode = new StringTableFieldReferenceExpression("Employees", "PostalCode", "Employee", "PostalCode", 50, false, false, new Erp.Objects.CodeDOM.GetObjectValueHandler(this.GetValue_PostalCode), new Erp.Objects.CodeDOM.SetObjectValueHandler(this.SetValue_PostalCode));
                this.Country = new StringTableFieldReferenceExpression("Employees", "Country", "Employee", "Country", 50, false, false, new Erp.Objects.CodeDOM.GetObjectValueHandler(this.GetValue_Country), new Erp.Objects.CodeDOM.SetObjectValueHandler(this.SetValue_Country));
                this.HomePhone = new StringTableFieldReferenceExpression("Employees", "HomePhone", "Employee", "HomePhone", 50, false, false, new Erp.Objects.CodeDOM.GetObjectValueHandler(this.GetValue_HomePhone), new Erp.Objects.CodeDOM.SetObjectValueHandler(this.SetValue_HomePhone));
                this.Extension = new StringTableFieldReferenceExpression("Employees", "Extension", "Employee", "Extension", 50, false, false, new Erp.Objects.CodeDOM.GetObjectValueHandler(this.GetValue_Extension), new Erp.Objects.CodeDOM.SetObjectValueHandler(this.SetValue_Extension));
                this.Notes = new StringTableFieldReferenceExpression("Employees", "Notes", "Employee", "Notes", 50, false, false, new Erp.Objects.CodeDOM.GetObjectValueHandler(this.GetValue_Notes), new Erp.Objects.CodeDOM.SetObjectValueHandler(this.SetValue_Notes));
                this.ReportsTo = new StringTableFieldReferenceExpression("Employees", "ReportsTo", "Employee", "ReportsTo", 50, false, false, new Erp.Objects.CodeDOM.GetObjectValueHandler(this.GetValue_ReportsTo), new Erp.Objects.CodeDOM.SetObjectValueHandler(this.SetValue_ReportsTo));
                this._ObjectName = "Employee";
                this._TableName = "Employees";
                this.FieldDictionary["EmployeeID"] = this.EmployeeID;
                this.FieldDictionary["LastName"] = this.LastName;
                this.FieldDictionary["FirstName"] = this.FirstName;
                this.FieldDictionary["Title"] = this.Title;
                this.FieldDictionary["TitleOfCourtesy"] = this.TitleOfCourtesy;
                this.FieldDictionary["BirthDate"] = this.BirthDate;
                this.FieldDictionary["HireDate"] = this.HireDate;
                this.FieldDictionary["Address"] = this.Address;
                this.FieldDictionary["City"] = this.City;
                this.FieldDictionary["Region"] = this.Region;
                this.FieldDictionary["PostalCode"] = this.PostalCode;
                this.FieldDictionary["Country"] = this.Country;
                this.FieldDictionary["HomePhone"] = this.HomePhone;
                this.FieldDictionary["Extension"] = this.Extension;
                this.FieldDictionary["Notes"] = this.Notes;
                this.FieldDictionary["ReportsTo"] = this.ReportsTo;
                this._AllFields = new Erp.Objects.CodeDOM.TableFieldReferenceExpression[16];
                this._AllFields[0] = this.EmployeeID;
                this._AllFields[1] = this.LastName;
                this._AllFields[2] = this.FirstName;
                this._AllFields[3] = this.Title;
                this._AllFields[4] = this.TitleOfCourtesy;
                this._AllFields[5] = this.BirthDate;
                this._AllFields[6] = this.HireDate;
                this._AllFields[7] = this.Address;
                this._AllFields[8] = this.City;
                this._AllFields[9] = this.Region;
                this._AllFields[10] = this.PostalCode;
                this._AllFields[11] = this.Country;
                this._AllFields[12] = this.HomePhone;
                this._AllFields[13] = this.Extension;
                this._AllFields[14] = this.Notes;
                this._AllFields[15] = this.ReportsTo;
                this._Fields = new Erp.Objects.CodeDOM.TableFieldReferenceExpression[15];
                this._Fields[0] = this.LastName;
                this._Fields[1] = this.FirstName;
                this._Fields[2] = this.Title;
                this._Fields[3] = this.TitleOfCourtesy;
                this._Fields[4] = this.BirthDate;
                this._Fields[5] = this.HireDate;
                this._Fields[6] = this.Address;
                this._Fields[7] = this.City;
                this._Fields[8] = this.Region;
                this._Fields[9] = this.PostalCode;
                this._Fields[10] = this.Country;
                this._Fields[11] = this.HomePhone;
                this._Fields[12] = this.Extension;
                this._Fields[13] = this.Notes;
                this._Fields[14] = this.ReportsTo;
                this._PrimaryKey = this.EmployeeID;
                this._Identity = this.EmployeeID;
                this._FieldList = @"Employees.EmployeeID,Employees.LastName,Employees.FirstName,Employees.Title,Employees.TitleOfCourtesy,Employees.BirthDate,Employees.HireDate,Employees.Address,Employees.City,Employees.Region,Employees.PostalCode,Employees.Country,Employees.HomePhone,Employees.Extension,Employees.Notes,Employees.ReportsTo";
                this._InsertSql = @"INSERT INTO Employees(Employees.LastName,Employees.FirstName,Employees.Title,Employees.TitleOfCourtesy,Employees.BirthDate,Employees.HireDate,Employees.Address,Employees.City,Employees.Region,Employees.PostalCode,Employees.Country,Employees.HomePhone,Employees.Extension,Employees.Notes,Employees.ReportsTo) VALUES (@LastName,@FirstName,@Title,@TitleOfCourtesy,@BirthDate,@HireDate,@Address,@City,@Region,@PostalCode,@Country,@HomePhone,@Extension,@Notes,@ReportsTo)";
                this._UpdateSql = @"UPDATE Employees SET Employees.LastName = @LastName,Employees.FirstName = @FirstName,Employees.Title = @Title,Employees.TitleOfCourtesy = @TitleOfCourtesy,Employees.BirthDate = @BirthDate,Employees.HireDate = @HireDate,Employees.Address = @Address,Employees.City = @City,Employees.Region = @Region,Employees.PostalCode = @PostalCode,Employees.Country = @Country,Employees.HomePhone = @HomePhone,Employees.Extension = @Extension,Employees.Notes = @Notes,Employees.ReportsTo = @ReportsTo WHERE Employees.EmployeeID = @EmployeeID";
                this._DeleteSql = "DELETE FROM Employees WHERE Employees.EmployeeID = @EmployeeID";
            }
            #endregion
        }
        
        [DataObject()]
        [ErpObjectAttribute(TableName="Employees", ObjectName="Employee")]
        public partial class EmployeeAdapter : ErpObjectAdapter<Employee,EmployeeAdapter,EmployeeList> {
            
            [DataObjectMethod(DataObjectMethodType.Select)]
            public virtual Employee Get(long EmployeeID) {
                return this.Get((Schema.EmployeeID == EmployeeID), 0, 1);
            }
            
            [DataObjectMethod(DataObjectMethodType.Select)]
            public virtual int DeleteBy(long EmployeeID) {
                return this.Delete((Schema.EmployeeID == EmployeeID));
            }
            
            public override Erp.Objects.ErpObjectSchema MetaData {
                get {
                    return Employee.Schema;
                }
            }
        }
        
        public static EmployeeSchema Schema = new EmployeeSchema();
        
        public static EmployeeAdapter Adapter = new EmployeeAdapter();
        
        protected override void LoadFrom(System.Data.IDataReader reader) {
            object val;
            this.ResetObject();
            val = reader[0];
            if ((val != System.DBNull.Value)) {
                this.EmployeeID = ((long)(System.Convert.ChangeType(val, typeof(long))));
            }
            val = reader[1];
            if ((val != System.DBNull.Value)) {
                this.LastName = ((string)(System.Convert.ChangeType(val, typeof(string))));
            }
            val = reader[2];
            if ((val != System.DBNull.Value)) {
                this.FirstName = ((string)(System.Convert.ChangeType(val, typeof(string))));
            }
            val = reader[3];
            if ((val != System.DBNull.Value)) {
                this.Title = ((string)(System.Convert.ChangeType(val, typeof(string))));
            }
            val = reader[4];
            if ((val != System.DBNull.Value)) {
                this.TitleOfCourtesy = ((string)(System.Convert.ChangeType(val, typeof(string))));
            }
            val = reader[5];
            if ((val != System.DBNull.Value)) {
                this.BirthDate = ((System.DateTime)(System.Convert.ChangeType(val, typeof(System.DateTime))));
            }
            val = reader[6];
            if ((val != System.DBNull.Value)) {
                this.HireDate = ((System.DateTime)(System.Convert.ChangeType(val, typeof(System.DateTime))));
            }
            val = reader[7];
            if ((val != System.DBNull.Value)) {
                this.Address = ((string)(System.Convert.ChangeType(val, typeof(string))));
            }
            val = reader[8];
            if ((val != System.DBNull.Value)) {
                this.City = ((string)(System.Convert.ChangeType(val, typeof(string))));
            }
            val = reader[9];
            if ((val != System.DBNull.Value)) {
                this.Region = ((string)(System.Convert.ChangeType(val, typeof(string))));
            }
            val = reader[10];
            if ((val != System.DBNull.Value)) {
                this.PostalCode = ((string)(System.Convert.ChangeType(val, typeof(string))));
            }
            val = reader[11];
            if ((val != System.DBNull.Value)) {
                this.Country = ((string)(System.Convert.ChangeType(val, typeof(string))));
            }
            val = reader[12];
            if ((val != System.DBNull.Value)) {
                this.HomePhone = ((string)(System.Convert.ChangeType(val, typeof(string))));
            }
            val = reader[13];
            if ((val != System.DBNull.Value)) {
                this.Extension = ((string)(System.Convert.ChangeType(val, typeof(string))));
            }
            val = reader[14];
            if ((val != System.DBNull.Value)) {
                this.Notes = ((string)(System.Convert.ChangeType(val, typeof(string))));
            }
            val = reader[15];
            if ((val != System.DBNull.Value)) {
                this.ReportsTo = ((string)(System.Convert.ChangeType(val, typeof(string))));
            }
        }
        
        protected override void InternalCopyFrom(Erp.Objects.ErpObject obj) {
            Employee val = ((Employee)(obj));
            this._EmployeeID = val.EmployeeID;
            this._LastName = val.LastName;
            this._FirstName = val.FirstName;
            this._Title = val.Title;
            this._TitleOfCourtesy = val.TitleOfCourtesy;
            this._BirthDate = val.BirthDate;
            this._HireDate = val.HireDate;
            this._Address = val.Address;
            this._City = val.City;
            this._Region = val.Region;
            this._PostalCode = val.PostalCode;
            this._Country = val.Country;
            this._HomePhone = val.HomePhone;
            this._Extension = val.Extension;
            this._Notes = val.Notes;
            this._ReportsTo = val.ReportsTo;
        }
        
        private void ResetObject() {
            this._EmployeeID = 0;
            this._LastName = "";
            this._FirstName = "";
            this._Title = "";
            this._TitleOfCourtesy = "";
            this._BirthDate = DateTime.MinValue;
            this._HireDate = DateTime.MinValue;
            this._Address = "";
            this._City = "";
            this._Region = "";
            this._PostalCode = "";
            this._Country = "";
            this._HomePhone = "";
            this._Extension = "";
            this._Notes = "";
            this._ReportsTo = "";
        }
    }
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Erp.Objects.Schema.Generator.SchemaObjectSetGenerator", "3.84.3521.40227")]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class EmployeeList : ErpObjectList<Employee> {
    }
}
