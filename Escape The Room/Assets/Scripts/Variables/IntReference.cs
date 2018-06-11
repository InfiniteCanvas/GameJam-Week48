namespace ScriptableObjectsFramework
{
    [System.Serializable]
    public class IntReference
    {
        public bool UseConstant = true;
        public int Constant;
        public IntVariable Variable;

        public int Value
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

        public static implicit operator int(IntReference ir) => ir.Value;

        public static implicit operator string(IntReference ir) => ir.Value.ToString();
    }

}