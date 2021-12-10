using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventoOfCode2021.Puzzles
{
    public class PuzzlesDay5
    {
        private readonly string[] _input;
        private SetOfLines _lines;

        public PuzzlesDay5()
        {
            _input = System.IO.File.ReadAllLines(@"./Inputs/InputPuzzlesDay5.txt");
            _lines = new SetOfLines(_input);
        }

        public string GetNumPointsOverlaped()
        {
            _lines.RenderBoard();
            return _lines.GetNumOverlapedLines().ToString();
        }

        public string GetNumPointsOverlapedWithDiagonals()
        {
            _lines.RenderBoardWithDiagonals();
            return _lines.GetNumOverlapedLines().ToString();
        }
    }

    internal class SetOfLines
    {
        private List<Line> _lines = new List<Line>();
        private int[,] _board;

        public SetOfLines(string[] input)
        {
            int x1;
            int y1;
            int x2;
            int y2;
            int maxX = 0;
            int maxY = 0;

            foreach (string i in input)
            {
                x1 = Convert.ToInt32(i.Split("->")[0].Split(",")[0]);
                y1 = Convert.ToInt32(i.Split("->")[0].Split(",")[1]);
                x2 = Convert.ToInt32(i.Split("->")[1].Split(",")[0]);
                y2 = Convert.ToInt32(i.Split("->")[1].Split(",")[1]);

                _lines.Add(new Line(new Point(x1, y1), new Point(x2, y2)));

                if(x1 > maxX) maxX = x1;
                if(x2 > maxX) maxX = x2;
                if (y1 > maxY) maxY = y1;
                if (y2 > maxY) maxY = y2;
            }

            _board = new int[maxX+1, maxY+1];
        }

        public void RenderBoard()
        {
            _board = new int[_board.GetLength(0), _board.GetLength(1)];

            foreach (Line line in _lines)
            {
                if(line.IsHorizontal() || line.IsVertical())
                {
                    foreach(Point point in line.GetAllPoints())
                    {
                        _board[point.X, point.Y]++;
                    }
                }
            }
        }

        public void RenderBoardWithDiagonals()
        {
            _board = new int[_board.GetLength(0), _board.GetLength(1)];

            foreach (Line line in _lines)
            {                
                foreach (Point point in line.GetAllPoints())
                {
                    _board[point.X, point.Y]++;
                }
            }
        }

        public int GetNumOverlapedLines()
        {
            int num = 0;

            for(int i = 0; i < _board.GetLength(0); i++)
            {
                for(int j = 0; j < _board.GetLength(1); j++)
                {
                    if(_board[i, j] > 1)
                    {
                        num++;
                    }
                }
            }

            return num;
        }
    }

    internal class Line
    {
        private readonly Point _x;
        private readonly Point _y;
        private readonly List<Point> _points = new List<Point>();

        public Point X { get { return _x; } }
        public Point Y { get { return _y; } }

        public Line(Point x, Point y)
        {
            _x = x;
            _y = y;

            //horizontal
            if (_x.X == _y.X)
            {
                if(_x.Y < _y.Y)
                {
                    for (int i = _x.Y; i<=_y.Y;i++)
                    {
                        _points.Add(new Point(_x.X,i));
                    }
                }
                else
                {
                    for (int i = _x.Y; i >= _y.Y; i--)
                    {
                        _points.Add(new Point(_x.X, i));
                    }
                }

            }
            else if (_x.Y == _y.Y) // vertical
            {
                if (_x.X < _y.X)
                {
                    for (int i = _x.X; i <= _y.X; i++)
                    {
                        _points.Add(new Point(i,_x.Y));
                    }
                }
                else
                {
                    for (int i = _x.X; i >= _y.X; i--)
                    {
                        _points.Add(new Point(i,_x.Y));
                    }
                }

            }
            else //diagnoal
            {
                int[] xPositions;
                int[] yPositions;

                if(_x.X < _y.X)
                {
                    xPositions = Enumerable.Range(_x.X, (_y.X - _x.X) + 1).ToArray();
                }
                else
                {
                    xPositions = Enumerable.Range(_y.X, (_x.X - _y.X) + 1).Reverse().ToArray();
                }

                if(_x.Y < _y.Y)
                {
                    yPositions = Enumerable.Range(_x.Y, (_y.Y - _x.Y) + 1).ToArray();
                }
                else
                {
                    yPositions = Enumerable.Range(_y.Y, (_x.Y - _y.Y) + 1).Reverse().ToArray();
                }

                for(int i = 0; i < xPositions.Length; i++)
                {
                    _points.Add(new Point(xPositions[i], yPositions[i]));
                }
            }
        }

        public bool IsHorizontal()
        {
            return _x.X == _y.X;
        }

        public bool IsVertical()
        {
            return _x.Y == _y.Y;
        }

        override
        public string ToString()
        {
            return _x.X + "," + _x.Y + " -> " + _y.X + "-" + _y.Y;
        }

        public List<Point> GetAllPoints()
        {
            return _points;
        }
    }

    internal class Point
    {
        private readonly int _x;
        private readonly int _y;

        public int X { get { return _x; } }
        public int Y { get { return _y; } }

        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              