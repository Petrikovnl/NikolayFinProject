using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp4.Data
{
    public class User
    {
        public User(string login, string password, string name, string surname,  string email, string phone, byte[] img)
        {
            Login = login;
            Password = password;
            Name = name;
            Surname = surname;
            Email=email;
            Phone = phone;
            Img = img;
        }

		public User()
		{
		}

		public ObjectId _id { get; set; }

        [Required][RegularExpression(@"^[a-zA-Z][a-zA-Z0-9-_\.]{1,20}$"
        ,ErrorMessage = "Limit of 2-20 characters, which can be letters and numbers" +
            ", the first character must be a letter")] public string Login { get; set; }

        [Required][RegularExpression(@"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$"
        , ErrorMessage = "Uppercase and lowercase Latin letters" +
            ", numbers, special characters.Minimum 8 characters")] public string Password { get; set; }
        
        [BsonIgnore][Compare("Password")] public string ConfirmPassword { get; set; }
        [BsonIgnoreIfNull] public string Name { get; set; }
        [BsonIgnoreIfNull] public string Surname { get; set; }
        [Required][EmailAddress] public string Email { get; set; }
        [BsonIgnoreIfNull][Phone] public string Phone { get; set; }
        [BsonIgnoreIfNull] public byte[] Img { get; set; }

        public static void AddUserToDB(string login, string password, string name, string surname, string email,
            string phone, byte[] img) //Добавление юзера в БД
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("NikolayFinProject");
            var collection = database.GetCollection<User>("Users");
            collection.InsertOne(new User(login,password, name, surname, email, phone, img));
        }

        public static User GetAccountProfile(string searchedLogin)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("NikolayFinProject");
            var collection = database.GetCollection<User>("Users");
            User FoundUser=collection.Find(x=>x.Login== searchedLogin).FirstOrDefault();
            return FoundUser;
        }

        public static void DeleteUser(string searchedLogin)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("NikolayFinProject");
            var collection = database.GetCollection<User>("Users");
            collection.DeleteOne(x=>x.Login==searchedLogin);
        }

        public static List<User> GetAllUsersFromDb()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("NikolayFinProject");
            var collection = database.GetCollection<User>("Users");
            var allUsersFromDB = collection.Find(x => true).ToList();
            return allUsersFromDB;
        }
        
        
        public static List<String> GetLoginFromDb()
        {

            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("NikolayFinProject");
            var collection = database.GetCollection<User>("Users");
            var listUsersFromDB = collection.Find(x => true).ToList();
            var listToReturn = new List<string>();
            foreach (var item in listUsersFromDB)
            {
                listToReturn.Add(item.Login);
            }
            return listToReturn;
        }
    }
}