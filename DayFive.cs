namespace aoc2021
{

	public struct Point
	{
		public Point(int x, int y)
		{
			X = x;
			Y = y;
		}

		public int X {get;}
		public int Y {get;}
	}

	public struct Line
	{
		public Line(Point start, Point end)
		{
			Start = start;
			End = end;
		}

		public Point Start {get;}
		public Point End {get;}
	}
	
	public class DayFive{

		public void PartOne()
		{
			Console.WriteLine("Day 5 - Part One");

			string[] input = InputReader.ReadFileAsStrings("input-d5.txt");;

 			List<Line> lines = new List<Line>();

			foreach(string lineinput in input)
			{
				lines.Add(parseLine(lineinput));
			}

			List<Line> filteredLines = new List<Line>();

			foreach(Line l in lines)
			{
				if (l.Start.X == l.End.X || l.Start.Y == l.End.Y)
				{
					filteredLines.Add(l);
				}
			}

			int gridSize = 1000;
			int[][] grid = new int[gridSize][];

			for(int i=0;i<grid.Length;i++)
			{
				grid[i] = new int[gridSize];
			}

			plotLines(grid,filteredLines);

			int intersecCount = 0;
			for (int i=0;i<grid.Length;i++)
			{
				for (int j=0;j<grid[i].Length;j++)
				{
					if (grid[i][j] >1){
						intersecCount++;
					}
				}
			}

			Console.WriteLine("Total: " + intersecCount);
		}

		public void PartTwo()
		{
			Console.WriteLine("Day 5 - Part Two");

			string[] input = InputReader.ReadFileAsStrings("input-d5.txt");

		}

		private Line parseLine(string lineInput)
		{

			string[] lineParts = lineInput.Split("->");

			string[] startParts = lineParts[0].Trim().Split(',');

			int startX = int.Parse(startParts[0]);
			int startY = int.Parse(startParts[1]);

			string[] endParts = lineParts[1].Trim().Split(',');

			int endX = int.Parse(endParts[0]);
			int endY = int.Parse(endParts[1]);

			return new Line(new Point(startX,startY),new Point(endX, endY));
		}

		private void plotLines(int [][] grid, List<Line> lines)
		{
		
			foreach(Line l in lines)
			{

				if (l.Start.X == l.End.X)
				{
					int start;
					int end;

					if (l.Start.Y > l.End.Y)
					{
						start = l.End.Y;
						end = l.Start.Y;
					}
					else
					{
						start = l.Start.Y;
						end = l.End.Y;
					}

					for(int i=start; i<=end;i++)
					{
						grid[l.Start.X][i]++;
					}
				} 
				else if (l.Start.Y == l.End.Y)
				{
					int start;
					int end;

					if (l.Start.X > l.End.X)
					{
						start = l.End.X;
						end = l.Start.X;
					}
					else 
					{
						start = l.Start.X;
						end = l.End.X;
					}

					for (int i=start; i <=end;i++)
					{
						grid[i][l.Start.Y]++;
					}
				}
				else
				{
				}
			}
		}

	}
}
