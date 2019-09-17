using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inteview.Models;

namespace Inteview.ViewModels
{
    public class ItunesViewClass
    {
        public string wrapperType { get; set; }
        public string artistType { get; set; }
        public string artistName { get; set; }
        public string artistLinkUrl { get; set; }
        public int artistId { get; set; }
        public int amgArtistId { get; set; }
        public string primaryGenreName { get; set; }
        public int primaryGenreId { get; set; }

    }

    public class RootObject
    {
        public int resultCount { get; set; }
        public List<ItunesViewClass> results { get; set; }
    }
}

