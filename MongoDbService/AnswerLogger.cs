using Model.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbService
{
    public  class AnswerLogger
    {
        public static void logger(string jsonString)
        {
            AnswerEntities answerEntities = JsonConvert.DeserializeObject<AnswerEntities>(jsonString);

            IDictionary<string, string> keys =new Dictionary<string,string>();

            keys.Add("Id", answerEntities.Id.ToString());
            keys.Add("Name", answerEntities.Name.ToString());
            keys.Add("Email", answerEntities.Email.ToString());
            keys.Add("Date", answerEntities.Date.ToString());
            keys.Add("Content", answerEntities.Content.ToString());

            LoggerHelper loggerHelper = new LoggerHelper(keys, "Answers");

        }
      

    }
}
