using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Olympus_the_Game.View.Editor
{
    [AttributeUsage(AttributeTargets.Property)]
    class ExcludeFromEditor : System.Attribute
    {
        public bool Exclude { get; private set; }

        public ExcludeFromEditor() : this(true) 
        { }

        public ExcludeFromEditor(bool exclude)
        {
            Exclude = exclude;
        }
    }
}
