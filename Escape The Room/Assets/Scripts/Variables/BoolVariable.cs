using UnityEngine;

namespace ScriptableObjectsFramework
{
    [CreateAssetMenu(fileName = nameof(BoolVariable), menuName = "ScriptableObjects/Variables/" + nameof(BoolVariable), order = -1000)]
    public class BoolVariable : Variable
    {
        public bool Value;
    }

}