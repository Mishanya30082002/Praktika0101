using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MySqlConnector;
using PraktikaVanyushkin.Models;

namespace PraktikaVanyushkin;

public partial class AddAppointments : Window
{
    private List<Illness_record> _records;
    private List<Employee> _employees;
    private List<Appoinment> _appoinments;
    private double zarlata;
    private DBHelper db = new DBHelper();
    public AddAppointments()
    {
        InitializeComponent();
        Update();
    }

    public void Update()
    {
        _appoinments = new List<Appoinment>();
        _employees = new List<Employee>();
        _records = new List<Illness_record>();
        using (var conn = new MySqlConnection(db._connectionString.ConnectionString))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM illness_record " +
                                  "JOIN medicalcard " +
                                  "ON illness_record.MedCards = medicalcard.id " +
                                  "JOIN Patients " +
                                  "on medicalcard.patient = Patients.id " +
                                  "JOIN diseases " +
                                  "ON illness_record.DiseasesID = diseases.id";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _records.Add(new Illness_record(
                        reader.GetInt16("id"),
                        reader.GetString("fName") + " "+
                        reader.GetString("sName") +" "+ 
                        reader.GetString("lName"),
                        reader.GetString("NameDiseases"),
                        reader.GetDateTime("receipt_date"),
                        reader.GetDateTime("date_of_discharge")));
                }
                
            }
            conn.Close();
        }
        using (var conn = new MySqlConnection(db._connectionString.ConnectionString))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Employee " +
                                  "JOIN JobTitles " +
                                  "ON JobTitles.id = employee.JobTitle " +
                                  "WHERE JobTitles.NameJobTitle = 'Врач' ";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _employees.Add(new Employee(reader.GetInt16("id"),
                        reader.GetString("login"),
                        reader.GetString("password"),
                        reader.GetString("FirstName"),
                        reader.GetString("SecondName"),
                        reader.GetString("LastName"),
                        reader.GetDateTime("birthday"),
                        reader.GetString("Gender"),
                        reader.GetString("NameJobTitle"),
                        reader.GetString("phone_number")));
                }
                
            }
            conn.Close();
        }
        using (var conn = new MySqlConnection(db._connectionString.ConnectionString))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Appointment " +
                                  "JOIN Employee " +
                                  "On Appointment.DoctorID = Employee.id " +
                                  "JOIN illness_record " +
                                  "on Appointment.illness_record = illness_record.id " +
                                  "JOIN medicalcard " +
                                  "ON illness_record.MedCards = medicalcard.id " +
                                  "JOIN Patients " +
                                  "on medicalcard.patient = Patients.id " +
                                  "JOIN diseases " +
                                  "ON illness_record.DiseasesID = diseases.id";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _appoinments.Add(new Appoinment(
                        reader.GetInt16("id"),
                        reader.GetDateTime("AppointmentDate"),
                        reader.GetString("FirstName") + " "+
                        reader.GetString("SecondName") +" "+ 
                        reader.GetString("LastName"),
                        reader.GetString("fName") + " "+
                        reader.GetString("sName") +" "+ 
                        reader.GetString("lName") +" " +
                        reader.GetString("NameDiseases"),
                        reader.GetBoolean("Attendance")));
                }
                
            }
            conn.Close();
        }

        foreach (var a in _appoinments)
        {
            if (a.Attendance) zarlata += 1000;
        }
        CbDoctors.ItemsSource = _employees;
        CbIllnessRecord.ItemsSource = _records;
        List.ItemsSource = _appoinments;
        tbZarplata.Text += " " +zarlata;
    }

    private void LogOut(object? sender, RoutedEventArgs e)
    {
        new MainWindow().Show();
        Close();
    }

    private void Insert(object? sender, RoutedEventArgs e)
    {
        using (var conn = new MySqlConnection(db._connectionString.ConnectionString))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO appointment (AppointmentDate,DoctorID,illness_record) " +
                                  "VALUES (@AppointmentDate,@DoctorID,@illness_record)";
                cmd.Parameters.AddWithValue("@AppointmentDate",Date.SelectedDate + Time.SelectedTime);
                cmd.Parameters.AddWithValue("@DoctorID",(CbDoctors.SelectedItem as Employee).Id);
                cmd.Parameters.AddWithValue("@illness_record",(CbIllnessRecord.SelectedItem as Illness_record).Id);
                var reader = cmd.ExecuteReader();
            }
            conn.Close();
        }
        Update();
    }

   
}