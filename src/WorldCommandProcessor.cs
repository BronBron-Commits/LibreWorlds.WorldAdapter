using LibreWorlds.WorldQueue.Interfaces;
using LibreWorlds.WorldQueue.Commands;

namespace LibreWorlds.WorldAdapter
{
    public sealed class WorldCommandProcessor
    {
        private readonly IWorldEngine _engine;

        public WorldCommandProcessor(IWorldEngine engine)
        {
            _engine = engine;
        }

        public void Execute(IWorldCommand command)
        {
            switch (command)
            {
                case AddObjectCommand add:
                    _engine.AddObject(
                        add.ObjectId,
                        add.ModelName,
                        add.ModelBytes,
                        add.Position,
                        add.Rotation);
                    break;

                case UpdateObjectTransformCommand update:
                    _engine.UpdateObjectTransform(
                        update.ObjectId,
                        update.Position,
                        update.Rotation);
                    break;

                case RemoveObjectCommand remove:
                    _engine.RemoveObject(remove.ObjectId);
                    break;
            }
        }
    }
}
