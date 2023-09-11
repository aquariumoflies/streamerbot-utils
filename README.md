# StreamerBot Utils

A collection of utilities I've written for use with StreamerBot.

https://streamer.bot/

## GetBotPath.cs

### Description

Will get the path that contains the StreamerBot executable. Can be useful for reading StreamerBot
data or building commands that can be seamlessly copied between locations by having files relative
to the directory.

### Example Usage

```
Execute Method (GetBothPath, Execute)
Twitch Message (Test: %botPath%)
```

### Arguments

None

### Result

`botPath` - Contains path to the bot on your file system.

### Additional notes

Need to add a reference to System.dll to compile.

### Import String

```
U0JBRR+LCAAAAAAABACdVV2TojgUfZ+q+Q+UVfO2Wgjix1TNQ2O3+NVMKyo26zxAEjFjQhgIKj3V/30DqC3qbG2tVT5wzs25555A8vvzJ0mq7FAUYxZUvkrqXzmAacgivjjDSgFTHGCa0A+8IteUWr1yZBF3BfY7exCPgUtRVvKcSk+HTK4oE4yb8A2LMu7hV+JGOKHf12OM4nPBh59KvSbX5DMBUQwiHPIjWcng96I7dEvdXZAVxQL5u0CkE5XTGObuW81Ww1NQFYF6s9poyajaVgCotrX6GnWacrNdr59658t+JSjJhgoSQi5xFLgeQZkmjxJUYg6AJBD1Ikb7OOYsSkXR2iVxqeqUlYG4zviLyzeltn7EkvAyL2nOMYlLNS7Zu2k8TYJ7+pEbQEYfwDG4Gx6wACRRhAJ+j+UR9n2xJVmYP0o9b0O+Cvo/THdvYy3EY4lvkOQxLoVigYQD6YtXLP4iuZF/o7BFKHwgeIfuTFBkgNZITAjQjd+c7n5drWwsYtrHq9UzBhGL2ZrXzKfZatWLxAR7Fm1Xq11DvJCqrNY7qxWNAYsI9mqQkGs//0/RSmOOaK5XlvtxPY2XctRlMM91nLb9iT3dDownH9AFdZZD4lGTDPrT3aBnakCdEs/Stp6x96HR9l+VDgcGiZ2JPIJLM/Qo8OcqeYPGgn/f32LjLXnJ8MdJuIf2MHbtZ6Fx2AD12Z/U9YFlawLTiOBbjxPmD7oP/jhlZtff+iOsz5zl9E14YY6lY0+dBCDVCTIWP+FyGnpKw3cMkjq2KXvqUBsY4nPJPNKOPDd6stvVldflMHwVfR2rcdRsm138IProH35oZ+d19d5Rl4y621PN2VP+7zsbgHXq2gcy7w930Oj89JS9/2LpM7Q0ZceWk7nI0Mt0DLLzsKYD1SSe6IMsrS9m6Z29U3jB+eF4Cwl80jaePWcjS3v0lCmZ0N6bM4uPXoo/pL100Nc30PCzvomzvMiaLFLX2lz7E9qH3avSi/NMHst62R6MiSl691JHXXDH1uRRdyiynk5el1M2wHu/yDL3b0D7UOh0Nzk/3po7MYOYZ85Aju/9AW4kA7wNR1fexfslw+UwEfuZQnt+znYt3qX15Nu3m+8yjBBgNMTkjx8mRMRNLe5G9w6fvCJ2d2iK4oTwGVuIAzA7bP+ttlRVubFUHP6aApsd2IZVWZXX1QYEzaq7bq6rqONpSkdBrZam3CzdI+xvMp/iVrrmeBpm/TrZ75o7neBXF0fO/fHyKMwGEB2yhpf4+8fDnQPZyJrdntaAEeKGMYIX/Ik+Cp7qi4uuJCGWUyqukTLIMT1dDPld/PnT+z+gmP6EUwgAAA==
```
