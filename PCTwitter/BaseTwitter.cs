namespace PRoConEvents {
  using System;
  using System.IO;
  using System.Text;
  using System.Collections.Generic;
  using System.Windows.Forms;

  using PRoCon.Core;
  using PRoCon.Core.Plugin;

  using PCTwitter;
  using OAuth;
  public class CTwitter : PRoConPluginAPI, IPRoConPluginInterface {
    #region Statics And Helpers
    private static readonly string CONSUMER_KEY    = "HTBrJaK47t7hfK5CaxXmzA";
    private static readonly string CONSUMER_SECRET = "0CiSL0lbw8FUiqekMbZQdCk6ZSDDtNsmBtJxowo4J8";

    public void consoleWrite(String message) { this.ExecuteCommand("procon.protected.pluginconsole.write", "CTwitter: " + message); }
    public void setPluginState(Boolean state) { this.ExecuteCommand("procon.protected.plugins.enable", "CTwitter", state.ToString()); }
    #endregion

    #region Plugin Information
    public string GetPluginName() { return "Twitter Integration"; }
    public string GetPluginVersion() { return "0.0.1"; }
    public string GetPluginAuthor() { return "Ed Ceaser <eac@tehasdf.com>"; }
    public string GetPluginWebsite() { return "http://github.com/eac/CTwitter"; }
    public string GetPluginDescription() {
      return @"Twitter Integration for your BF3 Server.";
    }
    #endregion

    #region Plugin Setup / Teardown
    public void OnPluginLoaded(String hostname, String port, String PRoConVersion) {
      this.RegisterEvents(this.GetType().Name, "OnLevelLoaded");
    }

    public void OnPluginEnable() {
      if (twttrAccessToken == null) {
        // we need to auth.
        OAuthCredentials accessToken = TwitterHelper.PerformOAuth(CONSUMER_KEY, CONSUMER_SECRET);
        consoleWrite("^8OAuth Successful. Please copy and paste the following values into the plugin configuration, and reactivate: ");
        consoleWrite("Access Token: " + accessToken.Token);
        consoleWrite("Access Token Secret: " + accessToken.Secret);
        consoleWrite("Please keep the token secret safe. You can unauthorize this application at any time from your Twitter account settings.");
        setPluginState(false);
        return;
      }
      
      twttrService = TwitterHelper.CreateClient(CONSUMER_KEY, CONSUMER_SECRET, twttrAccessToken.Token, twttrAccessToken.Secret);
      consoleWrite("Twitter client created successfully.");
    }

    public void OnPluginDisable() {
      // shut the stupid plugin up
    }
    #endregion

    #region Events
    public override void OnLevelLoaded(string mapFileName, string Gamemode, int roundsPlayed, int roundsTotal) {
      CMap map = this.GetMapByFilename(mapFileName);
      TwitterHelper.Tweet(twttrService, "Changing map! New Map: " + map.PublicLevelName);
    }
    #endregion

    #region CTwitter Variables
    String uiToken = "";
    String uiTokenSecret = "";

    OAuthCredentials twttrAccessToken;
    OAuthConsumer twttrService;
    #endregion

    #region CTwitter Configuration
    public List<CPluginVariable> GetDisplayPluginVariables() {
      List<CPluginVariable> rv = new List<CPluginVariable>();
      rv.Add(new CPluginVariable("Twitter|Access Token", typeof(String), uiToken));
      rv.Add(new CPluginVariable("Twitter|Access Token Secret", typeof(String), uiTokenSecret));

      return rv;
    }

    public List<CPluginVariable> GetPluginVariables() {
      List<CPluginVariable> rv = new List<CPluginVariable>();
      rv.Add(new CPluginVariable("Access Token", typeof(String), uiToken));
      rv.Add(new CPluginVariable("Access Token Secret", typeof(String), uiTokenSecret));
      return rv;
    }

    public void SetPluginVariable(string variable, string value) {
      if (variable == "Access Token") {
        uiToken = value;
      } else if (variable == "Access Token Secret") {
        uiTokenSecret = value;
      }

      if (uiToken.Length > 0 && uiTokenSecret.Length > 0) {
        OAuthCredentials accessToken = new OAuthCredentials();
        accessToken.Token = uiToken;
        accessToken.Secret = uiTokenSecret;
        twttrAccessToken = accessToken;
      }
    }
    #endregion

    #region Constructor
    public CTwitter() {
      OAuthCredentials accessToken = new OAuthCredentials();
      accessToken.Token = uiToken;
      accessToken.Secret = uiTokenSecret;
      if (accessToken.Token.Length > 0 && accessToken.Secret.Length > 0) {
        twttrAccessToken = accessToken;
      }      
    }
    #endregion
  }
}