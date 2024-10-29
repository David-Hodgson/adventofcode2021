namespace aoc2021
{
	public class DaySixteen{

		private int VersionSum = 0;

		public class Op
		{
			public ulong literal {get;set;}
			public int operand {get;set;}
			public List<Op> children {get;set;} = new List<Op>();
		}

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

			string input = InputReader.ReadFileAsString("input-d16.txt");
			//input = "CE00C43D881120";
			string decodedInput = decodeInput(input);
			VersionSum = 0;
			Op rootOp = new Op();
			rootOp.operand = -1;
			parseMessage(decodedInput, rootOp);
			Console.WriteLine("Total: " + VersionSum);
			ulong total = runOps(rootOp);
			Console.WriteLine("Op Total: " + total);
		}

		private ulong runOps(Op rootOp)
		{
			ulong total = 0;	
			switch (rootOp.operand)
			{
				case -1:
					//Root node
					Console.WriteLine("Root Node. Children Count: " + rootOp.children.Count);
					total = total + runOps(rootOp.children[0]);
					break;
				case -2:
					//literal
					total = total + rootOp.literal;
					break;
				case 0:
					//Sum
					ulong sum = 0;
					foreach(Op child in rootOp.children)
					{
						sum = sum + runOps(child);
					}
					total = total + sum;
					break;
				case 1:
					//Product
					ulong product = 1;
					foreach(Op child in rootOp.children)
					{
						product = product * runOps(child);
					}
					total = total + product;
					break;
				case 2: 
					//minium
					ulong min = Int32.MaxValue;
					foreach(Op child in rootOp.children)
					{
						ulong childValue = runOps(child);
						if (childValue < min)
							min = childValue;
					}
					total = total + min;
					break;
				case 3: 
					//Max
					ulong max = 0;
					foreach(Op child in rootOp.children)
					{
						ulong childValue = runOps(child);
						if (childValue > max)
							max = childValue;
					}
					total = total + max;
					break;
				case 5:
					//greater than
					ulong gtfirstPacketTotal = runOps(rootOp.children[0]);
					ulong gtsecondPacketTotal = runOps(rootOp.children[1]);
					if (gtfirstPacketTotal > gtsecondPacketTotal)
						total = total + 1;
					break;
				case 6:
					//less than
					ulong firstPacketTotal = runOps(rootOp.children[0]);
					ulong secondPacketTotal = runOps(rootOp.children[1]);
					if (firstPacketTotal < secondPacketTotal)
						total = total + 1;
					break;
				case 7:
					ulong eqFirst = runOps(rootOp.children[0]);
					ulong eqSecond = runOps(rootOp.children[1]);
					if (eqFirst == eqSecond)
						total = total + 1;
					break;
				default:
					Console.WriteLine("Unknown operand: " + rootOp.operand);
					break;
			}

			return total;
		}

		private int parseMessage(string decodedMessage)
		{
			//Console.WriteLine("Parsing Message: " + decodedMessage);
			int version = binToInt(decodedMessage.Substring(0,3));
			int type = binToInt(decodedMessage.Substring(3,3));

			VersionSum = VersionSum+version;

			//Console.WriteLine("Version: "  + version);
			//Console.WriteLine("Type: " + type);

			int start = 6;
			if (type == 4)
			{
				//Parse Literal Message
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
			}
			else
			{
				//Console.WriteLine("Op Message");
				start = 6;
				//Parse Operator Message
				int lengthType = binToInt(decodedMessage.Substring(start,1));
				start++;
				if (lengthType == 0)
				{
					//Total Bit length
					int bitLength = binToInt(decodedMessage.Substring(start,15));
					//Console.WriteLine("Bit Length: " + bitLength);
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
					//Console.WriteLine("Message Count: " + messageCount);
					int readCount = 0;
					int totalRead = 0;
					for(int i=0;i<messageCount;i++)
					{
						//Console.WriteLine("Parsing sub message: " + i);
						readCount = parseMessage(decodedMessage.Substring(start+totalRead));
						totalRead = totalRead + readCount;
					}
					start = start + totalRead;
				}
			}

			return start;
		}

		private int parseMessage(string decodedMessage, Op parentOp)
		{
			int version = binToInt(decodedMessage.Substring(0,3));
			int type = binToInt(decodedMessage.Substring(3,3));

			VersionSum = VersionSum+version;

			int start = 6;

			switch(type)
			{
				case 4:
					{
						
						//Parse Literal Message
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

						Op literalOp = new Op();
						literalOp.literal = binToLong(literal);	
						literalOp.operand = -2;
						parentOp.children.Add(literalOp);

						break;
					}
				default:
					Op operatorOp = new Op();
					operatorOp.operand = type;

					parentOp.children.Add(operatorOp);	
					//Parse Operator Message
					int lengthType = binToInt(decodedMessage.Substring(start,1));
					start++;
					if (lengthType == 0)
					{
						//Total Bit length
						int bitLength = binToInt(decodedMessage.Substring(start,15));
						start = start + 15;
						int readCount = 0;
						int totalRead = 0;

						while(totalRead < bitLength)
						{	
							readCount = parseMessage(decodedMessage.Substring(start + totalRead),operatorOp);
							totalRead = totalRead + readCount;
						}
						start = start + totalRead;

					}
					else
					{
						//Message Length
						int messageCount = binToInt(decodedMessage.Substring(start,11));
						start = start + 11;
						int readCount = 0;
						int totalRead = 0;
						for(int i=0;i<messageCount;i++)
						{
							readCount = parseMessage(decodedMessage.Substring(start+totalRead),operatorOp);
							totalRead = totalRead + readCount;
						}
						start = start + totalRead;
					}

					break;
			}

			return start;
		}

		private ulong binToLong(string bin)
		{
			ulong res = 0;

			ulong mult = 1;
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
