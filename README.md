# Duration
Some .Net code to track how long things take in a `using` statement

# Usage

```c#
using (new DurationLogger((msg) => _logger.Debug(msg), "code_section.login"))
{
  // Do something that takes a long time, like make a HTTP request.
}
```

The function passed to the logger will log:

```
code_section.login=5ms
```
