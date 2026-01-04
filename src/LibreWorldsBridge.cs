using System;
using System.Numerics;
using LibreWorlds.WorldAdapter;

namespace LibreWorlds.WorldAdapter
{
    /// <summary>
    /// Bridges LibreWorlds SDK events into the WorldAdapter.
    /// This class does NOT own state and does NOT touch the engine directly.
    /// </summary>
    public sealed class LibreWorldsBridge
    {
        private readonly WorldAdapter _adapter;

        public LibreWorldsBridge(WorldAdapter adapter)
        {
            _adapter = adapter ?? throw new ArgumentNullException(nameof(adapter));
        }

        // ---------------- SDK → Adapter ----------------

        public void HandleObjectCreate(int id, string modelName)
        {
            // NOTE:
            // SDK does not yet provide model bytes or transforms here.
            // We forward structurally complete data without inventing facts.

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
