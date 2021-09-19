using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProgramskoInzenjerstvo.Models;

namespace ProgramskoInzenjerstvo.ViewModels
{
    public class BiljeKupovinaViewModel
    {
        public IEnumerable<BiljeKupovina> BiljeKupovinas { get; set; }
    }
}