using System;
using System.Numerics;
using LibreWorlds.WorldQueue.Queue;

namespace LibreWorlds.WorldAdapter
{
    public static class DebugHarness
    {
        public static void Run()
        {
            var queue = new WorldCommandQueue();
            var adapter = new WorldAdapter(queue);

            adapter.StateChanged += s =>
                Console.WriteLine($"[STATE] {s}");

            adapter.Start();
            adapter.Authenticate();
            adapter.EnterWorld();

            adapter.OnObjectCreate(
                1,
                "tree01.rwx",
                ReadOnlyMemory<byte>.Empty,
                Vector3.Zero,
                Quaternion.Identity);

            adapter.OnObjectUpdate(
                1,
                new Vector3(5, 0, 2),
                Quaternion.Identity);

            adapter.OnObjectDelete(1);

            adapter.Drain(cmd =>
            {
                Console.WriteLine($"[CMD] {cmd}");
            });
        }
    }
}
