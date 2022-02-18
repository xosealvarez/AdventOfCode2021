using AdventoOfCode2021.Puzzles;
using Xunit;

namespace AdventOfCode2021.Test
{
    public class PuzzlesTests
    {
        [Fact]
        public void Day1Part1Test()
        {
            PuzzlesDay1 puzzlesDay1 = new PuzzlesDay1(@"./Inputs/test/InputPuzzlesDay1.txt");
            Assert.Equal(7, puzzlesDay1.getNumberOfTimesDepthMeasurementIncrease());
        }

        [Fact]
        public void Day1Part2Test()
        {
            PuzzlesDay1 puzzlesDay1 = new PuzzlesDay1(@"./Inputs/test/InputPuzzlesDay1.txt");
            Assert.Equal(5, puzzlesDay1.getNumberOfTimesTheSumOfMeasurementInSlidingWindows());
        }

        [Fact]
        public void Day2Part1Test()
        {
            PuzzlesDay2 puzzlesDay2 = new PuzzlesDay2(@"./Inputs/test/InputPuzzlesDay2.txt");
            Assert.Equal(150, puzzlesDay2.getFinalPosition());
        }

        [Fact]
        public void Day2Part2Test()
        {
            PuzzlesDay2 puzzlesDay2 = new PuzzlesDay2(@"./Inputs/test/InputPuzzlesDay2.txt");
            Assert.Equal(900, puzzlesDay2.getFinalPositionWithAim());
        }
    }
}