using Data.Abstract;
using Data.Aspects.CacheAspects;
using Data.Caching.Redis;
using Model.Concrete;
using System.Data.SqlClient;

namespace Business.Concrete.Answer
{
    public class AnswerManager : IAnswerService
    {
        private readonly IAnswerDal _answerDal;

        public AnswerManager(IAnswerDal answerDal)
        {
            _answerDal = answerDal;
        }

        public bool Add(string commandText, List<SqlParameter> sqlParameters)
        {

            return _answerDal.Add(commandText, sqlParameters);
        }

        public bool Delete(string commandText, SqlParameter sqlParameter)
        {
            return _answerDal.Delete(commandText, sqlParameter);
        }
        [CacheAspect(typeof(RedisCacheManager))]
        public AnswerEntities Get(string commandText )
        {
            return _answerDal.Get(commandText);
        }

        [CacheAspect(typeof(RedisCacheManager))]
        public List<AnswerEntities> GetAll(string commandText)
        {
            return _answerDal.GetAll(commandText);
        }
        [CacheAspect(typeof(RedisCacheManager))]
        public SqlCommand GetAllCommand(string commandText)
        {
           return _answerDal.GetAllCommand(commandText);
        }
        [CacheAspect(typeof(RedisCacheManager))]
        public long GetAllCount(string commandText)
        {
            return _answerDal.GetAllCount(commandText);
        }

        public bool Update(string commandText, List<SqlParameter> sqlParameters)
        {
            return _answerDal.Update(commandText, sqlParameters);
        }
    }
}
