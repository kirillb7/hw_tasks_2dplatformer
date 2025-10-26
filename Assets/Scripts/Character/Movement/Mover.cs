using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 5;

    public void Move(float direction)
    {
        transform.Translate(_speed * direction * Time.deltaTime * Vector2.right, Space.World);
    }
}
