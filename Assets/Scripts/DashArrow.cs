using UnityEngine;
using UnityEngine.InputSystem;

public class DashArrow : MonoBehaviour
{
    private GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 directionToMouse = (Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - player.transform.position).normalized;

        float angle = Mathf.Atan2(directionToMouse.y, directionToMouse.x) * Mathf.Rad2Deg - 90f;

        transform.RotateAround(player.transform.position, Vector3.forward, angle - transform.rotation.eulerAngles.z);
    }
}
