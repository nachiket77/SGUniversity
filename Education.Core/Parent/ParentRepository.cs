using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Entity.Students;
using Education.DB;

namespace Education.Core.Parent
{
    public class ParentRepository : IParentRepository
    {
        public ajay_dbEntities dbEntities = new ajay_dbEntities();
        public AllDetails CreateParentDetails(AllDetails alldetails)
        {


            TBL_USER_PARENTS_DETAILS parentdetails = new TBL_USER_PARENTS_DETAILS();
            parentdetails.FATHERNAME = alldetails.ParentDetails.FATHERNAME;
            parentdetails.FATHERMOBILENUMBER = alldetails.ParentDetails.FATHERMOBILENUMBER;
            parentdetails.FATHEREMAIL = alldetails.ParentDetails.FATHEREMAIL;
            parentdetails.FATHERCOMPANYNAME = alldetails.ParentDetails.FATHERCOMPANYNAME;
            parentdetails.FATHERDESIGNATION = alldetails.ParentDetails.FATHERDESIGNATION;
            parentdetails.FATHEROCCUPATION = alldetails.ParentDetails.FATHEROCCUPATION;

            parentdetails.MOTHERCOMPANYNAME = alldetails.ParentDetails.MOTHERCOMPANYNAME;
            parentdetails.MOTHERDESIGNATION = alldetails.ParentDetails.MOTHERDESIGNATION;
            parentdetails.MOTHEREMAIL = alldetails.ParentDetails.MOTHEREMAIL;
            parentdetails.MOTHERMOBILENUMBER = alldetails.ParentDetails.MOTHERMOBILENUMBER;
            parentdetails.MOTHERNAME = alldetails.ParentDetails.MOTHERNAME;
            parentdetails.MOTHEROCCUPATION = alldetails.ParentDetails.MOTHEROCCUPATION;
            parentdetails.USERID = alldetails.ParentDetails.USERID;

            dbEntities.TBL_USER_PARENTS_DETAILS.Add(parentdetails);
            dbEntities.SaveChanges();

            return alldetails;



        }

    }
}
