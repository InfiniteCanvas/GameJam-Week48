using UnityEngine;

namespace ScriptableObjectsFramework
{
    [CreateAssetMenu(fileName = nameof(IntVariable), menuName = "ScriptableObjects/Variables/" + nameof(IntVariable), order = -1000)]
    public class IntVariable : Variable
    {
        public int Value;
    }

}