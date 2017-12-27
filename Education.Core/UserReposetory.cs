using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.DB;

namespace Education.Core
{
    public class UserReposetory : IUserReposetory
    {

       public ajay_dbEntities dbEntities = new ajay_dbEntities();
        public int InsertUserType(string usertype)
        {
            try
            {
                TBL_MASTER_USERTYPE objuser = new TBL_MASTER_USERTYPE();
                objuser.TYPENAME = usertype;
                dbEntities.TBL_MASTER_USERTYPE.Add(objuser);
                return 1;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<TBL_MASTER_USERTYPE> GetUserType(int  usertypeid)
        {
            try
            {
                //for single
                //var empQuery = from lang in dbEntities.TBL_MASTER_USERTYPE
                //               where lang.USERTYPEID == usertypeid
                //               select lang;
                //TBL_MASTER_USERTYPE objPackage = empQuery.SingleOrDefault();

                //for all
                var empQuery = from lang in dbEntities.TBL_MASTER_USERTYPE
                               select lang;
               List<TBL_MASTER_USERTYPE> objPackage = empQuery.ToList();

                return objPackage;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int UpdateUserType(int usertypeid,string usertype)
        {
            try
            {

                var empQuery = from lang in dbEntities.TBL_MASTER_USERTYPE
                               where lang.USERTYPEID == usertypeid
                               select lang;
                TBL_MASTER_USERTYPE objPackage = empQuery.SingleOrDefault();
                objPackage.TYPENAME = usertype;
                dbEntities.SaveChanges();
                return 1;
                //for all
              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
