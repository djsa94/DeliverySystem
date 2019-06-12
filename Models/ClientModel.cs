using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProyectoProgramado3.Models
{
    public class ClientModel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("idClient")]
        public string idClient { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("BirthDate")]
        public string BirthDate { get; set; }

        [BsonElement("Password")]
        public string Password { get; set; }
    }
}