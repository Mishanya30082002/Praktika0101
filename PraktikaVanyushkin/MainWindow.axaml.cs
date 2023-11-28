using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;
using MySqlConnector;
using PraktikaVanyushkin.Models;

namespace PraktikaVanyushkin;

public partial class MainWindow : Window
{
   
    private List<Employee> _employees;
    
    DBHelper db = new DBHelper();
    public MainWindow()
    {
        InitializeComponent();
        Update();
    }
    private void Update()
    {
        _employees = new List<Employee>();
        using (var connection = new MySqlConnection(db._connectionString.ConnectionString))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT * FROM Employee " +
                                      "JOIN JobTitles " +
                                      "ON JobTitles.id = employee.JobTitle";
                var reader = command.ExecuteReader();
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
            connection.Close();
        }
    }

    

    private void Log(object? sender, RoutedEventArgs e)
    {
        foreach (var emp in _employees)
        {
            if (!emp.log(tbName.Text, tbpassword.Text)) continue;
            if (emp.JobName == "администратор")
            {
                new AddAppointments().Show();
            }
            else
            {
                new AddIllnessRecord(emp).Show();
            }
        }
        Close();
    }
}
