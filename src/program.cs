using LibreWorlds.WorldAdapter;

class Program
{
    static void Main()
    {
        var engine = new RealmlibWorldEngine();
        var adapter = new WorldAdapter(engine);

        adapter.Start();
        adapter.Authenticate();
        adapter.EnterWorld();
    }
}
