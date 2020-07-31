using Despatch.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Despatch
{
    public class ViewModel
    {
        public IEnumerable<DriverReg> Driver { get; set; }
        public IEnumerable<VehicleReg> Vehicle { get; set; }

    }
}