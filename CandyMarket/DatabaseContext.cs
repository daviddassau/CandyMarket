﻿using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CandyMarket
{
    internal class DatabaseContext
    {
        private int _countOfTaffy;
        private int _countOfCandyCoated;
        private int _countOfChocolateBar;
        private int _countOfZagnut;

        public Dictionary<string, Dictionary<string, int>> UsersOfCandy = new Dictionary<string, Dictionary<string, int>>();



        /**
		 * this is just an example.
		 * feel free to modify the definition of this collection "BagOfCandy" if you choose to implement the more difficult data model.
		 * Dictionary<CandyType, List<Candy>> BagOfCandy { get; set; }
		 */

        public DatabaseContext(int tone) => Console.Beep(tone, 2500);

        internal List<string> GetCandyTypes()
        {
            return Enum
                .GetNames(typeof(CandyType))
                .Select(candyType =>
                    candyType.Humanize(LetterCasing.Title))
                .ToList();
        }

        internal void SaveNewCandy(char selectedCandyMenuOption)
        {
            var candyOption = int.Parse(selectedCandyMenuOption.ToString());

            var maybeCandyMaybeNot = (CandyType)selectedCandyMenuOption;
            var forRealTheCandyThisTime = (CandyType)candyOption;

            switch (forRealTheCandyThisTime)
            {
                case CandyType.TaffyNotLaffy:
                    ++_countOfTaffy;
                    break;
                case CandyType.CandyCoated:
                    ++_countOfCandyCoated;
                    break;
                case CandyType.CompressedSugar:
                    ++_countOfChocolateBar;
                    break;
                case CandyType.ZagnutStyle:
                    ++_countOfZagnut;
                    break;
                default:
                    break;
            }
        }

        internal void EatCandy(char selectedCandyMenuOptionToEat)
        {
            var candyOption = int.Parse(selectedCandyMenuOptionToEat.ToString());

            var forRealTheCandyEaten = (CandyType)candyOption;

            switch (forRealTheCandyEaten)
            {
                case CandyType.TaffyNotLaffy:
                    --_countOfTaffy;
                    break;
                case CandyType.CandyCoated:
                    --_countOfCandyCoated;
                    break;
                case CandyType.CompressedSugar:
                    --_countOfChocolateBar;
                    break;
                case CandyType.ZagnutStyle:
                    --_countOfZagnut;
                    break;
                default:
                    break;
            }
        }

        internal void TrashCandy(char selectedCandyMenuOptionToThrowAway)
        {
            var candyOption = int.Parse(selectedCandyMenuOptionToThrowAway.ToString());

            var forRealTheCandyThrownAway = (CandyType)candyOption;

            switch (forRealTheCandyThrownAway)
            {
                case CandyType.TaffyNotLaffy:
                    --_countOfTaffy;
                    break;
                case CandyType.CandyCoated:
                    --_countOfCandyCoated;
                    break;
                case CandyType.CompressedSugar:
                    --_countOfChocolateBar;
                    break;
                case CandyType.ZagnutStyle:
                    --_countOfZagnut;
                    break;
                default:
                    break;
            }
        }
    }
}