using Newtonsoft.Json;
using StackExchange.Redis;

namespace Review.Domain.Services
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
            var _isKeyExist = _db.KeyExists(key);

            if (_isKeyExist)
            {
                return _db.KeyDelete(key);
            }

            return false;
        }
    }
}
