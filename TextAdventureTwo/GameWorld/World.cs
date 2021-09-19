﻿using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureTwo.GamePlayer;

namespace TextAdventureTwo.GameWorld
{
    public class World
    {

        List<Location> Locations = new List<Location>();
        List<Npc> Npcs = new List<Npc>();

        /// <summary>
        /// Create a new location and store it in World.Locations.
        /// </summary>
        /// <param name="xCoordinate"></param>
        /// <param name="yCoordinate"></param>
        /// <param name="name"></param>
        public void AddLocation(int xCoordinate, int yCoordinate, string name)
        {
            Location location = new Location
            {
                XCoord = xCoordinate,
                YCoord = yCoordinate,
                Name = name
            };
            Locations.Add(location);
        }

        /// <summary>
        /// Create a new location and store it in World.Locations.
        /// </summary>
        /// <param name="xCoordinate"></param>
        /// <param name="yCoordinate"></param>
        /// <param name="name"></param>
        public void AddLocation(int xCoordinate, int yCoordinate, string name, string[] entryMessage, List<Npc> npcs)
        {
            Location location = new Location
            {
                XCoord = xCoordinate,
                YCoord = yCoordinate,
                Name = name,
                EntryMessage = entryMessage,
                Npcs = npcs
            };
            Locations.Add(location);
        }




        public Location LocationAt(int xCoordinate, int yCoordinate)
        {
            //TODO: Change this to a linq where statement? would return null if no matches?
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
