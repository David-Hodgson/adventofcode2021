namespace aoc2021
{
	public class DayEleven{

		public void PartOne()
		{
			Console.WriteLine("Day 11 - Part One");

			string[] input = InputReader.ReadFileAsStrings("input-d11.txt");

			int[][] grid = parseGrid(input);


			int steps = 100;

			int flashCount = 0;

			for (int flash=0; flash < steps; flash++)
			{
				//Update Energy
				updateEnergy(grid);
				//Process Flashes
				processEnergy(grid);
				//Count Flasshes
				flashCount = flashCount + countFlashes(grid);
				//Reset
				resetEnergy(grid);
			}

			Console.WriteLine("Total Flashes: " + flashCount);
		}

		public void PartTwo()
		{
			Console.WriteLine("Day 11 - Part Two");

			string[] input = InputReader.ReadFileAsStrings("input-d11.txt");

			int[][] grid = parseGrid(input);

			int currentStep = 0;
			int flashCount = 0;

			while(flashCount != 100)
			{
				currentStep++;
				//Update Energy
				updateEnergy(grid);
				//Process Flashes
				processEnergy(grid);
				//Count Flasshes
				flashCount = countFlashes(grid);
				//Reset
				resetEnergy(grid);
			}

			Console.WriteLine("All Flash at step: " + currentStep);


		}

		private void updateEnergy(int[][] grid)
		{
			for (int i=0; i < grid.Length; i++)
			{
				for (int j=0; j < grid[i].Length; j++)
				{
					grid[i][j] = grid[i][j] + 1;
				}
			}
		}

		private void processEnergy(int [][] grid)
		{
			bool done = false;

			while (!done)
			{
				done = true;

				for(int i=0; i<grid.Length; i++)
				{
					for( int j=0; j < grid[i].Length;j++)
					{
						if (grid[i][j] > 9) {
							done = false;
							grid[i][j]= -1;
							updateNeighbours(grid,i,j);
						}
					}
				}
			}
		}

		private void updateNeighbours(int[][] grid, int row, int col)
		{
			//above
			if (row > 0)
			{
				if (col > 0)
				{
					incrementOctopus(grid, row-1, col-1);
				}

				incrementOctopus(grid,row-1,col);

				if (col < grid[row].Length -1)
				{
					incrementOctopus(grid,row-1,col+1);
				}
			}

			//left
			if (col>0)
			{
				incrementOctopus(grid,row, col-1);
			}
			
			//right
			if (col < grid[row].Length -1)
			{
				incrementOctopus(grid,row,col+1);
			}

			//below
			if (row < grid.Length -1)
			{

				if (col > 0)
				{
					incrementOctopus(grid, row+1, col-1);
				}

				incrementOctopus(grid,row+1,col);

				if (col < grid[row].Length -1)
				{
					incrementOctopus(grid,row+1,col+1);
				}
			}
		}

		private void incrementOctopus(int[][] grid, int row, int col)
		{
			if (grid[row][col] != -1)
			{
				grid[row][col] = grid[row][col] + 1;
			}
		}

		private int countFlashes(int[][] grid)
		{
			int count = 0;

			for(int i=0; i<grid.Length;i++)
			{
				for(int j=0;j<grid[i].Length;j++)
				{
					if (grid[i][j] == -1)
					{
						count++;
					}
				}
			}

			return count;
		}

		private void resetEnergy(int[][] grid)
		{
			for (int i=0; i< grid.Length; i++)
			{
				for (int j=0; j < grid[i].Length; j++)
				{
					if (grid[i][j] == -1)
					{
						grid[i][j] = 0;
					}
				}
			}
		}

		private int[][] parseGrid(string[] input)
		{
			int[][] grid = new int[input.Length][];

			for (int i=0; i< grid.Length; i++)
			{
				grid[i] = new int[input[i].Length];

				for (int j=0; j < input[i].Length; j++)
				{
					grid[i][j] = int.Parse("" + input[i][j]);
				}
			}
			return grid;
		}

		private void printGrid(int[][] grid)
		{
			Console.WriteLine();

			for(int i=0; i < grid.Length; i++)
			{
				for (int j=0; j < grid[i].Length; j++)
				{
					Console.Write(grid[i][j]);
				}

				Console.Write("\n");
			}
		}

	}
}
