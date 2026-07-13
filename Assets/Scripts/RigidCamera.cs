using UnityEngine;

public class RigidCamera : MonoBehaviour
{
    public Transform target; // Твоя точка CameraTargetPoint
    public Vector3 offset = new Vector3(0, 5, -8);

    void LateUpdate()
    {
        if (target == null) return;

        // Просто приравниваем позицию. Никакого Lerp, никакого SmoothDamp.
        // Камера будет двигаться мгновенно за целью.
        transform.position = target.position + offset;

        // Если хочешь, чтобы камера всегда смотрела на трактор:
        transform.LookAt(target);
    }
}