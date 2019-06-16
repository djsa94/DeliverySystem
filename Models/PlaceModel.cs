using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProyectoProgramado3.Models
{
    public class PlaceModel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("idPlace")]
        public string idPlace { get; set; }

        [BsonElement("Latitude")]
        public string Latitude { get; set; }

        [BsonElement("Longitude")]
        public string Longitude { get; set; }

        [BsonElement("Address")]
        public string Address { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("DeliveryMen")]
        public string DeliveryMen { get; set; }

        [BsonElement("PlaceType")]
        public string PlaceType { get; set; }

        [BsonElement("Picture")]
        public string Picture { get; set; }

        [BsonElement("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [BsonElement("Rating")]
        public string Rating { get; set; }

        [BsonElement("Schedule")]
        public string Schedule { get; set; }

        [BsonElement("Website")]
        public string Website { get; set; }

        [BsonElement("ProductList")]
        public List<string> ProductList { get; set; }
    }
}
