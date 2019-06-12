using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProyectoProgramado3.Models
{
    public class OrderModel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("idOrder")]
        public string idOrder { get; set; }

        [BsonElement("idClient")]
        public string idClient { get; set; }

        [BsonElement("Quantity")]
        public string Quantity { get; set; }

        [BsonElement("Price")]
        public string Price { get; set; }

        [BsonElement("Date")]
        public string Date { get; set; }

        [BsonElement("Time")]
        public string Time { get; set; }

        [BsonElement("Status")]
        public string Status { get; set; }

        [BsonElement("Extras")]
        public string Extras { get; set; }
    }
}