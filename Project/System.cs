using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class System
    {
        // this is what the loop will use to run game
        private Room currentRoom;

        public System(Room startRoom)
        {
            this.currentRoom = startRoom;
        }

        public void nextRoom() // pick next room
        {
            currentRoom = currentRoom.decidePath();
        }
        public bool checkWin()
        {
            return currentRoom.getWinFlag();
        }
    }
}