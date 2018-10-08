using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceRegQuickExample.Model
{
    public class Racer
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int Age { get; set; }
        public String Gender { get; set; }
        public DateTime FinishTime { get; set; }

        public string GetToString()
        {
            return FirstName + ";" + LastName + ";" + Age + ";" + Gender + ";" + FinishTime.ToShortDateString();
        }
    }
}
