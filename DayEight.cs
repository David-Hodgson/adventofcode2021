namespace aoc2021
{
	public class DayEight{

		public void PartOne()
		{
			Console.WriteLine("Day 8 - Part One");

			string[] input = InputReader.ReadFileAsStrings("input-d8.txt");;

			int outputCount = 0;
			foreach(string entry in input)
			{
				string outputValues = entry.Split(" | ")[1];

				string[] outputs = outputValues.Split(' ');

				foreach(string output in outputs)
				{
					if (output.Length == 2 || //1
						output.Length == 4 || //4
						output.Length == 3 || //7
						output.Length == 7 ) //8
					{
						outputCount++;
					}
				}
			}

			Console.WriteLine("Total: " + outputCount);
		}

		public void PartTwo()
		{
			Console.WriteLine("Day 8 - Part Two");

			string[] input = InputReader.ReadFileAsStrings("input-d8.txt");

			int count =-0;
			Dictionary<string,int> valueMap = new Dictionary<string,int>();

			foreach(string entry in input)
			{
				string inputValues = entry.Split(" | ")[0];
				string outputValues = entry.Split(" | ")[1];

				string[] outputs = outputValues.Split(' ');
				string[] inputs = inputValues.Split(' ');

				List<string> sortedOutput = new List<string>();
				List<string> allValues = new List<string>();

				foreach(string output in outputs){
					char[] oa = output.ToArray();
					Array.Sort(oa);
					allValues.Add(new string(oa));
					sortedOutput.Add(new string(oa));
				}
				foreach(string inputV in inputs){
					char[] ia = inputV.ToArray();
					Array.Sort(ia);
					allValues.Add(new string(ia));
				}

				string oneString = getOneString(allValues);
				string sevenString = getSevenString(allValues);
				string fourString = getFourString(allValues);
				string eightString = getEightString(allValues);
				string threeString = getThreeString(allValues, oneString);
				string nineString = getNineString(allValues, fourString);
				string twoString = getTwoString(allValues, nineString);
				string fiveString = getFiveString(allValues, nineString, threeString);
				string zeroString = getZeroString(allValues, twoString, fiveString);
				string sixString = getSixString(allValues, oneString);

				valueMap[zeroString] = 0;
				valueMap[oneString] = 1;
				valueMap[twoString] = 2;
				valueMap[threeString] = 3;
				valueMap[fourString] = 4;
				valueMap[fiveString] = 5;
				valueMap[sixString] = 6;
				valueMap[sevenString] = 7;
				valueMap[eightString] = 8;
				valueMap[nineString] = 9;


				int localCount = 0;
				int factor = 1000;
				foreach(string outputDisplay in sortedOutput)
				{
					int intValue = valueMap[outputDisplay];
					localCount = localCount + (intValue * factor);
					factor = factor / 10;
				}				
				count = count + localCount;
			}

			Console.WriteLine("Total: " + count);
		}

		private string getOneString(List<string> values)
		{
			foreach(string s in values){
				if (s.Length == 2)
				{
					return s;
				}
			}

			return "";
		}

		private string getSevenString(List<string> values)
		{
			foreach(string s in values)
			{
				if (s.Length == 3)
				{
					return s;
				}
			}
			return "";
		}

		private string getFourString(List<string> values)
		{
			foreach(string s in values)
			{
				if (s.Length == 4)
				{
					return s;
				}
			}

			return "";
		}

		private string getEightString(List<string> values)
		{
			foreach(string s in values)
			{
				if (s.Length == 7)
				{
					return s;
				}
			}
			return "";
		}

		private string getThreeString(List<string> values, string oneValue)
		{
			foreach(string s in values)
			{
				if (s.Length == 5)
				{
					if (filterString(s, oneValue).Length ==3)
					{
						return s;
					}
				}
			}
			return "";
		}

		private string getNineString(List<string> values, string fourValues)
		{

			foreach(string s in values)
			{
				if (s.Length == 6)
				{

					if (filterString(s, fourValues).Length==2)
					{
						return s;
					}	
				}

			}
			return "";
		}

		private string getTwoString(List<string> values, string nineValue)
		{
			foreach(string s in values)
			{
				if (s.Length == 5)
				{
					if (filterString(s,nineValue).Length==1)
					{
						return s;
					}
				}
			}
			return "";
		}

		private string getFiveString(List<string> values, string nineValue, string threeString)
		{
			foreach(string s in values)
			{
				if (s.Length == 5 && s != threeString)
				{
					if (filterString(s,nineValue).Length == 0)
					{
						return s;
					}
				}
			}
			return "";
		}

		private string getZeroString(List<string> values, string twoValue, string fiveValue)
		{
			foreach(string s in values)
			{
				if (s.Length ==6)
				{
					if (filterString(s,twoValue).Length == 2 &&
						filterString(s,fiveValue).Length == 2)
					{
						return s;
					}
				}
			}
			return "";
		}

		private string getSixString(List<string> values, string oneValue)
		{
			foreach(string s in values)
			{
				if (s.Length == 6)
				{
					if (filterString(s, oneValue).Length == 5)
					{
						return s;
					}
				}
			}
			return "";
		}

		private string filterString(string source, string filter){

			string output = source;

			foreach(char s in filter)
			{
				string filterString = "";
				filterString = filterString + s;
				output = output.Replace(filterString,"");
			}

			return output;
		}
	}
}
