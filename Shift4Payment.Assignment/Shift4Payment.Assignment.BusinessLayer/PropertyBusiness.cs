using Shift4Payment.Assignment.DatabaseLayer;
using Shift4Payment.Assignment.DataModelLayer.Models;
using Shift4Payment.Assignment.DataModelLayer.Response;
using System.Collections.Generic;

namespace Shift4Payment.Assignment.BusinessLayer
{
    public class PropertyBusiness
    {
        /// <summary>
        /// Get Property List
        /// </summary>
        /// <returns></returns>
        public Result<List<PropertyModel>> GetPropertyList()
        {
            var propertyDB = new PropertyDatabase();
            return propertyDB.GetPropertyList();
        }

        /// <summary>
        /// saves new property
        /// </summary>
        /// <param name="propertyModel"></param>
        /// <returns></returns>
        public Result<int> SaveProperty(PropertyModel propertyModel)
        {
            var propertyDB = new PropertyDatabase();
            return propertyDB.SaveProperty(propertyModel);
        }

        /// <summary>
        /// gets property and tenant details corresponding to selected property
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Result<TenantPropertyModel> GetPropertyById(int id)
        {
            var propertyDB = new PropertyDatabase();
            if (id > 0)
            {
                return propertyDB.GetPropertyById(id);
            }
            else
            {
                var respone = new Result<TenantPropertyModel>();
                respone.Success = false;
                respone.Message = "Invalid Property Id";
                return respone;
            }
        }

    }
}
