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
            }catch (System.FormatException e){
                menuOption = 0;
            }
            return menuOption;
        }
        

        static void StartBreathingActivity(){
            int duration = displayInitialMessage(0);
            BreathingActivity breath = new BreathingActivity("1","Breathing Activity", duration);
            breath.displayMessage();
        }

        static void StartReflectingActivity(){
            int duration = displayInitialMessage(1);
            ReflectionActivity reflection = new ReflectionActivity("2","Reflection Activity", duration);
            reflection.displayPrompt();
            reflection.displayQuestion();
        }

        static void StartListingActivity(){
            int duration = displayInitialMessage(2);
            ListingActivity listing = new ListingActivity("3","Listing Activity", duration);
            listing.displayPrompt();
        }

        static int displayInitialMessage(int number){
            Tools ini = new Tools();
            Console.WriteLine(ini.description(number));
            Console.WriteLine();
            int min = 0;
            if (number == 0){
                min = 10;
            }   
            int duration = 0;    
            Console.WriteLine($"How long, in seconds, would you like for your session? Minimun {min} seconds.");
            try{
                duration = Int32.Parse(Console.ReadLine());
            }catch (System.FormatException e){
                duration = 0;
            }               
            while (duration < min){
                Console.WriteLine($"Please chose a values > {min}.");
                try{
                    duration = Int32.Parse(Console.ReadLine());
                }catch (System.FormatException e){
                    duration = 0;
                } 
            }
            return duration;
        }

        static void ProgramTermination(){
            System.Environment.Exit(1);
        }


    }
}