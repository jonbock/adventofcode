namespace AdventOfCode.One
{
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class Exercise1PartTwo
    {
        public int SutPartTwo(string input)
        {
            var intputList = input.ToCharArray().ToList();
            var halfwayCount = intputList.Count / 2;

            var calculationList = new List<int>();
            for (int i = 0; i < intputList.ToList().Count; i++)
            {
                
            }

           return 0;
        }

        [Fact]
        public void ExampleOne_GetSix()
        {
            var input = "1212";
            var result = SutPartTwo(input);

            result.Should().Be(6);
        }
    }
}
