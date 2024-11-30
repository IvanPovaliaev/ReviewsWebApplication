using Newtonsoft.Json;
using Reviews.Application.Helpers;
using Reviews.Domain.Interfaces;
using StackExchange.Redis;

namespace Reviews.Application.Services
{
    public class CacheService : ICacheService
    {
        private readonly IDatabase _db;

        public CacheService()
        {
            _db = ConnectionHelper.Connection.GetDatabase();
        }

        public T GetData<T>(string key)
        {
            var value = _db.StringGet(key);

            if (!string.IsNullOrEmpty(value))
            {
                return JsonConvert.DeserializeObject<T>(value)!;
            }

            return default!;
        }

        public bool SetData<T>(string key, T value, DateTimeOffset expirationTime)
        {
            var expiryTime = expirationTime.DateTime.Subtract(DateTime.Now);
            var isSet = _db.StringSet(key, JsonConvert.SerializeObject(value), expiryTime);
            return isSet;
        }

        public object RemoveData(string key)
        {
            var isKeyExist = _db.KeyExists(key);

            if (isKeyExist)
            {
                return _db.KeyDelete(key);
            }

            return false;
        }
    }
}
