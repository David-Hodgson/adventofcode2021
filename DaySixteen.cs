namespace aoc2021
{
	public class DaySixteen{

		public void PartOne()
		{
			Console.WriteLine("Day 16 - Part One");

			string input = InputReader.ReadFileAsString("input-d16.txt");

			string decodedInput = decodeInput(input);

			string testDecode = decodeInput("D2FE28");

			parseMessage(testDecode);
			//Console.WriteLine("Test 1: " + decodeInput("D2FE28"));
			//Console.WriteLine("Decoded Input: " +decodedInput);
			//
			parseMessage(decodedInput);

			Console.WriteLine("Op pack v4");
			parseMessage(decodeInput("8A004A801A8002F478"));
		}

		public void PartTwo()
		{
			Console.WriteLine("Day 16 - Part Two");

		}

		private void parseMessage(string decodedMessage)
		{
			int version = binToInt(decodedMessage.Substring(0,3));
			int type = binToInt(decodedMessage.Substring(3,3));

			Console.WriteLine("Version: "  + version);
			Console.WriteLine("Type: " + type);

			if (type == 4)
			{
				//Parse Literal Message
				int start = 6;
				bool done = false;

				string literal = "";
				while(!done)
				{
					string group = decodedMessage.Substring(start,5);

					start = start + 5;
					literal = literal +  group.Substring(1);
					
					if (group[0] == '0')
					{
						done = true;
					}
				}	
				Console.WriteLine("Literal Message: " + binToInt(literal));
			}
			else
			{
				int start = 6;
				//Parse Operator Message
				int lengthType = binToInt(decodedMessage.Substring(start,1));
				start++;
				if (lengthType == 0)
				{
					//Total Bit length

				}
			}
		}

		private int binToInt(string bin)
		{
			int res = 0;

			int mult = 1;
			for(int i= bin.Length-1; i>=0;i--)
			{

				if (bin[i] == '1')
				{
					res = res + mult;
				}

				mult = mult * 2;
			}
			return res;
		}

		private string decodeInput(string input)
		{
			string decode = "";

			for(int i=-0; i<input.Length; i++)
			{

				switch (input[i])
				{
					case '0':
						decode = decode + "0000";
						break;
					case '1': 
						decode = decode + "0001";
						break;
					case '2':
						decode = decode + "0010";
						break;
					case '3':
						decode = decode + "0011";
						break;
					case '4':
						decode = decode + "0100";
						break;
					case '5':
						decode = decode + "0101";
						break;
					case '6':
						decode = decode + "0110";
						break;
					case '7':
						decode = decode + "0111";
						break;
					case '8':
						decode = decode + "1000";
						break;
					case '9':
						decode = decode + "1001";
						break;
					case 'A':
						decode = decode + "1010";
						break;
					case 'B':
						decode = decode + "1011";
						break;
					case 'C':
						decode = decode + "1100";
						break;
					case 'D':
						decode = decode + "1101";
						break;
					case 'E':
						decode = decode + "1110";
						break;
					case 'F':
						decode = decode + "1111";
						break;
				}
			}

			return decode;
		}
	}
}
