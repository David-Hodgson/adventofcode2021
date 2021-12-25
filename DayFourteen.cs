using System.Text;

namespace aoc2021
{
	public class DayFourteen{

		public void PartOne()
		{
			Console.WriteLine("Day 14 - Part One");

			string[] input = InputReader.ReadFileAsStrings("input-d14.txt");
			string template = input[0];

			Dictionary<string,string> insertionRules = parseRules(input);

			string newString = template; 
			int steps = 10;

			for (int i=0; i<steps;i++)
			{	
				newString = process(newString, insertionRules);
			}

			int score = getScore(newString);
			Console.WriteLine("Score: " + score);
		}

		public void PartTwo()
		{
			Console.WriteLine("Day 14 - Part Two");
		}

		private string process(string input, Dictionary<string,string> insertionRules)
		{
			StringBuilder sb = new StringBuilder();

			sb.Append(input[0]);
			for( int i=0; i<input.Length-1;i++)
			{
				string source = "" + input[i] + input[i+1];
				string insert = insertionRules[source];
				sb.Append(insert);
				sb.Append(input[i+1]);
			}
			return sb.ToString();
		}

		private int getScore(string input)
		{
			Dictionary<char,int> letterScores = new Dictionary<char,int>();
			int maxCharCount = 9;
			int minCharCount = input.Length;

			for( int i=0; i<input.Length;i++)
			{
				if (!letterScores.ContainsKey(input[i]))
				{
					letterScores[input[i]] = 0;
				}

				letterScores[input[i]] = letterScores[input[i]] + 1;
			}

			foreach(KeyValuePair<char,int> kvp in letterScores)
			{
				if (kvp.Value > maxCharCount)
					maxCharCount = kvp.Value;

				if (kvp.Value < minCharCount)
					minCharCount = kvp.Value;
			}

			return maxCharCount - minCharCount;
		}
			
		private Dictionary<string,string> parseRules(string[] input)
		{
			Dictionary<string,string> insertionRules = new Dictionary<string,string>();

			for(int i=2; i< input.Length; i++)
			{
				string[] ruleParts = input[i].Split(" -> ");

				insertionRules[ruleParts[0]] = ruleParts[1];
			}

			return insertionRules;
		}
	}
}
