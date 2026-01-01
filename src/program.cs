using System;

class Program
{
    static void Main()
    {
        var engine = new RealmlibWorldEngine();
        var adapter = new WorldAdapter(engine);
        var assets = new AssetResolver();
        var bridge = new LibreWorldsBridge(adapter, assets);

        bridge.EmitObject(
            id: 1,
            modelName: "tree01.rwx",
            x: 0f,
            y: 0f,
            z: 0f,
            yaw: 0f,
            pitch: 0f,
            roll: 0f
        );

        Console.WriteLine("WorldAdapter test completed.");
    }
}

