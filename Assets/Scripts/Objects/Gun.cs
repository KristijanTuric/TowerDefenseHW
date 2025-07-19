using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform muzzlePosition;
    [SerializeField] private GameObject bulletPrefab;

    private const float shootingCooldown = 0.5f;
    private float timer = shootingCooldown;
    private void Update()
    {
        timer -= Time.deltaTime;
        
        if (Input.GetKeyDown(KeyCode.Space) && timer <= 0f)
        {
            AudioManagerTD.Instance.PlayGunshot();
            Instantiate(bulletPrefab, muzzlePosition.position, muzzlePosition.rotation);
            timer = shootingCooldown;
        }
    }
}
