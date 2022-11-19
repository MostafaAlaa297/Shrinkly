using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF
{
    internal class PersonalityQuestions
    {

        public int QuestionNum { get; set; }
        public string? LowQuestion { get; set; }
        public string? HighQuestion { get; set; }
        public int DiseaseId { get; set; }

        public PersonalityQuestions()
        {
        }
        public PersonalityQuestions(int aQuestionNum, string aLowQuestions, string aHighQuestion, int aDiseaseId)
        {
            QuestionNum = aQuestionNum;
            LowQuestion= aLowQuestions;
            HighQuestion = aHighQuestion;
            DiseaseId = aDiseaseId;
        }

    }
}
