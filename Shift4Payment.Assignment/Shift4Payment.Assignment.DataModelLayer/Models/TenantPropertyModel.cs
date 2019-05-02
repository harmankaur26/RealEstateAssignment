using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift4Payment.Assignment.DataModelLayer.Models
{
    public class TenantPropertyModel
    {
        /// <summary>
        /// Property Id
        /// </summary>
        public int PropertyID { get; set; }

        /// <summary>
        /// Property Name
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// property address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// property city
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// property state
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// property zip
        /// </summary>
        public string Zip { get; set; }

        /// <summary>
        /// property owner
        /// </summary>
        public string OwnerName { get; set; }

        /// <summary>
        /// user id
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// tenant ID
        /// </summary>
        public int TenantID { get; set; }

        /// <summary>
        /// tenant firstname
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
        /// uploaded file name
        /// </summary>
        public string FileName { get; set; }
    }
}
