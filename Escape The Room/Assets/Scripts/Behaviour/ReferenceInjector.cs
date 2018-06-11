using UnityEngine;

namespace ScriptableObjectsFramework.Behaviour
{
    [RequireComponent(typeof(ScriptableObjectBehaviourWrapper))]
    public class ReferenceInjector : MonoBehaviour
    {
        [Tooltip("The MonoBehaviour to be injected into the ScriptableObjectBehaviour")]
        public MonoBehaviour Component;
        [Tooltip("The name of the field on the ScriptableObjectBehaviour that requires the injection of the component")]
        public string FieldName;

        private ScriptableObjectBehaviourWrapper _wrapper;

        private void Awake()
        {
            _wrapper = GetComponent<ScriptableObjectBehaviourWrapper>();
            Inject();
        }

        private void Inject()
        {
            var behaviour = _wrapper.GetType().GetField("Behaviour").GetValue(_wrapper);
            var field = behaviour.GetType().GetField(FieldName);

            field.SetValue(behaviour, Component);
        }
    }
}