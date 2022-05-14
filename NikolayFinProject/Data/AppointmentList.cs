using MongoDB.Bson;
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

        public ObjectId _id { get; set; }
        public List<Appointment> appointmentList { get; set; }
        public static void AddAppointmentList(Appointment item, string month)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("NikolayFinProject");
            var collection = database.GetCollection<Appointment>(month);
            collection.InsertOne(item);
        }
        public static void AddAppointmentToDB(string nameOfAppointment, string appointmentsNotes, DateTime dateOfAppointment,
             string doctorsName, string doctorsSpecialization, string medCenterAddress,
            int cabinetNumber) //Добавление приема врача в БД
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("NikolayFinProject");
            var collection = database.GetCollection<Appointment>("Appointments");
            collection.InsertOne(new Appointment(nameOfAppointment, appointmentsNotes, dateOfAppointment, 
                doctorsName, doctorsSpecialization, medCenterAddress, cabinetNumber));
        }
        public static void AddItem(Appointment item, string day)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("NikolayFinProject");
            var collection = database.GetCollection<Appointment>(day);
            collection.InsertOne(item);
        }

    }
}
