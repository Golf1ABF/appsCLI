using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appsCLI
{
    internal class Apps
    {
        public string AppName { get; set; }
        public Category Category{ get; set; }
        public ContentRating ContentRating{ get; set; }
        public double Rating { get; set; }
        public int Reviews { get; set; }
        public string CurrentVer { get; set; }
        public int UpdateYear { get; set; }
        public int UpdateMonth { get; set; }

        public Apps(string appName, Category category, ContentRating contentRating, double rating, int reviews, string currentVer, int updateYear, int updateMonth)
        {
            AppName = appName;
            Category = category;
            ContentRating = contentRating;
            Rating = rating;
            Reviews = reviews;
            CurrentVer = currentVer;
            UpdateYear = updateYear;
            UpdateMonth = updateMonth;
        }

        public static List<Apps> LoadFromCsv(string path)
        {
            List<Apps> apps = new List<Apps>();
            string[] temp = File.ReadAllLines(path);
            foreach (string line in temp.Skip(1))
            {
                string[] s = line.Split(';');

                string AppName = s[0];
                Category Category = new Category(int.Parse(s[1]), s[2]);
                ContentRating ContentRating = new ContentRating(int.Parse(s[3]), s[4]);
                double Rating = double.Parse(s[5].Replace(".", ","));
                int Reviews = int.Parse(s[6]);
                string CurrentVer = s[7];
                int UpdateYear = int.Parse(s[8]);
                int UpdateMonth = int.Parse(s[9]);
                Apps app = new Apps(AppName, Category, ContentRating, Rating, Reviews, CurrentVer, UpdateYear, UpdateMonth);
                apps.Add(app);
            }
            return apps;
        }

        public string ConvertToStars(double starCount)
        {
            var starRounded = Math.Round(starCount); 
            string stars = "";
            for (int i = 0; i < starCount; i++)
            {
                stars += "*";
            }
            return stars;
        }

        public override string ToString()
        {
            string stars = ConvertToStars(Rating);
            if (stars == "")
            {
                stars = "-";
            }
            return $"{AppName} {stars}";
        }
    }
}
