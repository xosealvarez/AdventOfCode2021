using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventoOfCode2021.Puzzles
{
    public class PuzzlesDay3
    {
        private readonly string[] _input;
        
        public PuzzlesDay3()
        {
            _input = System.IO.File.ReadAllLines(@"./Inputs/InputPuzzlesDay3.txt");
        }

        public string getPowerConsumption()
        {
            string gammaRate = "";
            string epsilonRate = "";
            int powerConsumption = 0;            

            foreach(CommonBit cb in GetCommonBits(_input))
            {
                gammaRate += cb.getMostCommon();
                epsilonRate += cb.getLestCommon();
            }

            powerConsumption = Convert.ToInt32(gammaRate, 2) * Convert.ToInt32(epsilonRate, 2);
            return powerConsumption + " [Gamma rate: " + gammaRate + " (" + Convert.ToInt32(gammaRate,2) + "); Epsilon rate: " + epsilonRate + " (" + Convert.ToInt32(epsilonRate, 2) + ")]";
        }

        private CommonBit[] GetCommonBits(string[] input, int byIndex = -1)
        {
            int numBits = byIndex != -1 ? 1 : input[0].Length;
            CommonBit[] commonBits = new CommonBit[numBits].Select(cb => new CommonBit()).ToArray();

            foreach (string line in input)
            {
                if(byIndex != -1)
                {
                    commonBits[0].add(line[byIndex]);
                }
                else
                {
                    int i = 0;
                    foreach (char bit in line)
                    {
                        commonBits[i].add(bit);
                        i++;
                    }
                }                
            }

            return commonBits;
        }

        public string getLifeSupportRating()
        {
            int lifeSupportRating;
            string oxygenGeneratorRating = getOxygenGeneratorRating();
            string co2ScrubberRating = getCo2ScrubberRating();

            lifeSupportRating = Convert.ToInt32(oxygenGeneratorRating, 2) * Convert.ToInt32(co2ScrubberRating, 2);
            return lifeSupportRating + " [Oxygen rate: " + oxygenGeneratorRating + " (" + Convert.ToInt32(oxygenGeneratorRating, 2) + ");" +
                " CO2 Scrubber rate: " + co2ScrubberRating + " (" + Convert.ToInt32(co2ScrubberRating, 2) + ")]";
        }

        private string getOxygenGeneratorRating()
        {
            string mostCommonBit = "";
            string[] input = (string[])_input.Clone();
            int maxSizeLine = _input[0].Length;

            int i = 0;
            while(input.Length >= 2)
            {
                CommonBit[] cb = GetCommonBits(input, (i));
                mostCommonBit = cb[0].getMostCommon();

                input = input.Where(line => line[i].Equals(Convert.ToChar(mostCommonBit))).ToArray();
                i++;
            }

            return input[0];
        }

        private string getCo2ScrubberRating()
        {
            string mostCommonBit = "";
            string[] input = (string[])_input.Clone();
            int maxSizeLine = _input[0].Length;

            int i = 0;
            while (input.Length >= 2)
            {
                CommonBit[] cb = GetCommonBits(input, (i));
                mostCommonBit = cb[0].getLestCommon();

                input = input.Where(line => line[i].Equals(Convert.ToChar(mostCommonBit))).ToArray();
                i++;
            }

            return input[0];
        }
    }

    internal class CommonBit
    {
        int countZero;
        int countOne;

        public CommonBit()
        {
            countZero = 0;
            countOne = 0;
        }

        public void add(char bit)
        {
            if(bit.Equals('0'))
            {
                countZero++;
            }
            else if(bit.Equals('1'))
            {
                countOne++;
            }
        }

        public string getMostCommon()
        {
            if(countZero > countOne)
            {
                return "0";
            }
            else
            {
                return "1";
            }
        }
        public string getLestCommon()
        {
            if (countZero <= countOne)
            {
                return "0";
            }
            else
            {
                return "1";
            }
        }
    }
}
