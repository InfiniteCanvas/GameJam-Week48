using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectsFramework.Events
{
    [CreateAssetMenu(fileName = nameof(IntEventObject), menuName = "ScriptableObjects/EventSystem/" + nameof(IntEventObject), order = -1000)]
    public class IntEventObject : EventObject
    {
        public IntEvent IntEvent;
        public IntReference IntReference;

        public void Raise()
        {
            IntEvent?.Invoke(IntReference);
        }

        public void Raise(int i)
        {
            IntEvent?.Invoke(i);
        }
    }

    [System.Serializable]
    public class IntEvent : UnityEvent<int> { } 
}