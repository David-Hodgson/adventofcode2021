namespace aoc2021
{
	public class DayTwelve{

		public void PartOne()
		{
			Console.WriteLine("Day 12 - Part One");

			string[] nodeInputList = InputReader.ReadFileAsStrings("input-d12.txt");

			Dictionary<string,List<string>> graph = parseGraph(nodeInputList);

			Func<string,string,bool> visitMethod = canVisit;
			List<string> paths = getPaths(graph, "start", "", canVisit);

			Console.WriteLine("Path Count: " + paths.Count);
		}

		public void PartTwo()
		{
			Console.WriteLine("Day 12 - Part Two");

			string[] nodeInputList = InputReader.ReadFileAsStrings("input-d12.txt");

			Dictionary<string,List<string>> graph = parseGraph(nodeInputList);

			HashSet<string> paths = new HashSet<string>();
			getPaths2(graph, "start", "", paths);

			Console.WriteLine("Paths: " + paths.Count);
		}

		private void getPaths2(Dictionary<string,List<string>> graph, string start, string currentPath, HashSet<string> allPaths)
		{
			if (start == "end")
			{
				allPaths.Add(currentPath + "." + start);
				return;
			}	

			if (graph.ContainsKey(start))
			{
				foreach(string nextNode in graph[start])
				{
					if (canVisitPartTwo(currentPath + "." + start, nextNode))
					{
						getPaths2(graph,nextNode, currentPath + "." + start,allPaths);
					}
				}
			}
			else
			{

			}
		}


		private List<string> getPaths(Dictionary<string,List<string>> graph, string start, string currentPath, Func<string,string,bool> canVisit)
		{
			List<string> paths = new List<string>();

			if (currentPath.Contains(".end"))
			{
				return paths;
			}
			string delim  = "";
			if (currentPath != "")
			{
				delim = ".";
			}

			string newPath = currentPath + delim + start;

			if (graph.ContainsKey(start))
			{
				foreach(string nextNode in graph[start])
				{
					if (!canVisit(currentPath,nextNode))
					{
						addPath(paths,newPath);
						continue;
					}

					List<string> nextPaths = getPaths(graph, nextNode, newPath, canVisit);

					foreach(string nextPath in nextPaths)
					{
						addPath(paths,nextPath);
					}

					if (nextPaths.Count == 0)
					{
						addPath(paths,newPath);
					}
				}
			}
			else
			{
				addPath(paths,newPath);
			}

			return paths;
		}

		private bool canVisit(string path, string node)
		{
			bool smallCave = node.Equals(node.ToLower());

			if (smallCave && path.Contains(node))
			{
				return false;
			}

			return true;
		}

		private bool canVisitPartTwo(string path, string node)
		{
			bool smallCave = node.Equals(node.ToLower());

			if (smallCave)
			{
				if (path.Contains(node))
				{
					if (hasTwoCaves(path))
					{
						return false;
					}

					if (node == "start" || node == "end")
					{
						return false;
					}
				}
							
			}
			return true;
		}

		private bool hasTwoCaves(string path)
		{
			Dictionary<string,int> caveCount = new Dictionary<string,int>();
			string[] caves = path.Split(".");
			foreach(string cave in caves)
			{
				if (cave.ToUpper() == cave)
				{
					continue;
				}
				if (!caveCount.ContainsKey(cave))
				{
					caveCount[cave] = 0;
				}
				caveCount[cave] = caveCount[cave] + 1;
			}
			bool doubleCave = false;

			foreach(KeyValuePair<string,int> kvp in caveCount)
			{
				if (kvp.Value >1)
				{
					doubleCave = true;
					break;
				}
			}
			return doubleCave;
		}
		private void addPath(List<string> paths, string newPath)
		{

			if (paths.Contains(newPath))
			{
				return;
			}

			if (newPath.EndsWith(".end"))
			{
				paths.Add(newPath);
			}
		}

		private Dictionary<string,List<string>> parseGraph(string[] nodeInputList)
		{

			Dictionary<string,List<string>> graph = new Dictionary<string,List<string>>();

			foreach(string node in nodeInputList)
			{
				string[] nodeParts = node.Split("-");

				string start = nodeParts[0];
				string end = nodeParts[1];

				if (!graph.ContainsKey(start))
				{
					graph[start] = new List<string>();
				}

				graph[start].Add(end);

				if (!graph.ContainsKey(end))
				{
					graph[end] = new List<string>();
				}
				graph[end].Add(start);
			}

			return graph;
		}
	}
}
