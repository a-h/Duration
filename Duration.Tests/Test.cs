using NUnit.Framework;
using System;
using System.Threading;
using System.Linq;
using Duration;

namespace Duration.Tests
{
	[TestFixture()]
	public class Test
	{
		[Test]
		public void TestTimer()
		{
			var capturedMessage = "";
			Action<string> logger = msg => capturedMessage = msg;

			using (var timer = new DurationLogger(logger, "logentry"))
			{
				Thread.Sleep(5);
			}

			Assert.IsTrue(HasExpectedLogEntry(capturedMessage, "logentry", 5, 15), $"Expected a sleep between 5 and 15ms, but got '{capturedMessage}'");
		}

		[Test]
		public void TestExpectations()
		{
			Assert.IsTrue(HasExpectedLogEntry("a=1ms", "a", 1, 1), "1ms is in the range of 1-1");
			Assert.IsFalse(HasExpectedLogEntry("a=0ms", "a", 1, 1), "0ms is not in the range of 1-1");
			Assert.IsTrue(HasExpectedLogEntry("a=10ms", "a", 5, 11), "10ms is in the range of 5-11");
			Assert.IsFalse(HasExpectedLogEntry("a=12ms", "a", 5, 11), "12ms is not in the range of 5-11");
			Assert.IsFalse(HasExpectedLogEntry("a=12ms", "b", 5, 12), "Expected to that 'b' would not match 'a' was not expected.");
		}

		private bool HasExpectedLogEntry(string entry, string expectedName, int min, int max)
		{
			var actualName = entry.Split('=').First();

			if (actualName != expectedName)
			{
				return false;
			}

			var ms = int.Parse(entry.Split('=').Last().TrimEnd("ms".ToCharArray()));

			return ms >= min && ms <= max;
		}
	}
}