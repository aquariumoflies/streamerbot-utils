# StreamerBot Utils

A collection of utilities I've written for use with StreamerBot.

https://streamer.bot/

## General Notes

Some of these helpers should run at startup and need to run in a dependent order. I would recommend
to make a new Bootup action that triggers on StreamerBot startup as below:

![Example of startup action configuration](/startup.png)

## GetBotPath.cs

### Description

Will get the path that contains the StreamerBot executable. Can be useful for reading StreamerBot
data or building commands that can be seamlessly copied between locations by having files relative
to the directory. The default import will automatically run at start (you may need to right click
and select "Test Trigger" for it to take effect when first imported unless you restart).

### Example Usage

```
Get temp global "BotPath" to "botPath"
Twitch Message (Test: %botPath%)
```

### Arguments

None

### Result

Temp global `BotPath` - Contains path to the bot on your file system.

### Additional notes

Need to add a reference to System.dll to compile.

### Import String

```
U0JBRR+LCAAAAAAABACdVV2TojgUfZ+q+Q+UVfO2WoiiMm+N3SBqO620H806D+RDzJgAQ4JKT81/3wBq+zVbW0sVD7nn5txzTyD31+dPilLZ4oSTKKx8VRp/FQHC4igRs1NYK8OMhISl7CNeUWtarV45oFj4MvYrX8hl6DOcpzxnytM+pyvTJOKnYh0lOfbwM/UTkrJvqyHB/JTwoadSr6k19QQgzGFCYnEAK3n4d1kd+RfVfZgncRn5u4woR6iACSrUt1vtJtBwFcN6q9psq7ja0SCsdvT6ChsttdWp14+1i20/U5zmTYUppedxHPqA4pxTJCm+QPaQpghbScR6hIsoyWTSyqf8IuvolY2FGYkXX6wvygZJlMbnfilTQSi/yPHpzs/4JA3v8Sd+iCL2AA/G3eAwCmGaJDgU91CRkCCQR5Kb+f2i5q3JV0b/h+7uHayLBVfEGisgEkosNygkVL6AcvMXxU+CG4YNxvEDJVt8p4PSA7zCskOIb/QWcPfrcjkn0qYdXy6fCUwiHq1EbfT0ulxaiexgFyWb5XLblB9kQ23UjeWScRgllIAaovRaz/9jdDMuMCv4Lum+X3cDMoG7ESp8HWadYDyfbBz7KYBsxrxFnwI2ok5vsnWskQ4bEwpcfQPsXYDsTvCmGQLalHtjdYAWoxgwGEwb9B3ZM/FtdxsbbuhLHn8cxzs073N//iw59mvYeA7GddNx57qM6VTi7cdxFDjdh2CYRaNusAkGxHz1FpN3qSXyXJOAxjiEmUmxPfuBFpMYaM3As2nmzUcqaPR1x5a/S66RGerUtlS/a2pvi378Jut6bvPA2Rl1yYOsY37oYcYWdE3rwEsH3c0x56SpeHveGhKT+fM9nfb6W2QbP4C2C15c8xUvRqo3V9Op9BDkPDbdAqKbsDGiQNbBrt6TvVgn7QydYUE83CCKnvQ1mE+jgas/Am1Cx8x69175QUv5ImZlTs9cIzvI66be4sxrOst8d32tT3Lvt2+axQtPHi/58jMY0pGsjTjQ+mtg5T0GZHzy0OGOVdRLJ9pMnYQzDsp1VOK51jrJz3BQ6uJO10mHxIkH7i7wmMWhNo3zb+DkY9fMpBd1yJoB6vXrHz2ahvwOjJv/M04wjFhM6B9/UISpn7nCT+5dQkUG97d4gnlKxWs0kxdhfun+W+5FVuVGUjkEdA21DNRBVbWhrqpNBFtVf9VaVbEBdM3QcLutazdbd5gE61ynnE7XmMjivJ6RP9fY8Sa/GiAF9schUooNEd7nBc/jvz8Wdy5mOy92e2vDiFI/5hid4Uf4QHjMLwfeBYXczpgcJ5dBQdhxQBQz+fOn3/8A/5Y9E1sIAAA=
```

## ParseUserConfig.cs

### Description

Some of my scripts need user-configured values. Rather than storing these values in the script or
actions (which can make it difficult to share or update them), this action supports storing user
config options in the `user/config.json` directory under the main StreamerBot directory.

Config values will be imported to non-persisted globals with a value of `Config.{key}`. For example:

```
{
    "configA": "one",
    "configB": "two",
    "nested": {
        "configC": "three",
        "configD": "four"
    }
}
```

would get parsed into the following variables:

```
Config.configA = one
Config.configB = two
Config.nested.configC = three
Config.nested.configD = four
```

### Arguments

None

### Result

User config values stored in non-persisted global variables.

