using System.Collections.Generic;
using Tweetinvi;
using Tweetinvi.Core.Credentials;
using Tweet = Xeromatic.Models.Tweet;
using System.Linq;

namespace Xeromatic.Services
{
    public class TwitterApiService : ITwitterService 
        //API service is based on Interface Twitter Service
    {
        // Get keys from: https://apps.twitter.com
        // Wiki for tweetinvi: https://github.com/linvi/tweetinvi/wiki

        readonly TwitterCredentials _creds;

        public TwitterApiService()
        {
            _creds = new TwitterCredentials
            {
                ConsumerKey = "2ufrrXd3CEEJeI1sHlowRvcRK",
                ConsumerSecret = "F0Ax9uKkA7kASssiRLX2cHYlck6K4CoAXkcL6Bjbi2OWXBiVsT",
                AccessToken = "60007046-yjvA1X8QRyK2gqyNUbmueKt404MEYXITFo8ehTXHY",
                AccessTokenSecret = "94VliknkgAO1pCClTw1LBJWXMCG5bU2qwJWQQlNgaCWJE"
            };
        }

        public IEnumerable<Tweet> GetTweets()
        {
            var tweets = 
                Auth.ExecuteOperationWithCredentials(_creds, () => Timeline.GetUserTimeline("May2June", 10)).ToList();
            if (tweets.Any())
            {
                return tweets.Select(t => new Tweet
                {
                    Id = t.Id,
                    Text = t.Text
                });
            }
            return new List<Tweet>();
        }

    }
}