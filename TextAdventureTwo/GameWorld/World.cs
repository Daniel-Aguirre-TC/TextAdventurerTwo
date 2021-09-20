using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TextAdventureTwo.GamePlayer;

namespace TextAdventureTwo.GameWorld
{
    public class World
    {

        List<Location> Locations = new List<Location>();



        /// <summary>
        /// Create a new location and store it in World.Locations.
        /// </summary>
        /// <param name="xCoordinate"></param>
        /// <param name="yCoordinate"></param>
        /// <param name="name"></param>
        public void AddLocation(int xCoordinate, int yCoordinate, string name, string[] options)
        {
            Location location = new Location
            {
                XCoord = xCoordinate,
                YCoord = yCoordinate,
                Name = name,
                Options = options.ToList()
            };
            Locations.Add(location);
        }

        /// <summary>
        /// Create a new location and store it in World.Locations.
        /// </summary>
        /// <param name="xCoordinate"></param>
        /// <param name="yCoordinate"></param>
        /// <param name="name"></param>
        public void AddLocation(int xCoordinate, int yCoordinate, string name, string[] options, string[] entryMessage, List<Npc> npcs)
        {
            Location location = new Location
            {
                XCoord = xCoordinate,
                YCoord = yCoordinate,
                Name = name,
                Options = options.ToList(),
                EntryMessage = entryMessage,
                Npcs = npcs
            };
            Locations.Add(location);
        }


        /// <summary>
        /// Create a new location and store it in World.Locations.
        /// </summary>
        /// <param name="xCoordinate"></param>
        /// <param name="yCoordinate"></param>
        /// <param name="name"></param>
        public void AddLocation(int xCoordinate, int yCoordinate, string name, string[] options, string[] entryMessage, List<Enemy> enemies)
        {
            Location location = new Location
            {
                XCoord = xCoordinate,
                YCoord = yCoordinate,
                Name = name,
                Options = options.ToList(),
                EntryMessage = entryMessage,
                Enemies = enemies
            };
            Locations.Add(location);
        }


        public Location FindLocation(string name)
        {
            foreach (var location in Locations)
            {
                if (location.Name == name)
                {
                    return location;
                }
            }
            return null;
        }


        public Location FindLocation(int xCoordinate, int yCoordinate)
        {

            foreach (Location location in Locations)
            {
                if (location.XCoord == xCoordinate && location.YCoord == yCoordinate)
                {
                    return location;
                }
            }
            // if no location at provided Coordinates, then return null
            return null;
        }



    }
}
