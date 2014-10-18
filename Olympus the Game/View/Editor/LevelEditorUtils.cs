using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Olympus_the_Game.Model;
using System.Linq;

namespace Olympus_the_Game.View.Editor
{
    static class LevelEditorUtils
    {
        public static readonly Dictionary<ObjectType, GameObject> ConstructorList =
            new Dictionary<ObjectType, GameObject>();

        static LevelEditorUtils()
        {
            foreach (
                Type t in typeof (GameObject).Assembly.GetTypes().Where(type => type.IsSubclassOf(typeof (GameObject))))
            {
                RuntimeHelpers.RunClassConstructor(t.TypeHandle);
            }
        }

        public static void RegisterWithEditor(this GameObject go, ObjectType ot)
        {
            ConstructorList.Add(ot, go);
        }

        public static GameObject CreateObjectOfType(ObjectType ot)
        {
            GameObject result;
            ConstructorList.TryGetValue(ot, out result);

            return (GameObject) (result == null ? null : Activator.CreateInstance(result.GetType()));
        }
    }
}
