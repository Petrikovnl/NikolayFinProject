using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp4.Data
{
    public class User
    {
        //public Users(string login, string phoneNumber)
        //{
        //    Login = login;
        //    PhoneNumber = phoneNumber;
        //}

        public User(string login, string password, string name, string surname,  string email,string phone, byte[] img)
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
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public byte[] Img { get; set; }


        //public static List<User> GetList()
        //{
        //    List<User> listToReturn = new List<User>();
        //    listToReturn.Add(new User("Bob", "Bob", "Smith", "987654321"));
        //    listToReturn.Add(new User("Bob", "John", "Marlou", "789465413"));
        //    listToReturn.Add(new User("Bob", "Ivan", "Ivanov", "987654321"));
        //    listToReturn.Add(new User("Bob", "Petr", "Petrov", "987654321"));
        //    listToReturn.Add(new User("Bob", "Andrey", "Andreev", "987654321"));
        //    listToReturn.Add(new User("Bob", "Georgiy", "Fedorov", "987654321"));
        //    return listToReturn;
        //}

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