using System;
using System.Numerics;

namespace LibreWorlds.WorldAdapter
{
    public sealed class WorldAdapter
    {
        private readonly IWorldEngine _engine;

        public WorldAdapterState CurrentState { get; private set; } =
            WorldAdapterState.Offline;

        public event Action<WorldAdapterState>? StateChanged;

        public WorldAdapter(IWorldEngine engine)
        {
            _engine = engine ?? throw new ArgumentNullException(nameof(engine));
        }

        private void TransitionTo(WorldAdapterState newState)
        {
            if (CurrentState == newState)
                return;

            CurrentState = newState;
            StateChanged?.Invoke(newState);
        }

        // ---------------- Lifecycle ----------------

        public void Start()
        {
            TransitionTo(WorldAdapterState.Starting);
            TransitionTo(WorldAdapterState.Connected);
        }

        public void Authenticate()
        {
            TransitionTo(WorldAdapterState.Authenticating);
            TransitionTo(WorldAdapterState.Authenticated);
        }

        public void EnterWorld()
        {
            TransitionTo(WorldAdapterState.EnteringWorld);
            TransitionTo(WorldAdapterState.InWorld);
        }

        public void Stop()
        {
            TransitionTo(WorldAdapterState.Stopping);
            TransitionTo(WorldAdapterState.Offline);
        }

        // ---------------- World Semantics ----------------

        public void OnObjectCreate(
            int id,
            string modelName,
            ReadOnlyMemory<byte> modelBytes,
            Vector3 position,
            Quaternion rotation)
        {
            _engine.AddObject(id, modelName, modelBytes, position, rotation);
        }

        public void OnObjectUpdate(
            int id,
            Vector3 position,
            Quaternion rotation)
        {
            _engine.UpdateObjectTransform(id, position, rotation);
        }

        public void OnObjectDelete(int id)
        {
            _engine.RemoveObject(id);
        }
    }
}
