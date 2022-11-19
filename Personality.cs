using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF
{
    internal class Personality: Disease
    {
        public List<PersonalityQuestions> Questions { get; set; }
        public Personality() : base(4, "نمط الشخصية", 7, 5)
        {
            Questions = LoadPersonalityQuestions();
        }

        public override string DeclarePhase(int Score)
        {
            string phase = "";
            if (Score <90)
            {
                phase = "  نمط (ب) فى الشخصية ";
            }
            else if (Score > 90 && Score <= 99)
            {
                phase = "نمط (ب+) فى الشخصية";
            }
            else if (Score >= 100 && Score<=105)
            {
                phase = " نمط (أ-) فى الشخصية";
            }
            else if (Score >= 106 && Score <= 119)
            {
                phase = " نمط (أ) فى الشخصية";
            }
            else if (Score >= 120)
            {
                phase = " نمط (أ+) فى الشخصية";
            }
            return phase;
            
        }

        public static List<PersonalityQuestions> LoadPersonalityQuestions()
        {
            using (IDbConnection cnn = new SqliteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<PersonalityQuestions>("select * from PersonalityType", new DynamicParameters());
                return output.ToList();
            }
        }
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }

    }
}
