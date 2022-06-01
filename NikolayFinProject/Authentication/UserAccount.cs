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
        public UserAccount(string userName, string password, string role)
        {
            UserName = userName;
            Password = password;
            Role = role;
        }

        public ObjectId _id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        [BsonIgnore][Compare("Password")] public string ConfirmPassword { get; set; }
        public string Role { get; set; }

        public static void AddUserAccountToDB(string userName, string password)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("NikolayFinProject");
            var collection = database.GetCollection<UserAccount>("UserAccount");
            collection.InsertOne(new UserAccount(userName, password, "User"));
        }
        public static List<UserAccount> GetAllUserAccountFromDB()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("NikolayFinProject");
            var collection = database.GetCollection<UserAccount>("UserAccount");
            var allUsersFromDB = collection.Find(x => true).ToList();
            return allUsersFromDB;
        }
    }
}
