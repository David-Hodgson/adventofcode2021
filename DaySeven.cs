namespace aoc2021
{
	public class DaySeven{

		public void PartOne()
		{
			Console.WriteLine("Day 7 - Part One");

			string input = InputReader.ReadFileAsString("input-d7.txt");

			int[] crabLocations = new int[input.Split(',').Length];
			int cpos = 0;
			foreach(string i in input.Split(','))
			{
				crabLocations[cpos++] = int.Parse(i);
			}

			int minPos = -1;
			int maxPos = -1;

			foreach(int pos in crabLocations)
			{
				if (minPos == -1 || pos < minPos)
				{
					minPos = pos;
				}

				if (maxPos == -1 || pos > maxPos)
				{
					maxPos = pos;
				}
			}

			int lowestCost = -1;

			for(int i = minPos; i<=maxPos; i++)
			{
				int cost = 0;
				foreach(int pos in crabLocations)
				{
					cost = cost + Math.Abs(pos - i);
				}

				if (lowestCost == -1 || cost < lowestCost)
				{
					lowestCost = cost;
				}
			}


			Console.WriteLine("Lowest Fuel Cost: " + lowestCost);

		}

		public void PartTwo()
		{
			Console.WriteLine("Day 7 - Part Two");

			string input = InputReader.ReadFileAsString("input-d7.txt");

			int[] crabLocations = new int[input.Split(',').Length];
			int cpos = 0;
			foreach(string i in input.Split(','))
			{
				crabLocations[cpos++] = int.Parse(i);
			}

			int minPos = -1;
			int maxPos = -1;

			foreach(int pos in crabLocations)
			{
				if (minPos == -1 || pos < minPos)
				{
					minPos = pos;
				}

				if (maxPos == -1 || pos > maxPos)
				{
					maxPos = pos;
				}
			}

			int lowestCost = -1;

			for(int i = minPos; i<=maxPos; i++)
			{
				int cost = 0;
				foreach(int pos in crabLocations)
				{
					int dist =  Math.Abs(pos - i);

					for (int j=1;j<=dist;j++)
					{
						cost = cost + j;
					}
				}

				if (lowestCost == -1 || cost < lowestCost)
				{
					lowestCost = cost;
				}
			}


			Console.WriteLine("Lowest Fuel Cost: " + lowestCost);
		}

	}
}
