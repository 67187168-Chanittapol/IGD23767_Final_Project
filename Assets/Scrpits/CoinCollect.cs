
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    [Header("Coin Settings")]
    [SerializeField] private int coinValue = 1;

    public int CoinValue => coinValue;

    [Header("Sound Settings")]
    [SerializeField] private AudioClip collectSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collected Coin! Value: " + coinValue);

            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlaySFX(collectSound);
            }

            Destroy(gameObject);
        }
    }
}
