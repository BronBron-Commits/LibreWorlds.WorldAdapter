using System;
using System.Numerics;

namespace LibreWorlds.WorldAdapter
{
    /// <summary>
    /// Defines the authoritative execution surface for world mutations.
    /// Implemented by concrete engines (Godot, realmlib, headless, etc).
    /// </summary>
    public interface IWorldEngine
    {
        void AddObject(
            int id,
            string modelName,
            ReadOnlyMemory<byte> modelBytes,
            Vector3 position,
            Quaternion rotation);

        void UpdateObjectTransform(
            int id,
            Vector3 position,
            Quaternion rotation);

        void RemoveObject(int id);
    }
}
