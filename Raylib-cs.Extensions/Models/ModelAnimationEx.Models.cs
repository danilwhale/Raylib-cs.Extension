namespace Raylib_cs.Extensions;

public static class ModelAnimationEx
{
    /// <summary>
    ///     Unload animation data
    /// </summary>
    public static void Unload(this ModelAnimation animation)
    {
        Raylib.UnloadModelAnimation(animation);
    }

    /// <summary>
    ///     Unload animation array data
    /// </summary>
    public static unsafe void Unload(this Span<ModelAnimation> animations)
    {
        fixed (ModelAnimation* ptr = animations)
        {
            Raylib.UnloadModelAnimations(ptr, (uint)animations.Length);
        }
    }

    /// <summary>
    ///     Unload animation array data
    /// </summary>
    public static unsafe void Unload(this ReadOnlySpan<ModelAnimation> animations)
    {
        fixed (ModelAnimation* ptr = animations)
        {
            Raylib.UnloadModelAnimations(ptr, (uint)animations.Length);
        }
    }

    /// <summary>
    ///     Unload animation array data
    /// </summary>
    public static void Unload(this ModelAnimation[] animations)
    {
        Unload(animations.AsSpan());
    }
}