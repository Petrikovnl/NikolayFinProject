using Microsoft.AspNetCore.Components;
using NikolayFinProject.Data;
using System;
using System.Collections.Generic;

namespace NikolayFinProject.Pages
{
    public partial class MyAppointments
    {
        List<string> AllMonth = new() {"January", "February", "March", "April", "May", "June"
        , "July", "August", "September", "October", "November", "December"};
        string selectedString = ConvertMonthClass.ConvertMonth(DateTime.Now.Month);

        void DoStuff(ChangeEventArgs e)
        {
            selectedString = e.Value.ToString();
            _month = selectedString;
            GetList();
        }

        private List<Appointment> _appointmentList = AppointmentList.GetItem(_month);//new();

        private static string _month = ConvertMonthClass.ConvertMonth(DateTime.Now.Month);
        private string _nameOfAppointment;
        private string _appointmentsNotes;
        private DateTime _dateOfAppointment = DateTime.Now;
        private string _doctorsName;
        private string _doctorsSpecialization;
        private string _medCenterAddress;
        private int _cabinetNumber;
        private bool _isDone;

        private void AddNewTaskToList()
        {
            if (!string.IsNullOrEmpty(_nameOfAppointment) & !string.IsNullOrEmpty(_appointmentsNotes) & !string.IsNullOrEmpty(_doctorsName)
            & !string.IsNullOrEmpty(_doctorsSpecialization) & !string.IsNullOrEmpty(_medCenterAddress))
            {
                _appointmentList.Add(new Appointment(_nameOfAppointment, _appointmentsNotes, _dateOfAppointment,
                _doctorsName, _doctorsSpecialization, _medCenterAddress, _cabinetNumber));

                _nameOfAppointment = string.Empty;
                _appointmentsNotes = string.Empty;
                _doctorsName = string.Empty;
                _doctorsSpecialization = string.Empty;
                _medCenterAddress = string.Empty;
            }
        }

        private void DeleteTask(Appointment item)
        {
            _appointmentList.Remove(item);
        }

        private void AddToDB()
        {
            if (!string.IsNullOrEmpty(_month)) AppointmentList.AddItem(new AppointmentList(_appointmentList), _month);
        }

        private void GetList()
        {
            _appointmentList = AppointmentList.GetItem(_month);
        }
    }
}
