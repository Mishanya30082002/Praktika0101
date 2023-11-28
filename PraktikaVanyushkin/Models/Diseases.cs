namespace PraktikaVanyushkin.Models;

public class Diseases
{
    private int _id;
    private string _nameDiseases;

    public Diseases(int id, string nameDiseases)
    {
        _id = id;
        _nameDiseases = nameDiseases;
    }

    public int Id => _id;
    
    public string NameDiseases => _nameDiseases;
    
}