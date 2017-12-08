using Education.Entity.CountryEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Core.CountryStateCity
{
    public interface ICountryStateCityReposetory
    {
        List<Country> GetCountry();
        List<State> GetState(int CountryID);
        List<City> GetCity(int StateID);
    }
}
