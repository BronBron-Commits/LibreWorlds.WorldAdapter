using System.Numerics;
using LibreWorlds.WorldQueue.Commands;
using LibreWorlds.WorldQueue.Interfaces;

namespace LibreWorlds.WorldAdapter
{
    public sealed class WorldAdapter
    {
        private readonly IWorldCommandQueue _queue;

        public WorldAdapter(IWorldCommandQueue queue)
        {
            _queue = queue;
        }

        public void OnObjectCreate(
            int id,
            string modelName,
            ReadOnlyMemory<byte> modelBytes,
            Vector3 position,
            Quaternion rotation)
        {
            _queue.Enqueue(new AddObjectCommand(
                id, modelName, modelBytes, position, rotation));
        }

        public void OnObjectUpdate(
            int id,
            Vector3 position,
            Quaternion rotation)
        {
            _queue.Enqueue(new UpdateObjectTransformCommand(
                id, position, rotation));
        }

        public void OnObjectDelete(int id)
        {
            _queue.Enqueue(new RemoveObjectCommand(id));
        }
    }
}
