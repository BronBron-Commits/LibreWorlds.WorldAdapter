using System.Numerics;
using LibreWorlds.Sdk.Core.Api;   // <-- actual SDK surface

public sealed class LibreWorldsBridge
{
    private readonly WorldAdapter _adapter;
    private readonly AssetResolver _assets;

    public LibreWorldsBridge(
        WorldAdapter adapter,
        AssetResolver assets)
    {
        _adapter = adapter;
        _assets = assets;
    }

    // Called when YOU decide an object "exists"
    public void EmitObject(
        int id,
        string modelName,
        float x, float y, float z,
        float yaw, float pitch, float roll)
    {
        var obj = new WorldObject
        {
            Id = id,
            ModelName = modelName,
            Position = new Vector3(x, y, z),
            Rotation = Quaternion.CreateFromYawPitchRoll(
                yaw, pitch, roll)
        };

        var bytes = _assets.GetModelBytes(modelName);
        _adapter.OnObjectCreate(obj, bytes);
    }

    public void EmitObjectUpdate(
        int id,
        float x, float y, float z,
        float yaw, float pitch, float roll)
    {
        var obj = new WorldObject
        {
            Id = id,
            Position = new Vector3(x, y, z),
            Rotation = Quaternion.CreateFromYawPitchRoll(
                yaw, pitch, roll)
        };

        _adapter.OnObjectUpdate(obj);
    }

    public void EmitObjectDelete(int id)
    {
        _adapter.OnObjectDelete(id);
    }
}
