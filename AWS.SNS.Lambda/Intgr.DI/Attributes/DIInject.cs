using System;

namespace Intgr.DI.Attributes
{
    public class DIInject : Attribute
    {
        public DIInject()
        {
            new Injection();
        }
    }
}
