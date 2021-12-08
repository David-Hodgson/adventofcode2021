namespace aoc2021
{
	public class DayFour{

		public void PartOne()
		{
			Console.WriteLine("Day 4 - Part One");

			string[] input = InputReader.ReadFileAsStrings("input-d4.txt");
			
			List<int> bingoNumbers = getNumbers(input[0]);

			List<int[][]> boards = new List<int[][]>();

			for(int i=1;i<input.Length;){

				i++;//Skip blankLine
				string line1 = input[i++];
				string line2 = input[i++];
				string line3 = input[i++];
				string line4 = input[i++];
				string line5 = input[i++];

				int[][] board = createGameBoard(new string[] {line1,line2,line3,line4,line5});

				boards.Add(board);
			}

			int lowestWin = bingoNumbers.Count + 1;
			int lowestScore = 0;
			int lastNumber = 0;

			foreach(int[][] board in boards)
			{
				bool hasWon = false;

				int count = 0;
				foreach(int number in bingoNumbers)
				{
					count++;
					for(int i=0; i< board.Length;i++)
					{
						for(int j=0; j<board[i].Length;j++)
						{
							if (board[i][j] == number)
							{
								board[i][j] = -1;
							}
						}
					}
					
					if (IsBoardWinner(board))
					{
						hasWon = true;
						if (count < lowestWin)
						{
							lowestWin = count;
							lastNumber = number;
							lowestScore = CalculateScore(board);
						}
						break;
					}

				}

				if (hasWon)
				{
					break;
				}
			}	

			int total = lowestScore * lastNumber;
			Console.WriteLine("Final Score: " + total);

		}

		public void PartTwo()
		{
			Console.WriteLine("Day 4 - Part Two");

			string[] input = InputReader.ReadFileAsStrings("input-d4.txt");

			List<int> bingoNumbers = getNumbers(input[0]);

			List<int[][]> boards = new List<int[][]>();

			for(int i=1;i<input.Length;){

				i++;//Skip blankLine
				string line1 = input[i++];
				string line2 = input[i++];
				string line3 = input[i++];
				string line4 = input[i++];
				string line5 = input[i++];

				int[][] board = createGameBoard(new string[] {line1,line2,line3,line4,line5});

				boards.Add(board);
			}


			int lastToWin = 0;
			int lowestScore = 0;
			int lastNumber = 0;

			foreach(int[][] board in boards)
			{
				bool hasWon = false;

				int count = 0;
				foreach(int number in bingoNumbers)
				{
					count++;
					for(int i=0; i< board.Length;i++)
					{
						for(int j=0; j<board[i].Length;j++)
						{
							if (board[i][j] == number)
							{
								board[i][j] = -1;
							}
						}
					}
					
					if (IsBoardWinner(board))
					{
						hasWon = true;
						if (count > lastToWin)
						{
							lastToWin = count;
							lastNumber = number;
							lowestScore = CalculateScore(board);
						}
						break;
					}

				}

				if (hasWon)
				{
					break;
				}
			}	

			int total = lowestScore * lastNumber;
			Console.WriteLine("Final Score: " + total);
		}

		private List<int>  getNumbers(string input)
		{

			List<int> numbers = new List<int>();

			string[] inputValues = input.Split(',');

			foreach(string iv in inputValues)
			{
				numbers.Add(int.Parse(iv));
			}

			return numbers;
		}

		private int[][] createGameBoard(string[] lines)
		{
			int[][] board = new int[lines.Length][];

			for(int i=0;i<lines.Length; i++)
			{
				lines[i] = lines[i].Trim().Replace("  ", " 0");
				string[] numbers = lines[i].Split(' ');
				board[i] = new int[numbers.Length];
				for(int j=0; j<board[i].Length; j++)
				{
					board[i][j] = int.Parse(numbers[j]);
				}
			}

			return board;
		}

		private bool IsBoardWinner(int[][] board)
		{
			bool isWinner = false;

			//TODO Implement
			//
			// Check Rows
			for( int row=0; row < board.Length; row++)
			{
				bool rowWin = true;
				for (int col=0; col < board[row].Length; col++)
				{
					if (board[row][col] != -1)
					{
						rowWin = false;
						break;
					}
				}

				if (rowWin)
				{
					isWinner = true;
					break;
				}
			}

			// Check Cols
			for (int col = 0; col < board[0].Length; col++)
			{
				bool colWin = true;
				for (int row =0; row < board.Length; row++)
				{
					if (board[row][col] != -1)
					{
						colWin = false;
						break;
					}
				}
				if (colWin)
				{
					isWinner = true;
					break;
				}
			}
			return isWinner;
		}

		private int CalculateScore(int[][] board)
		{
			int score = 0;

			for(int i=0;i<board.Length; i++)
			{
				for(int j=0; j<board[i].Length; j++)
				{
					if (board[i][j] != -1)
					{
						score = score + board[i][j];
					}
				}
			}
			return score;
		}
	}
}
