using UnityEngine;

public class PlayerFinder : MonoBehaviour
{
    private GameObject player;
    private bool isPlayerTriggered = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Avatar"))
        {
            player = other.gameObject;
            isPlayerTriggered = true;
        }
    }

    public Vector3 GetPlayerPosition()
    {
        if (player != null)
        {
            return player.transform.position;
        }
        else
            return new Vector3();
    }

    public Inventory GetPlayerInventory()
    {
        if (isPlayerTriggered)
        {
            return player.GetComponent<Inventory>();
        }

        else return null;
    }
}
