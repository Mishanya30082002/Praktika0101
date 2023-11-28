using System;

namespace PraktikaVanyushkin.Models;

public class Transactions
{
    private int _id;
    private double _price;
    private DateTime _day;
    private int _appointmentID;

    public Transactions(int id, double price, DateTime day, int appointmentId)
    {
        _id = id;
        _price = price;
        _day = day;
        _appointmentID = appointmentId;
    }

    public int Id => _id;
    
    public double Price => _price;
    
    public DateTime Day => _day;
    
    public int AppintmentId => _appointmentID;
}