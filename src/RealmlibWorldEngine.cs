using System;
using System.Numerics;

public sealed class RealmlibWorldEngine : IWorldEngine
{
    public RealmlibWorldEngine()
    {
        RealmlibNative.realmlib_init();
    }

    public void AddObject(
        int id,
        string modelName,
        ReadOnlyMemory<byte> modelBytes,
        Vector3 position,
        Quaternion rotation)
    {
        RealmlibNative.realmlib_add_object(
            id,
            modelName,
            modelBytes.ToArray(),
            (nuint)modelBytes.Length);
    }

    public void UpdateObjectTransform(
        int id,
        Vector3 position,
        Quaternion rotation)
    {
        // next phase
    }

    public void RemoveObject(int id)
    {
        // next phase
    }

    public void UpdateTerrain(
        int chunkX,
        int chunkY,
        ReadOnlyMemory<float> heightmap)
    {
        // next phase
    }
}
