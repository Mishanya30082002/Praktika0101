using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;
using PraktikaVanyushkin.Models;
using MySqlConnector;

namespace PraktikaVanyushkin;

public partial class AddIllnessRecord : Window
{
    private List<Illness_record> _records;
    private List<Diseases> _diseasesList;
    private List<Medical_card> _medicalCards;
    private DBHelper db = new DBHelper();
    private Employee _employee;
    public AddIllnessRecord(Employee employee)
    {
        _employee = employee;
        InitializeComponent();
        Update();
    }

        
    public void Update()
    {
        _diseasesList = new List<Diseases>();
        _medicalCards = new List<Medical_card>();
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
                cmd.CommandText = "SELECT * FROM medicalcard " +
                                  "JOIN Patients " +
                                  "on medicalcard.patient = Patients.id ";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _medicalCards.Add(new Medical_card(
                        reader.GetInt16("id"),
                        reader.GetString("fName") + " "+
                        reader.GetString("sName") +" "+ 
                        reader.GetString("lName")));
                }
                
            }
            conn.Close();
        }
        using (var conn = new MySqlConnection(db._connectionString.ConnectionString))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM diseases " ;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _diseasesList.Add(new Diseases(
                        reader.GetInt16("id"),
                        reader.GetString("NameDiseases")));
                }
                
            }
            conn.Close();
        }

        CbDiseases.ItemsSource = _diseasesList;
        CbMedCard.ItemsSource = _medicalCards;
        List.ItemsSource = _records;
    }

    private void Insert(object? sender, RoutedEventArgs e)
    {
        using (var conn = new MySqlConnection(db._connectionString.ConnectionString))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO illness_record (MedCards,DiseasesID,receipt_date,date_of_discharge)" +
                                  "VALUES (@MedCards,@DiseasesID,@receipt_date,@date_of_discharge) ";
                cmd.Parameters.AddWithValue("@MedCards",(CbMedCard.SelectedItem as Medical_card).Id);
                cmd.Parameters.AddWithValue("@DiseasesID",(CbDiseases.SelectedItem as Diseases).Id);
                cmd.Parameters.AddWithValue("@receipt_date",Date.SelectedDate);
                cmd.Parameters.AddWithValue("@date_of_discharge",Date1.SelectedDate);
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
        Update();
    }

    private void LogOut(object? sender, RoutedEventArgs e)
    {
        new MainWindow().Show();
        Close();
    }

    private void openListAppointments(object? sender, RoutedEventArgs e)
    {
        new ListAppointments(_employee).Show();
    }
}