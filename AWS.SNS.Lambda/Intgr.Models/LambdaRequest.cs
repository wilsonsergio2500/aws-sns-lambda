﻿using System.Collections.Generic;

namespace Intgr.Models
{
    public class LambdaRequest<T>
    {
        public string method { get; set; }

        public Dictionary<string, string> headers { get; set; }

        public T body { get; set; }

    }
}
