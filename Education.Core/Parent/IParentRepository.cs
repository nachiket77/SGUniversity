using Education.Entity.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Core.Parent
{
    interface IParentRepository
    {
        AllDetails CreateParentDetails(AllDetails studentDetails);
    }
}
