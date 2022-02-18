using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventoOfCode2021.Puzzles
{
    public class PuzzlesDay2
    {
        private readonly string[] _input;
        
        public PuzzlesDay2(string inputFilePath)
        {
            _input = System.IO.File.ReadAllLines(inputFilePath);
        }

        public int getFinalPosition()
        {
            int horizontalPosition = 0;
            int depthPosition = 0;

            foreach (string cmd in _input)
            {
                string[] command = cmd.Split(' ');

                if(command[0].Equals("forward"))
                {
                    horizontalPosition += Convert.ToInt32(command[1]);
                }
                else if(command[0].Equals("down"))
                {
                    depthPosition += Convert.ToInt32(command[1]);
                }
                else if (command[0].Equals("up"))
                {
                    depthPosition -= Convert.ToInt32(command[1]);
                }

            }

            return horizontalPosition * depthPosition;
        }

        public int getFinalPositionWithAim()
        {
            int horizontalPosition = 0;
            int depthPosition = 0;
            int aim = 0;

            foreach (string cmd in _input)
            {
                string[] command = cmd.Split(' ');

                if (command[0].Equals("forward"))
                {
                    horizontalPosition += Convert.ToInt32(command[1]);
                    depthPosition += aim * Convert.ToInt32(command[1]);
                }
                else if (command[0].Equals("down"))
                {
                    aim += Convert.ToInt32(command[1]);
                }
                else if (command[0].Equals("up"))
                {
                    aim -= Convert.ToInt32(command[1]);
                }

            }

            return horizontalPosition * depthPosition;
        }
    }
}
