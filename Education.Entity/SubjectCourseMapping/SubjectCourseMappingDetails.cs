using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Entity.SubjectCourseMapping
{
  public class SubjectCourseMappingDetails
    {
        public int COURSEID { get; set; }
        public int SUBJECTID { get; set; }

        public string SubjectName { get; set; }


        public DateTime CREATEDDATE { get; set; }
        public DateTime MODIFIEDDATE { get; set; }
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
