namespace aoc2021
{
	public class DayTwo{

		public void PartOne()
		{
			Console.WriteLine("Day 2 - Part One");

			string[] commands = InputReader.ReadFileAsStrings("input-d2.txt");

			int horizontal = 0;
			int depth = 0;

			foreach(string command in commands)
			{
				string[] parts = command.Split(' ');

				string dir = parts[0];
				int dist = int.Parse(parts[1]);

				if (dir == "forward")
				{
					horizontal = horizontal + dist;
				}

				if (dir == "up")
				{
					depth = depth -  dist;
				}

				if (dir == "down")
				{
					depth = depth + dist;
				}	
			
			}

			int total = horizontal * depth;

			Console.WriteLine("Total: " + total);
			
		}

		public void PartTwo()
		{
			Console.WriteLine("Day 2 - Part Two");

			string[] commands = InputReader.ReadFileAsStrings("input-d2.txt");

			int horizontal = 0;
			int depth = 0;
			int aim = 0;

			foreach(string command in commands)
			{
				string[] parts = command.Split(' ');

				string dir = parts[0];
				int dist = int.Parse(parts[1]);

				if (dir == "forward")
				{
					horizontal = horizontal + dist;
					depth = depth + (aim * dist);
				}

				if (dir == "up")
				{
					aim = aim - dist;
				}

				if (dir == "down")
				{
					aim = aim + dist;
				}	
			
			}

			int total = horizontal * depth;

			Console.WriteLine("Total: " + total);
			
		}

	}
}
