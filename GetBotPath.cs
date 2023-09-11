// Add a reference to System.dll to compile
using System;
using System.IO;

public class CPHInline
{
    /*
	 * Sets the bot's execution directory into BotPath temp global.
	 */
    public bool Execute()
    {
        var fileProtocol = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
        var path = new System.Uri(fileProtocol).LocalPath;
        CPH.SetGlobalVar("BotPath", Path.GetFullPath(Path.Combine(path, "..")), false);
        return true;
    }
}
