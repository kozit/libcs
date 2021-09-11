using System;

namespace libcs
{
    public unsafe static class Syscall {


    public static byte* Call<T0>(
        uint Syscall_code,
        T0 EDI = null
    ) {
        return 
            Call<T0, byte, byte, byte, byte, byte, byte>(
                Syscall_code, 
                EDI, 
                null, 
                null, 
                null, 
                null, 
                null, 
                null
            );
    }
    public static byte* Call<T0, T1>(
        uint Syscall_code,
        T0 EDI = null,
        T1 ESI = null
    ) {
        return 
            Call<T0, T1, byte, byte, byte, byte, byte>(
                Syscall_code, 
                EDI, 
                ESI, 
                null, 
                null, 
                null, 
                null, 
                null
            );
    }
        public static byte* Call<T0, T1, T2>(
        uint Syscall_code,
        T0 EDI = null,
        T1 ESI = null,
        T2 EBP = null
    ) {
        return 
            Call<T0, T1, T2, byte, byte, byte, byte>(
                Syscall_code, 
                EDI, 
                ESI, 
                EBP, 
                null, 
                null, 
                null, 
                null
            );
    }

        public static byte* Call<T0, T1, T2, T3>(
        uint Syscall_code,
        T0 EDI = null,
        T1 ESI = null,
        T2 EBP = null,
        T3 ESP = null
    ) {
        return 
            Call<T0, T1, T2, T3, byte, byte, byte>(
                Syscall_code, 
                EDI, 
                ESI, 
                EBP, 
                ESP, 
                null, 
                null, 
                null
            );
    }
        public static byte* Call<T0, T1, T2, T3, T4>(
        uint Syscall_code,
        T0 EDI = null,
        T1 ESI = null,
        T2 EBP = null,
        T3 ESP = null,
        T4 EBX = null
    ) {
        return 
            Call<T0, T1, T2, T3, T4, byte, byte>(
                Syscall_code, 
                EDI, 
                ESI, 
                EBP, 
                ESP, 
                EBX, 
                null, 
                null
            );
    }

    public static byte* Call<T0, T1, T2, T3, T4, T5>(
        uint Syscall_code,
        T0 EDI = null,
        T1 ESI = null,
        T2 EBP = null,
        T3 ESP = null,
        T4 EBX = null,
        T5 EDX = null
    ) {
        return 
            Call<T0, T1, T2, T3, T4, T5, byte>(
                Syscall_code, 
                EDI, 
                ESI, 
                EBP, 
                ESP, 
                EBX, 
                EDX, 
                null
            );
    }


    public static byte* Call<T0, T1, T2, T3, T4, T5, T6>(
        uint Syscall_code,
        T0 EDI = null,
        T1 ESI = null,
        T2 EBP = null,
        T3 ESP = null,
        T4 EBX = null,
        T5 EDX = null,
        T6 ECX = null
    ) {
    }

    }
}