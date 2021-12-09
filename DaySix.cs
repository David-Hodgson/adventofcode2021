namespace aoc2021
{
	public class DaySix{

		public void PartOne()
		{
			Console.WriteLine("Day 6 - Part One");

			string input = InputReader.ReadFileAsString("input-d6.txt");;

			long[] fishes = parseFishList(input); 

			int maxDays = 80;

			runFishSimulation(maxDays,fishes);

			Console.WriteLine("Total Fish: " + countFish(fishes));
		}

		public void PartTwo()
		{
			Console.WriteLine("Day 6 - Part Two");

			string input = InputReader.ReadFileAsString("input-d6.txt");;

			long[] fishes = parseFishList(input); 

			int maxDays = 256;

			runFishSimulation(maxDays,fishes);

			Console.WriteLine("Total Fish: " + countFish(fishes));
		}

		private long[] parseFishList(string input)
		{

			long[] fishes = new long[9];
			foreach(string i in input.Split(','))
			{
				fishes[long.Parse(i)]++;
			}

			return fishes;
		}

		private void runFishSimulation(int maxDays, long[] fishes)
		{

			for (long i=0; i<maxDays; i++)
			{
				long newFishCount = fishes[0];
				
				fishes[0] = fishes[1];
				fishes[1] = fishes[2];
				fishes[2] = fishes[3];
				fishes[3] = fishes[4];
				fishes[4] = fishes[5];
				fishes[5] = fishes[6];
				fishes[6] = fishes[7] + newFishCount;
				fishes[7] = fishes[8];
				fishes[8] = newFishCount;

			}
		}

		private long countFish(long[] fishes)
		{
			long count = 0;
			foreach(long fish in fishes)
			{
				count = count + fish;
			}
			return count;
		}
	}
}
