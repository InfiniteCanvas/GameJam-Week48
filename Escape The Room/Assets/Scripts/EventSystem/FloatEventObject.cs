using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectsFramework.Events
{
    [CreateAssetMenu(fileName = nameof(FloatEventObject), menuName = "ScriptableObjects/EventSystem/" + nameof(FloatEventObject), order = -1000)]
    public class FloatEventObject : EventObject
    {
        public FloatEvent FloatEvent;
        public FloatReference FloatReference;

        public void Raise()
        {
            FloatEvent?.Invoke(FloatReference);
        }

        public void Raise(float f)
        {
            FloatEvent?.Invoke(f);
        }
    }

    [System.Serializable]
    public class FloatEvent : UnityEvent<float> { } 
}