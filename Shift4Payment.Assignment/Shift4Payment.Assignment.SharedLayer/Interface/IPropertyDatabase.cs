using Shift4Payment.Assignment.DataModelLayer.Models;
using Shift4Payment.Assignment.DataModelLayer.Response;
using System.Collections.Generic;

namespace Shift4Payment.Assignment.SharedLayer.Interface
{
    public interface IPropertyDatabase
    {
        /// <summary>
        /// add new property
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>

        Result<int> SaveProperty(PropertyModel property);
        /// <summary>
        /// get property and tenant  details
        /// </summary>
        /// <param name="propertyId"></param>
        /// <returns></returns>
        
        Result<TenantPropertyModel> GetPropertyById(int propertyId);
        /// <summary>
        /// gets list of all properties
        /// </summary>
        /// <returns></returns>
        Result<List<PropertyModel>> GetPropertyList();
    }
}
