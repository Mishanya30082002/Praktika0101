using System;

namespace PraktikaVanyushkin.Models;

public class Report_card
{
    private int _id;
    private DateTime _day;
    private int _employee;
    private int _dayType;

    public Report_card(int id, DateTime day, int employee, int dayType)
    {
        _id = id;
        _day = day;
        _employee = employee;
        _dayType = dayType;
    }

    public int Id => _id;
    
    public DateTime Day => _day;
    
    public int Employee => _employee;
    
    public int DayType => _dayType;
}