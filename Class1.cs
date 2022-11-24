using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsCoachingTimeManagement1
{
    public class Course
    {
        public string coachName;
        public int courseId;
        public string coachSurname;
        public string courseTime;
        public string courseDay;
        public string sportType;
        public Course(string day, string type, string name, int id, string surname, string time)
        {
            coachName = name;
            courseId = id;
            coachSurname = surname;
            courseTime = time;
            courseDay = day;
            sportType = type;

        }
    }
        
}
