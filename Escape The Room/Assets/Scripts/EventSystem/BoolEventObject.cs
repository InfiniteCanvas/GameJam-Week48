using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectsFramework.Events
{
    [CreateAssetMenu(fileName = nameof(BoolEventObject), menuName = "ScriptableObjects/EventSystem/" + nameof(BoolEventObject), order = -1000)]
    public class BoolEventObject : EventObject
    {
        public BoolEvent BoolEvent;
        public BoolReference BoolReference;

        public void Raise()
        {
            BoolEvent?.Invoke(BoolReference);
        }

        public void Raise(bool b)
        {
            BoolEvent?.Invoke(b);
        }
    }

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { } 
}