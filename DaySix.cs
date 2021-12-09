namespace aoc2021
{
	public class DaySix{

		public void PartOne()
		{
			Console.WriteLine("Day 6 - Part One");

			string input = InputReader.ReadFileAsString("input-d6.txt");;

///			string input = "3,4,3,1,2";

			List<int> fishes = parseFishList(input); 

			int maxDays = 80;

			runFishSimulation(maxDays,fishes);

			Console.WriteLine("Total Fish: " + fishes.Count);
		}

		public void PartTwo()
		{
			Console.WriteLine("Day 6 - Part Two");

//			string input = InputReader.ReadFileAsString("input-d6.txt");

		}

		private List<int> parseFishList(string input)
		{

			List<int> fishes = new List<int>();
			foreach(string i in input.Split(','))
			{
				fishes.Add(int.Parse(i));
			}

			return fishes;
		}

		private void runFishSimulation(int maxDays, List<int> fishes)
		{

			for (int i=0; i<maxDays; i++)
			{

				int fishLength = fishes.Count;
				for(int j=0; j< fishLength; j++ )
				{
					if (fishes[j] == 0) {
						fishes[j] = 6;
						fishes.Add(8);
					}
					else
					{
						fishes[j]--;
					}

				}

			}
		}
	}
}
