using UnityEngine;

public class BoostArrow : MonoBehaviour
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
        Vector2 velocityDirection = player.GetComponent<Rigidbody2D>().linearVelocity.normalized;

        float angle = Mathf.Atan2(velocityDirection.y, velocityDirection.x) * Mathf.Rad2Deg - 90f;

        transform.RotateAround(player.transform.position, Vector3.forward, angle - transform.rotation.eulerAngles.z);
    }
}
