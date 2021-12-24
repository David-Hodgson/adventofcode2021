namespace aoc2021
{
	public class DayTwelve{

		public void PartOne()
		{
			Console.WriteLine("Day 12 - Part One");

			string[] nodeInputList = InputReader.ReadFileAsStrings("input-d12.txt");

			Dictionary<string,List<string>> graph = parseGraph(nodeInputList);

			List<string> paths = getPaths(graph, "start", "");

			Console.WriteLine("Path Count: " + paths.Count);
		}

		public void PartTwo()
		{
			Console.WriteLine("Day 12 - Part Two");

		}

		private List<string> getPaths(Dictionary<string,List<string>> graph, string start, string currentPath)
		{
			List<string> paths = new List<string>();

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

					List<string> nextPaths = getPaths(graph, nextNode, newPath);

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
