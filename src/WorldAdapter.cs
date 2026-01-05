using System;
using System.Numerics;
using LibreWorlds.WorldQueue;
using LibreWorlds.WorldQueue.Commands;
using LibreWorlds.WorldQueue.Interfaces;

namespace LibreWorlds.WorldAdapter
{
    public sealed class WorldAdapter
    {
        private readonly IWorldCommandQueue _queue;

        public WorldAdapterState CurrentState { get; private set; } =
            WorldAdapterState.Offline;

        public event Action<WorldAdapterState>? StateChanged;

        private long _sequence;

        public WorldAdapter(IWorldCommandQueue queue)
        {
            _queue = queue ?? throw new ArgumentNullException(nameof(queue));
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
            int objectId,
            string modelName,
            ReadOnlyMemory<byte> modelBytes,
            Vector3 position,
            Quaternion rotation)
        {
            _queue.Enqueue(new AddObjectCommand(
                NextSeq(),
                objectId,
                modelName,
                modelBytes,
                position,
                rotation));
        }

        public void OnObjectUpdate(
            int objectId,
            Vector3 position,
            Quaternion rotation)
        {
            _queue.Enqueue(new UpdateObjectTransformCommand(
                NextSeq(),
                objectId,
                position,
                rotation));
        }

        public void OnObjectDelete(int objectId)
        {
            _queue.Enqueue(new RemoveObjectCommand(
                NextSeq(),
                objectId));
        }

        // ---------------- Drain ----------------

        public void Drain(Action<IWorldCommand> consumer)
        {
            while (_queue.TryDequeue(out var cmd))
            {
                consumer(cmd);
            }
        }

        private long NextSeq() => ++_sequence;
    }
}
