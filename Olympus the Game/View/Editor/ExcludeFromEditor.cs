using System;

namespace Olympus_the_Game.View.Editor
{
    /// <summary>
    ///     Geeft aan dat deze property niet in de <see cref="LevelEditor" /> moet komen.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    internal class ExcludeFromEditor : Attribute
    {
        public ExcludeFromEditor(bool exclude = true)
        {
            Exclude = exclude;
        }

        public bool Exclude { get; private set; }
    }

    [AttributeUsage(AttributeTargets.Property)]
    internal class EditorTooltip : Attribute
    {
        public EditorTooltip(string name, string descr)
        {
            Name = name;
            Description = descr;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
    }
}