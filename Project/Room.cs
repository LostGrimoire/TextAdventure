/// Rooms
/// this will be broken up into room types
/// there have to be something like 20 rooms
/// 1. Event room
/// 2. Battle room (requires monsters and such)
/// 3. Puzzle room
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Room
    {
        // guess it needs branch paths and room event
        protected Event roomEvent;
        protected Room destination1; // option 1 
        protected Room destination2; // option 2, or failure
        protected bool winFlag;

        // 2 outcomes
        public Room()
        {
            this.roomEvent = null;
            this.destination1 = null;
            this.destination2 = null;
            this.winFlag = false;
        }
        
        public virtual Room decidePath()
        {
            if (roomEvent.runEvent() == 1)
            {
                return destination1;
            }
            else
            {
                return destination2;
            }
        }
        

        public Room getDestination1()
        {
            return destination1;
        }
        public Room getDestination2()
        {
            return destination2;
        }
        public Event getEvent()
        {
            return roomEvent;
        }
        public bool getWinFlag()
        {
            return this.winFlag;
        }

        public void setDestination1(Room room) // shallow is fine?
        {
            this.destination1 = room; 
        }
        public void setDestination2(Room room)
        {
            this.destination2 = room;
        }
        public void setEvent(Event inputEvent)
        {
            this.roomEvent = inputEvent;
        }
        public void setWinFlag(bool flag)
        {
            this.winFlag = flag;
        }
        
    }

    class VictoryRoom : Room
    {
        public VictoryRoom()
        {
            this.destination1 = null;
            this.destination2 = null;
            this.winFlag = true;
        }
    }
}