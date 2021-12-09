// Hello World! program
namespace aoc2021
{
    class Program {         
        static void Main(string[] args)
        {
            System.Console.WriteLine("Advent of Code 2021!");

	    DayOne d1 = new DayOne();
	    d1.PartOne();
	    d1.PartTwo();

	    DayTwo d2 = new DayTwo();
	    d2.PartOne();
	    d2.PartTwo();

	    DayThree d3 = new DayThree();
	    d3.PartOne();
	    d3.PartTwo();

	    DayFour d4 = new DayFour();
	    d4.PartOne();
	    d4.PartTwo();

	    DayFive d5 = new DayFive();
	    d5.PartOne();
	    d5.PartTwo();

	    DaySix d6 = new DaySix();
	    d6.PartOne();
	    d6.PartTwo();
        }
    }

}
