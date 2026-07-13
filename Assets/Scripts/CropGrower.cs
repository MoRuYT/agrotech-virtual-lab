using UnityEngine;
using System.Collections; // Обязательно для использования IEnumerator и корутин

[RequireComponent(typeof(Transform))]
public class CropGrower : MonoBehaviour
{
    [Header("Настройки роста")]
    [Tooltip("Время плавного роста в секундах")]
    public float growDuration = 3.0f; // Можно настроить в инспекторе для разных овощей

    private Vector3 _finalScale = Vector3.one; // Конечный масштаб, который мы хотим получить

    private void Start()
    {
        // 1. При старте (при инстанцировании) сразу скрываем овощ, устанавливая масштаб в 0.
        transform.localScale = Vector3.zero;

        // 2. Запускаем корутину плавного роста.
        StartCoroutine(GrowOverTime());
    }

    // Корутина, которая плавно увеличивает масштаб объекта.
    private IEnumerator GrowOverTime()
    {
        float elapsedTime = 0f; // Переменная для хранения прошедшего времени

        // Цикл продолжается, пока elapsedTime не достигнет growDuration.
        while (elapsedTime < growDuration)
        {
            // Рассчитываем текущий процент завершения роста (от 0.0 до 1.0).
            float normalizedTime = elapsedTime / growDuration;

            // Плавная интерполяция масштаба от Vector3.zero до _finalScale.
            transform.localScale = Vector3.Lerp(Vector3.zero, _finalScale, normalizedTime);

            // Прибавляем время, прошедшее с прошлого кадра.
            elapsedTime += Time.deltaTime;

            // Ждем один кадр, чтобы Unity мог отрендерить сцену.
            yield return null;
        }

        // После завершения цикла, гарантированно устанавливаем точный конечный масштаб.
        transform.localScale = _finalScale;

        Debug.Log($"Рост овоща '{gameObject.name}' завершен.");
    }
}