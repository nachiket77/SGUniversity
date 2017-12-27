using Education.Entity.CountryEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Entity.Students
{
  public  class InstituteDetails
    {
        public List<Boards> BoardsList { get; set; }

        public Boards Boardmaster { get; set; }

        public List<Classes> ClassesList { get; set; }

        public Classes Classmaster { get; set; }

        public string percentage { get; set; }

        public string INSTITUTIONNAME { get; set; }

        public string PASSINGYEAR { get; set; }

    }
}
