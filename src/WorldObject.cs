using System.Numerics;

public sealed class WorldObject
{
    public int Id { get; init; }
    public string ModelName { get; init; } = string.Empty;

    public Vector3 Position { get; init; }
    public Quaternion Rotation { get; init; }
}
