using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenAI_PureData.Models
{
    public class ApiRequest
    {
        public int attendance;
        public int gradeLevel;
        public Courses[] courses;



        public Courses[] getCourses()
        {
            return this.courses;
        }

        public int getAttendance()
        {
            return this.attendance;
        }

        public int getGradeLevel()
        {
            return this.gradeLevel;
        }
    }
}