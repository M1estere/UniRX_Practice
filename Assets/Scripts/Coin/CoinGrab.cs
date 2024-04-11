using UnityEngine;

public class CoinGrab : MonoBehaviour
{
    private CoinDisplay _coinDisplay;
    
    private void OnEnable()
    {
        _coinDisplay = FindObjectOfType<CoinDisplay>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerMovement player) == false) return;
        
        _coinDisplay.TakeCoin();
        Destroy(gameObject);
    }
}
