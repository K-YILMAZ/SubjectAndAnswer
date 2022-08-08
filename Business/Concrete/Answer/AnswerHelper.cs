
using Business.Concrete.DependencyResolvers.Ninject;
using Data.Abstract;
using Model.Concrete;
using Newtonsoft.Json;
using RabbitMQService;
using System.Data.SqlClient;

namespace Business.Concrete.Answer
{
    public class AnswerHelper
    {
        private static IAnswerService _answerService;
        public AnswerHelper()
        {
            _answerService = InstanceFactory.GetInstance<IAnswerService>();
        }
        public static List<AnswerEntities> GetAll(string CommandText = null)
        {
            _answerService = InstanceFactory.GetInstance<IAnswerService>();
            string select = "SELECT * FROM Answers";
            select = CommandText != null ? CommandText : select;

            return _answerService.GetAll(CommandText);
        }

        public static AnswerEntities Get(string CommandText)
        {
            _answerService = InstanceFactory.GetInstance<IAnswerService>();
            string select = "SELECT * FROM Answers";
            select = CommandText != null ? select + CommandText : select;

            return _answerService.Get(select);
        }

        public static bool Add(string answer)
        {
            _answerService = InstanceFactory.GetInstance<IAnswerService>();
            AnswerEntities answerEntities = JsonConvert.DeserializeObject<AnswerEntities>(answer);

            string commandText = "INSERT INTO Answers (Name, Surname, Email, Date, Content, SubjectId)VALUES (@Name, @Surname, @Email, @Date, @Content, @SubjectId)";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
               new SqlParameter("@Name",answerEntities.Name),
               new SqlParameter("@Surname",answerEntities.Surname),
               new SqlParameter("@Email",answerEntities.Email),
               new SqlParameter("@Date",answerEntities.Date),
               new SqlParameter("@Content",answerEntities.Content),
               new SqlParameter("@SubjectId",answerEntities.SubjectId),

            };

            var jsonData = JsonConvert.SerializeObject(answerEntities);
            new Publisher("AnswersQueue", jsonData);
            return _answerService.Add(commandText, parameters);


        }
        public static bool Update(AnswerEntities answer)
        {
            _answerService = InstanceFactory.GetInstance<IAnswerService>();
            string commandText = "UPDATE Answers SET Name = @Name , Surname=@Surname, Email=@Email, Content=@Content WHERE UserId=@UserId";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
               new SqlParameter("@Id",answer.Id),
               new SqlParameter("@Name",answer.Name),
               new SqlParameter("@Surname",answer.Surname),
               new SqlParameter("@Email",answer.Email),
               new SqlParameter("@Content",answer.Content)
            };
            return _answerService.Add(commandText, parameters);
        }
    }
}
