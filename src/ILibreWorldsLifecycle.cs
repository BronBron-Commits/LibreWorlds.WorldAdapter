namespace LibreWorlds.WorldAdapter
{
    /// <summary>
    /// Explicit lifecycle signals emitted by the LibreWorlds SDK.
    /// This is the ONLY contract the adapter cares about.
    /// </summary>
    public interface ILibreWorldsLifecycle
    {
        void OnConnecting();
        void OnConnected();

        void OnAuthenticating();
        void OnAuthenticated();

        void OnEnteringWorld();
        void OnWorldEntered();

        void OnDisconnected();
    }
}
