using System;
using System.Diagnostics;

namespace Duration
{
	public class DurationLogger : IDisposable
	{
		Stopwatch stopWatch = new Stopwatch();

		public Action<string> Logger { get; set; }
		public string MetricName { get; set; }

		public DurationLogger(Action<string> logger, string metricName)
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

