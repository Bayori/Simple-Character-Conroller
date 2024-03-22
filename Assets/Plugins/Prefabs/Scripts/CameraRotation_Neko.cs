using UnityEngine;
using UnityEngine.InputSystem;

public class CameraRotation_Neko : MonoBehaviour
{
    [Header("Настройки камеры игрока")]

    [Tooltip("Разрешить камере двигаться?")] public bool _AllowCameraRotate = true;
    [SerializeField, Tooltip("Тело игрока")] private Transform playerBody;
    [Tooltip("Чувствительность камеры")] public float mouseSens = 50f;

    [Space]
    [SerializeField, Tooltip("Ограничение камеры вверх")] private float lockUp = 90f;
    [SerializeField, Tooltip("Ограничение камеры вниз")] private float lockDown = -90f;

    [SerializeField, Tooltip("Заблокировать курсор игрока на старте?")] private bool _lockMouseOnStart = true;


    private float xRotation = 0f;
    private Vector2 _inputValue;

    private void LateUpdate()
    {
        if (!_AllowCameraRotate) { return; }

        float mouseX = _inputValue.x * mouseSens * Time.deltaTime;
        float mouseY = _inputValue.y * mouseSens * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, lockDown, lockUp);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void Start()
    {
        Cursor.lockState = _lockMouseOnStart ? CursorLockMode.Locked : CursorLockMode.None;
    }
    public void ReadMouseInput(InputAction.CallbackContext context)
    {
        _inputValue = context.ReadValue<Vector2>();
    }



}
