//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Shift4Payment.Assignment.DatabaseLayer.RealtorEntity
{
    using System;
    
    public partial class spGetPropertyByID_Result
    {
        public int PropertyID { get; set; }
        public string PropertyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string OwnerName { get; set; }
        public int UserID { get; set; }
        public Nullable<int> TenantID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string FileName { get; set; }
    }
}
