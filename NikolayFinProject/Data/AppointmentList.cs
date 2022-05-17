using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace NikolayFinProject.Data
{
    public class AppointmentList
    {
        public AppointmentList(List<Appointment> appointmentList)
        {
            this.appointmentList = appointmentList;
        }
                [BsonIgnoreIfDefault]
        public ObjectId _id { get; set; }
        public List<Appointment> appointmentList { get; set; }
        public static void AddItem(AppointmentList item, string month)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("NikolayFinProject");
            var collection = database.GetCollection<AppointmentList>(month);
            if (database.ListCollectionNames().ToList().Exists(x => x == month))
                collection.ReplaceOne(x => true, item);
            else
                collection.InsertOne(item);
        }
        public static List<Appointment> GetItem(string month)
        {
            List<string> AllMonth = new()
            {
                "January",
                "February",
                "March",
                "April",
                "May",
                "June",
                "July",
                "August",
                "September",
                "October",
                "November",
                "December"
            };
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("NikolayFinProject");
            List<Appointment> list = new();
            if (AllMonth.Exists(x=>x==month) & database.ListCollectionNames().ToList().Exists(x => x == month))
            {
                var collection = database.GetCollection<AppointmentList>(month);
                list.AddRange(collection.Find(x => true).FirstOrDefault().appointmentList);
            }
            else
                list.Add(new Appointment("-", "-",new DateTime(), "-", "-", "-", 0));
            return list;
        }
    }
}