//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WeddingManager.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Invoice
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public Nullable<System.DateTimeOffset> DateSuppressed { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public System.DateTimeOffset CreatedDate { get; set; }
        public System.DateTimeOffset DueDate { get; set; }
    
        public virtual Service Service { get; set; }
    }
}
