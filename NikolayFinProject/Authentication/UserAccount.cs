using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NikolayFinProject.Authentication
{
    public class UserAccount
    {
        public UserAccount()
        {
        }
        public UserAccount(string userLogin, string password, string role)
        {
            UserLogin = userLogin;
            Password = password;
            Role = role;
        }

        public UserAccount(string userLogin, string password, string role, byte[] img)
        {
            UserLogin = userLogin;
            Password = password;
            Role = role;
            Img = img;
        }
        [BsonIgnoreIfDefault]
        [BsonElement]
        public ObjectId _id { get; set; }
        [EmailAddress]
        public string UserLogin { get; set; }
        public string Password { get; set; }
        [BsonIgnore][Compare("Password")] public string ConfirmPassword { get; set; }
        public string Role { get; set; }
        [BsonIgnoreIfNull]
        public byte[] Img;

        public static void ReplaceUserAccountToDB(string userLogin, byte[] img)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("NikolayFinProject");
            var collection = database.GetCollection<UserAccount>("UserAccount");
            UserAccount userAccount = collection.Find(x => x.UserLogin == userLogin).FirstOrDefault();
            collection.ReplaceOne(x=>x.UserLogin==userLogin, new UserAccount(userAccount.UserLogin, userAccount.Password
                ,userAccount.Role,img));
        }
        public static void AddUserAccountToDB(string userLogin, string password)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("NikolayFinProject");
            var collection = database.GetCollection<UserAccount>("UserAccount");
            collection.InsertOne(new UserAccount(userLogin, password, "User"));
        }
        public static List<UserAccount> GetAllUserAccountFromDB()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("NikolayFinProject");
            var collection = database.GetCollection<UserAccount>("UserAccount");
            var allUsersFromDB = collection.Find(x => true).ToList();
            return allUsersFromDB;
        }
        public static UserAccount GetAccountProfile(string searchedLogin)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("NikolayFinProject");
            var collection = database.GetCollection<UserAccount>("UserAccount");
            UserAccount FoundUser = collection.Find(x => x.UserLogin == searchedLogin).FirstOrDefault();
            return FoundUser;
        }
    }
}
