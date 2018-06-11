using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectsFramework.Events
{
    [CreateAssetMenu(fileName = nameof(VoidEventObject), menuName = "ScriptableObjects/EventSystem/" + nameof(VoidEventObject), order = -1000)]
    public class VoidEventObject : EventObject
    {
        public UnityEvent VoidEvent;

        public void Raise()
        {
            VoidEvent?.Invoke();
        }
    } 
}
