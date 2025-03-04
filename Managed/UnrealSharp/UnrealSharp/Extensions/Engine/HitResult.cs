namespace UnrealSharp.Engine;

public partial struct FHitResult
{
    /// <summary>
    /// The hit Actor.
    /// </summary>
    public AActor? Actor => bBlockingHit ? Component.Object!.Owner : null;
}