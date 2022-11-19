using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WF
{
    public abstract class Disease
    {
        public int Id{ get; set; } 
        public string Name{ get; set; }
        public int TotalQuestions{ get; set; }
        public int Phases { get; set; }
        public static List<Patient> Patients = new List<Patient>();

        public Disease (int aId , string aName, int aTotalQuestions, int aPhases)
        {
            Id = aId;
            Name = aName;
            TotalQuestions= aTotalQuestions;
            Phases=aPhases;
        }

        public abstract string DeclarePhase(int Score );
    }
}