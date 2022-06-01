using BlazorApp4.Data;
using MongoDB.Driver;

namespace NikolayFinProject
{
    public class Services
    {
    }
    
    public class SingletonService
    {
        public SingletonService()
        {
            authorizedUser = GetAccountProfile("petrikov89");
        }
        public User authorizedUser { get; set; }
        public string Login { get; set; }
        public static User GetAccountProfile(string searchedLogin)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("NikolayFinProject");
            var collection = database.GetCollection<User>("Users");
            User FoundUser = collection.Find(x => x.Login == searchedLogin).FirstOrDefault();
            return FoundUser;
        }
    }

    public class TransientService
    {
        public int Value { get; set; }
    }
}