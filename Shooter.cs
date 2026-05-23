using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Shooter : MonoBehaviour
{    
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _shotDelay;

    [SerializeField] private Transform Target;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        while (enabled)
        {
            Vector3 _shotDirection = (Target.position - transform.position).normalized;
            var NewBullet = Instantiate(_prefab, transform.position + _shotDirection, Quaternion.identity);

            NewBullet.GetComponent<Rigidbody>().transform.up = _shotDirection;
            NewBullet.GetComponent<Rigidbody>().velocity = _shotDirection * _bulletSpeed;

            yield return new WaitForSeconds(_shotDelay);
        }
    }
}