using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public Transform target;
    
    [SerializeField] private float enemyMaxHealth = 30;
    [SerializeField] private float enemyCurrentHealth;
    [SerializeField] private float enemySpeed = 30;
    [SerializeField] private Image healthImageFill;

    private void Start()
    {
        // Randomize enemy hp
        enemyMaxHealth = Random.Range(10, 50);
        enemyCurrentHealth = enemyMaxHealth;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, enemySpeed * Time.deltaTime);
        transform.LookAt(target);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerControllerTD player))
        {
            // We need to decrease the player health and destroy the enemy
            player.DecreaseHealth();
            AudioManagerTD.Instance.PlayEnemyDeath();
            Destroy(gameObject);
        }
    }

    public void DecreaseEnemyHealth(float damage)
    {
        enemyCurrentHealth -= damage;
        healthImageFill.fillAmount = (enemyCurrentHealth / enemyMaxHealth);
        if (enemyCurrentHealth <= 0)
        {
            GameManager.Instance.IncreaseScore();
            AudioManagerTD.Instance.PlayEnemyDeath();
            Destroy(gameObject);
        }
    }
}
