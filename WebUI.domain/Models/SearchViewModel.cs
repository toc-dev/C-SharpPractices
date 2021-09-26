using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.domain.Utilities.Enumerators;

namespace WebUI.domain.Models
{
    public class SearchViewModel
    {
        public string Input { get; set; }
        public SearchOptions Options { get; set; }
    }
}
