using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Entity.Teachers
{
    public class TeacherDetails
    {

        public int TEACHERID { get; set; }
        public string FIRSTNAME { get; set; }
        public string MIDDLENAME { get; set; }
        public string LASTNAME { get; set; }
        public string EMAILID { get; set; }
        public string MOBILENUMBER { get; set; }

        public string PASSWORD { get; set; }
        public int COURSEID { get; set; }
        public int SUBJECTID { get; set; }

        public long CREATEDBY { get; set; }
        public DateTime CREATEDDATE { get; set; }



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
}
