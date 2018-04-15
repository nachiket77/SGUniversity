using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Education.Entity.Master;
using Education.DB;
using System.ComponentModel.DataAnnotations;
using Education.Entity.CountryEntity;

namespace Education.Entity.Students
{
    public class StudentDetails
    {
        public long PERSONALDETAILID { get; set; }
        public string PASSWORD { get; set; }
        public long USERID { get; set; }
        [Required]
        [Display(Name = "Email Id")]
        [DataType(DataType.EmailAddress)]
        public string EMAILID { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FIRSTNAME { get; set; }
        [Required]
        [Display(Name = "Middle Name")]
        public string MIDDLENAME { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LASTNAME { get; set; }
        [Required]
        [Display(Name = "Mother Name")]
        public string MOTHERNAME { get; set; }

        [Required]
        [Display(Name = "Father Name")]
        public string FATHERNAME { get; set; }
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }
        public string DISABILITY { get; set; }
        public string ENROLNMENTID { get; set; }
        [Required]
        [Display(Name = "Nationality")]
        public string NATIONALITY { get; set; }
        [Display(Name = "Mobile Number:")]
        [Required(ErrorMessage = "Mobile Number is required.")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Invalid Mobile Number.")]
        public string MOBILENO { get; set; }
        public long CREATEDBY { get; set; }
        public Education.Entity.Master.UserLoginStatus LoginStatus { get; set; }
        public Education.Entity.Master.Gender Gender { get; set; }
        public Education.Entity.Master.UserType UserType { get; set; }

        //public Education.Entity.Master.CourseID CourseID { get; set; }

        public int CourseID { get; set; }

        public string CourseName { get; set; }


        public int AddressTypeID { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        public int CountryID { get; set; }

        public int StateID { get; set; }

        public int CityID { get; set; }

        public int Pincode { get; set; }

        public int STATUSID { get; set; }

        public Education.DB.TBL_USER_LOGIN UserLogin { get; set; }

        public Education.DB.TBL_USER_ROLE UserRole { get; set; }

        public List<CourseMaster> CourseList { get; set; }


        public string percentage { get; set; }

        public string INSTITUTIONNAME { get; set; }

        public string PASSINGYEAR { get; set; }

        public List<City> citylist { get; set; }

        public List<State> statelist { get; set; }

        public List<Country> Countrylist { get; set; }





    }

    public class ParentDetails
    {
        public long USERID { get; set; }
        public long PARENTID { get; set; }
        public string FATHERNAME { get; set; }
        public string FATHEREMAIL { get; set; }

        public string FATHERMOBILENUMBER { get; set; }

        public string FATHEROCCUPATION { get; set; }

        public string FATHERCOMPANYNAME { get; set; }
        public string FATHERDESIGNATION { get; set; }
        public string MOTHERNAME { get; set; }
        public string MOTHEREMAIL { get; set; }
        public string MOTHERMOBILENUMBER { get; set; }
        public string MOTHEROCCUPATION { get; set; }
        public string MOTHERCOMPANYNAME { get; set; }
        public string MOTHERDESIGNATION { get; set; }
        public int CREATEDBY { get; set; }

        public DateTime CREATEDDATE { get; set; }

        public int MODIFIEDBY { get; set; }

        public DateTime MODIFIEDDATE { get; set; }


    }

    public class ProfessionalDetails
    {
        
        public long PROFESSIONALDETAILID { get; set; }
        public Nullable<long> USERID { get; set; }
        public string COMPANYNAME { get; set; }
        public string DESIGNATION { get; set; }
        public string EMPLOYEETYPE { get; set; }
        public string REMARKS { get; set; }
        public Nullable<long> CREATEBY { get; set; }
        public Nullable<System.DateTime> CREATEDDATE { get; set; }
        public Nullable<long> MODIFIEDDBY { get; set; }
        public Nullable<System.DateTime> MODIFIEDDATE { get; set; }

        public virtual TBL_USER_LOGIN TBL_USER_LOGIN { get; set; }

    }

    public class CourseMaster
    {
        public string NAME
        {
            get;
            set;
        }
        public int ID
        {
            get;
            set;
        }

        public List<CourseMaster> Coursedetails
        {
            get;
            set;
        }

        //Value of checkbox   
        public int Value
        {
            get;
            set;
        }
        //description of checkbox   
        public string Text
        {
            get;
            set;
        }
        //whether the checkbox is selected or not   
        public bool IsChecked
        {
            get;
            set;
        }
    }

    public class SubjectMaster
    {
        public string SUBJECTNAME
        {
            get;
            set;
        }
        public int SUBJECTID
        {
            get;
            set;
        }

        public List<SubjectMaster> Subjectdetails
        {
            get;
            set;
        }


    }

    public class ListStudents
    {
        public List<StudentDetails> ListDetails { get; set; }
        public long USERID { get; set; }
        public int CourseID { get; set; }
        public int Count { get; set; }

    }

  

}
