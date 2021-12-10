namespace aoc2021
{
	public class DayEight{

		public void PartOne()
		{
			Console.WriteLine("Day 8 - Part One");

			string[] input = InputReader.ReadFileAsStrings("input-d8.txt");;

			int outputCount = 0;
			foreach(string entry in input)
			{
				string outputValues = entry.Split(" | ")[1];

				string[] outputs = outputValues.Split(' ');

				foreach(string output in outputs)
				{
					if (output.Length == 2 || //1
						output.Length == 4 || //4
						output.Length == 3 || //7
						output.Length == 7 ) //8
					{
						outputCount++;
					}
				}
			}

			Console.WriteLine("Total: " + outputCount);
		}

		public void PartTwo()
		{
			Console.WriteLine("Day 8 - Part Two");

			string input = InputReader.ReadFileAsString("input-d8.txt");

		}

	}
}
