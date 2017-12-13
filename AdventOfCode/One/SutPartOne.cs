namespace AdventOfCode.One
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SutPartOne
    {
        public int Handle(string input)
        {
            var intputList = input.ToCharArray().ToList();

            var previousNum = 0;
            var firstNumber = 0;
            var calculationList = new List<int>();
            for (int i = 0; i < intputList.ToList().Count; i++)
            {
                var currentNumber = Convert.ToInt32(intputList[i].ToString());
                if (i == 0)
                {
                    previousNum = currentNumber;
                    firstNumber = currentNumber;
                    continue;
                }

                if (currentNumber == previousNum)
                {
                    calculationList.Add(currentNumber);
                }
                previousNum = currentNumber;
            }

            if (firstNumber == previousNum)
            {
                calculationList.Add(firstNumber);
            }

            return calculationList.Sum(x => Convert.ToInt32(x));
        }
    }
}
