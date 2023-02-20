using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenAI_PureData.Models
{
    public class Courses
    {
        public string name;
        public string letter;

        public Courses()
        {
            this.name = "";
            this.letter = "";
        }

        public string getName()
        {
            return name;
        }

        public string getLetter()
        {
            return letter;
        }
    }
}