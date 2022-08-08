using Data.Abstract;
using Model.Abstract;
using Model.Concrete;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AdoRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        public bool Add(string commandText, List<SqlParameter> sqlParameters)
        {
            bool result = false;
            using (var connection = Connection.GetConnection)
            {
                var command = new SqlCommand(commandText, connection);
                sqlParameters.ForEach(prm => command.Parameters.AddWithValue(prm.ParameterName, prm.Value));
                connection.Open();
                if (command.ExecuteNonQuery() != -1)
                {
                    result = true;
                }
                connection.Close();
            }
            return result;
        }

        public bool Delete(string commandText, SqlParameter sqlParameter)
        {
            bool result = false;
            using (var connection = Connection.GetConnection)
            {
                var command = new SqlCommand(commandText, connection);
                command.Parameters.AddWithValue(sqlParameter.ParameterName, sqlParameter.Value);
                connection.Open();
                if (command.ExecuteNonQuery() != -1)
                {
                    result = true;
                }
                connection.Close();
            }
            return result;
        }

        public TEntity Get(string commandText)
        {
            List<TEntity> entities = new List<TEntity>();
            using (var connection = Connection.GetConnection)
            {
                var command = new SqlCommand(commandText, connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var type = typeof(TEntity);
                        TEntity obj = (TEntity)Activator.CreateInstance(type);
                        foreach (var item in type.GetProperties())
                        {
                            var propType = item.PropertyType;
                            item.SetValue(obj, Convert.ChangeType(reader[item.Name].ToString(), propType));
                        }
                        entities.Add(obj);
                    }
                }
                connection.Close();
            }
            return entities.FirstOrDefault();
        }

        public List<TEntity> GetAll(string commandText)
        {
            List<TEntity> entities = new List<TEntity>();
            using (var connection = Connection.GetConnection)
            {
                var command = new SqlCommand(commandText, connection);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var type = typeof(TEntity);
                        TEntity obj = (TEntity)Activator.CreateInstance(type);
                        foreach (var item in type.GetProperties())
                        {
                            var propType = item.PropertyType;
                            item.SetValue(obj, Convert.ChangeType(reader[item.Name].ToString(), propType));
                        }
                        entities.Add(obj);
                    }
                }
                connection.Close();
            }
            return entities;
        }
        public long GetAllCount(string commandText)
        {
            using (var connection = Connection.GetConnection)
            {
                var command = new SqlCommand(commandText, connection);
               
                try
                {
                    connection.Open();

                }
                catch (Exception)
                {
                    using (DataContext context = new DataContext())
                    {
                        context.Set<SubjectEntities>().ToList();
                    }
                    connection.Open();
                }

                var cc = (int)command.ExecuteScalar();
                return cc;
            }
        }
        public SqlCommand GetAllCommand(string commandText)
        {
            using (var connection = Connection.GetConnection)
            {
                return new SqlCommand(commandText, connection);
            }
        }

        public bool Update(string commandText, List<SqlParameter> sqlParameters)
        {
            bool result = false;
            using (var connection = Connection.GetConnection)
            {
                var command = new SqlCommand(commandText, connection);
                sqlParameters.ForEach(prm => command.Parameters.AddWithValue(prm.ParameterName, prm.Value));
                connection.Open();
                if (command.ExecuteNonQuery() != -1)
                {
                    result = true;
                }
                connection.Close();
            }
            return result;
        }
    }
}
