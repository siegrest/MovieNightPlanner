using System;
using System.Linq;
using System.Text.RegularExpressions;
using DAL;
using DAL.Domain;

namespace NetGroupCV.Models {
    public class ListNewViewModel {
        private static readonly Regex UrlRegex = new Regex(@"^(https?://)?m\w{9}t\.net/\w{5}/(\d+)/.+$");
        public string Url { get; set; }

        public ListNewViewModel() { }

        public bool Verify(out string msg) {
            if (string.IsNullOrEmpty(Url) || string.IsNullOrWhiteSpace(Url)) {
                msg = "Missing url";
                return false;
            }

            if (!UrlRegex.IsMatch(Url)) {
                msg = "Url does not match expected pattern";
                return false;
            }

            msg = "All good";
            return true;
        }

        public bool AddToDb(MlContext ctx, string username, out string msg) {
            // Extract id from user-provided url
            var id = int.Parse(UrlRegex.Match(Url).Groups[2].Value);

            // Check if the submission already exists. Prevents api spam
            // I'd use .Any() but it's throwing a lot of `InvalidOperationException: No coercion operator is defined
            // between types 'System.Int16' and 'System.Boolean'.` exceptions so I went with the gimmicky option due to
            // time constraints
            if (ctx.Submissions.Where(t => t.Id == id).ToList().Any()) {
                msg = "Already exists";
                return false;
            }

            // Get movie details from external API
            var entry = Utility.ApiConnector.AsyncGet(id).Result;

            // Attempt to add to database
            try {
                ctx.Submissions.Add(new Submission {
                    Id = entry.MalId,
                    UserId = ctx.Users.First(t => t.Username.Equals(username)).Id,
                    Url = Url,
                    Title = entry.Title,
                    Duration = entry.Duration,
                    Episodes = entry.Episodes,
                    ImageUrl = entry.ImageUrl,
                    Score = entry.Score,
                    Type = entry.Type,
                    TrailerUrl = entry.TrailerUrl,
                    Rating = entry.Rating,
                    Synopsis = entry.Synopsis,
                    Genres = entry.Genres.Select(t => t.Name).Aggregate((i, j) => i + ", " + j)
                });

                ctx.SaveChanges();
            } catch (Exception ex) {
                msg = ex.Message;
                return false;
            }

            msg = "Successfully added";
            return true;
        }
    }
}