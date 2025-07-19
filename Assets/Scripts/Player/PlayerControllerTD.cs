using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerControllerTD : MonoBehaviour
{
    [SerializeField] private float playerMaxHealth = 100f;
    
    private float playerCurrentHealth;
    private float playerRotationSpeed = 60f;

    private void Start()
    {
        playerCurrentHealth = playerMaxHealth;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) RotatePlayer(-1f);
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) RotatePlayer(1f);
    }

    private void RotatePlayer(float direction)
    {
        transform.Rotate(0, direction * playerRotationSpeed * Time.deltaTime, 0);
    }

    public void DecreaseHealth()
    {
        playerCurrentHealth -= 10f;
        
        UIManagerTD.Instance.UpdateHealthBar(playerCurrentHealth / playerMaxHealth);
        
        if (playerCurrentHealth <= 0)
        {
            PlayerGameOver();
        }
    }

    private void PlayerGameOver()
    {
        GameManager.Instance.StopSpawning();
        UIManagerTD.Instance.ShowGameOver();
        
        playerCurrentHealth = playerMaxHealth;
        UIManagerTD.Instance.UpdateHealthBar(playerCurrentHealth / playerMaxHealth);
    }
    
}
