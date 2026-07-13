using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TractorController : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float turnSpeed = 90f;

    private Rigidbody _rb;
    private float _moveInput;
    private float _turnInput;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        // Смещаем центр тяжести вниз, чтобы трактор не переворачивался на поворотах
        _rb.centerOfMass = new Vector3(0, -0.5f, 0);
    }

    void Update()
    {
        // Считываем ввод пользователя
        _moveInput = Input.GetAxis("Vertical");
        _turnInput = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        // Движение вперед/назад
        Vector3 moveDistance = transform.forward * _moveInput * moveSpeed * Time.fixedDeltaTime;
        _rb.MovePosition(_rb.position + moveDistance);

        // Поворот (работает только если трактор едет, как в реальности)
        if (Mathf.Abs(_moveInput) > 0.1f)
        {
            // При движении назад инвертируем руль для удобства
            float direction = Mathf.Sign(_moveInput);
            Quaternion turnRotation = Quaternion.Euler(0f, _turnInput * turnSpeed * direction * Time.fixedDeltaTime, 0f);
            _rb.MoveRotation(_rb.rotation * turnRotation);
        }
    }
}