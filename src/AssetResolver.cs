using System;
using System.Text;

public sealed class AssetResolver
{
    public ReadOnlyMemory<byte> GetModelBytes(string modelName)
    {
        // TEMP STUB:
        // This lets the adapter run end-to-end.
        // realmlib / engine will receive bytes.
        // Replace this later with real asset logic.

        var fakeData = $"FAKE MODEL DATA FOR {modelName}";
        return Encoding.ASCII.GetBytes(fakeData);
    }
}
