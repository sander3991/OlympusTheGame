using System;

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

    [AttributeUsage(AttributeTargets.Property)]
    internal class EditorTooltip : Attribute
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public EditorTooltip(string name, string descr)
        {
            Name = name;
            Description = descr;
        }
    }
}