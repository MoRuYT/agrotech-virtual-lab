using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [Header("Настройки слежения")]
    public Transform target; // Перетащи сюда твой CameraTargetPoint
    public float smoothTime = 0.3f; // Время "задержки" (чем больше, тем плавнее)

    [Header("Смещение камеры")]
    public Vector3 offset = new Vector3(0, 5, -8); // Настрой расстояние тут

    private Vector3 _currentVelocity = Vector3.zero;

    // LateUpdate выполняется после всех движений физики
    // Это критично, чтобы камера не дрожала
    void LateUpdate()
    {
        if (target == null) return;

        // Вычисляем желаемую позицию
        // target.position + смещение, которое мы задали
        Vector3 targetPosition = target.position + offset;

        // Плавное движение к цели (используем SmoothDamp — это профессиональный стандарт)
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);

        // Камера всегда смотрит на объект-цель
        transform.LookAt(target);
    }
}