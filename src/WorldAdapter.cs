// WorldAdapter.cs
using System.Numerics;

public sealed class WorldAdapter
{
    private readonly IWorldEngine _engine;

    public WorldAdapter(IWorldEngine engine)
    {
        _engine = engine;
    }

    public void OnObjectCreate(
        WorldObject obj,
        ReadOnlyMemory<byte> modelBytes)
    {
        _engine.AddObject(
            obj.Id,
            obj.ModelName,
            modelBytes,
            obj.Position,
            obj.Rotation);
    }

    public void OnObjectUpdate(WorldObject obj)
    {
        _engine.UpdateObjectTransform(
            obj.Id,
            obj.Position,
            obj.Rotation);
    }

    public void OnObjectDelete(int id)
    {
        _engine.RemoveObject(id);
    }
}

