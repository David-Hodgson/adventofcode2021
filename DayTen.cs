namespace aoc2021
{
	public class DayTen{

		private static string starts = "([{<";
		private static string ends = ")]}>";

		private static Dictionary<char,char> matches = new Dictionary<char,char>()
		{
			{'(',')'},
			{'[',']'},
			{'{','}'},
			{'<','>'}
		};

		private static Dictionary<char,int> corruptScores = new Dictionary<char,int>()
		{
			{')', 3},
			{']', 57},
			{'}', 1197},
			{'>', 25137}
		};

		private static Dictionary<char,int> completeScores = new Dictionary<char,int>()
		{
			{')', 1},
			{']', 2},
			{'}', 3},
			{'>', 4}
		};

		public void PartOne()
		{
			Console.WriteLine("Day 10 - Part One");

			string[] chunks = InputReader.ReadFileAsStrings("input-d10.txt");

			int score = 0;
			foreach(string chunk in chunks)
			{
				Tuple<bool,char> result = verifyChunk(chunk);
				if (!result.Item1)
				{
					score = score + corruptScores[result.Item2];
				}
			}

			Console.WriteLine("Score: " + score);
		}

		public void PartTwo()
		{
			Console.WriteLine("Day 10 - Part Two");


			string[] chunks = InputReader.ReadFileAsStrings("input-d10.txt");

			List<long> scores = new List<long>();
			
			foreach(string chunk in chunks)
			{
				Tuple<bool,char> result = verifyChunk(chunk);
				if (result.Item1)
				{
					string extra = completeChunk(chunk);
					long chunkScore = calculateCompleteScore(extra);
					scores.Add(chunkScore);
				}
			}

			scores.Sort();
			int midPoint = scores.Count /2 ;
			Console.WriteLine("Score: " + scores[midPoint]);
		}

		private Tuple<bool,char> verifyChunk(string chunk)
		{
			bool valid = true;
			char lastChar = 'z';

			Stack<char> parseStack = new Stack<char>();

			for(int i=0; i< chunk.Length; i++)
			{

				if (starts.Contains(chunk[i]))
				{
					parseStack.Push(chunk[i]);
				}
				else if (ends.Contains(chunk[i]))
				{
					char starter = parseStack.Pop();
					if (matches[starter] != chunk[i])
					{
						valid = false;
						lastChar = chunk[i];
						break;
					}
				}
				else
				{
					Console.WriteLine("Unknown Char");
				}
			}
			return new Tuple<bool,char>(valid,lastChar);
		}

		private string completeChunk(string chunk)
		{
			string extra = "";
			Stack<char> parseStack = new Stack<char>();
			
			for (int i=0; i < chunk.Length; i++)
			{
				if (starts.Contains(chunk[i]))
				{
					parseStack.Push(chunk[i]);
				}
				else if (ends.Contains(chunk[i]))
				{
					parseStack.Pop();
				}
			}

			int stackSize = parseStack.Count;
			for (int j=0; j < stackSize; j++)
			{
				char starter = parseStack.Pop();
				extra = extra + matches[starter];
			}

			return extra;
		}

		private long calculateCompleteScore(string completionString)
		{
			long score = 0;

			for (int i=0; i < completionString.Length; i++)
			{
				score = score * 5;
				score = score + completeScores[completionString[i]];
			}

			return score;
		}

	}
}
