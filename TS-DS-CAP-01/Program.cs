namespace TS_DS_CAP_01
{
    internal class Program
    {
        static List<string> passengerNames = new List<string>() { "Wajdan", "Ali", "Ahmed", "Sara", "Fatma" };
        static List<string> ticketNumbers = new List<string>() { "TKT-001", "TKT-002", "TKT-003", "TKT-004", "TKT-005" };
        static string[] flightNumbers = { "OA101", "OA102", "OA103", "OA104", "OA105", "OA106" };
        static List<string> availableDates = new List<string>() {"12-Jan-2026","15-Jan-2026","18-Jan-2026","20-Jan-2026" };
        static Dictionary<string, string> bookingRecord = new Dictionary<string, string>();
        static Queue<string> checkedInQueue =new Queue<string>();
        static Stack<string> boardingStack =new Stack<string>();
        static List<string> cancelledTickets =new List<string>();
        static Dictionary<string, string> passengerSeatMap =new Dictionary<string, string>();
        static Queue<string> waitlistQueue =new Queue<string>();

        public static void RegisterNewPassenger()
        {
            Console.Write("Enter passenger name: ");
            string EnterpassengerName = Console.ReadLine();

            // Check if name is empty
            if (EnterpassengerName.Trim() == "")
            {
                Console.WriteLine("Name cannot be empty.");
                return;
            }

            // Check if the passenger already exists in the list
            for (int i = 0; i < passengerNames.Count; i++)
            {
                // Compare names ignoring uppercase and lowercase letters
                if (EnterpassengerName.ToLower().Trim() == passengerNames[i].ToLower().Trim())
                {
                    Console.WriteLine("Passenger already exists.");
                    return;
                }
            }//end of for

            // Generate new ticket ID
            string ticketID = "TKT-" + (ticketNumbers.Count + 1).ToString("000");

            // Add passenger name and ticket ID at the same index
            passengerNames.Add(EnterpassengerName);
            ticketNumbers.Add(ticketID);

            // Display success message
            Console.WriteLine("Passenger registered successfully.");
            Console.WriteLine("Passenger Name: " + EnterpassengerName);
            Console.WriteLine("Ticket ID: " + ticketID);
        }
        public static void ViewAllPassengers()
        {
            // Check if there are any registered passengers
            if (passengerNames.Count == 0)
            {
                Console.WriteLine("No passengers registered yet.");
                return;
            }
           
            // Display table header
            Console.WriteLine( "No.".PadRight(5) + " | " + "Passenger Name".PadRight(22) + " | " + "Ticket ID".PadRight(22) + " | " + "Status" );
            // Loop through all passengers
            for (int index = 0; index < passengerNames.Count; index++)
            {
                // Default passenger status
                string status = "Active";
                // Check if the ticket has been cancelled
                if (cancelledTickets.Contains(ticketNumbers[index]))
                {
                    status = "CANCELLED";
                }
                // Display passenger information
                Console.WriteLine((index + 1).ToString().PadRight(5) + " | " +   passengerNames[index].PadRight(22) + " | " +  ticketNumbers[index].PadRight(22) + " | " +  status);
            }
            // Display total number of passengers
            Console.WriteLine("Total Passengers: " + passengerNames.Count);
        }

        public static void showMenue()
        {
            Console.WriteLine("=======================================");
            Console.WriteLine("\nSKY WINGS FLIGHT MANAGEMENT SYSTEM");
            Console.WriteLine("=======================================");
            Console.WriteLine("\n1. Register New Passenger");
            Console.WriteLine("\n2. View All Passengers");
            Console.WriteLine("\n3. Book a Flight Ticke");
            Console.WriteLine("\n4. View Booking Details");
            Console.WriteLine("\n5. Update a Booking");
            Console.WriteLine("\n6. Cancel a Ticket");
            Console.WriteLine("\n7. Passenger Check-In");
            Console.WriteLine("\n8. Board Passengers (Boarding Stack)");
            Console.WriteLine("\n9. Generate Flight Manifest");
            Console.WriteLine("\n10. Manage Waitlist & Seat Assignment");
            Console.WriteLine("\n0. Exit");
            Console.WriteLine("=======================================");
            Console.Write("\nEnter your choice: ");
        }
            static void Main(string[] args)
        {
            bool exit = false;
            while (exit == false)
            {
                showMenue();
                int enterChoise = int.Parse(Console.ReadLine());
                switch (enterChoise) {
                    case 1://1. Register New Passenger
                        RegisterNewPassenger();
                        break;
                    case 2://2. View All Passengers
                        ViewAllPassengers();
                        break;
                    case 3://3. Book a Flight Ticke
                        break;
                    case 4://4. View Booking Details
                        break;
                    case 5://5. Update a Booking
                        break;
                    case 6://6. Cancel a Ticket
                        break;
                    case 7://7. Passenger Check-In
                        break;
                    case 8://8. Board Passengers (Boarding Stack
                        break;
                    case 9://9. Generate Flight Manifest
                        break;
                    case 10://10. Manage Waitlist & Seat Assignment
                        break;
                    case 0://0. Exit
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("=======================================");
                        Console.WriteLine("Invalid choice. Please try again.");

                        break;
                
                }
                Console.WriteLine("Press Any Key To Continue .....");
                Console.ReadKey();
                Console.Clear();
            }

        }
    }
}
