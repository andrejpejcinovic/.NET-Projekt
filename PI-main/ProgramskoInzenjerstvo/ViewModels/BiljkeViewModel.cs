using ProgramskoInzenjerstvo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgramskoInzenjerstvo.ViewModels
{
    public class BiljkeViewModel
    {
        
        public IEnumerable<UporabeViewModel> Uporabe { get; set; }
        public IEnumerable<NarodnaImenaViewModel> NarodnaImena { get; set; }
        public int IDBilje { get; set; }
        public string Rod { get; set; }
        public string Vrsta { get; set; }
        public decimal Cijena { get; set; }
    }
}