using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Make coin count static so it's shared across all Coin instances
    private static int coin = 0;
    public TextMeshProUGUI CoinText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Increment coin count
            coin++;

            // Update UI text
            CoinText.text = "Coins: " + coin.ToString();
            Debug.Log("Coin collected. Total coins: " + coin);

            // Destroy the coin GameObject
            Destroy(gameObject);
        }
    }
}