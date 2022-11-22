using System;
using System.Collections.Generic;

// Every class in the program is defined within the "Quest" namespace
// Classes within the same namespace refer to one another without a "using" statement
namespace Quest
{
    class Program
    {
        static void Main(string[] args)
        {


            // Create a few challenges for our Adventurer's quest
            // The "Challenge" Constructor takes three arguments
            //   the text of the challenge
            //   a correct answer
            //   a number of awesome points to gain or lose depending on the success of the challenge
            Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);
            Challenge theAnswer = new Challenge(
                "What's the answer to life, the universe and everything?", 42, 25);
            Challenge whatSecond = new Challenge(
                "What is the current second?", DateTime.Now.Second, 50);

            int randomNumber = new Random().Next() % 10;
            Challenge guessRandom = new Challenge("What number am I thinking of?", randomNumber, 25);

            Challenge favoriteBeatle = new Challenge(
                @"Who's your favorite Beatle?
        1) John
        2) Paul
        3) George
        4) Ringo
    ",
                4, 20
            );
            Challenge numberOfLicks = new Challenge("How many licks to get to the center of a Tootsie Pop?", 3, 20);
            Challenge bottlesOfBeer = new Challenge("100 bottles of beer on the wall, take one down, pass it around, how many bottles of beer on the wall?", 99, 15);

            // "Awesomeness" is like our Adventurer's current "score"
            // A higher Awesomeness is better

            // Here we set some reasonable min and max values.
            //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
            //  If an Adventurer has an Awesomeness less than the min, they are terrible
            int minAwesomeness = 0;
            int maxAwesomeness = 100;

            Robe robe = new Robe();
            robe.Colors = new List<string>() { "blue", "purple", "gold" };
            robe.Length = 65;

            Hat hat = new Hat();
            hat.ShininessLevel = 8;

            // Make a new "Adventurer" object using the "Adventurer" class
            Console.Write("What is your name, adventurer?");
            Adventurer theAdventurer = new Adventurer(Console.ReadLine(), robe, hat);

            string playAgain = "yes";
            while (playAgain == "yes")
            {
                Console.WriteLine(theAdventurer.GetDescription());

                // A list of challenges for the Adventurer to complete
                // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
                List<Challenge> challenges = new List<Challenge>()
                {
                    twoPlusTwo,
                    theAnswer,
                    whatSecond,
                    guessRandom,
                    favoriteBeatle,
                    numberOfLicks,
                    bottlesOfBeer
                };

                List<Challenge> randomChallenges = new List<Challenge>();
                while (randomChallenges.Count < 5)
                {
                    int randomInt = new Random().Next(challenges.Count);
                    Challenge randomChallenge = challenges[randomInt];
                    if (!randomChallenges.Contains(randomChallenge))
                    {
                        randomChallenges.Add(randomChallenge);
                    }
                }

                int numberSuccessful = 0;

                // Loop through all the challenges and subject the Adventurer to them
                foreach (Challenge challenge in randomChallenges)
                {
                    int startingAwesomeness = theAdventurer.Awesomeness;
                    challenge.RunChallenge(theAdventurer);
                    if (theAdventurer.Awesomeness > startingAwesomeness)
                    {
                        numberSuccessful++;
                    }
                }

                // This code examines how Awesome the Adventurer is after completing the challenges
                // And praises or humiliates them accordingly
                if (theAdventurer.Awesomeness >= maxAwesomeness)
                {
                    Console.WriteLine("YOU DID IT! You are truly awesome!");
                }
                else if (theAdventurer.Awesomeness <= minAwesomeness)
                {
                    Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
                }
                else
                {
                    Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight.");
                }

                Prize prize = new Prize("You got a Dazzling Ruby");
                prize.ShowPrize(theAdventurer);

                Console.Write("Try again?");
                playAgain = Console.ReadLine().ToLower();

                if (playAgain == "yes")
                {
                    theAdventurer.Awesomeness = 50 + numberSuccessful * 10;
                }
            }
        }
    }
}