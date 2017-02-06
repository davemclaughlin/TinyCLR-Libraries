using System;
using System.Runtime.CompilerServices;

namespace GHIElectronics.TinyCLR.Native
{
    public class ConstraintException : Exception
    {
    }

    public static class ExecutionConstraint
    {
        [MethodImplAttribute(MethodImplOptions.InternalCall)]
        extern static public void Install(int timeout, int priority);
    }
}


