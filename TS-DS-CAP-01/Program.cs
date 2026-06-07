using System.Net.Sockets;

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
            Console.WriteLine("===============================================================================================================");

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
            Console.WriteLine("=======================================");

        }
        public static void BookFlightTicket()
        {
            Console.Write("Enter a ticket ID : ");
            string  ticketID = Console.ReadLine();
            // Check if ticket ID exists
            if (!ticketNumbers.Contains(ticketID))
            {
                Console.WriteLine("Ticket not found.");
                return;
            }
            // Check if ticket is cancelled
            if (cancelledTickets.Contains(ticketID))
            {
                Console.WriteLine("This ticket has been cancelled.");
                return;
            }
            // Check if ticket already has a booking
            if (bookingRecord.ContainsKey(ticketID))
            {
                Console.WriteLine("Ticket already booked.");
                return;
            }
            // Display available flights
            Console.WriteLine("\nAvailable Flights:");
            for (int i = 0; i < flightNumbers.Length; i++)
            {
                Console.WriteLine((i + 1) + ". " + flightNumbers[i]);
            }
            // Select flight
            Console.Write("Select Flight: ");
            int flightChoice = int.Parse(Console.ReadLine());
            if (flightChoice < 1 || flightChoice > flightNumbers.Length)
            {
                Console.WriteLine("Invalid flight choice.");
                return;
            }
            string selectedFlight = flightNumbers[flightChoice - 1];
            // Display available dates
            Console.WriteLine("\nAvailable Dates:");
            for (int i = 0; i < availableDates.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + availableDates[i]);
            }
            // Select date
            Console.Write("Select Date: ");
            int dateChoice = int.Parse(Console.ReadLine());
            if (dateChoice < 1 || dateChoice > availableDates.Count)
            {
                Console.WriteLine("Invalid date choice.");
                return;
            }
            // Store the selected date
            string selectedDate = availableDates[dateChoice - 1];

            // Save booking in dictionary
            bookingRecord.Add(ticketID, selectedFlight + "|" + selectedDate);

            // Find passenger name using ticket index
            int passengerIndex = ticketNumbers.IndexOf(ticketID);

            // Display booking confirmation
            Console.WriteLine("\nBooking Successful");
            Console.WriteLine("Passenger Name: " + passengerNames[passengerIndex]);
            Console.WriteLine("Ticket ID: " + ticketID);
            Console.WriteLine("Flight: " + selectedFlight);
            Console.WriteLine("Date: " + selectedDate);
        }
        public static void ViewBookingDetails()
        {
            Console.WriteLine("Enter tickit ID : ");
            string ticketId = Console.ReadLine();
            // Check if ticket exists
            if (!ticketNumbers.Contains(ticketId))
            {
                Console.WriteLine("Ticket not found.");
                return;
            }
            // Get passenger name using ticket index
            int passengerIndex = ticketNumbers.IndexOf(ticketId);
                string passengerName = passengerNames[passengerIndex];
            // Check if ticket is cancelled
            if (!ticketNumbers.Contains(ticketId))
            {
                Console.WriteLine("Ticket not found.");
                return;
            }
            // Check if ticket is cancelled
            if (cancelledTickets.Contains(ticketId))
            {
                Console.WriteLine("This ticket has been cancelled.");
                return;
            }

            // Check if booking exists
            if (!bookingRecord.ContainsKey(ticketId))
            {
                Console.WriteLine("No booking found for this ticket.");
                return;
            }

            // Get booking value from dictionary
            string bookingValue = bookingRecord[ticketId];

            // Split flight and date
            string[] bookingParts = bookingValue.Split('|');

            string flight = bookingParts[0];
            string date = bookingParts[1];

            // Display booking details
            Console.WriteLine("\nBooking Details");
            Console.WriteLine("Passenger Name: " + passengerName);
            Console.WriteLine("Ticket ID: " + ticketId);
            Console.WriteLine("Flight: " + flight);
            Console.WriteLine("Date: " + date);
        }
        public static void UpdateBookingMenu()
        {
            // Sub-menu code
            bool back = false;

            while (back == false)
            {
                Console.WriteLine("1. Change flight only");
                Console.WriteLine("2. Change date only");
                Console.WriteLine("3. Change both");
                Console.WriteLine("0. Cancel update");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Change flight only");
                        // Display flights
                        for (int i = 0; i < flightNumbers.Length; i++)
                        {
                            Console.WriteLine((i + 1) + ". " + flightNumbers[i]);
                        }
                        
                        back = true;
                        break;

                    case 2:
                        Console.WriteLine("Change date only");
                        back = true;
                        break;

                    case 3:
                        Console.WriteLine("Change both");
                        back = true;
                        break;

                    case 0:
                        Console.WriteLine("Update cancelled.");
                        back = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
        public static void UpdateBooking()
        {
            Console.Write("Enter Ticket ID: ");
            string ticketID = Console.ReadLine();

            // Check if ticket exists
            if (!ticketNumbers.Contains(ticketID))
            {
                Console.WriteLine("Ticket not found.");
                return;
            }

            // Check if ticket is cancelled
            if (cancelledTickets.Contains(ticketID))
            {
                Console.WriteLine("This ticket has been cancelled.");
                return;
            }

            // Check if booking exists
            if (!bookingRecord.ContainsKey(ticketID))
            {
                Console.WriteLine("No booking found.");
                return;
            }
            Console.WriteLine(bookingRecord[ticketID]);
            UpdateBookingMenu();
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
                        BookFlightTicket();
                        break;
                    case 4://4. View Booking Details
                        ViewBookingDetails();
                        break;
                    case 5://5. Update a Booking
                        UpdateBooking();
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
