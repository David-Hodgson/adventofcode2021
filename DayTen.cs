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

		private static Dictionary<char,int> scores = new Dictionary<char,int>()
		{
			{')', 3},
			{']', 57},
			{'}', 1197},
			{'>', 25137}
		};

		public void PartOne()
		{
			Console.WriteLine("Day 10 - Part One");

			string[] chunks = InputReader.ReadFileAsStrings("input-d10.txt");

			int score = 0;
			foreach(string chunk in chunks)
			{
				Tuple<bool,char> result = verifyChunk(chunk);
				//Console.WriteLine("Line is valid: " + result.Item1);
				if (!result.Item1)
				{
					score = score + scores[result.Item2];
				}
			}

			Console.WriteLine("Score: " + score);
		}

		public void PartTwo()
		{
			Console.WriteLine("Day 10 - Part Two");

			string[] depths = InputReader.ReadFileAsStrings("input-d10.txt");
		}

		private Tuple<bool,char> verifyChunk(string chunk)
		{
			bool valid = true;
			char lastChar = 'z';

			Stack<char> parseStack = new Stack<char>();

			for(int i=0; i< chunk.Length; i++)
			{
				//Console.WriteLine(chunk[i]);

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

	}
}
