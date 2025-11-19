using UnityEngine;
using UnityEngine.InputSystem;

public class DragCamera : MonoBehaviour
{
    public float dragSpeed = 2f;

    private LevelInput levelInput;

    private bool isDragging = false;
    private Vector3 dragOrigin;

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
        levelInput.Game.Click.started -= OnClickStarted;
        levelInput.Game.Click.canceled -= OnClickCanceled;
        levelInput.Game.Disable();
    }

    private void OnClickStarted(InputAction.CallbackContext ctx)
    {
        dragOrigin = levelInput.Game.Point.ReadValue<Vector2>();
        isDragging = true;
    }

    private void OnClickCanceled(InputAction.CallbackContext ctx)
    {
        isDragging = false;
    }

    void Update()
    {
        if (!isDragging) return;

        Vector2 mousePos = levelInput.Game.Point.ReadValue<Vector2>();
        Vector3 pos = Camera.main.ScreenToViewportPoint(mousePos - (Vector2)dragOrigin);

        Vector3 move = new Vector3(pos.x * dragSpeed, 0, pos.y * dragSpeed);
        transform.Translate(move, Space.World);
    }
}
