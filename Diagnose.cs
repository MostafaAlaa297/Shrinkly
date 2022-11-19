using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF
{
    public class Diagnose
    {
        public int Yes_No { get; set; }
        public string? Questions { get; set; }

        public int QuestionId { get; set; }

        public Diagnose()
        {
        }
        public Diagnose(int aQuestionId, string aQuestion ,int aYesNo)
        {
            Yes_No = aYesNo;
            Questions = aQuestion;
            QuestionId = aQuestionId;
        }
    }   
}
