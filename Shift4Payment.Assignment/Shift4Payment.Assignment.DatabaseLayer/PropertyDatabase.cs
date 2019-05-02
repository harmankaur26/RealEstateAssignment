using Shift4Payment.Assignment.DatabaseLayer.RealtorEntity;
using Shift4Payment.Assignment.DataModelLayer.Models;
using Shift4Payment.Assignment.DataModelLayer.Response;
using Shift4Payment.Assignment.SharedLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shift4Payment.Assignment.DatabaseLayer
{
    /// <summary>
    /// Contains database functions for saving and fetching property details
    /// </summary>
    public class PropertyDatabase : IPropertyDatabase
    {
        RealtorEntities dbModel = null;

        public PropertyDatabase()
        {
            if (dbModel == null)
            {
                dbModel = new RealtorEntities();
            }
        }

        /// <summary>
        /// add new property
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        public Result<int> SaveProperty(PropertyModel property)
        {
            var response = new Result<int>();

            try
            {
                dbModel.spAddProperty(property.PropertyID,
                property.PropertyName
                , property.Address
                , property.City
                , property.State
                , property.Zip
                , property.OwnerName
                , property.UserID);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }

        /// <summary>
        /// get property and tenant  details
        /// </summary>
        /// <param name="propertyId"></param>
        /// <returns></returns>
        public Result<TenantPropertyModel> GetPropertyById(int propertyId)
        {
            var response = new Result<TenantPropertyModel>();
            try
            {
                var tenantProperty = (from pt in dbModel.spGetPropertyByID(propertyId)
                                      select new TenantPropertyModel
                                      {
                                          PropertyID = pt.PropertyID,
                                          PropertyName = pt.PropertyName,
                                          City = pt.City,
                                          State = pt.State,
                                          Address = pt.Address,
                                          Zip = pt.Zip,
                                          UserID = pt.UserID,
                                          OwnerName = pt.OwnerName,
                                          TenantID = pt.TenantID ?? 0,
                                          Firstname = pt.Firstname,
                                          Lastname = pt.Lastname,
                                          StartDate = pt.StartDate ?? DateTime.Now.Date,
                                          EndDate = pt.EndDate ?? DateTime.Now.Date.AddYears(1),
                                          Amount = pt.Amount ?? 0,
                                          FileName = pt.FileName

                                      }).SingleOrDefault();
                response.Model = tenantProperty;
                response.Success = true;
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
                response.Success = false;
            }
            return response;
        }

        /// <summary>
        /// gets list of all properties
        /// </summary>
        /// <returns></returns>
        public Result<List<PropertyModel>> GetPropertyList()
        {
            var response = new Result<List<PropertyModel>>();
            try
            {
                var propertyList = (from p in dbModel.spGetAllProperties()
                                    select new PropertyModel
                                    {
                                        PropertyID = p.PropertyID,
                                        PropertyName = p.PropertyName,
                                        City = p.City,
                                        State = p.State,
                                        Address = p.Address,
                                        Zip = p.Zip,
                                        UserID = p.UserID ?? 0,
                                        OwnerName = p.OwnerName
                                    }).ToList();
                response.Model = propertyList;
                response.Success = true;
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
                response.Success = false;
            }
            return response;

        }
    }
}
