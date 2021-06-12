using System;

namespace libcs.common.Attribute
{
    [System.AttributeUsage(System.AttributeTargets.Method, AllowMultiple = true)] 
    public class SyscallAttribute: System.Attribute
    {
        public byte SysCall {get; private set;}
        public SyscallAttribute(byte SysCall)
        {
            this.SysCall = SysCall;
        }
    }
}
