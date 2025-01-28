using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField]
    private float _bulletspeed;

    private void OnEnable()
    {
        if(_rigidbody == null)
        {
            _rigidbody = gameObject.GetComponent<Rigidbody>();
        }
        _rigidbody.AddForce(transform.forward * _bulletspeed, ForceMode.Impulse);
    }
}
