using AdventoOfCode2021.Puzzles;

Console.WriteLine("Advent of Code 2021");

PuzzlesDay1 puzzlesDay1 = new PuzzlesDay1();
Console.WriteLine("\tPuzzle Day 1 Part 1: " + puzzlesDay1.getNumberOfTimesDepthMeasurementIncrease());
Console.WriteLine("\tPuzzle Day 1 Part 2: " + puzzlesDay1.getNumberOfTimesTheSumOfMeasurementInSlidingWindows());

PuzzlesDay2 puzzlesDay2 = new PuzzlesDay2();
Console.WriteLine("\n\tPuzzle Day 2 Part 1: " + puzzlesDay2.getFinalPosition());
Console.WriteLine("\tPuzzle Day 2 Part 2: " + puzzlesDay2.getFinalPositionWithAim());