namespace ConsoleApp1;

public static class EventService
{
    private static List<Eveniment> Events = new List<Eveniment>();

    public static void CreateEvent(Organizator organizer, string name, string description, int capacity, DateTime date)
    {
        int id = Events.Count + 1;
        var newEvent = new Eveniment(id, name, description, capacity, date);
        Events.Add(newEvent);
        Console.WriteLine($"Event '{name}' has been created by {organizer.FirstName}.");
    }

    public static void UpdateEvent(int eventId, string updateDetails)
    {
        var ev = Events.FirstOrDefault(e => e.Id == eventId);
        if (ev != null)
        {
            Console.WriteLine($"Event '{ev.Name}' has been updated: {updateDetails}");
        }
        else
        {
            Console.WriteLine("Event not found.");
        }
    }

    public static void DisplayEvents()
    {
        foreach (var ev in Events)
        {
            Console.WriteLine($"[{ev.Id}] {ev.Name} -{ev.Description} - {ev.Date:dd/MM/yyyy} ({ev.Participants.Count}/{ev.Capacity})");
        }
    }

    public static void RegisterForEvent(Client client, int eventId)
    {
        var ev = Events.FirstOrDefault(e => e.Id == eventId);
        if (ev != null && ev.Participants.Count < ev.Capacity)
        {
            ev.Participants.Add(client);
            Console.WriteLine($"{client.FirstName} has registered for the event '{ev.Name}'.");
        }
        else
        {
            Console.WriteLine("Event is full or does not exist.");
        }
    }
}