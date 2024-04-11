using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 5f;

    private void Update()
    {
        transform.Rotate(0, 0, rotateSpeed, Space.Self);
    }
}
