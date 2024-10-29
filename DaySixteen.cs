namespace aoc2021
{
	public class DaySixteen{

		private int VersionSum = 0;

		public void Examples()
		{

			Console.WriteLine("Decoding D2FE28");
			VersionSum = 0;
			string testDecode = decodeInput("D2FE28");
			parseMessage(testDecode);

			//Console.WriteLine("Test 1: " + decodeInput("D2FE28"));
			//Console.WriteLine("Decoded Input: " +decodedInput);
			//
			//parseMessage(decodedInput);

			string opInput = "38006F45291200";
			Console.WriteLine("Op Input Decoding: " + opInput);
			parseMessage(decodeInput(opInput));

			string opPacketCount = "EE00D40C823060";
			Console.WriteLine("Op Input Decoding Packet Count: " + opPacketCount);
			parseMessage(decodeInput(opPacketCount));

			Console.WriteLine("------------------------------");
			Console.WriteLine("Op pack v4");
			Console.WriteLine("Decoding: 8A004A801A8002F478");
			VersionSum=0;
			parseMessage(decodeInput("8A004A801A8002F478"));
			Console.WriteLine("Total: " + VersionSum);

			VersionSum=0;
			Console.WriteLine("Decoding: 620080001611562C8802118E34");
			parseMessage(decodeInput("620080001611562C8802118E34"));
			Console.WriteLine("Total: " + VersionSum);

			VersionSum=0;
			parseMessage(decodeInput("A0016C880162017C3686B18A3D4780"));
			Console.WriteLine("Total: " + VersionSum);

		}

		public void PartOne()
		{
			Console.WriteLine("Day 16 - Part One");

			string input = InputReader.ReadFileAsString("input-d16.txt");
			string decodedInput = decodeInput(input);
			VersionSum = 0;
			parseMessage(decodedInput);
			Console.WriteLine("Total: " + VersionSum);

		}

		public void PartTwo()
		{
			Console.WriteLine("Day 16 - Part Two");

		}

		private int parseMessage(string decodedMessage)
		{
			Console.WriteLine("Parsing Message: " + decodedMessage);
			int version = binToInt(decodedMessage.Substring(0,3));
			int type = binToInt(decodedMessage.Substring(3,3));

			VersionSum = VersionSum+version;

			Console.WriteLine("Version: "  + version);
			Console.WriteLine("Type: " + type);

			int start = 0;
			if (type == 4)
			{
				//Parse Literal Message
				start = 6;
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
			//	Console.WriteLine("Read Count: " + start);
			}
			else
			{
				Console.WriteLine("Op Message");
				start = 6;
				//Parse Operator Message
				int lengthType = binToInt(decodedMessage.Substring(start,1));
				start++;
				if (lengthType == 0)
				{
					//Total Bit length
					int bitLength = binToInt(decodedMessage.Substring(start,15));
					Console.WriteLine("Bit Length: " + bitLength);
					start = start + 15;
					int readCount = 0;
					int totalRead = 0;

					while(totalRead < bitLength)
					{	
						readCount = parseMessage(decodedMessage.Substring(start + totalRead));
						totalRead = totalRead + readCount;
					}
					start = start + totalRead;

				}
				else
				{
					//Message Length
					int messageCount = binToInt(decodedMessage.Substring(start,11));
					start = start + 11;
					Console.WriteLine("Message Count: " + messageCount);
					int readCount = 0;
					int totalRead = 0;
					for(int i=0;i<messageCount;i++)
					{
						Console.WriteLine("Parsing sub message: " + i);
						readCount = parseMessage(decodedMessage.Substring(start+totalRead));
						totalRead = totalRead + readCount;
					}
					start = start + totalRead;
				}
			}

			return start;
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
