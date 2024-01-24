using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

public class QuoteMeta
{
    public int Version { get; set; }
    public List<QuoteData> Quotes { get; set; }
}

public class QuoteData
{
    public string Timestamp { get; set; }
    public int Id { get; set; }
    public int UserId { get; set; }
    public String User { get; set; }
    public String GameId { get; set; }
    public String GameName { get; set; }
    public String Quote { get; set; }
}

public class CPHInline
{
    // Name of the action to call when a quote is not found. leave blank to not output.
    const string MISSING_ACTION = "";
    // Name of the action to call when a quote is found. should probably match settings -> quotes -> quote output
    const string QUOTE_OUTPUT_ACTION = "";
    public bool Execute()
    {
        string QuotesPath = System.IO.Path.Combine(CPH.GetGlobalVar<string>("BotPath", false), @"data\quotes.dat");
        List<QuoteData> matchingQuotes = new List<QuoteData>();
        string term;
        int termAsNum;
        try
        {
            term = args["input0"].ToString().ToLower();
        }
        catch (KeyNotFoundException e)
        {
            // No search term was provided so don't do anything
            return false;
        }

        // Term is blank or was "add" which is quote add and not search; don't do anything
        if (term.Equals("") || term.Equals("add"))
        {
            return false;
        }

        // if term is just a number, assume it's a quote id and not a search term
        if (int.TryParse(term, out termAsNum))
        {
            return false;
        }

        string json = File.ReadAllText(QuotesPath);
        QuoteMeta? quoteMeta = JsonConvert.DeserializeObject<QuoteMeta>(json);
        foreach (var quote in quoteMeta.Quotes)
        {
            if (quote.Quote.ToLower().Contains(term))
            {
                matchingQuotes.Add(quote);
            }
        }

        if (matchingQuotes.Count == 0)
        {
            CPH.LogDebug(String.Format("No matching quote found for {0}", term));
            if (!MISSING_ACTION.Equals(""))
            {
                CPH.RunAction(MISSING_ACTION);
            }

            return false;
        }

        var random = new Random();
        var pickedQuote = random.Next(matchingQuotes.Count);
        CPH.SetArgument("quote", matchingQuotes[pickedQuote].Quote);
        CPH.SetArgument("quoteId", matchingQuotes[pickedQuote].Id);
        CPH.SetArgument("quoteUser", matchingQuotes[pickedQuote].User);
        CPH.SetArgument("quoteGame", matchingQuotes[pickedQuote].GameName);
        var timestamp = DateTime.Parse(matchingQuotes[pickedQuote].Timestamp);
        CPH.SetArgument("quoteTime", timestamp.ToString("M/d/yyyy"));
        CPH.RunAction(QUOTE_OUTPUT_ACTION);
        return true;
    }
}
