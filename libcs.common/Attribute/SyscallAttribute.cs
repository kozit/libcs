using System;

namespace libcs.common.Attribute
{
    public class IRQField {
        public Type FieldType {get; set;} = typeof(uint);
        
        public string FieldName {get; set;} = "";
    }

    [System.AttributeUsage(System.AttributeTargets.Method, AllowMultiple = false)] 
    public class SyscallAttribute: System.Attribute
    {
        public uint[] SysCall {get; private set;}

        public IRQField EDI {get; private set;} = null;
        public IRQField ESI {get; private set;} = null;
        public IRQField EBP {get; private set;} = null;
        public IRQField ESP {get; private set;} = null;
        public IRQField EBX {get; private set;} = null;
        public IRQField EDX {get; private set;} = null;
        public IRQField ECX {get; private set;} = null;
        public SyscallAttribute(
            uint SysCall
            )
        {

            this.SysCall = SysCall;
        }

    }
}
