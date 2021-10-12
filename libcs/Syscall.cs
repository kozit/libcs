using System;
using System.Runtime.InteropServices;

using libcs.Types.Unmanaged;
namespace libcs
{
    public unsafe static class Syscall {

        public static IntPtr Call(
            uint Syscall_code
        ) 
        {
            byte data = 0x00;
            return 
                Call<byte, byte, byte, byte, byte, byte, byte>(
                    Syscall_code, 
                    ref data, 
                    ref data, 
                    ref data, 
                    ref data, 
                    ref data, 
                    ref data, 
                    ref data
                );

        }

        public static IntPtr Call<T0>(
            uint Syscall_code,
            ref T0 EDI
        ) 
        where T0 : struct
        {
            byte data = 0x00;
            return 
                Call<T0, byte, byte, byte, byte, byte, byte>(
                    Syscall_code, 
                    ref EDI, 
                    ref data, 
                    ref data, 
                    ref data, 
                    ref data, 
                    ref data, 
                    ref data
                );
        }
        
        public static IntPtr Call<T0, T1>(
            uint Syscall_code,
            ref T0 EDI,
            ref T1 ESI
        ) 
        where T0 : struct
        where T1 : struct
        {
            byte data = 0x00;
            return 
                Call<T0, T1, byte, byte, byte, byte, byte>(
                    Syscall_code, 
                    ref EDI, 
                    ref ESI, 
                    ref data, 
                    ref data, 
                    ref data, 
                    ref data, 
                    ref data
                );
        }
        
        public static IntPtr Call<T0, T1, T2>(
            uint Syscall_code,
            ref T0 EDI,
            ref T1 ESI,
            ref T2 EBP
        ) 
        where T0 : struct
        where T1 : struct
        where T2 : struct
        {
            byte data = 0x00;
            return 
                Call<T0, T1, T2, byte, byte, byte, byte>(
                    Syscall_code, 
                    ref EDI, 
                    ref ESI, 
                    ref EBP, 
                    ref data, 
                    ref data, 
                    ref data, 
                    ref data
                );
        }

            public static IntPtr Call<T0, T1, T2, T3>(
            uint Syscall_code,
            ref T0 EDI,
            ref T1 ESI,
            ref T2 EBP,
            ref T3 ESP
        ) 
        where T0 : struct
        where T1 : struct
        where T2 : struct
        where T3 : struct
        {
            byte data = 0x00;
            return 
                Call<T0, T1, T2, T3, byte, byte, byte>(
                    Syscall_code, 
                    ref EDI, 
                    ref ESI, 
                    ref EBP, 
                    ref ESP, 
                    ref data, 
                    ref data, 
                    ref data
                );
        }
            public static IntPtr Call<T0, T1, T2, T3, T4>(
            uint Syscall_code,
            ref T0 EDI,
            ref T1 ESI,
            ref T2 EBP,
            ref T3 ESP,
            ref T4 EBX
        ) 
        where T0 : struct
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        {
            byte data = 0x00;
            return 
                Call<T0, T1, T2, T3, T4, byte, byte>(
                    Syscall_code, 
                    ref EDI, 
                    ref ESI, 
                    ref EBP, 
                    ref ESP, 
                    ref EBX, 
                    ref data, 
                    ref data
                );
        }

        public static IntPtr Call<T0, T1, T2, T3, T4, T5>(
            uint Syscall_code,
            ref T0 EDI,
            ref T1 ESI,
            ref T2 EBP,
            ref T3 ESP,
            ref T4 EBX,
            ref T5 EDX
        )
        where T0 : struct
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
        {
            byte data = 0x00;
            return 
                Call<T0, T1, T2, T3, T4, T5, byte>(
                    Syscall_code, 
                    ref EDI, 
                    ref ESI, 
                    ref EBP, 
                    ref ESP, 
                    ref EBX, 
                    ref EDX, 
                    ref data
                );
        }


        public static IntPtr Call<T0, T1, T2, T3, T4, T5, T6>(
            uint Syscall_code,
            ref T0 EDI,
            ref T1 ESI,
            ref T2 EBP,
            ref T3 ESP,
            ref T4 EBX,
            ref T5 EDX,
            ref T6 ECX
        ) 
        where T0 : struct
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
        where T6 : struct
        {
            return (IntPtr)0;
        }

    }
}