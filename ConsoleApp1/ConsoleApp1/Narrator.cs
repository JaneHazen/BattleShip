using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Narrator
    {
        protected int NumberOfPlayers;
        public List<Player> Players;
        public string ShipCoordinates;
        public Narrator()
        {
            Players = new List<Player>();
            Console.WriteLine("Let's play BattleShip!");
            GetPlayers();
            PlayGame();
            
        }
        public List<Player> GetPlayers()
        {
           
            Console.WriteLine("How many players would like to play?");
            string input = Console.ReadLine();
            CheckIntForValidity(input);
            for(int i = 0; i < NumberOfPlayers; i++)
            {
                Console.WriteLine($"Player {i + 1}, please enter your name:");
                string nameinput = Console.ReadLine();
                CheckNameForValidity(nameinput);
                Players.Add(new Player(nameinput));
                Console.WriteLine($"Thanks, {Players[i]}! Now you've just got to set three points that will have ships.");
                Console.WriteLine("The format for entering a point is 'letter''number' So if you want a ship in the top right corner you should type A1.");
                Console.WriteLine("The letters run from A-G and number run from 1-7");
                Console.WriteLine("Go ahead and make your ships:");
                ShipCoordinates = Console.ReadLine();
                ValidateCoordinates(ShipCoordinates);
                Players[i].MakeShips(ShipCoordinates);
                Console.WriteLine("Sweet, thanks!");
            }
            return Players;
        }

        public void ValidateCoordinates(string coordinates)
        {
            bool CorrectlyFormated = Regex.IsMatch(coordinates, @"[A-Za-z][0..7] [A-Za-z][0..7] [A-Za-z][0..7]");
            while (!CorrectlyFormated)
            {
                Console.WriteLine("Sorry, that wasn't formatted correctly; please try again:");
                coordinates = Console.ReadLine();
                CorrectlyFormated = Regex.IsMatch(coordinates, @"[A-Za-z][0..7] [A-Za-z][0..7] [A-Za-z][0..7]");

            }
        }

        public void CheckIntForValidity(string input)
        {
            bool validInput = false;
            while (!validInput)
            {
                if (int.TryParse(input, out int numberOfPlayers))
                {
                    this.NumberOfPlayers = numberOfPlayers;
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("I'm sorry, you must type a number; please try again:");
                    input = Console.ReadLine();
                }
            }
        }

        public void CheckNameForValidity(string nameinput)
        {   
            bool validInput = false;
            while(!validInput)
            {
                if (Regex.IsMatch(nameinput, @"[A-Za-z]+$"))
                    validInput = true;
                else
                {
                    Console.WriteLine("I'm sorry, your name must only contain letters; please try again:");
                    nameinput = Console.ReadLine();
                }
            }
        }

        public void PlayGame()
        {
            bool GameOver = false;
            int CurrentPlayer = 0;
            while (!GameOver)
            {
                string currentPlayerName = Players[CurrentPlayer].Name;
                Console.WriteLine($"Okay, {currentPlayerName}, pick a player to attack:");
                string victimName = Console.ReadLine();
                Console.WriteLine($"What coordinates would you like to attack on {victimName}'s territory?");
                string coordinates = Console.ReadLine();
                foreach(Player p in Players)
                {
                    if (victimName == p.Name)
                    {
                        string message = p.CheckBoard(coordinates);
                       
                        Console.WriteLine(message);
                    }
                }
            }
        }
    }
}
