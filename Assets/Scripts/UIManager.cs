using UnityEngine;
using TMPro; // Обязательно подключаем библиотеку TextMeshPro

public class UIManager : MonoBehaviour
{
    // Создаем Singleton, чтобы другие скрипты легко могли обратиться к UIManager
    public static UIManager Instance { get; private set; }

    [Header("UI Элементы")]
    public TextMeshProUGUI progressText; // Ссылка на наш текст на Canvas

    private int _processedFieldsCount = 0; // Счетчик

    private void Awake()
    {
        // Настройка Singleton: если менеджер уже существует, удаляем дубликат
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        UpdateUI();
    }

    // Этот метод будут вызывать грядки
    public void AddProcessedField()
    {
        _processedFieldsCount++;
        UpdateUI();
    }

    // Обновляем текст на экране
    private void UpdateUI()
    {
        if (progressText != null)
        {
            progressText.text = $"Обработано полей: {_processedFieldsCount}";
        }
        else
        {
            Debug.LogWarning("Progress Text не назначен в UIManager!");
        }
    }
}