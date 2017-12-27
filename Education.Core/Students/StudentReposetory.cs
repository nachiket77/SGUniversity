using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.DB;
using Education.Entity.Students;

namespace Education.Core.Students
{
    public class StudentReposetory : IStudentReposetory
    {
        public ajay_dbEntities dbEntities = new ajay_dbEntities();
        public bool StudentExist(StudentDetails student)
        {
            bool result = false;
            if (dbEntities.TBL_USER_LOGIN.Count(X => X.LOGIN_EMAIL.ToLower() == student.EMAILID.ToLower() || X.LOGIN_MOBILE == student.MOBILENO) > 0)
            {
                result = true;
            }
            return result;


        }



        public List<StudentDetails> GetStudentDetails()
        {
            return dbEntities.TBL_USER_DETAILS.OrderByDescending(x => x.USERID).Select(X => new StudentDetails() { USERID = X.USERID, FIRSTNAME = X.FIRSTNAME, LASTNAME = X.LASTNAME, MIDDLENAME = X.MIDDLENAME, DOB = X.DOB }).ToList();
            //return dbEntities.TBL_USER_DETAILS.Join(
            //dbEntities.TBL_USER_COURSE_MAPPING_DETAILS, r => r.USERID, p => p.COURSEID, (r, p) => new
            //{
            //    r.USERID,
            //    r.FIRSTNAME,
            //    r.LASTNAME,
            //    p.COURSEID
            //}
            //);

            //var query= from o in dbEntities.TBL_USER_DETAILS
            //            join od in dbEntities.TBL_USER_COURSE_MAPPING_DETAILS on o.USERID equals Convert.ToInt32(od.COURSEID)
            //            select new StudentDetails {USERID=o.USERID,FIRSTNAME=o.FIRSTNAME,LASTNAME=o.LASTNAME,CourseID=od.COURSEID };
            //      return   query.ToList();

        }
        public List<InstitutionDetail> GetInstitutes(long UserID)
        {
            return dbEntities.TBL_USER_INSTITUTION_DETAILS.Where(X => X.USERID == UserID).Select(X =>
            new InstitutionDetail()
            {
                BOARDID = X.BOARDID,
                CREATEDBY = X.CREATEDBY,
                CLASSID = X.CLASSID,
                USERID = X.USERID,
                CREATEDDATE = X.CREATEDDATE,
                GRADE_PERCENT = X.GRADE_PERCENT,
                INSTITUTIONID = X.INSTITUTIONID,
                INSTITUTIONNAME = X.INSTITUTIONNAME,
                MODIFIEDBY = X.MODIFIEDBY,
                MODIFIEDDATE = X.MODIFIEDDATE,
                PASSINGYEAR = X.PASSINGYEAR
            }

                ).ToList();
        }

        public InstitutionDetail AddInstitute(InstitutionDetail Institute)
        {
            TBL_USER_INSTITUTION_DETAILS institutionDetails = new TBL_USER_INSTITUTION_DETAILS();
            institutionDetails.BOARDID = Institute.BOARDID;
            institutionDetails.CLASSID = Institute.CLASSID;
            institutionDetails.CREATEDBY = Institute.CREATEDBY;
            institutionDetails.CREATEDDATE = DateTime.Now;
            institutionDetails.GRADE_PERCENT = Institute.GRADE_PERCENT;
            institutionDetails.INSTITUTIONNAME = Institute.INSTITUTIONNAME;
            institutionDetails.PASSINGYEAR = Institute.PASSINGYEAR;
            institutionDetails.USERID = Institute.USERID;

            dbEntities.TBL_USER_INSTITUTION_DETAILS.Add(institutionDetails);
            dbEntities.SaveChanges();
            Institute.INSTITUTIONID = institutionDetails.INSTITUTIONID;
            return Institute;
        }

