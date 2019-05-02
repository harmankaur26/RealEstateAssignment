using System;

namespace Shift4Payment.Assignment.DataModelLayer.Models
{
   public class TenantModel
    {
       /// <summary>
       /// tenant id
       /// </summary>
        public int TenantID { get; set; }

       /// <summary>
       /// tenant first name
       /// </summary>
        public string Firstname { get; set; }

       /// <summary>
       /// tenant lastname
       /// </summary>
        public string Lastname { get; set; }

       /// <summary>
       /// lease start date
       /// </summary>
        public DateTime StartDate { get; set; }

       /// <summary>
       /// lease end date
       /// </summary>
        public DateTime EndDate { get; set; }
       
       /// <summary>
       /// rent amount
       /// </summary>
        public decimal Amount { get; set; }

       /// <summary>
       /// rental file
       /// </summary>
        public string FileName { get; set; }

       /// <summary>
       /// userid
       /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Property Id
        /// </summary>
        public int PropertyID { get; set; }
    }
}
