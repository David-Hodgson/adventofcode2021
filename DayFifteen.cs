namespace aoc2021
{
	public class DayFifteen{

		public void Test()
		{
			Console.WriteLine("Day 15 - Example");

			string[] input = InputReader.ReadFileAsStrings("input-d15.txt.test");

			int[][] maze = parseMaze(input);

			generateDistanceMap(maze, 0,0,0);
			string maxKey = "" + (maze.Length-1) + "," + (maze[maze.Length-1].Length-1);
			Console.WriteLine("Min Length: " + distanceMap[maxKey]);
		}


		public void PartOne()
		{
			Console.WriteLine("Day 15 - Part One");

			distanceMap.Clear();

			string[] input = InputReader.ReadFileAsStrings("input-d15.txt");

			int[][] maze = parseMaze(input);

			generateDistanceMap(maze, 0,0,0);

			string maxKey = "" + (maze.Length-1) + "," + (maze[maze.Length-1].Length-1);
			Console.WriteLine("Min Length: " + distanceMap[maxKey]);
		}

		public void PartTwo()
		{
			Console.WriteLine("Day 15 - Part Two");

			distanceMap.Clear();
			string[] input = InputReader.ReadFileAsStrings("input-d15.txt");

			int[][] smallmaze = parseMaze(input);

			int[][] maze = extendMaze(smallmaze);

			generateDistanceMap(maze, 0,0,0);
			string maxKey = "" + (maze.Length-1) + "," + (maze[maze.Length-1].Length-1);
			Console.WriteLine("Min Length: " + distanceMap[maxKey]);


		}

		private Dictionary<string,int> distanceMap = new Dictionary<string,int>();

		private void generateDistanceMap(int[][] maze, int startX, int startY, int currentDistance){

			//Console.WriteLine("GDM " + startX + "," + startY + " Current Distance: " + currentDistance);

			int maxPath = maze.Length * 2 * 9;
			if (currentDistance > maxPath){
				return;
			}

			if (startX == maze.Length-1 &&
					startY ==maze[startX].Length-1)
			{
				return;
			
			}


			string cacheKey = "" + startX + "," + startY;
			if (distanceMap.ContainsKey(cacheKey) && currentDistance > distanceMap[cacheKey]){
				return;
			}

			if (startX < maze.Length-1)
			{
				//Move right
				int nextX = startX + 1;
				string distanceKey = ""+ nextX + "," + startY;
				int distance = currentDistance + maze[nextX][startY];

				if (!distanceMap.ContainsKey(distanceKey) || distance < distanceMap[distanceKey]){
					distanceMap[distanceKey] = distance;
					generateDistanceMap(maze, nextX, startY, distance);
				} 

			}


			if (startY < maze[startX].Length-1)
			{
				//Move Down
				int nextY = startY + 1;
				string distanceKey = "" + startX + "," + nextY;
				int distance = currentDistance + maze[startX][nextY];
				if (!distanceMap.ContainsKey(distanceKey) || distance < distanceMap[distanceKey]){
					distanceMap[distanceKey] = distance;
					generateDistanceMap(maze, startX, nextY, distance);
				}
			}


			if (startX > 0 )
			{
				//Move Left 
				int nextX = startX - 1;
				string distanceKey = ""+ nextX + "," + startY;
				int distance = currentDistance + maze[nextX][startY];
				if (!distanceMap.ContainsKey(distanceKey) || distance < distanceMap[distanceKey]){
					distanceMap[distanceKey] = distance;
					generateDistanceMap(maze, nextX, startY, distance);
				} 

			}

			if (startY > 0)
			{
				//Move Up 
				int nextY = startY - 1;
				string distanceKey = "" + startX + "," + nextY;
				int distance = currentDistance + maze[startX][nextY];
				if (!distanceMap.ContainsKey(distanceKey) || distance < distanceMap[distanceKey]){
					distanceMap[distanceKey] = distance;
					generateDistanceMap(maze, startX, nextY, distance);
				}
			}

		}

		public int[][] parseMaze(string[] input)
		{
			int[][] maze = new int[input.Length][];

			for(int i=0; i<input.Length; i++)
			{
				string row = input[i];
				maze[i] = new int[row.Length];
				for (int j=0; j<row.Length; j++)
				{
					int risk = int.Parse("" + row[j]);
					maze[i][j] = risk;
				}
			}

			return maze;
		}

		public int[][] extendMaze(int[][] sourceMaze)
		{
			int[][] maze = new int[sourceMaze.Length * 5][];

			for(int i=0;i<maze.Length;i++)
			{
				maze[i] = new int[maze.Length];
			}

			for(int i=0;i<5;i++)
			{
				for(int j=0;j<5;j++)
				{
					for(int x=0;x<sourceMaze.Length;x++){
						for(int y=0;y<sourceMaze[x].Length;y++){
							int newValue = sourceMaze[x][y] + i + j;
							newValue = newValue % 9;
							if (newValue==0)
								newValue=9;

							maze[x+(i*sourceMaze.Length)][y+(j*sourceMaze.Length)] = newValue;
						}
					}
				}
			}

			/*
			for(int i=0;i<maze.Length;i++)
			{
				for (int j=0;j<maze[i].Length;j++)
				{
					Console.Write(maze[i][j]);
				}
				Console.Write("\n");
			}
			*/
			return maze;
		}
	}
}


