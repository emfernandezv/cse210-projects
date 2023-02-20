using System;

class Program
{
    static void Main(string[] args)
    {   validate:
        int _menuOption =  Menu();
        //Validate option is correct
        while ( _menuOption <= 4 && _menuOption > 0){
            switch (_menuOption){
                case 1:
                    StartBreathingActivity();
                    break;
                case 2:
                    StartReflectingActivity();
                    break;
                case 3:
                    StartListingActivity();
                    break;
                default:
                    ProgramTermination();
                    break;
            }
            _menuOption = Menu();
        }
        Console.WriteLine("You have entered an invalid input. Please try again.");
        Thread.Sleep(2000);
        Console.Clear();
        goto validate;

        static int Menu(){
            int menuOption;
            Console.WriteLine("Menu Option:");
            Console.WriteLine("1. Start breathing activity.");
            Console.WriteLine("2. Start reflecting activity.");
            Console.WriteLine("3. Start listing activity.");
            Console.WriteLine("4. Quit");
            try{
                menuOption = Int32.Parse(Console.ReadLine());
            }catch (System.FormatException){
                menuOption = 0;
            }
            return menuOption;
        }

        static void StartBreathingActivity(){
            BreathingActivity breath = new BreathingActivity(1,"Breathing Activity");
            breath.Execute();
        }

        static void StartReflectingActivity(){
            ReflectionActivity reflection = new ReflectionActivity(2,"Reflection Activity");
            reflection.Execute();
        }

        static void StartListingActivity(){
            ListingActivity listing = new ListingActivity(3,"Listing Activity");
            listing.Execute();
        }

        static void ProgramTermination(){
            System.Environment.Exit(1);
        }


    }
}