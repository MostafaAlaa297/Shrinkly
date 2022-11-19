using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WF
{
    public class MaslowQuestions
    {
        public int QuestionNum{ get; set; }
        public int Yes { get; set; } 
        public int No{ get; set; }
        public int NotSure { get; set; }
        public string? Questions { get; set; }
        
        public int DiseaseId { get; set; }

        public MaslowQuestions()
        {
        }
        public MaslowQuestions (int aQuestionNum , int aYes , int aNo , int aNotSure,string aQuestions,int aDiseaseId)
        {
            QuestionNum = aQuestionNum;
            Yes = aYes; 
            No = aNo;
            NotSure = aNotSure;
            Questions= aQuestions;
            DiseaseId=aDiseaseId;
        }
       
    }
}