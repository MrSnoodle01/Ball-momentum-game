using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    public InputActionAsset playerActions;

    private InputAction dashAction;
    private InputAction boostAction;
    private Rigidbody2D rb2d;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dashAction = playerActions.FindAction("Dash");
        boostAction = playerActions.FindAction("Boost");
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // boost in direction of current velocity
        if(boostAction != null && boostAction.triggered && rb2d.linearVelocity.x < 20 && rb2d.linearVelocity.y < 20)
        {
            rb2d.linearVelocity *= 1.25f;
        }

        // dash towards mouse position using current velocity
        if(dashAction != null && dashAction.triggered)
        {
            float totalVelocity = Mathf.Abs(rb2d.linearVelocity.x) + Mathf.Abs(rb2d.linearVelocity.y);

            Vector2 directionToMouse = (Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - transform.position).normalized;

            rb2d.linearVelocity = directionToMouse * totalVelocity;
        }
    }
}
