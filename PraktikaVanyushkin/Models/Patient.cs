using System;

namespace PraktikaVanyushkin.Models;

public class Patient
{
    private int _id;
    private string _firstName;
    private string _secongName;
    private string _lastName;
    private DateTime _birthday;
    private string _phoneNumber;

    public Patient(int id, string firstName, string secondName, string lastName, DateTime birthday, string phoneNumber)
    {
        _id = id;
        _firstName = firstName;
        _secongName = secondName;
        _lastName = lastName;
        _birthday = birthday;
        _phoneNumber = phoneNumber;
    }

    public int Id => _id;
    
    public string FirstName => _firstName;
    
    public string SecondName => _secongName;
    
    public string LastName => _lastName;
    
    public DateTime Birthday => _birthday;
    
    public string PhoneNumber => _phoneNumber;

}