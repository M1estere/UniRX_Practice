using UnityEngine;

public class CoinGrab : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlayerMovement player) == false) return;
        
        
    }
}
