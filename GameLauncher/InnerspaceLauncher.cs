using System;
using System.Diagnostics;
using System.Windows;

namespace ISBoxerEVELauncher.GameLauncher
{
  public class InnerspaceLauncher
  {
    public static bool Launch(string ssoToken, string gameName, string gameProfileName, bool sisi,
      DirectXVersion dxVersion)
    {
      var cmdLine = CommandLineArgumentForInnerspace(ssoToken, gameName, gameProfileName, dxVersion);
      try
      {
        Process.Start(App.ISExecutable, cmdLine);
      }
      catch (Exception e)
      {
        MessageBox.Show("Launch failed. executable=" + App.ISExecutable + "; args=" + cmdLine + Environment.NewLine + e);
        return false;
      }
      return true;
    }

    public static string CommandLineArgumentForInnerspace(string ssoToken, string gameName, string gameProfileName,
      DirectXVersion dxVersion)
    {
      if (ssoToken == null)
        throw new ArgumentNullException("ssoToken");
      if (gameName == null)
        throw new ArgumentNullException("gameName");
      if (gameProfileName == null)
        throw new ArgumentNullException("gameProfileName");

      var cmdLine = "open \"" + gameName + "\" \"" + gameProfileName + "\" -addparam \"/ssoToken=" + ssoToken + "\"";
      if (dxVersion != DirectXVersion.Default)
      {
        cmdLine += " -addparam \"/triPlatform=" + dxVersion + "\"";
      }
      return cmdLine;
    }
  }
}