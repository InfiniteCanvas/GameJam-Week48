namespace ScriptableObjectsFramework
{
    [System.Serializable]
    public class BoolReference
    {
        public bool UseConstant = true;
        public bool Constant;
        public BoolVariable Variable;

        public bool Value
        {
            get
            {
                return UseConstant ? Constant : Variable.Value;
            }
            set
            {
                if (UseConstant)
                    Constant = value;
                else
                    Variable.Value = value;
            }
        }

        public static implicit operator bool(BoolReference b)
        {
            return b.Value;
        }
    }

}