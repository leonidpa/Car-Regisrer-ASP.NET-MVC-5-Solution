using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRegisterRepositoryLibrary.Services
{
    public class RepositoryService
    {
        private static Stack<KeyValuePair<string, object>> _dataStoreDictionary = new Stack<KeyValuePair<string, object>>();

        private RepositoryService() { }

        private static void CreateInstance<T>(string connectionString) where T : class, new()
        {
            if (_dataStoreDictionary.SingleOrDefault(e => (e.Value as T) != null).Equals(default(KeyValuePair<string, object>)))
            {
                var _dataStore = new T();
                _dataStoreDictionary.Push(new KeyValuePair<string, object>(connectionString, _dataStore));
            }
        }

        public static void Register<T>(string connectionString) where T : class, new()
        {
            CreateInstance<T>(connectionString);
        }

        public static string ConnectionString<T>() where T : class
            => _dataStoreDictionary?.SingleOrDefault(e => (e.Value as T) != null).Key;


        public static T Get<T>() where T : class
        {
            return _dataStoreDictionary.FirstOrDefault(e => e.Value is T).Value as T;
        }
    }
}
