namespace LibreWorlds.WorldAdapter;

public enum WorldAdapterState
{
    Offline,
    Connected,
    Authenticating,
    Authenticated,
    EnteringWorld,
    InWorld,
    Stopping
}
