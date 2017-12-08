using Education.Entity;
using Education.Entity.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Core
{
   public interface IUserReposetory
    {
        LoginResponse Login(Login login);
        int InsertUserType(string usertype);
        List<UserType> GetUserType();
     
    }
}
