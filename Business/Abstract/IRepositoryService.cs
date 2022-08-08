using Model.Abstract;
using System.Data.SqlClient;
namespace Business.Abstract
{
    public interface IRepositoryService<T> where T : class, IEntity, new()
    {
        List<T> GetAll(string commandText);
       SqlCommand GetAllCommand(string commandText);
        T Get(string commandText);
        long GetAllCount(string commandText);
        bool Add(string commandText, List<SqlParameter> sqlParameters);
        bool Update(string commandText, List<SqlParameter> sqlParameters);
        bool Delete(string commandText, SqlParameter sqlParameter);


    }
}
