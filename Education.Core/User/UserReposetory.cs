using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.DB;
using Education.Entity;
using Education.Entity.Login;

namespace Education.Core
{
    public class UserReposetory : IUserReposetory
    {

        ajay_dbEntities dbEntities = new ajay_dbEntities();
        public int InsertUserType(string usertype)
        {
            try
            {
                TBL_MASTER_USERTYPE objuser = new TBL_MASTER_USERTYPE();
                objuser.TYPENAME = usertype;
                dbEntities.TBL_MASTER_USERTYPE.Add(objuser);
                return 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<TBL_MASTER_USERTYPE> GetUserType(int usertypeid)
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

        public int UpdateUserType(int usertypeid, string usertype)
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

        public LoginResponse Login(Login login)
        {

            LoginResponse loginResponse = new LoginResponse();
            TBL_USER_LOGIN userLogin = dbEntities.TBL_USER_LOGIN.Where(X => X.LOGIN_EMAIL.ToLower() == login.LoginID.ToLower() || X.LOGIN_MOBILE == login.LoginID && X.PASSWORD == login.Password).SingleOrDefault();

            if (userLogin != null)
            {
                if (userLogin.TBL_USER_ROLE.Where(X => X.USERTYPEID == login.UserTypeID).Count() > 0)
                {

                    loginResponse.UserID = userLogin.USERID;
                    loginResponse.LoginEmail = userLogin.LOGIN_EMAIL;
                    loginResponse.LoginMobile = userLogin.LOGIN_MOBILE;
                    loginResponse.CreatedDate = userLogin.CREATEDDATE == null ? DateTime.MinValue : userLogin.CREATEDDATE.Value;
                    loginResponse.ModifiedDate = userLogin.MODIFIEDDATE == null ? DateTime.MinValue : userLogin.MODIFIEDDATE.Value;
                    loginResponse.PasswordRetryCount = userLogin.PASSWORDRETRYCOUNT;
                    loginResponse.UserTypeID = login.UserTypeID;
                    loginResponse.ErrorMessage = "";
                }
                else
                {
                    loginResponse.ErrorMessage = "Role not defined for the given user";
                }
            }
            else
            {
                loginResponse.ErrorMessage = "Invalid login cradential";
            }
            return loginResponse;
        }

        public List<UserType> GetUserType()
        {
            return dbEntities.TBL_MASTER_USERTYPE.Select(X => new UserType() { UsetTypeId = X.USERTYPEID, UsetType = X.TYPENAME }).ToList();


        }
    }
}
