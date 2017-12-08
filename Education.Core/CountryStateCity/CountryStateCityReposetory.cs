using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Entity.CountryEntity;
using Education.DB;

namespace Education.Core.CountryStateCity
{
    public class CountryStateCityReposetory : ICountryStateCityReposetory
    {
        ajay_dbEntities dbEntities = new ajay_dbEntities();

        public List<Country> GetCountry()
        {
            return dbEntities.TBL_MASTER_COUNTRY.Select(x => new Country() { CountryID = x.COUNTRYID, CountryName = x.NAME }).ToList();
        }

        public List<State> GetState(int CountryID)
        {
            return dbEntities.TBL_MASTER_STATE.Where(X => X.COUNTRYID == CountryID).Select(x => new State() { StateID = x.STATEID, StateName = x.NAME, CountryID = CountryID }).ToList();
        }
        public List<City> GetCity(int StateID)

        {
            return dbEntities.TBL_MASTER_CITY.Where(X => X.STATEID == StateID).Select(x => new City() { StateID =StateID, CityName = x.NAME, CityID = x.CITYID }).ToList();

        }
    }
}
