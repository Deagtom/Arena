using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
            Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}