namespace aoc2021
{
	public class DayThree{

		public void PartOne()
		{
			Console.WriteLine("Day 3 - Part One");

			string[] report  = InputReader.ReadFileAsStrings("input-d3.txt");

			int length = report[0].Length;

			int[] oneCounts = new int[length];
			int[] naughtCounts = new int[length];

			foreach(string entry in report){
				for(int i=0; i<length; i++)
				{
					if (entry[i] == '1')
					{
						oneCounts[i]++;
					}
					else
					{
						naughtCounts[i]++;
					}
				}
			}

			string gamma = "";
			string epsilon = "";

			for (int i=0; i<length;i++)
			{
				if (oneCounts[i] > naughtCounts[i])
				{
					gamma = gamma + '1';
					epsilon = epsilon + '0';
				}
				else{
					gamma = gamma + '0';
					epsilon = epsilon + '1' ;
				}
			}

			int power = BinaryStringToInt(gamma) * BinaryStringToInt(epsilon);
			Console.WriteLine("Power Comsumption: " + power);
		}

		public void PartTwo()
		{
			Console.WriteLine("Day 3 - Part Two");

			string[] commands = InputReader.ReadFileAsStrings("input-d3.txt");
			
		}

		private int BinaryStringToInt(string input)
		{
			int value = 0;
		
			int weight = 1;

			for(int i=input.Length-1; i>=0; i--)
			{
		
				if (input[i] == '1')
				{
					value = value + weight;
				}	
				weight = weight * 2;
			}

			return value;
		}

	}
}
