namespace aoc2021
{
	public class DayOne{

		public void PartOne()
		{
			Console.WriteLine("Day 1 - Part One");

			int[] depths = InputReader.ReadFileAsInts("input-d1.txt");

			int currentDepth = -1;
			int count = 0;

			foreach(int depth in depths)
			{
				if (currentDepth != -1 && depth > currentDepth)
				{
					count++;
				}
				currentDepth = depth;
			}

			Console.WriteLine("Count: " + count);

		}

		public void PartTwo()
		{
			Console.WriteLine("Day 1 - Part Two");

			int[] depths = InputReader.ReadFileAsInts("input-d1.txt");

			int currentDepth = -1;
			int count = 0;

			for(int i=0; i < depths.Length - 2 ; i++)
			{
				int depth = depths[i] + depths[i+1] + depths[i+2];
				if (currentDepth != -1 && depth > currentDepth)
				{
					count ++;
				}

				currentDepth = depth;
			}

			Console.WriteLine("Count: " + count);
		}

	}
}
