using System.Linq;
using ScriptableObjectsFramework.Events;
using ScriptableObjectsFramework.FSM;
using UnityEngine;

namespace ScriptableObjectsFramework.Utility
{
    [CreateAssetMenu(fileName = nameof(ScriptableObjectsDictionary), menuName = "ScriptableObjects/" + nameof(ScriptableObjectsDictionary), order = -1000)]
    public class ScriptableObjectsDictionary : ScriptableObject
    {
        [SerializeField] private StringStatePair[] States;
        [SerializeField] private StringVariablePair[] Variables;
        [SerializeField] private StringEventPair[] Events;

        public T GetScriptableObject<T>(string name) where T : ScriptableObject
        {
            if (typeof(T).IsSubclassOf(typeof(EventObject)))
                return GetFromEvents(name) as T;
            if (typeof(T).IsSubclassOf(typeof(State)))
                return GetFromStates(name) as T;
            if (typeof(T).IsSubclassOf(typeof(Variable)))
                return GetFromVariables(name) as T;

            return null;
        }

        private State GetFromStates(string name)
        {
            return States.Where(scriptableObjectPair => scriptableObjectPair.HasName(name))
                .Select(scriptableObjectPair => scriptableObjectPair.ScriptableObject)
                .FirstOrDefault();
        }

        private Variable GetFromVariables(string name)
        {
            return Variables.Where(scriptableObjectPair => scriptableObjectPair.HasName(name))
                .Select(scriptableObjectPair => scriptableObjectPair.ScriptableObject)
                .FirstOrDefault();
        }

        private EventObject GetFromEvents(string name)
        {
            return Events.Where(scriptableObjectPair => scriptableObjectPair.HasName(name))
                .Select(scriptableObjectPair => scriptableObjectPair.ScriptableObject)
                .FirstOrDefault();
        }
    }

    [System.Serializable]
    public class StringKey
    {
        public string Name;

        public bool HasName(string name)
        {
            bool result = Name.Equals(name);

            if (result)
                return true;

            var prop = Name.ToCharArray();
            var para = name.ToCharArray();

            int max = System.Math.Max(prop.Length, para.Length);
            int min = System.Math.Min(prop.Length, para.Length);
            int diff = max - min;

            if (diff >= 3) return false;
            for (int i = 0; i < min; i++)
            {
                if (prop[i] != para[i])
                    diff++;
            }

            Debug.LogWarning($"Difference of strings is {diff}.Comparing property and parameter:\n'{Name}'\n'{name}'");

            return Name.Equals(name);
        }
    }

    [System.Serializable]
    public class StringStatePair : StringKey
    {
        public State ScriptableObject;
    }

    [System.Serializable]
    public class StringVariablePair : StringKey
    {
        public Variable ScriptableObject;
    }

    [System.Serializable]
    public class StringEventPair : StringKey
    {
        public EventObject ScriptableObject;
    }
}