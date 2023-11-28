using System;

namespace PraktikaVanyushkin.Models;

public class Illness_record
{
    private int _id;
    private int _medCards;
    private string _medName;
    private int _diseasesId;
    private string _diseasesName;
    private DateTime _recieptDate;
    private DateTime _dateOfDischarge;

    public Illness_record(int id, string medCards, string diseasesId, DateTime recieptDate, DateTime dateOfDischarge)
    {
        _id = id;
        _medName = medCards;
        _diseasesName = diseasesId;
        _recieptDate = recieptDate;
        _dateOfDischarge = dateOfDischarge;
    }

    public int Id => _id;

    public string MedName => _medName;

    public string DiseasesName => _diseasesName;

    public int MedCard => _medCards;
    
    public int DiseasesId => _diseasesId;
    
    public DateTime RecieptDate => _recieptDate;
    
    public DateTime DateOfDischarge => _dateOfDischarge;

    public string DispleyInfo => _medName + " " + _diseasesName;
}