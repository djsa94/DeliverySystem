using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProyectoProgramado3.Models
{
    public class ShoppingCartModel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("idProduct")]
        public string idProduct { get; set; }

        [BsonElement("idClient")]
        public string idClient { get; set; }
    }
}