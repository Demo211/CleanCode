using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Shooter : MonoBehaviour
{    
    [SerializeField] private Bullet _prefab;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _shotDelay;

    [SerializeField] private Transform _target;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        Rigidbody spawnedBulletBody;

        while (enabled)
        {
            Vector3 shotDirection = (_target.position - transform.position).normalized;
            var newBullet = Instantiate(_prefab, transform.position + shotDirection, Quaternion.identity);

            if(newBullet.TryGetComponent<Rigidbody>(out spawnedBulletBody))
            {
                newBullet.transform.up = shotDirection;
                spawnedBulletBody.velocity = shotDirection * _bulletSpeed;
            }

            yield return new WaitForSeconds(_shotDelay);
        }
    }
}