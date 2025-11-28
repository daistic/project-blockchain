using UnityEngine;
using UnityEngine.InputSystem;

public class DragCamera : MonoBehaviour
{
    public float dragSpeed = 2f;

    [SerializeField] float leftBorder = -20f;
    [SerializeField] float rightBorder = 20f;

    private LevelInput levelInput;
    private bool isDragging = false;
    private Vector2 lastMousePos;

    private void Awake()
    {
        levelInput = new LevelInput();
    }

    private void OnEnable()
    {
        levelInput.Game.Enable();
        levelInput.Game.Click.performed += OnClickStarted;
        levelInput.Game.Click.canceled += OnClickCanceled;
    }

    private void OnDisable()
    {
        levelInput.Game.Click.performed -= OnClickStarted;
        levelInput.Game.Click.canceled -= OnClickCanceled;
        levelInput.Game.Disable();
    }

    private void OnClickStarted(InputAction.CallbackContext ctx)
    {
        lastMousePos = levelInput.Game.Point.ReadValue<Vector2>();
        isDragging = true;
    }

    private void OnClickCanceled(InputAction.CallbackContext ctx)
    {
        isDragging = false;
    }

    void Update()
    {
        if (!isDragging) return;

        Vector2 currentMousePos = levelInput.Game.Point.ReadValue<Vector2>();
        Vector3 delta = Camera.main.ScreenToViewportPoint(currentMousePos - lastMousePos);
        Vector3 move = new Vector3(delta.x * dragSpeed, 0, delta.y * dragSpeed) * -1;

        // Clamp the actual movement magnitude per frame to prevent huge jumps
        move = Vector3.ClampMagnitude(move, 1.5f);

        // Calculate proposed target position
        Vector3 targetPosition = transform.position + move;
        targetPosition.x = Mathf.Clamp(targetPosition.x, leftBorder, rightBorder);

        transform.position = targetPosition;
        lastMousePos = currentMousePos;
    }
}