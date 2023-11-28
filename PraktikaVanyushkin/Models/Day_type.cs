namespace PraktikaVanyushkin.Models;

public class Day_type
{
    private int _id;
    private string _dayType;

    public Day_type(int id, string dayType)
    {
        _id = id;
        _dayType = dayType;
    }

    public int Id => _id;
    
    public string DayType => _dayType;
}