//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GridSample.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AlertDetail
    {
        public string AlertGuid { get; set; }
        public string AlertName { get; set; }
        public string AlertDescription { get; set; }
        public Nullable<int> Severity { get; set; }
        public Nullable<int> Priority { get; set; }
        public string Category { get; set; }
        public Nullable<System.DateTime> RaisedDateTime { get; set; }
        public Nullable<int> RepeatCount { get; set; }
        public Nullable<System.DateTime> DWLastModifiedDateTime { get; set; }
    }
}
