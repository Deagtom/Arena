using UnityEngine;

public class Weapon : MonoBehaviour
{
   private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
            Destroy(collision.gameObject);
    }
}