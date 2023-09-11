// Add a reference to System.dll to compile
using System;
using System.IO;

public class CPHInline
{
    /*
	 * Sets the bot's execution directory into botPath variable.
	 */
    public bool Execute()
    {
        var fileProtocol = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
        var path = new System.Uri(fileProtocol).LocalPath;
        CPH.SetArgument("botPath", Path.GetFullPath(Path.Combine(path, "..")));
        return true;
    }
}
