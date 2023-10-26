namespace Raylib_cs.Extensions;

public static partial class ModelAnimationEx
{
    public static void Unload(this ModelAnimation animation) 
        => Raylib.UnloadModelAnimation(animation);
    
    public static unsafe void Unload(this Span<ModelAnimation> animations)
    { fixed (ModelAnimation* ptr = animations) Raylib.UnloadModelAnimations(ptr, (uint)animations.Length); }
    
    public static unsafe void Unload(this ReadOnlySpan<ModelAnimation> animations)
    { fixed (ModelAnimation* ptr = animations) Raylib.UnloadModelAnimations(ptr, (uint)animations.Length); }

    public static unsafe void Unload(this ModelAnimation[] animations)
        => Unload(animations.AsSpan());
}