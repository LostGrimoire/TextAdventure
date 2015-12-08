/// Depending on how in depth i want this system to be...
/// hp, damage are basic.
/// armor, xp, and gold are standard.
/// evasion, hit, talk are advanced.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Creature
    {
        protected string name;
        protected string description;
        protected int _health;
        protected int _totalHP;
        protected int _damage;
        protected int _exp; // leveling up is part of the game.
        protected bool alive;
        
        public Creature() // All creatures are slimes?!
        {
            this.name = "Slime";
            this.description = "Adventurers start on these.";
            this.Damage = 1;
            this.Health = 1;
            this.TotalHP = 1;
            this.Exp = 1;
            this.alive = true;
        }
        public Creature(Creature mob)
        {
            this.name = mob.name;
            this.description = mob.description;
            this.Damage = mob.Damage;
            this.Health = mob.Health;
            this.Exp = mob.Exp;
            this.alive = mob.alive;
        }

        public void attack(Creature creature)
        {
            creature.Health = (creature.Health - this.Damage);
            Console.WriteLine("{0} attacked {1} for {2} damage.", this.name, creature.name, this.Damage);
            if (creature.Health < 0)
            {
                creature.setAlive(false);
            }
        }

        public int Health 
        {
            get { return _health;}
            set { _health = value;}
        }
        public int TotalHP
        {
            get { return _totalHP; }
            set { _totalHP = value; }
        }
        public int Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }
        public int Exp
        {
            get { return _exp; }
            set { _exp = value; }
        }
        public string getName()
        {
            return this.name;
        }
        public string getDescription()
        {
            return this.description;
        }
        public bool getAlive()
        {
            return this.alive;
        }

        public void setName(string n)
        {
            this.name = n;
        }
        public void setDescription(string d)
        {
            this.description = d;
        }
        public void setAlive(bool life)
        {
            this.alive = life;
        }
    }

    class Hero : Creature
    {
        private Random random;
        private int _level;

        public Hero()
        {
            this.name = "Hero";
            this.Damage = 1;
            this.Health = 30;
            this.TotalHP = 30;
            this.description = "The hero of this story. You grow stronger quickly.";
            this.Level = 1;
            this.Exp = 0;
            this.random = new Random();
        }
        public Hero(Hero p1)
        {
            this.name = p1.getName();
            this.description = p1.getDescription();
            this.Damage = p1.Damage;
            this.TotalHP = p1.TotalHP;
        }

        // check exp for meeting level up req
        public void checkLevelUp()
        {
            while (Exp > 9)// every 10 xp level up
            {
                Console.WriteLine("Level Up!");
                this.Exp -= 10;
                levelUp();
            }
        }
        
        public void levelUp()
        {
            this.TotalHP += random.Next(3, 10); // 0-3 for light growth
            this.Damage += random.Next(3, 9);
            this.Health = this.TotalHP; // Full Heal.
        }
        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }
    }
    // Demon Lord is the end game boss
    class Boss : Creature
    {
        public Boss() // rediculously strong
        {
            this.name = "Demon Lord";
            this.description = "The terrible Demon Lord stands before you." +
                "\nThe atmosphere is heavy, the final battle is at hand!";
            this.Health = 300;
            this.TotalHP = 300;
            this.Damage = 20;
            this.Exp = 0; // Last boss won't level you.
        }
    }

    class Demon : Creature
    {
        public Demon()
        {
            this.name = "Demon Vassal";
            this.description = "A tough looking demon glares at you, hardly hiding their ill intent.";
            this.Health = 200;
            this.TotalHP = 200;
            this.Damage = 15;
            this.Exp = 20;
        }
    }

    class GoldSlime : Creature
    {
        public GoldSlime()
        {
            this.name = "Gold Slime";
            this.description = "WHOA! A Gold Slime wanders out in front of you. Luck is on your side!";
            this.Health = 5;
            this.TotalHP = 5;
            this.Damage = 5;
            this.Exp = 10;
        }
    }

    class Skeleton : Creature
    {
        public Skeleton()
        {
            this.name = "Skeleton";
            this.description = "A skeleton crawls out of the ground before you.";
            this.Health = 30;
            this.TotalHP = 30;
            this.Damage = 6;
            this.Exp = 5;
        }
    }
}