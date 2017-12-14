﻿namespace AdventOfCode.Two
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    ////--- Day 2: Corruption Checksum ---

    //// As you walk through the door, a glowing humanoid shape yells in your direction. "You there! Your state appears to be idle. Come help us repair the corruption in this spreadsheet - if we take another millisecond, we'll have to display an hourglass cursor!"

    //// The spreadsheet consists of rows of apparently-random numbers. To make sure the recovery process is on the right track, they need you to calculate the spreadsheet's checksum. For each row, determine the difference between the largest value and the smallest value; the checksum is the sum of all of these differences.

    //// For example, given the following spreadsheet:

    //// 5 1 9 5
    //// 7 5 3
    //// 2 4 6 8
    //// The first row's largest and smallest values are 9 and 1, and their difference is 8.
    //// The second row's largest and smallest values are 7 and 3, and their difference is 4.
    //// The third row's difference is 6.
    //// In this example, the spreadsheet's checksum would be 8 + 4 + 6 = 18.

    //// What is the checksum for the spreadsheet in your puzzle input?

    public class Exercise2PartOne
    {
        private string _exerciseInput = String.Empty;

        public Exercise2PartOne()
        {
            _exerciseInput = @"278	1689	250	1512	1792	1974	175	1639	235	1635	1690	1947	810	224	928	859
                            160	50	55	81	68	130	145	21	211	136	119	78	174	155	149	72
                            4284	185	4499	273	4750	4620	4779	4669	2333	231	416	1603	197	922	5149	2993
                            120	124	104	1015	1467	110	299	320	1516	137	1473	132	1229	1329	1430	392
                            257	234	3409	2914	2993	3291	368	284	259	3445	245	1400	3276	339	2207	233
                            1259	78	811	99	2295	1628	3264	2616	116	3069	2622	1696	1457	1532	268	82
                            868	619	139	522	168	872	176	160	1010	200	974	1008	1139	552	510	1083
                            1982	224	3003	234	212	1293	1453	3359	326	3627	3276	3347	1438	2910	248	2512
                            4964	527	5108	4742	4282	4561	4070	3540	196	228	3639	4848	152	1174	5005	202
                            1381	1480	116	435	980	1022	155	1452	1372	121	128	869	1043	826	1398	137
                            2067	2153	622	1479	2405	1134	2160	1057	819	99	106	1628	1538	108	112	1732
                            4535	2729	4960	241	4372	3960	248	267	230	5083	827	1843	3488	4762	2294	3932
                            3245	190	2249	2812	2620	2743	2209	465	139	2757	203	2832	2454	177	2799	2278
                            1308	797	498	791	1312	99	1402	1332	521	1354	1339	101	367	1333	111	92
                            149	4140	112	3748	148	815	4261	138	1422	2670	32	334	2029	4750	4472	2010
                            114	605	94	136	96	167	553	395	164	159	284	104	530	551	544	18";
        }

        public int ProcessCheckSum(string input)
        {
            var initialSplitOnRow = input.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
            var totalSum = new List<int>();
            foreach (var row in initialSplitOnRow)
            {
                //var listChecksums = row.Replace("\t", " ").Split(" ", StringSplitOptions.RemoveEmptyEntries);
                List<int> CalculatedChecksumItems = new List<int>();

                CalculatedChecksumItems.Add(CalculateCheckSum(row));


                totalSum.Add(CalculatedChecksumItems.Sum());
            }
            return totalSum.Sum();
        }

        public int CalculateCheckSum(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                var blockListString = input.Split("\t").ToList(); //input.ToCharArray().Select(c => c.ToString()).ToList();
                var blockListInt = blockListString.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList().ConvertAll(int.Parse);
                blockListInt.Sort();

                var firstNumber = blockListInt.FirstOrDefault();
                var lastNumber = blockListInt.LastOrDefault();

                return lastNumber - firstNumber;
            }
            return 0;
        }

        [Fact]
        public void ExampleCode_5195_GivesEight()
        {
            var input = "5\t1\t9\t5";

            var result = CalculateCheckSum(input);

            result.Should().Be(8);
        }

        [Fact]
        public void ExampleCode_753_GivesFour()
        {
            var input = "7\t5\t3";

            var result = CalculateCheckSum(input);

            result.Should().Be(4);
        }

        [Fact]
        public void ExampleCode_2468_GivesFour()
        {
            var input = "2\t4\t6\t8";

            var result = CalculateCheckSum(input);

            result.Should().Be(6);
        }

        [Fact]
        public void ExampleCode_5195_753_2468_GivesEighteen()
        {
            var input = "5\t1\t9\t5\r\n7\t5\t3\r\n2\t4\t6\t8";

            var result = ProcessCheckSum(input);

            result.Should().Be(18);
        }

        [Fact]
        public void CalculateSolution_GivesAnswer()
        {

            var result = ProcessCheckSum(_exerciseInput);

            result.Should().Be(42378);
        }
    }
}
