using System;
using System.IO;
using Newtonsoft.Json;

public class CPHInline
{
    // GetBotPath must have run previously.
    // config is stored in {botPath}/user/config.json
    public bool Execute()
    {
        var botPath = CPH.GetGlobalVar<string>("BotPath", false);
        var configPath = Path.Combine(botPath, @"user\config.json");
        CPH.LogDebug(String.Format("[ParseUserConfig] Path: {0}", configPath));
        using (var sr = new StreamReader(configPath))
        {
            var reader = new JsonTextReader(sr);
            while (reader.Read())
            {
                if (reader.Value != null && reader.TokenType.ToString() != "PropertyName")
                {
                    var key = String.Format("Config.{0}", reader.Path);
                    CPH.LogDebug(String.Format("[ParseUserConfig]   {0} => {1}", key, reader.Value));
                    CPH.SetGlobalVar(key, reader.Value, false);
                }
            }
        }

        return true;
    }
}
