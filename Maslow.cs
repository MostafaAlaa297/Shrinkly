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
    public class Maslow : Disease
    {
        public List<MaslowQuestions> Questions { get; set; }
        public Maslow() : base(1, "Maslow", 75, 3)
        {
           Questions = LoadMaslowQuestions();
        }

        public override string DeclarePhase(int Score)
        {
            string phase="";
            if (Score >=0 && Score<=11)
            {
                phase = "احساس عالى بالأمن ";
            }
            else if (Score >=12 && Score <=24)
            {
                phase = "احساس متوسط بالأمن";
            }
            else if (Score >=25)
            {
                phase = " عدم الشعور بالأمن";
            }
            return phase;
        }

        public static List<MaslowQuestions> LoadMaslowQuestions()
        {
            using (IDbConnection cnn = new SqliteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<MaslowQuestions>("select * from Maslow", new DynamicParameters());
                return output.ToList();
            }
        }
        private static string LoadConnectionString(string id = "Default")
         {
         return ConfigurationManager.ConnectionStrings[id].ConnectionString;
         }


       /* public static void savePerson(PersonModel person)
        {
            using (IDbConnection cnn = new SqliteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Person(FirstName , LastName) values (@FirstName ,@LastName)", person);
            }
        }*/

    }
}
