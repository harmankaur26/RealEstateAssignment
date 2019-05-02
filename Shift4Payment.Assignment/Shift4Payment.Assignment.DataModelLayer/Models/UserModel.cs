using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shift4Payment.Assignment.DataModelLayer.Models
{
    public class UserModel
    {
        /// <summary>
        /// user ID
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// user firstname
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// user lastname
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// user role
        /// </summary>
        public byte Role { get; set; }
    }
}
