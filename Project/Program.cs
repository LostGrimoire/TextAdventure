
/// Project "Text Adventure" CS155
/// Author: Peter Olivares
/// Process:
/// 1. Create Room/Cell class
/// 2. Create Event class
/// 3. Create monster class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero hero = new Hero();
            List<Creature> mobs = new List<Creature>(); 
            // add in monster from cookie cutter. or not
            mobs.Add(new Creature());
            mobs.Add(new GoldSlime());
            mobs.Add(new Skeleton());
            mobs.Add(new Demon());
            mobs.Add(new Boss());

            string text1, text2, text3;
            List<Event> story = new List<Event>();
            text1 = "You wake up by a river. Head pounding, memories foggy. \nYou see you are an adventurer." +
                "\nYou feel like you had to do something about \na Demon Lord. Path ahead. House on right." +
                "\n[1] Take Path [2] Go toward house";
            text2 = "You walk down the road.";
            text3 = "You walk to the final battle.";
            story.Add(new Event(text1, text2, text3));
            text1 = "Home, or you think it was home. Whats left \nis smoldering." +
                "\n[1] Go Back [2] Move On";
            text2 = "You return to the river.";
            text3 = "You part ways with home and continue down \nthe road.";
            story.Add(new Event(text1, text2, text3));
            text1 = "You reach a crossroads in your adventure. \nWhat is your plan?" +
                "\n[1] Look for a fight [2] Avoid trouble";
            text2 = "You go toward a grassy field, looking for \nweak prey.";
            text3 = "You decide to stick to the path and walk on.";
            story.Add(new Event(text1, text2, text3));
            // Fight Path
            text1 = "Grassy Field with a slime, you decide to \nfight it.";
            text2 = "Seeing what you did to their freind, a mess of \nslimes chase you away.";
            text3 = "You Died. Wow.";
            story.Add(new Duel(text1, text2, text3, mobs[0], hero));
            text1 = "You end up in a forest. A glorious gold \nslime is ahead, you eagerly attack.";
            text2 = "You kill it and enjoy its delicious jelly. \nAfter you head on inside the forest.";
            text3 = "It defends itself well, you died.";
            story.Add(new Duel(text1, text2, text3, mobs[1], hero));
            text1 = "End up in a Graveyard, a skeleton pops out of \nthe ground and attacks.";
            text2 = "You finish bashing this one in when many more \nstart crawling out. You run.";
            text3 = "You join the undead. Its not all bad.";
            story.Add(new Duel(text1, text2, text3, mobs[2], hero));
            text1 = "You approach a castle. A tough looking Demon " +
                "\nstands by the gate. Theres a hole in the wall" + 
                "\naround the left side.\n[1] Charge the gate [2] Go around";
            text2 = "You ready your weapon and charge the demon.";
            text3 = "You decide against fighting him, he might \nactually stand a chance.";
            story.Add(new Event(text1, text2, text3));
            // Fight Upper
            text1 = "You enter the hole and are immidiately beset \nby a skeleton.";
            text2 = "You finish it and move down the corridor you \nentered.";
            text3 = "You join the undead. Its not all bad.";
            story.Add(new Duel(text1, text2, text3, mobs[2], hero));
            text1 = "Whoa. Gold Slime just sitting there. You attack \nbefore it sees you.";
            text2 = "You hear skeletons behind you. You take what you \ncan and move on.";
            text3 = "It beat you anyways. You died.";
            story.Add(new Duel(text1, text2, text3, mobs[1], hero));
            // Fight Lower
            text1 = "Seeing your raised weapon the demon remarks, \n\"Oh, finally " + 
                "decide to fight? Bring it ON!\"\nThe demon charges at you.";
            text2 = "The demon lies unconcious. You wonder what he ment as you enter the castle.";
            text3 = "The demon delivers a final blow, knocking you into into next week.";
            story.Add(new Duel(text1, text2, text3, mobs[3], hero));
            // Sneak Path
            text1 = "You walk on the path near a forest and see a gold \nslime." +
                "\n[1] Attack the Slime [2] Keep walking";
            text2 = "You enter the forest and start sneaking toward it.";
            text3 = "Ignoring it, you move on.";
            story.Add(new Event(text1, text2, text3));
            text1 = "The path turned perilous as you walk on against \na cliff. There is a gap." +
                "\n[1] Jump it [2] Walk around";
            text2 = "You clear the gap, and continue on your path.";
            text3 = "You start looking around when you slip on lose \ndirt and slide down the cliff.";
            story.Add(new Event(text1, text2, text3));
            text1 = "Path ends up at a castle, you see a tree that can \nget you in a window and" +
                "\na crumbling wall you might be able to break." +
                "\n[1] Climp tree [2] Break wall";
            text2 = "You deftly climb the tree and get inside without \nissue.";
            text3 = "You break the wall, the old bricks easily crumble \naway leaving a new entrance.";
            story.Add(new Event(text1, text2, text3));
            // sneak high
            text1 = "You see a dark room to your side as you wander. Take a Look?" +
                "\n[1] Yes [2] No";
            text2 = " As you peak inside you quickly realize somethink \nhas fallen on your head." + 
                "You try to grasp it but your fingers just sink into \nit. A gold slime sufficates you.";
            text3 = "You ignore it and wander on. Thinking nothing of it.";
            story.Add(new Event(text1, text2, text3));
            text1 = "You wander this upper floor until end up on the \nroof, the shingles look slippery. " +
                "\nYou wonder what to do." +
                "\n[1] Run across [2] Walk across";
            text2 = "The shingles slip and you fall with a loud crash, \nattracting a demon.";
            text3 = "You make it to sturdier lumber and continue to a \ngreat hall.";
            story.Add(new Event(text1, text2, text3));
            // sneak low
            text1 = "You creep around and find yourself quite near the " + 
                "\nGreat Hall. You see a library not far from where \nyou are. Investigate?" + 
                "\n[1] Nah, books are dumb [2] Sure";
            text2 = "You ignore it and walk into the great hall.";
            text3 = "You walk into the old musty library.";
            story.Add(new Event(text1, text2, text3));
            text1 = "The place houses many broken book shelves and \nold rotten books. You see a new looking" +
                "\nbook nearby. Alice's Diary, it says on the cover. \nYour memory clears for a second, that" +
                "\nwas your wife's name! The burst of clarity quickly \nleaves though. You see a nearby magic" +
                "\ntome and think about trying your hand at magic!" +
                "\n[1] Ignore it, seems shady [2] Give it a shot";
            text2 = "You ignore it and decide to enter the great hall.";
            text3 = "You crack open the book and read the first phrase \nyou see. The book explodes, killing you.";
            story.Add(new Event(text1, text2, text3));
            // Finale
            text1 = "This is the demon lord's chamber, they haven't \nnoticed you yet." +
                "\n[1] Attack [2] Skip It [3] Talk";
            text2 = "\nYour sight fades to black... \n";
            text3 = "The Demon Lord throws their helmet to the ground \nand hugs you." 
                +"\n\"I was afraid you were lost to us!\"";
            story.Add(new Finale(text1, text2, text3, mobs[4], hero));
            
            
            VictoryRoom win = new VictoryRoom();
            List<Room> dungeon = new List<Room>();

            dungeon.Add(new Room());
            dungeon.Add(new Room());
            dungeon.Add(new Room());
            dungeon.Add(new Room());
            dungeon.Add(new Room());
            dungeon.Add(new Room());
            dungeon.Add(new Room());
            dungeon.Add(new Room());
            dungeon.Add(new Room());
            dungeon.Add(new Room());
            dungeon.Add(new Room());
            dungeon.Add(new Room());
            dungeon.Add(new Room());
            dungeon.Add(new Room());
            dungeon.Add(new Room());
            dungeon.Add(new Room());
            dungeon.Add(new Room());
            dungeon.Add(new Room());

            // Which one is which? 
            dungeon[0].setDestination1(dungeon[2]); // split
            dungeon[0].setDestination2(dungeon[1]); // home
            dungeon[0].setEvent(story[0]);
            dungeon[1].setDestination1(dungeon[0]); // start
            dungeon[1].setDestination2(dungeon[2]); // split
            dungeon[1].setEvent(story[1]);
            dungeon[2].setDestination1(dungeon[3]); // slime fight
            dungeon[2].setDestination2(dungeon[10]); // sneak 
            dungeon[2].setEvent(story[2]);
            dungeon[3].setDestination1(dungeon[4]); // g-slime fight
            dungeon[3].setDestination2(dungeon[0]);
            dungeon[3].setEvent(story[3]);
            dungeon[4].setDestination1(dungeon[5]); // skelly
            dungeon[4].setDestination2(dungeon[0]);
            dungeon[4].setEvent(story[4]);
            dungeon[5].setDestination1(dungeon[6]); // fight split
            dungeon[5].setDestination2(dungeon[0]);
            dungeon[5].setEvent(story[5]);
            dungeon[6].setDestination1(dungeon[9]); // lower fight
            dungeon[6].setDestination2(dungeon[7]); // upper fight
            dungeon[6].setEvent(story[6]);
            dungeon[7].setDestination1(dungeon[8]); // second upper
            dungeon[7].setDestination2(dungeon[0]);
            dungeon[7].setEvent(story[7]);
            dungeon[8].setDestination1(dungeon[17]); // end
            dungeon[8].setDestination2(dungeon[0]);
            dungeon[8].setEvent(story[8]);
            dungeon[9].setDestination1(dungeon[17]); // end
            dungeon[9].setDestination2(dungeon[0]);
            dungeon[9].setEvent(story[9]);
            dungeon[10].setDestination1(dungeon[4]); // g-slime
            dungeon[10].setDestination2(dungeon[11]);
            dungeon[10].setEvent(story[10]);
            dungeon[11].setDestination1(dungeon[12]);
            dungeon[11].setDestination2(dungeon[5]); // skelly
            dungeon[11].setEvent(story[11]);
            dungeon[12].setDestination1(dungeon[13]); // upper sneak
            dungeon[12].setDestination2(dungeon[15]); // lower sneak
            dungeon[12].setEvent(story[12]);
            dungeon[13].setDestination1(dungeon[0]); 
            dungeon[13].setDestination2(dungeon[14]); // upper 2
            dungeon[13].setEvent(story[13]);
            dungeon[14].setDestination1(dungeon[17]);// end
            dungeon[14].setDestination2(dungeon[7]); // demon fight
            dungeon[14].setEvent(story[14]);
            dungeon[15].setDestination1(dungeon[17]);
            dungeon[15].setDestination2(dungeon[16]); // library
            dungeon[15].setEvent(story[15]);
            dungeon[16].setDestination1(dungeon[17]);
            dungeon[16].setDestination2(dungeon[0]);
            dungeon[16].setEvent(story[16]);
            dungeon[17].setDestination1(dungeon[0]);
            dungeon[17].setDestination2(win);
            dungeon[17].setEvent(story[17]);

            System system = new System(dungeon[0]);
            while (!system.checkWin())
            {
                system.nextRoom();
            }
            Console.WriteLine("You find out you got seperated after entering" +
                "\nthe next room. You and the Demon Lord leave the ruined castle." + 
                "\nYou pick up your step-brother outside the gate and walk home " +
                "talking of your adventure.");
            Console.WriteLine("\nFIN");

            Console.ReadLine();
        }
    }
}