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
			Console.WriteLine("Day 9 - Part Two");

			string[] heights = InputReader.ReadFileAsStrings("input-d9.txt");;
			int[][] grid = parseGrid(heights);

			List<Tuple<int,int>> lowPoints = getLowPointLocations(grid);
			List<int> sizes = getBasinSizes(grid,lowPoints);

			sizes.Sort(Comparer<int>.Default);
			sizes.Reverse();

			int total = 1;
			for(int i=0; i < 3; i++)
			{
				total = total * sizes[i];	
			}

			Console.WriteLine("Total: " + total);
		}

		private List<Tuple<int,int>> getLowPointLocations(int[][] grid)
		{
			List<Tuple<int,int>> lowPoints = new List<Tuple<int,int>>();
			

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
						lowPoints.Add(new Tuple<int,int>(row,col));
					}	
				}
			}
			return lowPoints;
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

		private List<int> getBasinSizes(int[][] grid, List<Tuple<int,int>> lowPoints)
		{

			List<int> basinSizes = new List<int>();

			foreach(Tuple<int,int> lp in lowPoints)
			{
				basinSizes.Add(getBasinSize(grid,lp, new List<Tuple<int,int>>()));
			}
			return basinSizes;
		}

		private int getBasinSize(int[][] grid, Tuple<int,int> lowPoint, List<Tuple<int,int>> seen )
		{

			int size = 1;
			seen.Add(lowPoint);

			int lpHeight = grid[lowPoint.Item1][lowPoint.Item2];
			//top
			if (lowPoint.Item1 > 0)
			{
				Tuple<int,int> topPoint = new Tuple<int,int>(lowPoint.Item1-1,lowPoint.Item2);
				
				int topHeight = grid[topPoint.Item1][topPoint.Item2];
				if (topHeight > lpHeight  && topHeight != 9 && !seen.Contains(topPoint))
				{
					size = size + getBasinSize(grid, topPoint, seen);
				}
			}	
			///bottom
			if (lowPoint.Item1 < grid.Length -1)
			{
				Tuple<int,int> bottomPoint = new Tuple<int,int>(lowPoint.Item1+1,lowPoint.Item2);
				
				int bottomHeight = grid[bottomPoint.Item1][bottomPoint.Item2];
				if (bottomHeight > lpHeight && bottomHeight != 9 && !seen.Contains(bottomPoint))
				{
					size = size + getBasinSize(grid, bottomPoint,seen);
				}
			}	

			///left
			if (lowPoint.Item2 > 0)
			{
				Tuple<int,int> leftPoint = new Tuple<int,int>(lowPoint.Item1,lowPoint.Item2-1);
				
				int leftHeight = grid[leftPoint.Item1][leftPoint.Item2];
				if (leftHeight > lpHeight && leftHeight != 9 && !seen.Contains(leftPoint))
				{
					size = size + getBasinSize(grid, leftPoint, seen);
				}
			}	
			///right
			if (lowPoint.Item2 < grid[lowPoint.Item1].Length-1)
			{
				Tuple<int,int> rightPoint = new Tuple<int,int>(lowPoint.Item1,lowPoint.Item2+1);
				
				int rightHeight = grid[rightPoint.Item1][rightPoint.Item2];
				if (rightHeight > lpHeight && rightHeight != 9 && !seen.Contains(rightPoint))
				{
					size = size + getBasinSize(grid, rightPoint, seen);
				}
			}	
			return size;
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
