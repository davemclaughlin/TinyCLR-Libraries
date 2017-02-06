namespace System {
    [Serializable]
    public abstract class Enum : ValueType {

        public override string ToString() {
            var eT = this.GetType();
            var fi = eT.GetField("value__");
            var obj = fi.GetValue(this);

            return obj.ToString();
        }

    }
}


