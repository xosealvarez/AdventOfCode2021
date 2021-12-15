using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventoOfCode2021.Puzzles
{
    public class PuzzlesDay6
    {
        private readonly int[] _input;
        private SetOfLanternfish _setOfLanternfish;

        public PuzzlesDay6()
        {
            string[] data = System.IO.File.ReadAllLines(@"./Inputs/InputPuzzlesDay6.txt");
            data = data[0].Split(",");
            _input = Array.ConvertAll(data, d => Convert.ToInt32(d));
        }

        public string GetNumOfLanterfishAfter80Days()
        {
            _setOfLanternfish = new SetOfLanternfish(_input);
            return _setOfLanternfish.SimulateDays(80).ToString();
        }

        public string GetNumOfLanterfishAfter256Days()
        {
            _setOfLanternfish = new SetOfLanternfish(_input);
            return _setOfLanternfish.SimulateDays(256).ToString();
        }
    }

    internal class SetOfLanternfish
    {
        private Dictionary<int, long> _fishesDictionary = new Dictionary<int, long>();

        internal SetOfLanternfish(int[] input)
        {
            foreach(var key in Enumerable.Range(0, 9))
            {
                _fishesDictionary.Add(key, input.Count(item => item == key));
            }
        }

        internal long SimulateDays(int days)
        {
            long newFishes = 0;

            for(int i = 0; i < days; i++)
            {
                newFishes = 0;
                foreach(int key in _fishesDictionary.Keys)
                {
                    if(key == 0)
                    {
                        newFishes = _fishesDictionary[key];
                    }
                    
                    if (key == 8)
                    {
                        _fishesDictionary[key] = newFishes;
                        _fishesDictionary[6] += newFishes;
                    }
                    else
                    {
                        _fishesDictionary[key] = _fishesDictionary[key + 1];
                    }
                    
                }
            }

            return _fishesDictionary.Sum(key => key.Value);
        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              