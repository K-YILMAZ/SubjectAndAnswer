using Business.Abstract;
using Data.Abstract;
using Data.Aspects.CacheAspects;
using Data.Caching.Redis;
using Model.Concrete;
using System.Data.SqlClient;

namespace Business.Concrete.Subject
{
    public class SubjectManager : ISubjectService
    {
        private readonly ISubjectDal _subjectDal;

        public SubjectManager(ISubjectDal subjectDal)
        {
            _subjectDal = subjectDal;
        }

        [CacheRemoveAspect(typeof(RedisCacheManager))]
        public bool Add(string commandText, List<SqlParameter> sqlParameters)
        {
            return _subjectDal.Add(commandText, sqlParameters);
        }

        public bool Delete(string commandText, SqlParameter sqlParameter)
        {
            return _subjectDal.Delete(commandText, sqlParameter);
        }
        [CacheAspect(typeof(RedisCacheManager))]
        public SubjectEntities Get(string commandText)
        {
            return _subjectDal.Get(commandText);
        }
        [CacheAspect(typeof(RedisCacheManager))]
        public List<SubjectEntities> GetAll(string commandText=null)
        {
            string select = "SELECT * FROM Subjects";
            select = commandText != null ? select + commandText : select;

            return _subjectDal.GetAll(commandText);
        }
        [CacheAspect(typeof(RedisCacheManager))]
        public SqlCommand GetAllCommand(string commandText)
        {
           return _subjectDal.GetAllCommand(commandText);
        }
        [CacheAspect(typeof(RedisCacheManager))]
        public long GetAllCount(string commandText)
        {
            return _subjectDal.GetAllCount(commandText);
        }

        public bool Update(string commandText, List<SqlParameter> sqlParameters)
        {
            return _subjectDal.Update(commandText, sqlParameters);
        }
    }
}
