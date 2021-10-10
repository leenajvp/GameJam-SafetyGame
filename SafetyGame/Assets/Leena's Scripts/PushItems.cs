using UnityEngine;

public class PushItems : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            move player = collision.gameObject.GetComponent<move>();

            if (player)
            {
                //player.PushPlayer();
            }
        }
    }


}
