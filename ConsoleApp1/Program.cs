namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        AuthenticationService.InitializeUsers();
        User? currentUser = null;

        while (true)
        {
            if (currentUser == null)
            {
                Console.WriteLine("1. Login\n2. Exit");
                
                var choice = Console.ReadLine();
                if (choice == "1")
                {
                    Console.Write("Email: ");
                    string email = Console.ReadLine()!;
                    Console.Write("Password: ");
                    string password = Console.ReadLine()!;
                    currentUser = AuthenticationService.Login(email, password);

                    if (currentUser == null)
                        Console.WriteLine("Invalid email or password.");
                }
                else if (choice == "2")
                {
                    break;
                }
            }
            else
            {
                if (currentUser is Organizator organizer)
                {
                    Console.WriteLine("1. Create Event\n2. View Events\n3. Logout");
                    var choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        Console.Write("Event Name: ");
                        string name = Console.ReadLine()!;

                        Console.Write("Description: ");
                        string description = Console.ReadLine()!;

                        Console.Write("Capacity: ");
                        int capacity = int.Parse(Console.ReadLine()!);
                        while (true)
                        {
                            try
                            {
                                Console.Write("Date (yyyy-mm-dd): ");
                                DateTime date = DateTime.Parse(Console.ReadLine()!);
                                EventService.CreateEvent(organizer, name, description, capacity, date);
                                break;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Eroare neasteptata: {ex.Message}.Reintroduceti data!");
                            }
                        }
                    }
                    else if (choice == "2")
                        {
                            EventService.DisplayEvents();
                        }
                        else if (choice == "3")
                        {
                            currentUser = null;
                        }
                    }
                    else if (currentUser is Client client)
                    {
                        Console.WriteLine("1. View Events\n2. Register for Event\n3. Logout");
                        var choice = Console.ReadLine();
                        if (choice == "1")
                        {
                            EventService.DisplayEvents();
                        }
                        else if (choice == "2")
                        {
                            Console.Write("Event ID: ");
                            int eventId = int.Parse(Console.ReadLine()!);
                            EventService.RegisterForEvent(client, eventId);
                        }
                        else if (choice == "3")
                        {
                            currentUser = null;
                        }
                    }
                }
            }
        }
    }


 
 

 