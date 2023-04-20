using System.Globalization;
using System.Net.Sockets;
using System.Runtime.Intrinsics.Arm;

public class WashingMachine
{
    public class Washer
    {
        private bool doorOpen;
        private bool doorLock;
        private const float minRPM = 400;
        private const float maxRPM = 1400;
        private const float minDuration = 60;
        private const float maxDuration = 150;
        private const float minTemp = 30;
        private const float maxTemp = 120;
        private float duration = 0;
        private float RPM = 0;
        private float temp = 0;

        public bool GetDoor()
        {
            if (doorOpen == false)
            {
                // Door is open
                return false;
            }
            else
            {
                // Door is closed
                return true;
            }
        }
        public bool SetDoor(bool door)
        {
            if (door == true)
            {
                // Opens the door
                doorOpen = true;
                return doorOpen;
            }
            else
            {
                // Closes the door
                doorOpen = false;
                return doorOpen;
            }
        }
        public bool GetLock()
        {
            if (doorLock == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool SetLock(bool locke)
        {
            if (locke == false)
            {
                // Unlocks door
                doorLock = false;
                return doorLock;
            }
            else if (locke == true)
            {
                // Locks door
                doorLock = true;
                return doorLock;
            }
            else 
            { 
                return false;
            }
        }
        public float SetDuration(float dur)
        {
            duration = dur;
            if (duration >= minDuration && duration <= maxDuration)
            {
                return duration;
            }
            else if (duration < minDuration)
            {
                return minDuration;
            }
            else if (duration > maxDuration)
            {
                return maxDuration;
            }
            else
            {
                return minDuration;
            }
        }
        public float SetTemp(float tmp)
        {
            temp = tmp;
            if (tmp >= minTemp && tmp <= maxTemp ) 
            {
                return temp;
            }
            else if (tmp < minTemp)
            {
                return minTemp;
            }
            else if (tmp > maxTemp)
            {
                return maxTemp;
            }
            else
            {
                return minTemp;
            }
        }
        public float SetRPM(float rpm)
        {
            RPM = rpm;
            if (RPM >= minRPM && RPM <= maxRPM)
            {
                return RPM;
            }
            else if (RPM < minRPM)
            {
                return minRPM;
            }
            else if (RPM > maxRPM)
            {
                return maxRPM;
            }
            else
            {
                return minRPM;
            }
        }
    }
    public class WashingPrograms
    {
        static void BasicWash()
        {
            Console.Clear();
            Washer newwasher = new Washer();
            newwasher.SetLock(false);
            newwasher.SetDoor(true);
            float temperature = newwasher.SetTemp(50);
            float duration = newwasher.SetDuration(60);
            float rpm = newwasher.SetRPM(400);
            float remaining = duration;
            while (true)
            {
                Console.WriteLine("Washing program is ready to commence. Press any key after loading the washer with clothes. Close the door before starting the wash!");
                Console.WriteLine("Door is open: " + newwasher.GetDoor() + " and door is locked: " + newwasher.GetLock());
                Console.WriteLine("Estimated duration: " + duration + " /// RPM : " + rpm + " /// Temperature : " + temperature + "°C");
                Console.WriteLine("Close the door by writing 'close' or 'c' abort program by writing 'a' or 'abort'");
                string winput = Console.ReadLine();
                string wwinput = winput.ToLower();
                if (wwinput == "close" || wwinput == "c")
                {
                    newwasher.SetDoor(false);
                    if (newwasher.GetDoor() == false)
                    {
                        Console.Clear();
                        Console.WriteLine("Status: Ready");
                        Console.WriteLine("Current program: Basic Wash");
                        Console.WriteLine("Door is open: " + newwasher.GetDoor());
                        Console.WriteLine("Estimated duration: " + duration + " /// RPM : " + rpm + " /// Temperature : " + temperature + "°C");
                        Console.WriteLine("Press enter to start the program.");
                        Console.ReadLine();
                        Console.WriteLine("Door locking...");
                        newwasher.SetLock(true);
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                        for (int i = 0; i < duration; i++)
                        {
                            Console.WriteLine("Status: Running...");
                            Console.WriteLine("Current program: Basic Wash");
                            Console.WriteLine("Door is closed and locked: " + newwasher.GetLock());
                            Console.WriteLine("Estimated duration: " + remaining + " /// RPM : " + rpm + " /// Temperature : " + temperature + "°C");
                            remaining = remaining - 1;
                            System.Threading.Thread.Sleep(100);
                            Console.Clear();
                        }
                        Console.WriteLine("Washing completed! Disengaging lock...");
                        newwasher.SetLock(false);
                        System.Threading.Thread.Sleep(1000);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("There was an error verifying if the lock is engaged. Please try again.");
                        Console.WriteLine(newwasher.GetLock());
                        Console.WriteLine(newwasher.GetDoor());
                        Console.ReadLine();
                        break;
                    }
                }
                else if (wwinput == "abort" || wwinput == "a")
                {
                    Console.WriteLine("Washing program aborted.");
                    Console.ReadLine();
                    break;
                }
            }

        }
        static void ExtraWash()
        {
            Console.Clear();
            Washer newwasher = new Washer();
            newwasher.SetLock(false);
            newwasher.SetDoor(true);
            float temperature = newwasher.SetTemp(40);
            float duration = newwasher.SetDuration(120);
            float rpm = newwasher.SetRPM(400);
            float remaining = duration;
            while (true)
                {
                Console.WriteLine("Washing program is ready to commence. Press any key after loading the washer with clothes. Close the door before starting the wash!");
                Console.WriteLine("Door is open: " + newwasher.GetDoor() + " and door is locked: " + newwasher.GetLock());
                Console.WriteLine("Estimated duration: " + duration + " /// RPM : " + rpm + " /// Temperature : " + temperature + "°C");
                Console.WriteLine("Close the door by writing 'close' or 'c' abort program by writing 'a' or 'abort'");
                    string winput = Console.ReadLine();
                    string wwinput = winput.ToLower();
                    if (wwinput == "close" || wwinput == "c")
                    {
                    newwasher.SetDoor(false);
                        if (newwasher.GetDoor() == false)
                        {
                            Console.Clear();
                            Console.WriteLine("Status: Ready");
                            Console.WriteLine("Current program: Extra Wash");
                            Console.WriteLine("Door is open: " + newwasher.GetDoor());
                            Console.WriteLine("Estimated duration: " + duration + " /// RPM : " + rpm + " /// Temperature : " + temperature + "°C");
                            Console.WriteLine("Press enter to start the program.");
                            Console.ReadLine();
                            Console.WriteLine("Door locking...");
                            newwasher.SetLock(true);
                            System.Threading.Thread.Sleep(1000);
                            Console.Clear();
                            for (int i = 0; i < duration; i++)
                            {
                                Console.WriteLine("Status: Running...");
                                Console.WriteLine("Current program: Extra Wash");
                                Console.WriteLine("Door is closed and locked: " + newwasher.GetLock());
                                Console.WriteLine("Estimated duration: " + remaining + " /// RPM : " + rpm + " /// Temperature : " + temperature + "°C");
                                remaining = remaining - 1;
                                System.Threading.Thread.Sleep(100);
                                Console.Clear();
                            }
                            Console.WriteLine("Washing completed! Disengaging lock...");
                            newwasher.SetLock(false);
                            System.Threading.Thread.Sleep(1000);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("There was an error verifying if the lock is engaged. Please try again.");
                            Console.WriteLine(newwasher.GetLock());
                            Console.WriteLine(newwasher.GetDoor());
                            Console.ReadLine();
                            break;
                        }
                    }
                    else if (wwinput == "abort" || wwinput == "a")
                    {
                        Console.WriteLine("Washing program aborted.");
                        Console.ReadLine();
                        break;
                    }
                }
        }
        static void HeavyWash()
        {
            Console.Clear();
            Washer newwasher = new Washer();
            newwasher.SetLock(false);
            newwasher.SetDoor(true);
            float temperature = newwasher.SetTemp(40);
            float duration = newwasher.SetDuration(120);
            float rpm = newwasher.SetRPM(1200);
            float remaining = duration;
            while (true)
                {
                    Console.WriteLine("Washing program is ready to commence. Press any key after loading the washer with clothes. Close the door before starting the wash!");
                    Console.WriteLine("Door is open: " + newwasher.GetDoor() + " and door is locked: " + newwasher.GetLock());
                    Console.WriteLine("Estimated duration: " + duration + " /// RPM : " + rpm + " /// Temperature : " + temperature + "°C");
                    Console.WriteLine("Close the door by writing 'close' or 'c' abort program by writing 'a' or 'abort'");
                    string winput = Console.ReadLine();
                    string wwinput = winput.ToLower();
                    if (wwinput == "close" || wwinput == "c")
                    {
                        newwasher.SetDoor(false);
                        if (newwasher.GetDoor() == false)
                        {
                            Console.Clear();
                            Console.WriteLine("Status: Ready");
                            Console.WriteLine("Current program: Heavy Wash");
                            Console.WriteLine("Door is open: " + newwasher.GetDoor());
                            Console.WriteLine("Estimated duration: " + duration + " /// RPM : " + rpm + " /// Temperature : " + temperature + "°C");
                            Console.WriteLine("Press enter to start the program.");
                            Console.ReadLine();
                            Console.WriteLine("Door locking...");
                            newwasher.SetLock(true);
                            System.Threading.Thread.Sleep(1000);
                            Console.Clear();
                            for (int i = 0; i < duration; i++)
                            {
                                Console.WriteLine("Status: Running...");
                                Console.WriteLine("Current program: Heavy Wash");
                                Console.WriteLine("Door is closed and locked: " + newwasher.GetLock());
                                Console.WriteLine("Estimated duration: " + remaining + " /// RPM : " + rpm + " /// Temperature : " + temperature + "°C");
                                remaining = remaining - 1;
                                System.Threading.Thread.Sleep(100);
                                Console.Clear();
                            }
                            Console.WriteLine("Washing completed! Disengaging lock...");
                            newwasher.SetLock(false);
                            System.Threading.Thread.Sleep(1000);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("There was an error verifying if the lock is engaged. Please try again.");
                            Console.WriteLine(newwasher.GetLock());
                            Console.WriteLine(newwasher.GetDoor());
                            Console.ReadLine();
                            break;
                        }
                    }
                    else if (wwinput == "abort" || wwinput == "a")
                    {
                        Console.WriteLine("Washing program aborted.");
                        Console.ReadLine();
                        break;
                    }
                }
        }
        static void CustomWash()
        {
            Console.Clear();
            Washer newwasher = new Washer();
            newwasher.SetLock(false);
            newwasher.SetDoor(true);
            Console.WriteLine("Custom Washing mode selected.");
            Console.WriteLine("Please give following parameters in following order: Desired temperature, desired duration, and maximum RPM");
            Console.WriteLine("Give desired temperature. (Minimun is 30°C and maximum is 120°C)");
            string argetTemp = Console.ReadLine();
            float targetTemp = float.Parse(argetTemp, CultureInfo.InvariantCulture.NumberFormat);
            Console.WriteLine("Now give desired duration. (Minimun is 60 and maximum is 150)");
            string argetDuration = Console.ReadLine();
            float targetDuration = float.Parse(argetDuration, CultureInfo.InvariantCulture.NumberFormat);
            Console.WriteLine("Now give desired maximun RPM. (Minimun is 400 and maximum is 1400)");
            string argetRPM = Console.ReadLine();
            float targetRPM = float.Parse(argetRPM, CultureInfo.InvariantCulture.NumberFormat);
            float temperature = newwasher.SetTemp(targetTemp);
            float duration = newwasher.SetDuration(targetDuration);
            float rpm = newwasher.SetRPM(targetRPM);
            float remaining = duration;
            while (true)
                {
                    Console.WriteLine("Washing program is ready to commence. Press any key after loading the washer with clothes. Close the door before starting the wash!");
                    Console.WriteLine("Door is open: " + newwasher.GetDoor() + " and door is locked: " + newwasher.GetLock());
                    Console.WriteLine("Estimated duration: " + duration + " /// RPM : " + rpm + " /// Temperature : " + temperature + "°C");
                    Console.WriteLine("Close the door by writing 'close' or 'c' abort program by writing 'a' or 'abort'");
                    string winput = Console.ReadLine();
                    string wwinput = winput.ToLower();
                    if (wwinput == "close" || wwinput == "c")
                    {
                        newwasher.SetDoor(false);
                        if (newwasher.GetDoor() == false)
                        {
                            Console.Clear();
                            Console.WriteLine("Status: Ready");
                            Console.WriteLine("Current program: Custom Wash");
                            Console.WriteLine("Door is open: " + newwasher.GetDoor());
                            Console.WriteLine("Estimated duration: " + duration + " /// RPM : " + rpm + " /// Temperature : " + temperature + "°C");
                            Console.WriteLine("Press enter to start the program.");
                            Console.ReadLine();
                            Console.WriteLine("Door locking...");
                            newwasher.SetLock(true);
                            System.Threading.Thread.Sleep(1000);
                            Console.Clear();
                            for (int i = 0; i < duration; i++)
                            {
                                Console.WriteLine("Status: Running...");
                                Console.WriteLine("Current program: Custom Wash");
                                Console.WriteLine("Door is closed and locked: " + newwasher.GetLock());
                                Console.WriteLine("Estimated duration: " + remaining + " /// RPM : " + rpm + " /// Temperature : " + temperature + "°C");
                                remaining = remaining - 1;
                                System.Threading.Thread.Sleep(100);
                                Console.Clear();
                            }
                            Console.WriteLine("Washing completed! Disengaging lock...");
                            newwasher.SetLock(false);
                            System.Threading.Thread.Sleep(1000);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("There was an error verifying if the lock is engaged. Please try again.");
                            Console.WriteLine(newwasher.GetLock());
                            Console.WriteLine(newwasher.GetDoor());
                            Console.ReadLine();
                            break;
                        }
                    }
                    else if (wwinput == "abort" || wwinput == "a")
                    {
                        Console.WriteLine("Washing program aborted.");
                        Console.ReadLine();
                        break;
                    }
                }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Washing Machine Operating System De-Luxe.");
                Console.WriteLine("Please choose your desired washing program by refering to following instructions:");
                Console.WriteLine("1 - Basic Wash /// 2 - Extra Wash /// 3 - Heavy Wash /// 4 - Custom");
                Console.WriteLine("Type 'exit', 'c' or 'q' to exit the program.");
                string input = Console.ReadLine();
                string linput = input.ToLower();
                if (linput == "1")
                {
                    BasicWash();
                }
                else if (linput == "2")
                {
                    ExtraWash();
                }
                else if (linput == "3")
                {
                    HeavyWash();
                }
                else if (input == "4")
                {
                    CustomWash();
                }
                else if (linput == "exit" || linput == "e" || linput == "q")
                {
                    Console.WriteLine("Exiting program...");
                    break;
                }
                else
                {
                    Console.WriteLine("Unknown command. Try again.");
                }
            }
        }
    }
}