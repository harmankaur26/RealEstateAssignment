using System;

namespace Shift4Payment.Assignment.DataModelLayer.Models
{
    /// <summary>
    /// defines the data model for properties
    /// </summary>
    public class PropertyModel
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
        /// property owner name
        /// </summary>
        public string OwnerName { get; set; }

        /// <summary>
        /// user id who added property
        /// </summary>
        public int UserID { get; set; }
    }
}
