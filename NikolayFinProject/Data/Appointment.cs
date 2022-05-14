using MongoDB.Bson;
using System;

namespace NikolayFinProject.Data
{
    public class Appointment
    {
        public Appointment(string nameOfAppointment, string appointmentsNotes, DateTime dateOfAppointment, 
            string doctorsName, string doctorsSpecialization, string medCenterAddress, 
            int cabinetNumber)
        {
            NameOfAppointment = nameOfAppointment;
            AppointmentsNotes = appointmentsNotes;
            DateOfAppointment = dateOfAppointment;
            DoctorsName = doctorsName;
            DoctorsSpecialization = doctorsSpecialization;
            MedCenterAddress = medCenterAddress;
            CabinetNumber = cabinetNumber;
        }
        public ObjectId _id { get; set; }
        public string NameOfAppointment { get; set; }
        public string AppointmentsNotes { get; set; }
        public DateTime DateOfAppointment { get; set; }
        public string DoctorsName { get; set; }
        public string DoctorsSpecialization { get; set; }
        public string MedCenterAddress { get; set; }
        public int CabinetNumber { get; set; }
        public bool IsDone { get; set; }
    }
}
