using System.Globalization;

namespace Epoch
{
	public static class Helpers
	{
		public static string ToPaddedLeftString(this object obj, int length, char paddingChar)
			=> obj.ToString()!.PadLeft(length, paddingChar);
	}

	public static class Program
	{
		public static void Main(params string[] args)
		{
			var datetime = (args is not { Length: 0 } ? DateTime.Parse(args[0]) : DateTime.Now);
			
			var epoch = new DateTime(2023, 12, 26, 19, 0, 0);
			
			var delta = datetime.Subtract(epoch);
			
			var totalYears = Math.Floor(delta.TotalDays / 365);
			var totalDays = Math.Floor(delta.TotalDays - (totalYears*365));
			var totalSeconds = Math.Floor(delta.TotalSeconds);
			
			
			Console.WriteLine($"[{datetime.ToString(CultureInfo.InvariantCulture)}]");
			Console.WriteLine();
			Console.WriteLine($"{totalYears.ToPaddedLeftString(2, '0')} years");
			Console.WriteLine($"{totalDays.ToPaddedLeftString(2, '0')} days");
			Console.WriteLine($"{delta.Hours.ToPaddedLeftString(2, '0')} hours");
			Console.WriteLine($"{delta.Minutes.ToPaddedLeftString(2, '0')} minutes");
			Console.WriteLine();
			Console.WriteLine($"[{totalYears.ToPaddedLeftString(2,'0')}:{totalDays.ToPaddedLeftString(2, '0')}:{delta.Hours.ToPaddedLeftString(2, '0')}:{delta.Minutes.ToPaddedLeftString(2, '0')}] UTCT");
			Console.ReadLine();
		}
	}
}