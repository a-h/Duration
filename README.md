# Duration
Some .Net code to track how long things take in a `using` statement

# Usage

```c#
using (new DurationLogger((msg) => _logger.Debug(msg), "code_section.login"))
{
  // Do something that takes a long time, like make a HTTP request.
}
```

The argument passed to logging lambda expression will be:

```
code_section.login=5ms
```

One way to use this is to pass a function that logs to a log4net logger.
