namespace aoc2021
{
	public class DayThirteen{

		public void PartOne()
		{
			Console.WriteLine("Day 13 - Part One");

			string[] input = InputReader.ReadFileAsStrings("input-d13.txt");

			HashSet<Tuple<int,int>> grid = new HashSet<Tuple<int,int>>();

			int pos = 0;
			
			foreach(string coord in input)
			{
				pos++;
				if (coord == "")
				{
					break;
				}

				string[] coordPart = coord.Split(',');
				int x = int.Parse(coordPart[0]);
				int y = int.Parse(coordPart[1]);
				grid.Add(new Tuple<int,int>(x,y));
			}


			string instruct1 = input[pos];
			string[] instParts = instruct1.Split('=');

			char dir = instParts[0][instParts[0].Length-1];
			int axis = int.Parse(instParts[1]);

			if (dir == 'x')
			{
				verticalFold(grid,axis);
			}
			else
			{
				horizontalFold(grid,axis);
			}
			
			Console.WriteLine("Coord Count: " + grid.Count);
		}

		public void PartTwo()
		{
			Console.WriteLine("Day 13 - Part Two");

			string[] input = InputReader.ReadFileAsStrings("input-d13.txt");

			HashSet<Tuple<int,int>> grid = new HashSet<Tuple<int,int>>();

			int pos = 0;
			
			foreach(string coord in input)
			{
				pos++;
				if (coord == "")
				{
					break;
				}

				string[] coordPart = coord.Split(',');
				int x = int.Parse(coordPart[0]);
				int y = int.Parse(coordPart[1]);
				grid.Add(new Tuple<int,int>(x,y));
			}


			for(int i=pos; i<input.Length; i++)
			{
				string instruct1 = input[i];
				string[] instParts = instruct1.Split('=');

				char dir = instParts[0][instParts[0].Length-1];
				int axis = int.Parse(instParts[1]);

				if (dir == 'x')
				{
					verticalFold(grid,axis);
				}
				else
				{
					horizontalFold(grid,axis);
				}
			}
			
			drawGrid(grid);
		}

		private void verticalFold(HashSet<Tuple<int,int>> grid, int axis)
		{

			List<Tuple<int,int>> foldedPoints = new List<Tuple<int,int>>();
			List<Tuple<int,int>> newPoints = new List<Tuple<int,int>>();

			foreach(Tuple<int,int> point in grid)
			{
				if (point.Item1 > axis)
				{
					foldedPoints.Add(point);

					int newX = axis - (point.Item1 - axis);
					Tuple<int,int> newPoint = new Tuple<int,int>(newX, point.Item2);
					newPoints.Add(newPoint);
				}
			}

			foreach(Tuple<int,int> p in foldedPoints)
			{
				grid.Remove(p);
			}

			foreach(Tuple<int,int> p in newPoints)
			{
				grid.Add(p);
			}
		}

		private void horizontalFold(HashSet<Tuple<int,int>> grid, int axis)
		{

			List<Tuple<int,int>> foldedPoints = new List<Tuple<int,int>>();
			List<Tuple<int,int>> newPoints = new List<Tuple<int,int>>();

			foreach(Tuple<int,int> point in grid)
			{
				if (point.Item2 > axis)
				{
					foldedPoints.Add(point);

					int newY = axis - (point.Item2 - axis);
					Tuple<int,int> newPoint = new Tuple<int,int>(point.Item1, newY);
					newPoints.Add(newPoint);
				}
			}

			foreach(Tuple<int,int> p in foldedPoints)
			{
				grid.Remove(p);
			}

			foreach(Tuple<int,int> p in newPoints)
			{
				grid.Add(p);
			}
		}

		private void drawGrid(HashSet<Tuple<int,int>> grid)
		{
			Console.WriteLine();
			int maxX = 0;
			int maxY = 0;

			foreach(Tuple<int,int> p in grid)
			{
				if (p.Item1 > maxX)
				{
					maxX = p.Item1;
				}
				if (p.Item2 > maxY)
				{
					maxY = p.Item2;
				}
			}

			int[][] displayGrid = new int[maxY+1][];
			for(int i=0; i<maxY+1;i++)
			{
				displayGrid[i] = new int[maxX+1];
			}

			foreach(Tuple<int,int> p in grid)
			{

				displayGrid[p.Item2][p.Item1] = 1;
			}

			for(int i=0; i< displayGrid.Length;i++)
			{
				for (int j=0; j<displayGrid[i].Length;j++)
				{
					if (displayGrid[i][j]==0)
					{
						Console.Write(" ");
					}
					else
					{
						Console.Write("#");
					}
				}
				Console.Write("\n");
			}

			Console.WriteLine();
		}
	}

}
