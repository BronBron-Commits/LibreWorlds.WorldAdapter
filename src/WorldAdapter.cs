using System.Numerics;
using LibreWorlds.WorldQueue.Commands;
using LibreWorlds.WorldQueue.Interfaces;

namespace LibreWorlds.WorldAdapter;

public sealed class WorldAdapter
{
    private long _sequence;

    private readonly IWorldCommandQueue _queue;

    public WorldAdapter(IWorldCommandQueue queue)
    {
        _queue = queue;
    }

    private long NextSeq() => ++_sequence;

    // -------------------------------
    // OBJECT CREATE
    // -------------------------------
    public void OnObjectCreate(
        long objectId,
        string modelName,
        ReadOnlyMemory<byte> modelBytes,
        Vector3 position,
        Quaternion rotation
    )
    {
        var cmd = new AddObjectCommand(
            NextSeq(),
            objectId,
            modelName,
            modelBytes,
            position,
            rotation
        );

        _queue.Enqueue(cmd);
    }

    // -------------------------------
    // OBJECT UPDATE
    // -------------------------------
    public void OnObjectUpdate(
        long objectId,
        Vector3 position,
        Quaternion rotation
    )
    {
        var cmd = new UpdateObjectTransformCommand(
            NextSeq(),
            objectId,
            position,
            rotation
        );

        _queue.Enqueue(cmd);
    }

    // -------------------------------
    // OBJECT DELETE
    // -------------------------------
    public void OnObjectDelete(long objectId)
    {
        var cmd = new RemoveObjectCommand(
            NextSeq(),
            objectId
        );

        _queue.Enqueue(cmd);
    }
}
