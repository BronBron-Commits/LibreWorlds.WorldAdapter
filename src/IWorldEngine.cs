// IWorldEngine.cs
using System.Numerics;

public interface IWorldEngine
{
    void AddObject(
        int id,
        string modelName,
        ReadOnlyMemory<byte> modelBytes,
        Vector3 position,
        Quaternion rotation
    );

    void UpdateObjectTransform(
        int id,
        Vector3 position,
        Quaternion rotation
    );

    void RemoveObject(int id);

    void UpdateTerrain(
        int chunkX,
        int chunkY,
        ReadOnlyMemory<float> heightmap
    );
}
