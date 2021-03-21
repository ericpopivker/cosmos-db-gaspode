﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CosmosDbGaspode.Core
{ 
    public class CosmosDbOptions
    {
        public string Account { get; set; }

        public string Key { get; set; }
        
        public string DatabaseName { get; set; }

        public string ContainerName { get; set; }

    }
}
