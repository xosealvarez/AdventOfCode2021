using AdventoOfCode2021.Puzzles;

Console.WriteLine("Advent of Code 2021");

PuzzlesDay1 puzzlesDay1 = new PuzzlesDay1();
Console.WriteLine("\tPuzzle Day 1 Part 1: " + puzzlesDay1.getNumberOfTimesDepthMeasurementIncrease());
Console.WriteLine("\tPuzzle Day 1 Part 2: " + puzzlesDay1.getNumberOfTimesTheSumOfMeasurementInSlidingWindows());

PuzzlesDay2 puzzlesDay2 = new PuzzlesDay2();
Console.WriteLine("\n\tPuzzle Day 2 Part 1: " + puzzlesDay2.getFinalPosition());
Console.WriteLine("\tPuzzle Day 2 Part 2: " + puzzlesDay2.getFinalPositionWithAim());

PuzzlesDay3 puzzlesDay3 = new PuzzlesDay3();
Console.WriteLine("\n\tPuzzle Day 3 Part 1: " + puzzlesDay3.getPowerConsumption());
Console.WriteLine("\tPuzzle Day 3 Part 2: " + puzzlesDay3.getLifeSupportRating());

PuzzlesDay4 puzzlesDay4 = new PuzzlesDay4();
Console.WriteLine("\n\tPuzzle Day 4 Part 1: " + puzzlesDay4.GetFirstCardBingo());
Console.WriteLine("\tPuzzle Day 4 Part 2: " + puzzlesDay4.GetLastCardBingo());

PuzzlesDay5 puzzlesDay5 = new PuzzlesDay5();
Console.WriteLine("\n\tPuzzle Day 5 Part 1: " + puzzlesDay5.GetNumPointsOverlaped());
Console.WriteLine("\tPuzzle Day 5 Part 2: " + puzzlesDay5.GetNumPointsOverlapedWithDiagonals());
