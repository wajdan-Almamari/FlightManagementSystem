namespace TS_DS_CAP_01
{
    internal class Program
    {
        // MAI TEST 123
        // Test Comment
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
                        break;
                    case 2://2. View All Passengers
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
