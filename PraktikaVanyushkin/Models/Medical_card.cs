namespace PraktikaVanyushkin.Models;

public class Medical_card
{
    private int _id;
    private int _patientID;
    private string _patientInfo;

    public Medical_card(int id, string patientInfo)
    {
        _id = id;
        _patientInfo = patientInfo;
    }

    public int Id => _id;
    
    public string PatientInfo => _patientInfo;
    
}