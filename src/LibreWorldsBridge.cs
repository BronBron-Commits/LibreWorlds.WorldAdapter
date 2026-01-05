using System;
using System.Numerics;

namespace LibreWorlds.WorldAdapter
{
    /// <summary>
    /// Bridges LibreWorlds SDK world events into the WorldAdapter.
    ///
    /// This class:
    /// - Does NOT own lifecycle
    /// - Does NOT change adapter state
    /// - Does NOT talk to the engine directly
    ///
    /// It only forwards semantic world events.
    /// </summary>
    public sealed class LibreWorldsBridge
    {
        private readonly WorldAdapter _adapter;

        public LibreWorldsBridge(WorldAdapter adapter)
        {
            _adapter = adapter ?? throw new ArgumentNullException(nameof(adapter));
        }

        // ============================
        // SDK → Adapter (WORLD EVENTS)
        // ============================

        public void HandleObjectCreate(int id, string modelName)
        {
            _adapter.OnObjectCreate(
                id,
                modelName,
                ReadOnlyMemory<byte>.Empty,
                Vector3.Zero,
                Quaternion.Identity);
        }

        public void HandleObjectUpdate(int id)
        {
            _adapter.OnObjectUpdate(
                id,
                Vector3.Zero,
                Quaternion.Identity);
        }

        public void HandleObjectDelete(int id)
        {
            _adapter.OnObjectDelete(id);
        }
    }
}