        public AllDetails CreateStudent(AllDetails alldetails)
        {

            TBL_USER_LOGIN userLogin = new TBL_USER_LOGIN();

            userLogin.LOGIN_EMAIL = alldetails.StudentDetails.EMAILID;
            userLogin.LOGIN_MOBILE = alldetails.StudentDetails.MOBILENO;
            // userLogin.MODIFIEDDATE = null;
            userLogin.PASSWORD = alldetails.StudentDetails.PASSWORD;
            userLogin.PASSWORDRETRYCOUNT = 0;
            userLogin.STATUSID = Convert.ToInt16(alldetails.StudentDetails.STATUSID);
            userLogin.USERTYPEID = Convert.ToInt16(alldetails.StudentDetails.UserType);
            userLogin.CREATEDDATE = DateTime.Now;

            TBL_USER_DETAILS UserDetails = new TBL_USER_DETAILS();

            //UserDetails.PERSONALDETAILID = 17;
            UserDetails.FIRSTNAME = alldetails.StudentDetails.FIRSTNAME;
            UserDetails.MIDDLENAME = alldetails.StudentDetails.MIDDLENAME;
            UserDetails.LASTNAME = alldetails.StudentDetails.LASTNAME;
            UserDetails.MOTHERNAME = alldetails.StudentDetails.MOTHERNAME;
            UserDetails.FATHERNAME = alldetails.StudentDetails.FATHERNAME;
            UserDetails.LASTNAME = alldetails.StudentDetails.LASTNAME;
            UserDetails.GENDER = alldetails.StudentDetails.Gender.ToString();
            UserDetails.NATIONALITY = alldetails.StudentDetails.NATIONALITY;
            UserDetails.USERID = userLogin.USERID;
            UserDetails.DOB = alldetails.StudentDetails.DOB;
            userLogin.TBL_USER_DETAILS.Add(UserDetails);

            TBL_USER_ROLE UserRole = new TBL_USER_ROLE();
            UserRole.USERID = userLogin.USERID;
            UserRole.USERTYPEID = Convert.ToInt16(alldetails.StudentDetails.UserType);
            UserRole.CREATEDBY = alldetails.StudentDetails.CREATEDBY;
            UserRole.CREATEDDATE = DateTime.Now;

            userLogin.TBL_USER_ROLE.Add(UserRole);

            TBL_USER_ADDRESS_DETAILS address = new TBL_USER_ADDRESS_DETAILS();
            address.ADDRESSLINE1 = alldetails.StudentDetails.AddressLine1;
            address.ADDRESSLINE2 = alldetails.StudentDetails.AddressLine2;
            address.ADDRESSTYPEID = alldetails.StudentDetails.AddressTypeID;
            address.CITY = alldetails.StudentDetails.CityID;
            address.COUNTRY = alldetails.StudentDetails.CountryID;
            address.CREATEDBY = alldetails.StudentDetails.CREATEDBY;
            address.CREATEDDATE = DateTime.Now;
            address.PINCODE = alldetails.StudentDetails.Pincode.ToString();
            address.USERID = userLogin.USERID;
            userLogin.TBL_USER_ADDRESS_DETAILS.Add(address);


            TBL_USER_INSTITUTION_DETAILS institutiondetails = new TBL_USER_INSTITUTION_DETAILS();


            institutiondetails.BOARDID = alldetails.BoardsMaster.BoardID;
            institutiondetails.CLASSID = alldetails.ClassesMaster.ClassID;
            institutiondetails.PASSINGYEAR = Convert.ToInt32(alldetails.StudentDetails.PASSINGYEAR);
            institutiondetails.GRADE_PERCENT = alldetails.StudentDetails.percentage;
            institutiondetails.INSTITUTIONNAME = alldetails.StudentDetails.INSTITUTIONNAME;
            institutiondetails.USERID = userLogin.USERID;
            institutiondetails.CREATEDDATE = DateTime.Now;
            userLogin.TBL_USER_INSTITUTION_DETAILS.Add(institutiondetails);


            dbEntities.TBL_USER_LOGIN.Add(userLogin);
            dbEntities.SaveChanges();
            alldetails.StudentDetails.USERID = userLogin.USERID;
            

            TBL_USER_COURSE_MAPPING_DETAILS objusercourse = new TBL_USER_COURSE_MAPPING_DETAILS();
            foreach (var item in alldetails.CourseList)
            {
                if (item.IsChecked == true)
                {
                    objusercourse.COURSEID = item.ID;
                    objusercourse.USERID = userLogin.USERID;
                    objusercourse.CREATEDDATE = DateTime.Now;
                    dbEntities.TBL_USER_COURSE_MAPPING_DETAILS.Add(objusercourse);
                    dbEntities.SaveChanges();
                }

            }

            return alldetails;


        }

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
            //parentdetails.MOTHEREMAIL = alldetails.ParentDetails.MOTHEREMAIL;
            parentdetails.MOTHERMOBILENUMBER = alldetails.ParentDetails.MOTHERMOBILENUMBER;
            parentdetails.MOTHERNAME = alldetails.ParentDetails.MOTHERNAME;
            parentdetails.MOTHEROCCUPATION = alldetails.ParentDetails.MOTHEROCCUPATION;
            parentdetails.USERID = alldetails.ParentDetails.USERID;
            parentdetails.CREATEDDATE = DateTime.Now;

            dbEntities.TBL_USER_PARENTS_DETAILS.Add(parentdetails);
            dbEntities.SaveChanges();

            return alldetails;



        }

        public AllDetails CreateProfessionalDetails(AllDetails alldetails)
        {

            
            TBL_USER_PROFESSIONAL_DETAILS professionaldetails = new TBL_USER_PROFESSIONAL_DETAILS();
            professionaldetails.COMPANYNAME = alldetails.ProfessionalDetails.COMPANYNAME;
            professionaldetails.DESIGNATION = alldetails.ProfessionalDetails.DESIGNATION;
            professionaldetails.EMPLOYEETYPE = alldetails.ProfessionalDetails.EMPLOYEETYPE;
            professionaldetails.REMARKS = alldetails.ProfessionalDetails.REMARKS;
            professionaldetails.USERID = alldetails.ProfessionalDetails.USERID;
            //  professionaldetails.CREATEBY = 1234;
            professionaldetails.CREATEDDATE = DateTime.Now;

            dbEntities.TBL_USER_PROFESSIONAL_DETAILS.Add(professionaldetails);
            dbEntities.SaveChanges();


            //TBL_STUDENT_MASTER_MAPPING objstudentmapping = new TBL_STUDENT_MASTER_MAPPING();
            //objstudentmapping.USERID = alldetails.StudentDetails.USERID;
            //objstudentmapping.PARENTID = alldetails.ParentDetails.PARENTID;
            //objstudentmapping.PROFESSIONALDETAILID = alldetails.ProfessionalDetails.PROFESSIONALDETAILID;



            return alldetails;



        }



