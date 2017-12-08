using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Entity.Master
{
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

    //public class CourseList
    //{
    //    //use CheckBoxModel class as list   
    //    public string NAME;
    //    public int ID;
    //    public List<CourseMaster> Course
    //    {
    //        get;
    //        set;
    //    }

    //    public int Value
    //    {
    //        get;
    //        set;
    //    }
    //    //description of checkbox   
    //    public string Text
    //    {
    //        get;
    //        set;
    //    }
    //    //whether the checkbox is selected or not   
    //    public bool IsChecked
    //    {
    //        get;
    //        set;
    //    }
    //}
}
