using UnityEngine;

public class FieldZone : MonoBehaviour
{
    [Header("Настройки урожая")]
    public GameObject cropPrefab; // Сюда кладем префаб овоща
    public Transform[] spawnPoints; // Точки, где появятся овощи

    private bool _isProcessed = false;

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, что в зону заехал именно трактор, а не что-то еще
        if (!_isProcessed && other.CompareTag("Tractor"))
        {
            ProcessField();
        }
    }

    private void ProcessField()
    {
        _isProcessed = true;

        GetComponent<Renderer>().material.color = new Color(0.35f, 0.25f, 0.15f);

        foreach (Transform point in spawnPoints)
        {
            Instantiate(cropPrefab, point.position, point.rotation, transform);
        }

        // --- НОВАЯ СТРОКА ---
        // Обращаемся к UI менеджеру через Singleton и увеличиваем счетчик
        if (UIManager.Instance != null)
        {
            UIManager.Instance.AddProcessedField();
        }

        Debug.Log("Поле обработано: Посадка завершена.");
    }
}