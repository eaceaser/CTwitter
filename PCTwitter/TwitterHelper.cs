namespace PCTwitter {
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;

  using OAuth;

  public class OAuthCredentials {
    private string _token;
    private string _secret;

    public string Token {
      get { return _token; }
      set { _token = value; }
    }

    public string Secret {
      get { return _secret; }
      set { _secret = value; }
    }
  }

  public class TwitterHelper {
    public static OAuthCredentials PerformOAuth(string consumerKey, string consumerSecret) {
      OAuthConfig oauthConfig = new OAuthConfig("console");
      oauthConfig.OauthVersion = "1.0";
      oauthConfig.OauthSignatureMethod = "HMAC-SHA1";

      oauthConfig.ConsumerKey = consumerKey;
      oauthConfig.ConsumerSecret = consumerSecret;

      oauthConfig.RequestTokenUrl = "https://api.twitter.com/oauth/request_token";
      oauthConfig.AccessTokenUrl = "https://api.twitter.com/oauth/access_token";
      oauthConfig.UserAuthorizationUrl = "https://api.twitter.com/oauth/authorize";

      OAuthConsumer oauthConsumer = new OAuthConsumer(oauthConfig, "console");
      oauthConsumer.getRequestToken();

      VerificationInput input = new VerificationInput();
      input.ShowDialog();
      string code = input.GetCode();
      oauthConsumer.getAccessToken(code);
      OAuthCredentials rv = new OAuthCredentials();
      rv.Token = oauthConfig.OauthToken;
      rv.Secret = oauthConfig.OauthTokenSecret;
      return rv;
    }

    public static OAuthConsumer CreateClient(string consumerKey, string consumerSecret, string accessToken, string accessSecret) {
      OAuthConfig oauthConfig = new OAuthConfig("console");
      oauthConfig.OauthVersion = "1.0";
      oauthConfig.OauthSignatureMethod = "HMAC-SHA1";
      oauthConfig.ConsumerKey = consumerKey;
      oauthConfig.ConsumerSecret = consumerSecret;
      oauthConfig.OauthToken = accessToken;
      oauthConfig.OauthTokenSecret = accessSecret;
      OAuthConsumer oauthConsumer = new OAuthConsumer(oauthConfig, "console");
      return oauthConsumer;
    }

    public static void Tweet(OAuthConsumer consumer, string text) {
      List<QueryParameter> post = new List<QueryParameter>();
      post.Add(new QueryParameter("status", text));

      consumer.request("http://api.twitter.com/1/statuses/update.json", "POST", post, "PLAIN");
    }
  }
}