/*
    Toni Mäkelä
    07.03.2018
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameDayProgram
{
    public class Names
    {
        public string date { get; set; }
        public string names { get; set; }

        // Tulostetaan pelkästään nimet.
        public override string ToString()
        {
            return "Names: " + names;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                // Tiedoston luku yhteys.
                using (StreamReader sr = new StreamReader("nimet.csv"))
                {
                    String line;

                    List<Names> nameDay = new List<Names>();

                    // Tiedoston sisällön erottelu nameDay olioon.
                    while ((line = sr.ReadLine()) != null)
                    {
                        var values = line.Split(';');
                        nameDay.Add(new Names(){ date = values[0], names = values[1] });
                    }

                    // Ajetaan niin kauan kuin tiedostosta löytyy nimiä.
                    while (true) {
                        Console.WriteLine("Enter Date");

                        string userinput = Console.ReadLine();
                        if (nameDay.Find(x => x.date == userinput) != null)
                        {
                            // Haetaan olio käyttäjän syöttämän päivän mukaan.
                            Console.WriteLine(nameDay.Find(x => x.date == userinput));
                            break;
                        } else
                        {
                            Console.WriteLine("names could not be found.");
                        }
                    }
                }
                // Tarkistus jos tiedosto löytyi / avautui.
            } catch (Exception e)
            {
                Console.WriteLine("The File could not be read:");
                Console.WriteLine(e.Message);

                Console.ReadLine();
            }

            Console.Write("Press any key to exit");
            Console.ReadLine();

        }
    }
}
