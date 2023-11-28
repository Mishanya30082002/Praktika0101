using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MySqlConnector;
using PraktikaVanyushkin.Models;

namespace PraktikaVanyushkin;

public partial class ListAppointments : Window
{
    private DBHelper db = new DBHelper();
    private Employee _employee;
    private List<Appoinment> _appoinments;
    public ListAppointments(Employee employee)
    {
        _employee = employee;
        InitializeComponent();
        Update();
    }

    public void Update()
    {
        _appoinments = new List<Appoinment>();
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
                                  "ON illness_record.DiseasesID = diseases.id " +
                                  "WHERE Appointment.DoctorID = @id";
                cmd.Parameters.AddWithValue("@id", _employee.Id);
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

        List.ItemsSource = _appoinments;
    }

    private void ToggleButton_OnChecked(object? sender, RoutedEventArgs e)
    {
        CheckBox checkBox = sender as CheckBox;
        if(checkBox == null) return;
        if (checkBox.IsChecked == true)
        {
            Appoinment apcheck = checkBox.DataContext as Appoinment;
            using (var conn = new MySqlConnection(db._connectionString.ConnectionString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "Update Appointment " +
                                      "Set Attendance = @Attendance " +
                                      "Where id = @id";
                    cmd.Parameters.AddWithValue("@id", apcheck.Id);
                    cmd.Parameters.AddWithValue("@Attendance", 1);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
        Update();
    }
}