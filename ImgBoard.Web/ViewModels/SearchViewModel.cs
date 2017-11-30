using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ImgBoard.Models.Main;

namespace ImgBoard.Web.ViewModels
{
    public class SearchViewModel
    {
        public string Term { get; set; }
        public List<Image> Results { get; set; }
    }
}