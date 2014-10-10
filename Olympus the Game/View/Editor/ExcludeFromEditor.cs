﻿using System;

namespace Olympus_the_Game.View.Editor
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class ExcludeFromEditor : Attribute
    {
        public ExcludeFromEditor() : this(true)
        {
        }

        public ExcludeFromEditor(bool exclude)
        {
            Exclude = exclude;
        }

        public bool Exclude { get; private set; }
    }
}