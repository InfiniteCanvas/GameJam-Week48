using UnityEngine;

namespace ScriptableObjectsFramework
{
    [CreateAssetMenu(fileName = nameof(FloatVariable), menuName = "ScriptableObjects/Variables/" + nameof(FloatVariable), order = -1000)]
    public class FloatVariable : Variable
    {
        public float Value;
    }

}