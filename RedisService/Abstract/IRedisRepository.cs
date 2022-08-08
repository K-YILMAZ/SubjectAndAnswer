using Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisService.Abstract
{
    public interface IRedisRepository<T> where T : class
    {
        List<T> GetAll();
        T Get(string key,string value);
        bool Add(string jsonString, string value);
        bool Update(string jsonString, string value);
        bool Delete(string key, string value);
    }
}
