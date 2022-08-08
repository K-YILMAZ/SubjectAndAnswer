using Business.Abstract;
using Business.Concrete.DependencyResolvers.Ninject;
using Model.Concrete;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace Business.Concrete.Subject
{
    public class SubjectHelper
    {
        static ISubjectService _subjectService;

        public SubjectHelper()
        {
            _subjectService = InstanceFactory.GetInstance<ISubjectService>();
        }
        public static List<SubjectEntities> GetAll(string CommandText = null)
        {
            _subjectService = InstanceFactory.GetInstance<ISubjectService>();
            string select = "SELECT * FROM Subjects";
            select = CommandText != null ? CommandText : select;

            return _subjectService.GetAll(select);
        }

        public static SubjectEntities Get(string CommandText)
        {
            _subjectService = InstanceFactory.GetInstance<ISubjectService>();
            string select = "SELECT * FROM Subjects";
            select = CommandText != null ? select + CommandText : select;

            return _subjectService.Get(select);
        }

        public static bool Add(string subject)
        {
            _subjectService = InstanceFactory.GetInstance<ISubjectService>();
            SubjectEntities subjectEntities = JsonConvert.DeserializeObject<SubjectEntities>(subject);

            string commandText = "INSERT INTO Subjects (Name, Surname, Email, Title, Content, Date)VALUES (@Name, @Surname, @Email, @Title, @Content, @Date)";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
               new SqlParameter("@Name",subjectEntities.Name),
               new SqlParameter("@Surname",subjectEntities.Surname),
               new SqlParameter("@Email",subjectEntities.Email),
               new SqlParameter("@Title",subjectEntities.Title),
               new SqlParameter("@Content",subjectEntities.Content),
               new SqlParameter("@Date",subjectEntities.Date)
            };
            return _subjectService.Add(commandText, parameters);
        }
        public static bool Update(SubjectEntities subject )
        {
            _subjectService = InstanceFactory.GetInstance<ISubjectService>();
            string commandText = "UPDATE Subjects SET Name = @Name , Surname=@Surname, Email=@Email, Title=@Title, Content=@Content, Date=@Date WHERE UserId=@UserId";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
               new SqlParameter("@Id",subject.Id),
               new SqlParameter("@Name",subject.Name),
               new SqlParameter("@Surname",subject.Surname),
               new SqlParameter("@Email",subject.Email),
               new SqlParameter("@Title",subject.Title),
               new SqlParameter("@Content",subject.Content),
               new SqlParameter("@Date",subject.Date)
            };
            return _subjectService.Add(commandText, parameters);
        }

    }
}
