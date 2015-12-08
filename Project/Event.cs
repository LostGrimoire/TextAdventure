using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Event
    {
        protected string _description;
        protected string _exitDescription1;
        protected string _exitDescription2;
        
        public Event ()
        {
            this.Description = "";
        }
        
        public Event(string text, string exit1, string exit2)
        {
            this.Description = text;
            this.ExitDescription1 = exit1;
            this.ExitDescription2 = exit2;
        }

        public virtual int runEvent() 
        {
            bool badChoice = true;
            int output = 0;
            string input;
            Console.WriteLine("");
            Console.WriteLine(Description);
            while (badChoice) // continue until decent input
            {
                Console.Write("Enter 1 or 2: ");
                input = Console.ReadLine();
                if (input[0] == '1')
                {
                    Console.WriteLine(ExitDescription1);
                    output = 1;
                    badChoice = false;
                }
                if (input[0] == '2')
                {
                    Console.WriteLine(ExitDescription2);
                    output = 2;
                    badChoice = false;
                }
            }
            return output;
        }

        public string Description
        {
            get { return this._description;}
            set { this._description = value;}
        }
        public string ExitDescription1
        {
            get { return this._exitDescription1;}
            set { this._exitDescription1 = value;}
        }
        public string ExitDescription2
        {
            get { return this._exitDescription2; }
            set { this._exitDescription2 = value; }
        }
    }

    class Duel : Event // fight
    {
        protected Creature monster;
        protected Hero player; // needs player to partake

        public Duel()
        {
            this.Description = null;
            this.ExitDescription1 = null;
            this.ExitDescription2 = null;
            this.monster = null;
            this.player = null;
        }
        public Duel(string text, string exit1, string exit2, Creature mon, Hero p1)
        {
            this.Description = text;
            this.ExitDescription1 = exit1;
            this.ExitDescription2 = exit2;
            this.monster = mon;
            this.player = p1; // using the same is good?
        }

        public override int runEvent()
        {
            Console.WriteLine("");
            Console.WriteLine(Description);
            monster.Health = monster.TotalHP; // reset health for repeated runs.
            monster.setAlive(true);
            while (player.getAlive() && monster.getAlive())
            {
                this.fight();
            }
            if (player.getAlive())
            {
                player.Exp += monster.Exp;
                player.checkLevelUp();
                Console.WriteLine(ExitDescription1);
                Console.Write("Enter anything to continue. ");
                Console.ReadLine();
                return 1;
            }
            else
            {
                player.Health = player.TotalHP;
                player.setAlive(true);
                Console.WriteLine(ExitDescription2);
                Console.Write("Enter anything to continue. ");
                Console.ReadLine();
                return 2;
            }
        }

        public void fight()
        {
            if (player.getAlive())
                player.attack(monster);
            if (monster.getAlive())
                monster.attack(player);
        }

        // check health test
        public bool checkHero()
        {
            if (player.getAlive())
                Console.WriteLine("Player Health: {0}", player.Health);
            return player.getAlive();
        }
        public bool checkMonster()
        {
            if (monster.getAlive())
                Console.WriteLine("Monster Health: {0}", monster.Health);
            return monster.getAlive();
        }
    }

    class Finale : Duel // this event determines 1 of 3 outcomes.
    {
        private int path;
        private Event sneak1;

        public Finale(string text, string exit1, string exit2, Creature mon, Hero p1)
        {
            this.Description = text;
            this.ExitDescription1 = exit1;
            this.ExitDescription2 = exit2;
            this.monster = new Creature(mon);
            this.player = p1; // using the same hero
            this.path = 0;
            string eventText1 = "You decide to run for it! You run strait at the Demon Lord," +
                    " they whip around to face you and attack. [1] Dodge Left [2] Dodge Right";
            string eventText2 = "The Demon Lord misses as you dodge correctly.";
            string eventText3 = "The Demon Lord's blade buries itself in your face.";
            this.sneak1 = new Event(eventText1, eventText2, eventText3);
        }

        public override int runEvent() // this is gonna be fat...
        {
            Console.WriteLine("");
            int input = this.determineAction();
            if (input == 1)
            {
                if (runFight())
                {
                    winFight();
                    badEnd();
                }
                else
                    loseFight();
                Console.WriteLine(ExitDescription1);
                path = 1;
            }
            else if (input == 2)
            {
                if (sneak1.runEvent() == 1)
                    badEnd();
                Console.WriteLine(ExitDescription1);
                path = 1;
            }
            else if (input == 3)
            {
                string demonLordsQuery = "You speak up, the Demon Lord turns to face you." + 
                    "\n\"Why have you returned?\" The Demon Lord asks. ";
                demonLordsQuery += "\n\"Do you remember my name?\" Enter Name: ";
                Console.Write(demonLordsQuery);
                string inputString = Console.ReadLine();
                if (inputString.ToUpper() == "ALICE") // don't even ask
                {
                    Console.WriteLine(ExitDescription2);
                    path = 2;
                }
                else
                {
                    Console.WriteLine("Who is that supposed to be? Unfaithful oaf!");
                    if (runFight())
                    {
                        winFight();
                        badEnd();
                    }
                    else
                        loseFight();
                    Console.WriteLine(ExitDescription1);
                    path = 1;
                }
            }
            return path;
        }


        public bool runFight()
        {
            while (player.getAlive() && monster.getAlive())
            {
                this.fight();
            }
            if (player.getAlive())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int determineAction()
        {
            bool badChoice = true;
            int output = 0;
            string input;
            Console.WriteLine(Description);
            while (badChoice) // continue until decent input
            {
                Console.Write("Enter 1, 2, or 3: ");
                input = Console.ReadLine();
                if (input[0] == '1')
                {
                    output = 1;
                    badChoice = false;
                }
                if (input[0] == '2')
                {
                    output = 2;
                    badChoice = false;
                }
                if (input[0] == '3')
                {
                    output = 3;
                    badChoice = false;
                }
            }
            return output;
        }
        public void winFight()
        {
            Console.WriteLine("You Defeated the Demon Lord. You do a happy dance, " +
                "\r\ntrip on their corpse, and impale yourself on their helmet." +
                "\r\nDarn your happy feet. You die shortly after.");
        }
        public void loseFight()
        {
            Console.WriteLine("You lie on the floor, dying. The Demon Lord beside you" +
                " says a silent prayer.\r\nYou think you see a tear fall from their helmet.");
        }
        public void badEnd()
        {
            Console.WriteLine("You make it into the next room, darkness surrounds you." +
                        "\nA giant Eye flips open in front of you, you immediatly reel in pain.");
        }
    }
}