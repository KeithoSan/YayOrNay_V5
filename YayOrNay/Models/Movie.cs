using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YayOrNay.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Certificate { get; set; }


        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ReleaseDate { get; set; }


        //public double AverageRating
        //{
        //    get
        //    {
        //        using (MovieReview db = new MovieReview())
        //        {
        //            var reviews = db.Rating

        //                if (reviews.Count()>0)
        //            {
        //                double RatingAverage = (double) reviews.Average(r => r.Rating) 0;
        //                return RatingAverage;
        //            }
        //            return 0;
        //        }
        //    }
        //}

            


        //public double Rating { get; set; }



        public virtual ICollection<MovieReview> Reviews { get; set; }
        public virtual ICollection<File> Files { get; set; }

    }
}