### Additional notes

This needs to run after GetBotPath as it resolves relative to the bot's location.

### Import String

```
U0JBRR+LCAAAAAAABACdVttu4kgQfV9p/gHxvES+QIJHmgdwwBgCEyDY4GWkcV8wvXTbHl8AM8q/b7cNBANZrRapQa7LqapT1bh+f/mjUqlucRSTwK9+rah/5gLCwiBKrLNYKcSM+ISl7ENelR6UB7l61OLE5bLf4oE/+i7DwmSYVTp7AVeYcY2bJusgErrWr9SNSMq+r14Ijs8GH/lU5QfpQTorEI5hRMLkqKwK8XsRHbml6C4URjGX/FVIKidVriZI+LtN+VGTkFxTGiu1VgfqqtaUn5QakiCGstRUFBedYuduv1KciqL8lNJLOfZdQLHATKIUlzR7SFOEu1HAeiROgijjRiuXxiWrE1evbhTjWYwjPfBXxCvF9qIgDS9Jq8wSQuOSjUt3bhZPUv9ekMj1UcBa8MjejR4GPkyjCPvJPW0SEc/jfRGM/ijFvGX6iu3/WuK9FufmUSUVXzD3qNQq7tYlVDBeIX7lZwH08HuDs/efFY8GwC3TkuNuMA5blGzxneIKevAK8+IhviklV+tfl0ubcAZ38XI5JDAK4mCVPIw6b8tlN+LF7YJo81hfLrd1PrKqpMracsliGESUgAdE6XVG/xdzmsUJZjliGfDHdUUgS7AeoJx2NB+FgEFvptIDMqzk+04aXMteNvT1Uv7GLBUZWgoVjSG9MeC/qdA/j8Mdsvuxaw+9hbJfQ3XojeW2ObUbXNagXP/0PA48U295L1nTmyiWNGaaNDO6kqu3E44vmcZ6jdjMg76Vmr125sydEKjWAfQ26aXvgsd0GPVNgx7M3kgCap86ejsEpP20OGH2pC3HpJBofwOlwVwbpq4/2gJPGggcji8v2D5cZG0CFC02O1bdsUcyMmbBYHyyiUc6aeVxxUGsm5lGf4u67TUyPO912n6edbxU1DJR9tsF68YWt3nlOUFGU+dQD8zN2Z686G22sPcHZ7o5c1HEcdaQtI95ovFiPgnMZ8kruGk8A0UmgsPBR2yeb4vk9dF9uT5ihqIfZ2y9yPHN0PyJYRFkw2CmTjKO579snC1k8hrpHrHl9hr6I2oJzA3HYU7oyMccngMPH9qaSXZn7ovcNtexZKjwurNWkHPVG2WiDsBnxuwKTqw1sPp0YU94X9alegfTTYlrXMK94L938m9pptGgKGvnM2gZVh11z9gHSK44LvJTXYPGzrQViFwcw8peqPAZ38S/1/8LnNAhlxjOGvQsauodkZMMjJ3XJwvvQz/ZuoqVWj26c6aNGZCP85F5Ye6j98eQaTtn3pfwrLEG9oycZ/D6fJrT5YwmFE85P91TnIbB70iymI/5PB57mzWehj1JzGTm2N2NMzfTY0/v8HZxOqPxVG8MgYI6jt2XnWz9hnp98d+QTpiWAbsrDfQ+4FgZVCyLn2x8nJn5NM9/t+K5vfK7Opzn8SNnvok/+tqw+R2R+R25mq2bHuRzPbu6e4O89p133ZtP797FWd3hvCxra9y3xD+PI6F5n/9fTTJkz87Ywm81/vbt5p0TRhgGLCT005cOwtTNpokb3Xvn5haxu8UTHKc0eQss/t4Xr71/sy1ZVW9SKhYfiOr4Cawea/gR4FpdBc2auwKwtlKaTYDrakMCyo3rDhNvLfLkG9m1LslCEU8Tn2vdaXG5Wppy3aeLU5Gsj/BeBLyUv3883NlDDBHsdkmBAaVuGGN0oT+pj4An+2LJK0Fwd8b49lQWJoSd9qF8D/3yx/s/z7gNfk8LAAA=
```

## QuoteSearch (Action)

### Description

Given a word in a command trigger, will output a matching quote.

### Arguments

`%line0%` - Argument from command

### Result

None; outputs directly to chat

### Additional notes

Needs GetBotPath action.

Needs to set some appropriate actions in the C# code - `MISSING_ACTION` and `QUOTE_OUTPUT_ACTION`.

`MISSING ACTION` - Name of the action to run if no matching quote was found.

`QUOTE_OUTPUT_ACTION` - Name of the action to run with the quote details. Should probably be the
same action configured for the `Show Quote` trigger.

### Import String

```
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
```
