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

			string[] input = InputReader.ReadFileAsStrings("input-d14.txt");
			string template = input[0];

			Console.WriteLine(template);
			Dictionary<string,string> insertionRules = parseRules(input);

			int steps = 40;
			Dictionary<char,long> letterScores = new Dictionary<char,long>();
			letterScores = processStream(template,steps, insertionRules);

			populateLetterScores(template, letterScores);
			long score = 0;

			score = getScore(letterScores);
			Console.WriteLine("Score: " + score);

		}

		private Dictionary<string, Dictionary<char,long>> cache = new Dictionary<string,Dictionary<char,long>>();

		private Dictionary<char,long> processStream(string input, int depth, Dictionary<string,string> rules)
		{
			//Console.WriteLine("Processing " + input + ", at depth " + depth);
			
			Dictionary<char,long> scores = new Dictionary<char,long>();

			string cacheKey = "" + input + depth;

			if (cache.ContainsKey(cacheKey)){

				return cache[cacheKey];
			}

			//Console.WriteLine("No cache hit");
			if (depth == 0){
				//Console.WriteLine("Reached the bottom");
			//	populateLetterScores(input,scores);
			}
			else{

				for (int i=0; i<input.Length -1; i++)
				{
					//Console.WriteLine("Pair " + input[i] + ", " + input[i+1]);


					string source = "" + input[i] + input[i+1];
					string insert = rules[source];
					populateLetterScores(insert, scores);
					string expanded = "" + input[i] + insert + input[i+1];
					Dictionary<char,long> newScores = processStream(expanded, depth-1,rules);	

					foreach(KeyValuePair<char,long> kvp in newScores)
					{
						if (!scores.ContainsKey(kvp.Key))
						{
							scores[kvp.Key] = kvp.Value;
						}
						else
						{
							scores[kvp.Key] = scores[kvp.Key] + newScores[kvp.Key];
						}
					}

				}
			}

			cache[cacheKey] = scores;
			return scores;
		}

		private Dictionary<char,long>  processPairwise(string input, int depth)
		{
			Dictionary<char,long> scores = new Dictionary<char,long>();

			if (depth ==0 )
			{
				populateLetterScores(input, scores);
			}
			else
			{
				int newDepth = depth - 1;
			}

			return scores;
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

		private void populateLetterScores(string input, Dictionary<char,long> letterScores)
		{

			for( int i=0; i<input.Length;i++)
			{
				if (!letterScores.ContainsKey(input[i]))
				{
					letterScores[input[i]] = 0;
				}

				letterScores[input[i]] = letterScores[input[i]] + 1;
			}

		}

		private long getScore(Dictionary<char,long> letterScores)
		{
			long maxCharCount = 9;
			long minCharCount = Int64.MaxValue;

			long totalCount = 0;

			foreach(KeyValuePair<char,long> kvp in letterScores)
			{
				totalCount = totalCount + kvp.Value;
				if (kvp.Value > maxCharCount)
					maxCharCount = kvp.Value;

				if (kvp.Value < minCharCount)
					minCharCount = kvp.Value;
			}

			Console.WriteLine("Total: " + totalCount);
			Console.WriteLine("Max Value: " + maxCharCount);
			Console.WriteLine("Min Value: " + minCharCount);
			return maxCharCount - minCharCount;
		}

		private int getScore(string input)
		{
			Dictionary<char,int> letterScores = new Dictionary<char,int>();
			int maxCharCount = 9;
			int minCharCount = input.Length;
			int totalCount = 0;

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
				totalCount = totalCount + kvp.Value;
				if (kvp.Value > maxCharCount)
					maxCharCount = kvp.Value;

				if (kvp.Value < minCharCount)
					minCharCount = kvp.Value;
			}

			Console.WriteLine("Total: " + totalCount);
			Console.WriteLine("Max Value: " + maxCharCount);
			Console.WriteLine("Min Value: " + minCharCount);
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
