using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            gameObject.SetActive(false);
            player.HasKey = true;
        }
    }
}
