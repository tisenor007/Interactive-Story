using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Interactive_Story__Final
{
    class Program
    {

        //static SoundPlayer button;    
        static bool GameOver;
        //static int x;
        static string line;
        static int pageNumber;
        static string[] story;
        static string[] lineSection;
        static string currentplot;
        static string optionA;
        static string optionB;
        static string DestinationpageA;
        static string DestinationpageB;
        static string savefile = "SaveGame.txt";
        static string savedpage;
        
        //title screen art...
        static void Titlescreen(int scale)
        {
        //this title screen really hurt my eyes when typing it out
                string[,] titlescreen = new string[,]
                {
                    //THE
                    {"'","'","'"," ","'"," ","'"," ","'","'","'","","","","","","","","","","","","","","","","","",""},
                    {" ","'"," "," ","'"," ","'"," ","'"," "," ","","","","","","","","","","","","","","","","","","" },
                    { " ","'"," "," ","'","'","'"," ","'","'","'","","","","","","","","","","","","","","","","","","" },
                    { " ","'"," "," ","'"," ","'"," ","'"," "," ","","","","","","","","","","","","","","","","","","" },
                    { " ","'"," "," ","'"," ","'"," ","'"," "," ","","","","","","","","","","","","","","","","","","" },
                    { " ","'"," "," ","'"," ","'"," ","'","'","'","","","","","","","","","","","","","","","","","","" },
                    { " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," " },
                    //WOODS
                    {"","'"," "," "," ","'",""," ","'","'","'"," ","'","'","'"," ","'","'"," "," ","'","'","'"," ","","","","",""},
                    {"","'"," "," "," ","'",""," ","'"," ","'"," ","'"," ","'"," ","'"," ","'"," ","'"," "," "," ","","","","","" },
                    { "","'"," ","'"," ","'",""," ","'"," ","'"," ","'"," ","'"," ","'"," ","'"," ","'","'","'","","","","","","" },
                    { "","'"," ","'"," ","'",""," ","'"," ","'"," ","'"," ","'"," ","'"," ","'"," "," "," ","'","","","","","","" },
                    { ""," ","'"," ","'"," ",""," ","'"," ","'"," ","'"," ","'"," ","'"," ","'"," "," "," ","'","","","","","","" },
                    { ""," ","'"," ","'"," ",""," ","'","'","'"," ","'","'","'"," ","'","'"," "," ","'","'","'","","","","","","" },
                };
            //loop to simply make it bigger, look more full
            for (int y = 0; y <= 12; y = y + 1)
            {
                for (int x = 0; x <= 28; x = x + 1)
                {
                    for (int u = 0; u <= scale; u = u + 1)
                    {
                        Console.Write(titlescreen[y, x]);
                    }
                    
                }
                Console.WriteLine();
            }
        }       

        //playing sound did not want to work because no matter what location the mp3 file was in, program could never find it.//////
       // static void playsound()
        //{
             //button = new SoundPlayer("button.MP3");
            //button.Play();
        //}

        //Main Menu
        static void Main()
        { 
            //displays Main Menu
            Console.WriteLine();
            Titlescreen(2);
            Console.WriteLine("Press key of option to continue...");
            Console.WriteLine();
            Console.WriteLine("1 - New Game");
            Console.WriteLine("2 - Load Game");
            Console.WriteLine("3 - Quit Game");
            Console.WriteLine();

            //Main menu option for a new game
            ConsoleKeyInfo keyPressed = Console.ReadKey();
            if (keyPressed.Key == ConsoleKey.D1)
            {
               
                //playsound();
               
                while (true)
                {
                    //error checking...
                    if (File.Exists("Story.txt") == false)
                    {
                        Console.WriteLine("Story file does not exist, taking you back to main menu");
                        Main();
                    }
                    else
                    {
                        pageNumber = 1;
                        GameEngine();
                    }
                
                }
            }

            //main menu option for load 
            if (keyPressed.Key == ConsoleKey.D2)
            {
                //error checking...
                if (File.Exists("SaveGame.txt") == false)
                {
                    Console.WriteLine("Story file does not exist, taking you back to main menu");
                    Main();
                }
                else
                {
                    Console.WriteLine();
                    loadsave();
                }
            }
             //if you want to quit game from menu
            if (keyPressed.Key == ConsoleKey.D3)
            {
                System.Environment.Exit(1);
            }
            //If player hits wrong button
            else
            {
                Console.WriteLine("This is not an option...");
                Main();
            }
            
           

            


            Console.ReadKey(true);
        }
        static void GameEngine()
        {
           
            //read story text file
            story = System.IO.File.ReadAllLines("Story.txt");

            //FAILED ATTEMPTS:
            //line = System.IO.File.ReadAllText("Story.txt");
            //story = contents.Split(';');

             //default gameover status..
             GameOver = false;
 
            // matt's DEBUG CODE
            //Console.WriteLine("DEBUG: story[pagenum] = " + story[pageNumber]); 

            //GameLoop (was not present in first playable)
            while (GameOver == false) 
            {
   
                //This relates line and story file to each other
                line = story[pageNumber];

                //split for file
                lineSection = line.Split(';');

                //program detecting if a gameover line is a gameover line...
                //also will break loop to take you to gameover screen.
                if (line == lineSection[0])
                { 
                    GameOver = true;
                    break;
                }

                //story display mechanics.......
                currentplot = lineSection[0];
                optionA = lineSection[1];
                optionB = lineSection[2];
                DestinationpageA = lineSection[3];
                DestinationpageB = lineSection[4];

                //changing destination pages to ints
                int parsednumber = int.Parse(DestinationpageA);
                int parsednumber2 = int.Parse(DestinationpageB);

              
                //FAILED ATTEMPTS to display:
                //Console.WriteLine(lineSection[0]);
                //Console.WriteLine("A -  " + lineSection[1]);
                //Console.WriteLine("B -  " + lineSection[2]);
                //Console.WriteLine(story[pagenumber]

                //actual story display with choices
                Console.WriteLine();
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("Page: " + pageNumber);
                Console.WriteLine();
                Console.WriteLine(currentplot);
                Console.WriteLine();
                Console.WriteLine("A -  " + optionA);
                Console.WriteLine("B -  " + optionB);
                Console.WriteLine("C -  Save Game");
                Console.WriteLine("D -  Quit Game");
                Console.WriteLine();
                Console.WriteLine("Press Key of option + enter to progress...");
                Console.WriteLine();
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");

                //error checking when destination page values are less than or equal to 0......
                if (parsednumber <= 0)
                {
                    Console.WriteLine("Destination pages do not accept values lower or equal to 0, fix story");
                }
                if (parsednumber2 <= 0)
                {
                    Console.WriteLine("Destination pages do not accept values lower or equal to 0, fix story");
                }
 
                //readkey instead of readline.....
                ConsoleKeyInfo keyPressed = Console.ReadKey();

                //option 1 result for each page
                if (keyPressed.Key == ConsoleKey.A)
                {
                    //FAILED ATTEMPS of options/HAcking:
                    //pageNumber = lineSection[3]
                    //pageNumber = 2 * pageNumber;

                    pageNumber = parsednumber;
                  
                }

                //option 2 result for each page
                if (keyPressed.Key == ConsoleKey.B)
                {
                    //FAILED ATTEMPS of options/HAcking:
                    //pageNumber = lineSection[4]
                    //pageNumber = 3 * pageNumber + 1;

                    pageNumber = parsednumber2;
                }

                //page number value will be writen into "SaveGame" file 
                //player will still be able to play after save....
                if (keyPressed.Key == ConsoleKey.C)
                {    
                    //savepage = pageNumber;

                    Console.WriteLine();
                    string save;
                    save = pageNumber.ToString();
                    File.WriteAllText(savefile, save);
                    Console.WriteLine("Your game was saved on Page: " + save); //DEBUG CODE
                }

                //Quit
                if (keyPressed.Key == ConsoleKey.D)
                {
                    System.Environment.Exit(1);
                }
               
                //no else statements because page will just loop to one its currently on giving player another chance

            }

            //GameOver Screen
            while (GameOver == true)
            {
                Console.WriteLine();
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("Page: " + pageNumber);
                Console.WriteLine();
                Console.WriteLine("GAME OVER!");
                Console.WriteLine(story[pageNumber]);
                Console.WriteLine();
                Console.WriteLine("A -  Quit");
                Console.WriteLine("B -  Main Menu");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                ConsoleKeyInfo keyPressed = Console.ReadKey();

                //to end program after game over
                if (keyPressed.Key == ConsoleKey.A)
                {
                    System.Environment.Exit(1);
                }

                //to bring you to the main menu after game over
                if (keyPressed.Key == ConsoleKey.B)
                {
                    Main();
                    break;
                }

                // if player enters wrong value
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("This is not an option.....");
                    Console.WriteLine("Press any button to go back to Main Menu....");
                    break;
                }
            }


            Console.ReadKey(true);
        }

        //To load a save....
        static void loadsave()
        {
            //If save loaded, program will read page from file that was just writen into it. 
            savedpage = File.ReadAllText(savefile);
            
            //Converting read value back to int
            int parsednumber3;    
            Int32.TryParse(savedpage, out parsednumber3);

            //save value being equaled the page number
            pageNumber = parsednumber3;

            //display to load a save
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Your last save was on Page: " + parsednumber3);
            Console.WriteLine("Would you like to load this save?");
            Console.WriteLine();
            Console.WriteLine("A - Yes");
            Console.WriteLine("B - No");
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine();
            ConsoleKeyInfo keyPressed = Console.ReadKey();

            //If player hits yes, they will go into the game with saved page number...
            if (keyPressed.Key == ConsoleKey.A)
            {
                GameEngine();
            }

            // If player hits no, they go back to main menu...
            if (keyPressed.Key == ConsoleKey.B)
            {
                Console.WriteLine("Taking you back to main menu");
                Main();
            }

        }
       
    }

}
