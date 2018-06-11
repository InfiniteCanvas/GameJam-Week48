namespace ScriptableObjectsFramework
{
    [System.Serializable]
    public class FloatReference
    {
        public bool UseConstant = true;
        public float Constant;
        public FloatVariable Variable;

        public float Value
        {
            get { return UseConstant ? Constant : Variable.Value; }
            set
            {
                if (UseConstant)
                    Constant = value;
                else
                    Variable.Value = value;
            }
        }

        public static implicit operator float(FloatReference f) => f.Value;

        public static implicit operator string(FloatReference f) => f.Value.ToString();
    }

}