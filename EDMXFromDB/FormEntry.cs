//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EDMXFromDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class FormEntry
    {
        public int FormID { get; set; }
        public string Department { get; set; }
        public string CustomerName { get; set; }
        public string JobNumber { get; set; }
        public string SubjectLine { get; set; }
        public string ProblemMsg { get; set; }
        public string SuggestionMsg { get; set; }
        public System.DateTime DateEntered { get; set; }
        public bool IsAllDept { get; set; }
        public int Customer_CustID { get; set; }
        public int Employee_EmpID { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
