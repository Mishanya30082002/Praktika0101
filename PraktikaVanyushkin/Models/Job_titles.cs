namespace PraktikaVanyushkin.Models;

public class Job_titles
{
    private int _id;
    private string _nameJobTitle;

    public Job_titles(int id, string nameJobTitle)
    {
        _id = id;
        _nameJobTitle = nameJobTitle;
    }

    public int Id => _id;
    public string NameJobTitle => _nameJobTitle;
}
