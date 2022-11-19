using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WF
{
    public class Patient
    {
        public int PatientId{ get; set; }
        public string Name{ get; set; }
        public string Age{ get; set; }
        public string Gender{ get; set; }
        private List<Disease> Diseases = new List<Disease>();
        private List<Diagnose> Diagnose { get; set; }
        public byte[] Image { get; set; }
        public string Nationality { get; set; }
        public string Social_Status { get; set; }

        public Patient()
        {
        }
        public Patient(string aName, string aAge, string aGender,byte[] aImage,string aNationality,string aScoial_Status)
        {
            Name = aName;
            Age = aAge;
            Gender = aGender;
            Image = aImage;
            Nationality = aNationality;
            Social_Status = aScoial_Status;
        }

    }
}