namespace libcs.common
{
    
    public enum SysCall: uint {
        system_shutdown = 0x01,
        system_reboot   = 0x02,
        system_time     = 0x03,

        process_signal  = 0x50,
        process_interprocess_communication_send  = 0x51,
        process_interprocess_communication_clear = 0x52,
        process_interprocess_communication_count = 0x53,
        process_interprocess_communication_retrieve = 0x54,
        process_interprocess_communication_retrieve_acknowledgement = 0x55,
    }

}