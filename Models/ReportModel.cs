using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoProgramado3.Models
{
    public class ReportModel
    {
        
        public IList<OrderModel> OrderReport { get; set; }

        public IList<PlaceModel> SiteReport { get; set; }
        
        public IList<PlaceModel> TopReport { get; set; }
        
        public IList<ClientModel> SiteInCommon { get; set; }

    }
}