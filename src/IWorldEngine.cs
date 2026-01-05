using System.Numerics;

namespace LibreWorlds.WorldAdapter;

public interface IWorldEngine
{
    void AddObject(
        long objectId,
        string modelName,
        ReadOnlyMemory<byte> modelBytes,
        Vector3 position,
        Quaternion rotation
    );

    void UpdateObjectTransform(
        long objectId,
        Vector3 position,
        Quaternion rotation
    );

    void RemoveObject(long objectId);
}
