using System;
using DMS_BOL;
using DMS_DAL.DBLayer;
using System.Collections.Generic;
using DMS_BOL.Validation_Classes;

namespace DMS_BLL.Repositories
{
    public class AddressRepo
    {
        private AddressDb dbObj;

        public AddressRepo()
        {
            dbObj= new AddressDb();
        }

        public int InsertAddress(tblAddress model)
        {
            try
            {
                if (model != null)
                {
                    var addressId = dbObj.InsertAddress(model);
                    if (addressId > 0)
                        return addressId;
                    else
                        return 0;
                }
                else
                    return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateAddress(tblAddress model)
        {
            try
            {
                if (model != null && model.AddressID > 0)
                {
                    var addressId = dbObj.UpdateAddress(model);
                    if (addressId > 0)
                        return addressId;
                    else
                        return 0;
                }
                else
                    return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ValidateAddress GetAddressById(int id)
        {
            try
            {
                if (id > 0)
                {
                    var address = dbObj.GetAddressById(id);
                    if (address != null)
                        return address;
                    else
                        return null;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<tblState> GetAllState()
        {
            return dbObj.GetAllState();
        }

        public IEnumerable<tblCity> GetAllCity()
        {
            return dbObj.GetAllCity();
        }

        public IEnumerable<tblZone> GetAllZone()
        {
            return dbObj.GetAllZone();
        }

        public IEnumerable<tblCity> GetCitiesByState(int StateId)
        {
            return dbObj.GetCitiesByState(StateId);
        }

        public IEnumerable<tblZone> GetZoneByCity(int CityId)
        {
            return dbObj.GetZoneByCity(CityId);
        }

        public Tuple<decimal?, decimal?, string> GetZoneLatLong(int ZoneId)
        {
            if (ZoneId > 0)
                return dbObj.GetZoneLatLong(ZoneId);
            else
                return null;
        }

        public Tuple<string, string> GetStateandCity(int CityId)
        {
            if (CityId > 0)
                return dbObj.GetStateandCity(CityId);
            else
                return null;
        }
    }
}
