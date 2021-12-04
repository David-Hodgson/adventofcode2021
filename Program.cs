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
        }
    }

}
