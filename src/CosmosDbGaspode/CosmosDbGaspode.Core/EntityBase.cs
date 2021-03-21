using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CosmosDbGaspode.Core
{
    public abstract class EntityBase
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        public string EntityType { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? LastUpdatedAt { get; set; }

        public bool IsDeleted { get; set; }
        
        public DateTime? DeletedAt { get; set; }
    }
}
