﻿using System;

namespace PraktikaVanyushkin.Models;

public class Employee
{
    private int _id;
    private string _login;
    private string _password;
    private string _firstName;
    private string _secondName;
    private string _lastName;
    private DateTime _birthday;
    private string _gender;
    private int _jobTitle;
    private string _jobName;
    private string _phoneNumber;

    public Employee(int id, string login, string password, string firstName, string secondName, string lastName,
        DateTime birthday, string gender, string jobName, string phoneNumber)
    {
        _id = id;
        _login = login;
        _password = password;
        _firstName = firstName;
        _secondName = secondName;
        _lastName = lastName;
        _birthday = birthday;
        _gender = gender;
        _phoneNumber = phoneNumber;
        _jobName = jobName;
    }

    public bool log(string login, string password)
    {
        if (_login == login && _password == password) return true;
        return false;
    }
    public int Id => _id;

    public string Login => _login;

    public string Password => _password;

    public string FirstName => _firstName;

    public string SecondName => _secondName;

    public string LastName => _lastName;

    public DateTime Birthday => _birthday;

    public string Gender => _gender;
    
    public int JobTitle=>_jobTitle;

    public string JobName => _jobName;
    public string PhoneNumber=>_phoneNumber;

    public string DisplayInfo => _firstName +
                                 " " + _secondName +
                                 " " + _lastName +
                                 " | " + _jobName;

}