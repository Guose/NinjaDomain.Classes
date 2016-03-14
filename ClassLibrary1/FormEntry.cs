namespace ClassLibrary1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FormEntry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FormID { get; set; }

        [Required]
        public string Department { get; set; }

        public string CustomerName { get; set; }

        public string JobNumber { get; set; }

        public string SubjectLine { get; set; }

        [Required]
        public string ProblemMsg { get; set; }

        [Required]
        public string SuggestionMsg { get; set; }

        public DateTime DateEntered { get; set; }

        public bool IsAllDept { get; set; }

        public int Customer_CustID { get; set; }

        public int Employee_EmpID { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
