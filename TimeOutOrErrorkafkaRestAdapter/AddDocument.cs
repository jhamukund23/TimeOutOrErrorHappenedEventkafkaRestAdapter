﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeOutOrErrorkafkaRestAdapter
{
    public class AddDocument
    {
        public Guid CorrelationId { get; set; }
        public string FileName { get; set; }
        public string FileSise { get; set; }

    }
}
