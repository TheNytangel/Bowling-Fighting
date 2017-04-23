using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : NetworkBehaviour {
    // Max player health
    public const int maxHealth = 25;

    // SyncVar that syncs with server and calls OnHealthChange when the value gets changed
    [SyncVar(hook = "OnHealthChange")]
    public int currentHealth = maxHealth;

    // Health bar/text above player's head
    public RectTransform healthBar;
    public Text healthText;

    // Use this for initialization
    void Start () {
        // Set the health
        currentHealth = maxHealth;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage(int amount)
    {
        // Check to make sure it's not the server
        if (!isServer)
            return;

        // Subtract health
        currentHealth -= amount;

        if(currentHealth <= 0)
        {
            // Dead
            currentHealth = 0;
        }
    }

    private void OnHealthChange(int health)
    {
        // Update HUD
        healthText.text = health + "/" + maxHealth;
        healthBar.sizeDelta = new Vector2(health * 10, healthBar.sizeDelta.y);

        // If health is now less than 0, stop the client and told them they lost
        if(health <= 0 && isLocalPlayer)
        {
            GameManager.instance.networkManager.StopClient();
            SceneManager.LoadScene("Lose");
        }
    }
}