        public List<Boards> GetBoards()
        {
            return dbEntities.TBL_MASTER_BOARDS.Select(X => new Boards() { BoardID = X.BOARDID, BoardName = X.NAME }).ToList();
        }

        public List<Classes> GetClasses()
        {
            return dbEntities.TBL_MASTER_CLASS.Select(X => new Classes() { ClassID = X.CLASSID, ClassName = X.NAME }).ToList();
        }

        public List<CourseMaster> GetCourse()
        {
            try
            {
                List<CourseMaster> Subjectdetails = new List<CourseMaster>();

                return dbEntities.TBL_MASTER_COURSE.Select(X => new CourseMaster() { NAME = X.NAME, ID = X.COURSEID }).ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteInstitute(long InstituteID)
        {
            bool Restul = false;
            TBL_USER_INSTITUTION_DETAILS institustiondetail = dbEntities.TBL_USER_INSTITUTION_DETAILS.Where(x => x.INSTITUTIONID == InstituteID).SingleOrDefault();
            if (institustiondetail != null)
            {
                dbEntities.TBL_USER_INSTITUTION_DETAILS.Remove(institustiondetail);
                dbEntities.SaveChanges();
                Restul = true;
            }
            return Restul;
        }

        public List<Documents> GetDocuments(long UserID)
        {
            return dbEntities.TBL_USER_DOCUMENTS_DETAILS.Where(X => X.USERID == UserID).Select(X =>
            new Documents()
            {
                CREATEDBY = X.CREATEDBY,
                CREATEDDATE = X.CREATEDDATE,
                DOCUMENTNAME = X.DOCUMENTNAME,
                DOCUMENTTYPEID = X.DOCUMENTTYPEID,
                DOCUMENTTYPENAME = X.TBL_MASTER_DOCUMENTTYPE.DocumentTypeName,
                MODIFIEDBY = X.MODIFIEDBY,
                MODIFIEDDATE = X.MODIFIEDDATE,
                STATUS = X.STATUS,
                USERDOCUMENTID = X.USERDOCUMENTID,
                USERID = X.USERID

            }

                ).ToList();
        }

        public bool DeleteDocument(long DocumentID)
        {
            bool Restul = false;
            TBL_USER_DOCUMENTS_DETAILS documentdetail = dbEntities.TBL_USER_DOCUMENTS_DETAILS.Where(x => x.USERDOCUMENTID == DocumentID).SingleOrDefault();
            if (documentdetail != null)
            {
                dbEntities.TBL_USER_DOCUMENTS_DETAILS.Remove(documentdetail);
                dbEntities.SaveChanges();
                Restul = true;
            }
            return Restul;
        }
        public Documents AddDocuments(Documents document)
        {
            TBL_USER_DOCUMENTS_DETAILS DocumentsDetails = new TBL_USER_DOCUMENTS_DETAILS();
            DocumentsDetails.CREATEDBY = document.CREATEDBY;
            DocumentsDetails.CREATEDDATE = document.CREATEDDATE;
            DocumentsDetails.DOCUMENTNAME = document.DOCUMENTNAME;
            DocumentsDetails.DOCUMENTTYPEID = document.DOCUMENTTYPEID;

            DocumentsDetails.MODIFIEDBY = document.MODIFIEDBY;
            DocumentsDetails.MODIFIEDDATE = document.MODIFIEDDATE;
            DocumentsDetails.STATUS = document.STATUS;
            DocumentsDetails.USERDOCUMENTID = document.USERDOCUMENTID;
            DocumentsDetails.USERID = document.USERID;

            dbEntities.TBL_USER_DOCUMENTS_DETAILS.Add(DocumentsDetails);
            dbEntities.SaveChanges();
            document.USERDOCUMENTID = DocumentsDetails.USERDOCUMENTID;
            return document;
        }

        public List<SubjectMaster> Getsubject()
        {
            try
            {
                List<SubjectMaster> Subjectdetails = new List<SubjectMaster>();

                return dbEntities.TBL_MASTER_SUBJECT.Select(X => new SubjectMaster() { SUBJECTNAME = X.NAME, SUBJECTID = X.SUBJECTID }).ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }



        public void updateStudentDetail(int userid, string FirstName, string Last, string middle)
        {
            var StudentData = dbEntities.TBL_USER_DETAILS.Where(x => x.USERID == userid).FirstOrDefault();
            if (StudentData != null)
            {
                StudentData.FIRSTNAME = FirstName;
                StudentData.LASTNAME = Last;
                StudentData.MIDDLENAME = middle;
                dbEntities.SaveChanges();
            }



        }
    }
}
