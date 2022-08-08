using Model.Abstract;
using Model.Concrete;
using System.Data.SqlClient;
using System.Linq.Expressions;

namespace Data.Abstract
{
    public interface IAnswerDal : IRepository<AnswerEntities> { }
}
