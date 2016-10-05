using System;
using System.Diagnostics;

namespace DurationTimer
{
	public class TimeLogger : IDisposable
	{
		Stopwatch stopWatch = new Stopwatch();

		public Action<string> Logger { get; set; }
		public string MetricName { get; set; }

		public TimeLogger(Action<string> logger, string metricName)
		{
			this.Logger = logger;
			this.MetricName = metricName;

			stopWatch.Start();
		}

		public void Dispose()
		{
			stopWatch.Stop();
			this.Logger($"{this.MetricName}={stopWatch.ElapsedMilliseconds}ms");
		}
	}
}

