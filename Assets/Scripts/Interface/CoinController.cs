using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CoinController : MonoBehaviour
{
    [SerializeField] private Image _coinImage;

    private void OnEnable()
    {
        _coinImage.fillAmount = 0;
    }

    public void EnableCoin() => _coinImage.DOFillAmount(1, .5f).SetUpdate(true);
}
