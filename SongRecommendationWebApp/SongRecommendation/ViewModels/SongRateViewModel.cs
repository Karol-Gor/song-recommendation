using Microsoft.AspNetCore.Mvc.Rendering;
using SongRecommendation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongRecommendation.ViewModels
{
    public class SongRateViewModel
    {
        public string Rate0 { get; set; }
        public string Rate1 { get; set; }
        public string Rate2 { get; set; }
        public string Rate3 { get; set; }
        public string Rate4 { get; set; }
        public string Rate5 { get; set; }
        public string Rate6 { get; set; }
        public string Rate7 { get; set; }
        public string Rate8 { get; set; }
        public string Rate9 { get; set; }

        public List<SelectListItem> Rating { get;} = new List<SelectListItem>
        {
            new SelectListItem { Value = "1", Text = "1" },
            new SelectListItem { Value = "2", Text = "2" },
            new SelectListItem { Value = "3", Text = "3" },
            new SelectListItem { Value = "4", Text = "4" },
            new SelectListItem { Value = "5", Text = "5" },
        };


        public IEnumerable<SongsDb> Songs { get; set; }


    }
}
