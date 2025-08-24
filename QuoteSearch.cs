using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

public class QuoteMeta
{
    public int Version { get; set; }
    public List<MyQuoteData> Quotes { get; set; }
}

public class MyQuoteData
{
    public string Timestamp { get; set; }
    public int Id { get; set; }
    public String UserId { get; set; }
    public String User { get; set; }
    public String Platform { get; set; }
    public String GameId { get; set; }
    public String GameName { get; set; }
    public String Quote { get; set; }
}

public class CPHInline
{
    // quoteId = 0 finds a random quote
    QuoteData FindQuote(int quoteId)
    {
        var random = new Random();
        if (CPH.GetQuoteCount() == 0)
        {
            return null;
        }
        while (true)
        {
            try
            {
                if (quoteId == 0)
                {
                    // quotes start at 1-n (instead of 0-(n-1))
                    return CPH.GetQuote(random.Next(CPH.GetQuoteCount()) + 1);
                }
                else
                {
                    return CPH.GetQuote(quoteId);
                }
            }
            catch (NullReferenceException)
            {
                if (quoteId != 0)
                {
                    return null;
                }
            }
        }
    }

    // https://docs.streamer.bot/api/csharp/core/quotes has type def of QuoteData
    void ShowQuote(QuoteData quote)
    {
        if (quote == null)
        {
            // Message when quote is missing
            CPH.SendMessage("Quote not found!");
            return;
        }
        // Message when a quote is found
        CPH.SendMessage(String.Format("Aquarium once said: \"{0}\" (at {1})", quote.Quote, quote.Timestamp.ToString("M/d/yyyy")));
    }

    void AddQuote()
    {
        string userId = null;
        string quote = null;
        string user = null;
        try
        {
            userId = args["userId"].ToString();
            user = args["user"].ToString();
            quote = args["rawInput"].ToString();
        }
        catch (KeyNotFoundException e) {}
        quote = quote.Substring(4);
        var quoteId = CPH.AddQuoteForTwitch(userId, quote);
        CPH.SendMessage(String.Format("Thank you for adding a quote, {0} (id {1})!", user, quoteId));
    }

    public bool Execute()
    {
        string QuotesPath = System.IO.Path.Combine(CPH.GetGlobalVar<string>("BotPath", false), @"data\quotes.dat");
        List<MyQuoteData> matchingQuotes = new List<MyQuoteData>();
        string term = "";
        int termAsNum;
        try
        {
            term = args["input0"].ToString().ToLower();
        }
        catch (KeyNotFoundException e) {}

        // Term is blank or was "add" which is quote add and not search
        if (term.Equals(""))
        {
            ShowQuote(FindQuote(0));
            return false;
        }
        if (term.Equals("add"))
        {
            AddQuote();
            return false;
        }

        // if term is just a number, assume it's a quote id and not a search term
        if (int.TryParse(term, out termAsNum))
        {
            ShowQuote(FindQuote(termAsNum));
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
            ShowQuote(null);
            return false;
        }

        var random = new Random();
        var pickedQuoteId = random.Next(matchingQuotes.Count);
        var pickedQuote = matchingQuotes[pickedQuoteId];
        QuoteData cleanQuote = new QuoteData();

        cleanQuote.Timestamp = DateTime.Parse(pickedQuote.Timestamp);
        cleanQuote.Id = pickedQuote.Id;
        cleanQuote.UserId = pickedQuote.UserId;
        cleanQuote.User = pickedQuote.User;
        cleanQuote.Platform = pickedQuote.Platform;
        // https://docs.streamer.bot/api/csharp/core/quotes
        // wiki says QuoteData should have GameId but it fails to compile?
        //cleanQuote.GameId = pickedQuote.GameId;
        cleanQuote.GameName = pickedQuote.GameName;
        cleanQuote.Quote = pickedQuote.Quote;
        ShowQuote(cleanQuote);
        return true;
    }
}
