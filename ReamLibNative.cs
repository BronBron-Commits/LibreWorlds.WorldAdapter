internal static class RealmlibNative
{
    [DllImport("realmlib_ffi.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void realmlib_init();

    [DllImport("realmlib_ffi.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void realmlib_add_object(
        int id,
        string modelName,
        byte[] data,
        nuint len);

    [DllImport("realmlib_ffi.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void realmlib_update_transform(
        int id,
        float x, float y, float z,
        float yaw, float pitch, float roll);

    [DllImport("realmlib_ffi.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void realmlib_remove_object(int id);

    [DllImport("realmlib_ffi.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void realmlib_update_terrain(
        int chunkX,
        int chunkZ,
        nuint heightCount);

    [DllImport("realmlib_ffi.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void realmlib_shutdown();
}
