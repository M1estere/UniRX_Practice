using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HeartController : MonoBehaviour
{
    [SerializeField] private Image _heartImage;

    private void OnEnable()
    {
        _heartImage.fillAmount = 1;
    }
    
    public void DisableHeart() => _heartImage.DOFillAmount(0, .5f).SetUpdate(true);
}
