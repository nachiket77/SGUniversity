using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Entity.Master;
using Education.DB;

namespace Education.Core.Admin.Master
{
    public class UserType : IUserType
    {
        public ajay_dbEntities dbEntities = new ajay_dbEntities();
        public UserTypeMaster CreateUserTypeMasterDetails(UserTypeMaster ObjUserTypeMasterdetails)
        {
            try
            {
                TBL_MASTER_USERTYPE UserTypedetails = new TBL_MASTER_USERTYPE();
                UserTypedetails.TYPENAME = ObjUserTypeMasterdetails.TYPENAME;
                dbEntities.TBL_MASTER_USERTYPE.Add(UserTypedetails);
                dbEntities.SaveChanges();
                return ObjUserTypeMasterdetails;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<UserTypeMaster> GetUserType()
        {
            try
            {
                List<UserTypeMaster> UserTypedetails = new List<UserTypeMaster>();

                return dbEntities.TBL_MASTER_USERTYPE.Select(X => new UserTypeMaster() { TYPENAME = X.TYPENAME }).ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
