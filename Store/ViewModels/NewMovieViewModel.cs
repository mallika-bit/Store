using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Store.Models;

namespace Store.ViewModels
{
    public class NewMovieViewModel
    {
       public  IEnumerable<Genres> Genres { get; set; }
        public Movie Movie { get; set; }
    }
}