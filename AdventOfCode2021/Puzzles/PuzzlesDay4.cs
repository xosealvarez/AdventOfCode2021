using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventoOfCode2021.Puzzles
{
    public class PuzzlesDay4
    {
        private readonly int[] _nums;
        private readonly string[] _input;
        private readonly string[] _inputCards;
        private readonly SetOfCards _cards = new SetOfCards();

        public PuzzlesDay4()
        {
            int rows = 0;
            string cardNumbers = "";

            _input = System.IO.File.ReadAllLines(@"./Inputs/InputPuzzlesDay4.txt");
            _nums = Array.ConvertAll(_input[0].Split(","), s => Convert.ToInt32(s));
            _inputCards = _input.Skip(2).ToArray();

            foreach (string line in _inputCards)
            {
                if (line.Length > 0)
                {
                    cardNumbers += line + " ";
                    rows++;
                }

                if (rows == 5)
                {
                    _cards.Add(new Card(Array.ConvertAll(cardNumbers.Trim().Replace("  ", " ").Split(" "), s => Convert.ToInt32(s))));
                    cardNumbers = "";
                    rows = 0;
                }
            }
        }

        public string GetFirstCardBingo()
        {
            int result = 0;
            int winCard = 0;
            string stringResult = "";           

            foreach(int num in _nums)
            {
                _cards.MarkNumber(num);
                winCard = _cards.CardWithBingo();

                if(winCard != -1)
                {                    
                    result = _cards.GetSumUnmarkedNumbers(winCard);
                    stringResult = (num*result) + " (Last num: " + num + ", Sum unmarked numbers: " + result + ")";
                    break;
                }
            }

            return stringResult;
        }

        public string GetLastCardBingo()
        {
            int result = 0;
            string stringResult = "";

            _cards.Reset();

            foreach (int num in _nums)
            {
                _cards.MarkNumber(num);

                if (_cards.Count() == 1 && _cards.CardWithBingo() != -1)
                {
                    result = _cards.GetSumUnmarkedNumbers(0);
                    stringResult = (num * result) + " (Last num: " + num + ", Sum unmarked numbers: " + result + ")";
                    break;
                }

                _cards.DeleteCardsWithBingo();
            }

            return stringResult;
        }

        internal class SetOfCards
        {
            private List<Card> _cards;

            public SetOfCards()
            {
                _cards = new List<Card>();
            }

            public void Add(Card card)
            {
                _cards.Add(card);
            }

            public void MarkNumber(int number)
            {
                foreach(Card card in _cards)
                {
                    card.MarkNumber(number);
                }
            }

            public int CardWithBingo()
            {
                int i = 0;
                foreach(Card card in _cards)
                {
                    if(card.ExistBingo())
                    {
                        return i;
                    }
                    i++;
                }

                return -1;
            }

            public int GetSumUnmarkedNumbers(int card)
            {
                return _cards[card].GetSumUnmarkedNumbers();
            }

            internal int Count()
            {
                return _cards.Count;
            }

            internal void DeleteCardsWithBingo()
            {
                _cards = _cards.Where(n => !n.ExistBingo()).ToList();
            }

            internal void Reset()
            {
                foreach (Card card in _cards)
                {
                    card.Reset();
                }
            }
        }

        internal class Card
        {
            private CardNumber[,] cardNumbers = new CardNumber[5,5];

            public Card(int[] numbers)
            {
                int k = 0;
                for(int i=0;i<5;i++)
                {
                    for(int j=0;j<5;j++)
                    {
                        cardNumbers[i, j] = new CardNumber(numbers[k]);
                        k++;
                    }
                }
            }

            public void MarkNumber(int number)
            {
                foreach(CardNumber cardNumbers in cardNumbers)
                {
                    if(cardNumbers.GetNumber() == number)
                    {
                        cardNumbers.Mark();
                    }
                }
            }

            internal bool ExistBingo()
            {
                //check rows
                for(int i = 0;i<5;i++)
                {
                    if(cardNumbers[i,0].IsMarked() && cardNumbers[i, 1].IsMarked() && cardNumbers[i, 2].IsMarked() 
                        && cardNumbers[i, 3].IsMarked() && cardNumbers[i, 4].IsMarked() )
                    {
                        return true;
                    }
                }

                //check cols
                for (int i = 0; i < 5; i++)
                {
                    if (cardNumbers[0, i].IsMarked() && cardNumbers[1, i].IsMarked() && cardNumbers[2, i].IsMarked()
                        && cardNumbers[3, i].IsMarked() && cardNumbers[4, i].IsMarked())
                    {
                        return true;
                    }
                }

                return false;
            }

            internal int GetSumUnmarkedNumbers()
            {
                int sum = 0;

                foreach(CardNumber card in cardNumbers)
                {
                    if(!card.IsMarked())
                    {
                        sum += card.GetNumber();
                    }
                }

                return sum;
            }

            internal void Reset()
            {
                foreach(CardNumber card in cardNumbers)
                {
                    card.Unmark();
                }
            }
        }

        internal class CardNumber
        {
            private int _number;
            private bool _marked;

            public CardNumber(int number)
            {
                _number = number;
                _marked = false;
            }

            public void Mark()
            {
                _marked = true;
            }

            public int GetNumber()
            {
                return _number;
            }

            public bool IsMarked()
            {
                return _marked;
            }

            internal void Unmark()
            {
                _marked=false;
            }
        }
    }
}
