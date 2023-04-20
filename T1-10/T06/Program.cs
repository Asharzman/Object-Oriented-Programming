using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Linq;

public class Sauna_Heater
{
    public class Kiuas
    {
        public Kiuas() 
        {
            State = false;
            Temp = 24;
            Hum = 50;
        }
        public Kiuas(bool state, double temp, double hum) 
        {
            State = state;
            Temp = temp;
            Hum = hum;
        }
        public bool State { get; set; }
        public double Temp { get; set; }
        public double Hum { get; set; }

        public override string ToString()
        {
            return $"Sauna on: {State}. Sauna temperature is {Temp}°C and humidity is {Hum}%";
        }
    }


    static void Main()
    {
        var kiuasstate = new Kiuas();
        while (true)
        {
            Console.WriteLine("//////////////////////////////////////////////////////////////////////////////////////////////////");
            Console.WriteLine(kiuasstate);
            Console.WriteLine("Commands: Toggle - Toggles the sauna on/off. Temp - To adjust Temperature Hum - To adjust humidity");
            string input = Console.ReadLine();
            string tinput = string.Concat(input.Where(c => !Char.IsWhiteSpace(c)));
            if (tinput == "Toggle" || tinput == "toggle" )
            {
                if (kiuasstate.State == false)
                {
                    kiuasstate.State = !kiuasstate.State;
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Turning sauna off... Sauna will cooldown to initial settings.");
                    Console.ReadLine();
                    kiuasstate.Temp = 24;
                    kiuasstate.Hum = 50;
                    Console.Clear();
                }
            }
            else if (tinput == "Temp" || tinput == "temp" )
            {
                if (kiuasstate.State == true)
                {
                    Console.WriteLine("Give new temperature.");
                    string newtemp = Console.ReadLine();
                    int anewtemp = Int32.Parse(newtemp);
                    kiuasstate.Temp = anewtemp;
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Turn on the sauna first. Press Enter to continue.");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            else if (tinput == "Hum" || tinput == "hum" )
            {
                if (kiuasstate.State == true)
                {
                    Console.WriteLine("Give new target humidity.");
                    string newhum = Console.ReadLine();
                    int anewhum = Int32.Parse(newhum);
                    kiuasstate.Hum = anewhum;
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Turn on the sauna first. Press Enter to continue.");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            else if (tinput == "") 
            {
                Console.WriteLine("Program exiting...");
                break; 
            }
            else
            {
                Console.WriteLine("Incorrect input. Please follow instructions.");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}