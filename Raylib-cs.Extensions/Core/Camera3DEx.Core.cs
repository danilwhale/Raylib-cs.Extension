using System.Numerics;

namespace Raylib_cs.Extensions;

public static partial class Camera3DEx
{
    /// <summary>
    /// Begin 3D mode with custom camera (3D)
    /// </summary>
    public static void BeginMode(this Camera3D camera) => Raylib.BeginMode3D(camera);
    
    /// <summary>
    /// Ends 3D mode and returns to default 2D orthographic mode
    /// </summary>
    public static void EndMode(this Camera3D camera) => Raylib.EndMode3D();
    
    /// <summary>
    /// Get a ray trace from mouse position
    /// </summary>
    public static Ray GetMouseRay(this Camera3D camera, Vector2 mousePosition) =>
        Raylib.GetMouseRay(mousePosition, camera);
    
    /// <summary>
    /// Get the screen space position for a 3d world space position
    /// </summary>
    public static Vector2 GetWorldToScreen(this Camera3D camera, Vector3 position) =>
        Raylib.GetWorldToScreen(position, camera);
    
    /// <summary>
    /// Get size position for a 3d world space position
    /// </summary>
    public static Vector2 GetWorldToScreen(this Camera3D camera, Vector3 position, int width, int height) =>
        Raylib.GetWorldToScreenEx(position, camera, width, height);
    
    /// <summary>
    /// Get camera transform matrix (view matrix)
    /// </summary>
    public static Matrix4x4 GetMatrix(this Camera3D camera) => Raylib.GetCameraMatrix(camera);
    
    /// <summary>
    /// Update camera position for selected mode
    /// </summary>
    public static void Update(this ref Camera3D camera, CameraMode mode) => Raylib.UpdateCamera(ref camera, mode);
    
    /// <summary>
    /// Update camera movement/rotation
    /// </summary>
    public static void Update(this ref Camera3D camera, Vector3 movement, Vector3 rotation, float zoom) =>
        Raylib.UpdateCameraPro(ref camera, movement, rotation, zoom);
    
    // rcamera.h
    
    /// <summary>
    /// Returns the cameras forward vector (normalized)
    /// </summary>
    public static unsafe Vector3 GetForward(this ref Camera3D camera)
    { fixed (Camera3D* ptr = &camera) return Raylib.GetCameraForward(ptr); }
    
    /// <summary>
    /// Returns the cameras right vector (normalized)
    /// </summary>
    public static unsafe Vector3 GetRight(this ref Camera3D camera)
    { fixed (Camera3D* ptr = &camera) return Raylib.GetCameraRight(ptr); }
    
    /// <summary> 
    /// Returns the cameras up vector (normalized) <br/>
    /// Note: The up vector might not be perpendicular to the forward vector
    /// </summary>
    public static unsafe Vector3 GetUp(this ref Camera3D camera)
    { fixed (Camera3D* ptr = &camera) return Raylib.GetCameraUp(ptr); }
    
    
    /// <summary>
    /// Moves the camera in its forward direction
    /// </summary>
    public static unsafe void MoveForward(this ref Camera3D camera, float distance, bool inWorldPlane)
    { fixed (Camera3D* ptr = &camera) Raylib.CameraMoveForward(ptr, distance, inWorldPlane); }
    
    /// <summary>
    /// Moves the camera target in its current right direction
    /// </summary>
    public static unsafe void MoveRight(this ref Camera3D camera, float distance, bool inWorldPlane)
    { fixed (Camera3D* ptr = &camera) Raylib.CameraMoveRight(ptr, distance, inWorldPlane); }
    
    /// <summary>
    /// Moves the camera in its up direction
    /// </summary>
    public static unsafe void MoveUp(this ref Camera3D camera, float distance)
    { fixed (Camera3D* ptr = &camera) Raylib.CameraMoveUp(ptr, distance); }
    
    /// <summary>
    /// Moves the camera position closer/farther to/from the camera target
    /// </summary>
    public static unsafe void MoveToTarget(this ref Camera3D camera, float delta)
    { fixed (Camera3D* ptr = &camera) Raylib.CameraMoveToTarget(ptr, delta); }
    
    
    /// <summary>
    /// Rotates the camera around its up vector <br/>
    /// Yaw is "looking left and right" <br/>
    /// If rotateAroundTarget is false, the camera rotates around its position <br/>
    /// Note: angle must be provided in radians (set 'useDegrees' to 'true' if you use degrees)
    /// </summary>
    public static unsafe void RotateYaw(this ref Camera3D camera, float angle, bool rotateAroundTarget, bool useDegrees = false)
    { fixed (Camera3D* ptr = &camera) Raylib.CameraYaw(ptr, useDegrees ? angle * Raylib.DEG2RAD : angle, rotateAroundTarget); }
        
    /// <summary>
    /// Rotates the camera around its right vector, pitch is "looking up and down" <br/>
    ///  - lockView prevents camera overrotation (aka "somersaults") <br/>
    ///  - rotateAroundTarget defines if rotation is around target or around its position <br/>
    ///  - rotateUp rotates the up direction as well (typically only usefull in CAMERA_FREE) <br/>
    /// NOTE: angle must be provided in radians (set 'useDegrees' to 'true' if you use degrees)
    /// </summary>
    public static unsafe void RotatePitch(this ref Camera3D camera, float angle, bool lockView, bool rotateAroundTarget, bool rotateUp, bool useDegrees = false)
    { fixed (Camera3D* ptr = &camera) Raylib.CameraPitch(ptr, useDegrees ? angle * Raylib.DEG2RAD : angle, lockView, rotateAroundTarget, rotateUp); }
    
    /// <summary>
    /// Rotates the camera around its forward vector <br/>  
    /// Roll is "turning your head sideways to the left or right" <br/> 
    /// Note: angle must be provided in radians (set 'useDegrees' to 'true' if you use degrees)
    /// </summary>
    public static unsafe void RotateRoll(this ref Camera3D camera, float angle, bool useDegrees = false)
    { fixed (Camera3D* ptr = &camera) Raylib.CameraRoll(ptr, useDegrees ? angle * Raylib.DEG2RAD : angle); }
    
    
    /// <summary>
    /// Returns the camera view matrix
    /// </summary>
    public static unsafe Matrix4x4 GetViewMatrix(this ref Camera3D camera)
    { fixed (Camera3D* ptr = &camera) return Raylib.GetCameraViewMatrix(ptr); }
    
    /// <summary>
    /// Returns the camera projection matrix
    /// </summary>
    public static unsafe Matrix4x4 GetProjectionMatrix(this ref Camera3D camera)
    { fixed (Camera3D* ptr = &camera) return Raylib.GetCameraProjectionMatrix(ptr, (float)Raylib.GetScreenWidth() / Raylib.GetScreenHeight()); }
    
    /// <summary>
    /// Returns the camera projection matrix
    /// </summary>
    public static unsafe Matrix4x4 GetProjectionMatrix(this ref Camera3D camera, float aspect)
    { fixed (Camera3D* ptr = &camera) return Raylib.GetCameraProjectionMatrix(ptr, aspect); }
}