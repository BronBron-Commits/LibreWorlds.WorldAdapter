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
        var euler = rotation.ToEulerAngles();
        RealmlibNative.realmlib_update_transform(
            id,
            position.X, position.Y, position.Z,
            euler.Y, euler.X, euler.Z);
    }

    public void RemoveObject(int id)
    {
        RealmlibNative.realmlib_remove_object(id);
    }

    public void UpdateTerrain(
        int chunkX,
        int chunkY,
        ReadOnlyMemory<float> heightmap)
    {
        RealmlibNative.realmlib_update_terrain(
            chunkX,
            chunkY,
            (nuint)heightmap.Length);
    }
}
