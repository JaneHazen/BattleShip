using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Player
    {
        public string Name;
        public List<string> Ships;
        public Player(string name)
        {
            Name = name;
        }

        public string CheckBoard(string coordinates)
        {

            foreach(string s in Ships)
            {
                if (s == coordinates)
                {
                    Ships.Remove(s);
                    if (Ships.Count != 0)
                        return "You got a hit!";
                    else
                        return "You got their last ship!";
                }
                else
                    return "It got away!";
            }

            return "Something went wrong; This player's already been wiped out";
        }

        public List<string> MakeShips(string coordinates)
        {
            string[] ShipCoordinates = coordinates.Split(' ');
            foreach(string ship in ShipCoordinates)
            {
                Ships.Add(ship);
            }
            return Ships;
        }

        
    }
}
