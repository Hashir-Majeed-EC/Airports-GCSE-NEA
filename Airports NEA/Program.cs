using System;
using System.IO;

namespace Airports_NEA
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = Menu();

            if (choice == 1)
            {
                Console.WriteLine(AirportDetails());
            }else if (choice == 2)
            {
                FlightDetails();
            }else if (choice == 3)
            {
                CalculateProfit();
            }
            else
            {

            }
        }

        static int Menu()
        {
            int choice = -1;
            do
            {
                Console.WriteLine("1. Enter Airport Details.");
                Console.WriteLine("2. Enter Flight Details.");
                Console.WriteLine("3. Enter Price Plan and Calculate Profits.");
                Console.WriteLine("Choose 1, 2 or 3. If you want to quit, press enter : ");

                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Invalid Choice... ");
                }
            } while (choice == -1);

            return choice;
            
        }

        static string AirportDetails()
        {
            const int numOfValsPerRow = 4;
            string ukAirport = "";
            string abroad = "";

            string[] readAirports = readFile("Airports");

            do
            {
                Console.WriteLine("Choose UK Airport: Liverpool John Lennon (type LPL) or Bourenmouth International (type BOH) : ");
                ukAirport = Console.ReadLine();
            } while (ukAirport != "LPL" && ukAirport != "BOH");
            
            Console.WriteLine("Enter abroad airport code: ");
            abroad = Console.ReadLine();         

            return validateFileData(readAirports, abroad, numOfValsPerRow);
        }

        static void FlightDetails()
        {
            string[] planeTypes = readFile("Planes");
        }

        static void CalculateProfit()
        {

        }

        static string[] readFile(string filename)
        { 
            string contents = "";
            string[] rows = new string[5];
            contents = File.ReadAllText(filename + ".txt");
            rows = contents.Split(',');

            return rows;
        }

        static string validateFileData(string[] fileContents, string val, int numOfValsPerRow)
        {

            bool found = false;
            int count = 0;

            while (!found && count < fileContents.Length / numOfValsPerRow)
            {
                if (fileContents[count] == val)
                {
                    found = true;
                    for (int i = 1; i < numOfValsPerRow; i++)
                    {
                        val += ", " + fileContents[count + 1];
                        count++;
                    }
                }
                else
                {
                    count += numOfValsPerRow;
                }
            }

            return val;
        }

    }
}
