namespace libcs.common
{
    
    public enum SysCall: uint {
        system_shutdown = 0x01,
        system_reboot   = 0x02,
        system_time     = 0x03,

        process_signal  = 0x50,
        process_interprocess_communication  = 0x51,
    }

}