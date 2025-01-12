namespace ConsoleApp1;

public class Eveniment
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Capacity { get; set; }
    public DateTime Date { get; set; }
    public List<Client> Participants { get; set; } = new List<Client>();

    public Eveniment(int id, string name, string description, int capacity, DateTime date)
    {
        Id = id;
        Name = name;
        Description = description;
        Capacity = capacity;
        Date = date;
    }
}