using System;
using System.Collections.Generic;
using System.Linq;

namespace CandyMarket
{
	class Program
	{
		static void Main(string[] args)
		{
			// wanna be a l33t h@x0r? skip all this console menu nonsense and go with straight command line arguments. something like `candy-market add taffy "blueberry cheesecake" yesterday`
			var db = SetupNewApp();

            var keith = new User("Keith");
            var dave = new User("Dave");
            var sam = new User("Sam");

            var userList = new List<User> { keith, dave, sam };


            var keithsCandyBag = new CandyBag();
            keithsCandyBag.Owner = keith;
            var bagOfKeith = new Dictionary<CandyType, int>();
            bagOfKeith.Add((CandyType)1, 5);
            keithsCandyBag.Bag = bagOfKeith;

            var davesCandyBag = new CandyBag();
            davesCandyBag.Owner = dave;
            var bagOfDave = new Dictionary<CandyType, int>();
            bagOfDave.Add((CandyType)2, 3);
            davesCandyBag.Bag = bagOfDave;

            var samsCandyBag = new CandyBag();
            samsCandyBag.Owner = sam;
            var bagOfSam = new Dictionary<CandyType, int>();
            bagOfSam.Add((CandyType)2, 3);
            samsCandyBag.Bag = bagOfSam;


            var run = true;
			while (run)
			{
				ConsoleKeyInfo userInput = UserPicker(userList);

				switch (userInput.KeyChar)
				{
					case '0':
						run = false;
						break;
                    case '1': // 

                        break;
                    case '2': // add candy to your bag

						// select a candy type
						var selectedCandyType = AddNewCandyType(db);

						/** MORE DIFFICULT DATA MODEL
						 * show a new menu to enter candy details
						 * it would be convenient to show the menu in stages e.g. press enter to go to next detail stage, but write the whole screen again with responses populated so far.
						 */

						// if(moreDifficultDataModel) bug - this is passing candy type right now (which just increments in our DatabaseContext), but should also be passing candy details
						db.SaveNewCandy(selectedCandyType.KeyChar);
						break;
					case '3':
                        //eat candy
                        // select a candy type
                        var selectedCandyTypeToEat = AddNewCandyTypeToEat(db);
                        // select specific candy details to eat from list filtered to selected candy type
                        db.EatCandy(selectedCandyTypeToEat.KeyChar);  
						// enjoy candy
						break;
					case '4':
                        //throw away candy
                        // select a candy type
                        var selectedCandyTypeToThrowAway = AddNewCandyTypeToThrowAway(db);
                        // if(moreDifficultDataModel) enhancement - give user the option to throw away old candy in one action. this would require capturing the detail of when the candy was new.
                        //* 
                        // select specific candy details to throw away from list filtered to selected candy type
                        // *
                        // cry for lost candy
                        db.TrashCandy(selectedCandyTypeToThrowAway.KeyChar);
						break;
					case '5':
                        /** give candy
						 * feel free to hardcode your users. no need to create a whole UI to register users.
						 * no one is impressed by user registration unless it's just amazingly fast & simple
						 * 
						 * select candy in any manner you prefer.
						 * it may be easiest to reuse some code for throwing away candy since that's basically what you're doing. except instead of throwing it away, you're giving it away to another user.
						 * you'll need a way to select what user you're giving candy to.
						 * one design suggestion would be to put candy "on the table" and then "give the candy on the table" to another user once you've selected all the candy to give away
						 */
                         // Restructure beginning, to where it asks you which user you are
                         // Figure out how to store the data, then figure out how to collect the data
                        //var selectedCandyTypeToGive = AddNewCandyTypeToGive(db);


						break;
					case '6':
						/** trade candy
						 * this is the next logical step. who wants to just give away candy forever?
						 */
						break;
					default: // what about requesting candy? like a wishlist. that would be cool.
						break;
				}
			}
		}

        static DatabaseContext SetupNewApp()
		{
			Console.Title = "Cross Confectioneries Incorporated";

			var cSharp = 554;
			var db = new DatabaseContext(tone: cSharp);

			Console.SetWindowSize(60, 30);
			Console.SetBufferSize(60, 30);
			Console.BackgroundColor = ConsoleColor.White;
			Console.ForegroundColor = ConsoleColor.Black;
			return db;
		}

        static ConsoleKeyInfo UserPicker(List<User> userList)
        {
            var listOfNames = userList.Select(user => user.Name).ToList();
            View userPicker = new View()
                    .AddMenuText("Which user are you?")
                    .AddMenuOptions(listOfNames);

            Console.Write(userPicker.GetFullMenu());
            ConsoleKeyInfo pickUser = Console.ReadKey();



            return pickUser;
        }

		static ConsoleKeyInfo CandyOptions()
		{
			View mainMenu = new View()
					.AddMenuOption("Did you just get some new candy? Add it here.")
					.AddMenuOption("Do you want to eat some candy? Take it here.")
                    .AddMenuOption("Do you want to throw away your candy, like a friggin idiot? Do it here.")
                    .AddMenuOption("Want to give your candy to another user? Do it here.")
					.AddMenuText("Press 0 to exit.");

			Console.Write(mainMenu.GetFullMenu());
			ConsoleKeyInfo userOption = Console.ReadKey();
			return userOption;
		}

		static ConsoleKeyInfo AddNewCandyType(DatabaseContext db)
		{
			var candyTypes = db.GetCandyTypes();

			var newCandyMenu = new View()
					.AddMenuText("What type of candy did you get?")
					.AddMenuOptions(candyTypes);

			Console.Write(newCandyMenu.GetFullMenu());

			ConsoleKeyInfo selectedCandyType = Console.ReadKey();
			return selectedCandyType;
		}

        static ConsoleKeyInfo AddNewCandyTypeToEat(DatabaseContext db)
        {
            var candyTypes = db.GetCandyTypes();

            var newCandyMenu = new View()
                .AddMenuText("What type of candy did you eat?")
                .AddMenuOptions(candyTypes);

            Console.Write(newCandyMenu.GetFullMenu());

            ConsoleKeyInfo selectedCandyTypeToEat = Console.ReadKey();
            return selectedCandyTypeToEat;
        }

        static ConsoleKeyInfo AddNewCandyTypeToThrowAway(DatabaseContext db)
        {
            var candyTypes = db.GetCandyTypes();

            var newCandyMenu = new View()
                .AddMenuText("What type of candy do you want to throw away?")
                .AddMenuOptions(candyTypes);

            Console.Write(newCandyMenu.GetFullMenu());

            ConsoleKeyInfo selectedCandyTypeToThrowAway = Console.ReadKey();
            return selectedCandyTypeToThrowAway;
        }

        //static ConsoleKeyInfo AddNewCandyTypeToGive(DatabaseContext db)
        //{
        //    var whichUser = db.usersOfCandy();

        //    var newCandyMenu = new View()
        //        .AddMenuText("Which user are you?")
        //}
    }
}
