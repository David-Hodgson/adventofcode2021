namespace aoc2021
{
	public class InputReader{


		public static string ReadFileAsString(string filename)
		{
			
			string inputText = System.IO.File.ReadAllText(filename);


			return inputText;
		}

		public static string[] ReadFileAsStrings(string filename)
		{
			
			string inputText = System.IO.File.ReadAllText(filename);

			string[] values = inputText.Trim().Split('\n');

			return values;
		}

		public static int[] ReadFileAsInts(string filename)
		{
			string inputText = System.IO.File.ReadAllText(filename);

			string[] values = inputText.Trim().Split('\n');

			int[] intValues = new int[values.Length];

			for(int i=0; i< intValues.Length; i++)
			{
				intValues[i] = int.Parse(values[i]);
			}

			return intValues;
		}

	}
}
