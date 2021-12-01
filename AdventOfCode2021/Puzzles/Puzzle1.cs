using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventoOfCode2021.Puzzles
{
    public class PuzzlesDay1
    {
        private readonly int[] _input;
        
        public PuzzlesDay1()
        {
            string[] measuresFile = System.IO.File.ReadAllLines(@"./Inputs/InputPuzzle1.txt");
            _input = Array.ConvertAll(measuresFile, s => int.Parse(s));
        }

        public int getNumberOfTimesDepthMeasurementIncrease()
        {
            return countIncrements(_input);
        }

        private int countIncrements(int[] input)
        {
            int numIncrements = 0;
            int lastMeasure = input[0];

            foreach (int measure in input)
            {
                if (measure > lastMeasure)
                {
                    numIncrements++;
                }

                lastMeasure = measure;
            }

            return numIncrements;
        }

        public int getNumberOfTimesTheSumOfMeasurementInSlidingWindows()
        {
            List<int> sumWindowsMeasures = new List<int>();

            for(int i=0;i<_input.Length;i++)
            {
                try
                {
                    sumWindowsMeasures.Add(_input[i..(i + 3)].Sum());
                }
                catch(ArgumentOutOfRangeException)
                {
                    break;
                }

            }

            return countIncrements(sumWindowsMeasures.ToArray());
        }
    }
}
