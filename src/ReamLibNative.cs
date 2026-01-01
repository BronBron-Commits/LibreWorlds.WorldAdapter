using System.Runtime.InteropServices;

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
    public static extern void realmlib_shutdown();
}
