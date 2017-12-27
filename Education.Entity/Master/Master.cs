using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Entity.Master
{

    public enum UserType
    {
        Student = 1,
        //SuperAdmin = 1,
        //SubAdmin = 2,
        //Teacher = 3,
        //Parent = 4,
        
    }

    public enum UserLoginStatus
    {
        Active = 1,
        Disabled = 2,
        Locked = 3
    }
    public enum Gender
    {
        Male,
        Female
    }

    public enum CourseID
    {
        UPSC=1,
        MPSC=2,
        Banking=3
    }

    public enum TestTypeId
    {
        Random = 1,
        Weekly = 2,
        Monthly = 3
    }


}
