using EC.Infrastructure.Abstractions.Repositories;

namespace EC.Forms.Infrastructure
{
    public class ApplicationDataRepository : IApplicationDataRepository
    {
        private const string StorageGroupKey = "Default";

        // private static readonly SimpleStorage StorageGroup = SimpleStorage.EditGroup(StorageGroupKey);

        public string GetStringFromApplicationData(string key, string defaultValue)
        {
            //var returnString = StorageGroup.HasKey(key) ?
            //    StorageGroup.Get<string>(key) :
            //    defaultValue;
            //return returnString;
            return defaultValue;
        }

        public bool? GetOptionalBooleanFromApplicationData(string key, bool? defaultValue)
        {
            //var returnBool = StorageGroup.HasKey(key) ? 
            //    StorageGroup.Get<bool?>(key) : 
            //    defaultValue;

            //return returnBool;
            return defaultValue;
        }

        public int? GetOptionalIntegerFromApplicationData(string key, int? defaultValue)
        {
            //var returnInt = StorageGroup.HasKey(key) ? 
            //    StorageGroup.Get<int?>(key) : 
            //    defaultValue;

            //return returnInt;
            return defaultValue;            
        }

        public void SetStringToApplicationData(string key, string value)
        {
            // StorageGroup.Put<string>(key, value);
        }
    }
}
