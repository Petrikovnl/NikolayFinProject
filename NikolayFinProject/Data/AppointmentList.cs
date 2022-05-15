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
            {
                collection.ReplaceOne(x => true, item);
            }
            else
            {
                collection.InsertOne(item);
            }
        }
        public static List<Appointment> GetItem(string month)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("NikolayFinProject");
            if (month != null)
            {
                var collection = database.GetCollection<AppointmentList>(month);
                List<Appointment> list = new();
                list.AddRange(collection.Find(x => true).FirstOrDefault().appointmentList);
                return list;
            }
            else
            {
                var collection = database.GetCollection<AppointmentList>("January");
                List<Appointment> list = new();
                list.AddRange(collection.Find(x => true).FirstOrDefault().appointmentList);
                return list;
            }
        }
    }
}
