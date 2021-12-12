namespace aoc2021
{
	public class DayNine{

		public void PartOne()
		{
			Console.WriteLine("Day 9 - Part One");

			string[] heights = InputReader.ReadFileAsStrings("input-d9.txt");;

			int[][] grid = parseGrid(heights);

			List<int> lowPoints = getLowPoints(grid);

			int score = 0;
			foreach(int height in lowPoints)
			{
				score = score + 1 + height;
			}

			Console.WriteLine("Score: " + score);
		}

		public void PartTwo()
		{
			Console.WriteLine("Day 9 - Part One");

			string[] heights = InputReader.ReadFileAsStrings("input-d9.txt");;

		}

		private List<int> getLowPoints(int[][] grid)
		{
			List<int> lowPoints = new List<int>();

			for(int row=0; row<grid.Length; row++)
			{
				for (int col=0; col<grid[row].Length; col++)
				{
					int height = grid[row][col];
					bool isLow = true;

					//Left
					if (col > 0){
						if (grid[row][col-1] <= grid[row][col]){

							isLow = false;
							continue;
						}
					}

					//RIgfht
					if (col < grid[row].Length-1)
					{
						if (grid[row][col+1] <= grid[row][col])
						{
							isLow = false;
							continue;
						}
					}
					
					//Top
					if (row > 0)
					{
						if (grid[row-1][col] <= grid[row][col])
						{
							isLow = false;
							continue;
						}
					}

					//Bottomw
					if (row < grid.Length -1)
					{
						if (grid[row+1][col] <= grid[row][col])
						{
							isLow = false;
							continue;
						}
					}
					
					if (isLow)
					{
						lowPoints.Add(grid[row][col]);
					}	
				}
			}
			return lowPoints;
		}

		private int[][] parseGrid(string[] input)
		{
			int[][] grid = new int[input.Length][];

			int row = 0;
			foreach(string rowInput in input)
			{
				grid[row] = new int[rowInput.Length];

				for(int col=0; col < rowInput.Length; col++)
				{
					grid[row][col] = int.Parse("" + rowInput[col]);
				}
				row++;
			}
			return grid;
		}

	}
}
