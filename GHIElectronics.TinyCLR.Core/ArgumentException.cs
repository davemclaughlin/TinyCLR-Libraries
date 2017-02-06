namespace System {
    // The ArgumentException is thrown when an argument does not meet
    // the contract of the method.  Ideally it should give a meaningful error
    // message describing what was wrong and which parameter is incorrect.
    //
    [Serializable()]
    public class ArgumentException : SystemException {
        private string m_paramName;

        // Creates a new ArgumentException with its message
        // string set to the empty string.
        public ArgumentException()
            : base() {
        }

        // Creates a new ArgumentException with its message
        // string set to message.
        //
        public ArgumentException(string message)
            : base(message) {
        }

        public ArgumentException(string message, Exception innerException)
            : base(message, innerException) {
        }

        public ArgumentException(string message, string paramName, Exception innerException)
            : base(message, innerException) => this.m_paramName = paramName;

        public ArgumentException(string message, string paramName)

            : base(message) => this.m_paramName = paramName;

        public override string Message {
            get {
                var s = base.Message;
                if (!((this.m_paramName == null) ||
                       (this.m_paramName.Length == 0)))
                    return s + "\n" + "Invalid argument " + "'" + this.m_paramName + "'";
                else
                    return s;
            }
        }

        public virtual string ParamName => this.m_paramName;
    }
}


