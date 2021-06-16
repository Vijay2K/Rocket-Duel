using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayerArea : MonoBehaviour
{
    [SerializeField] private Transform target = null;
    [SerializeField] private Transform shootPoint = null;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Enemy") {
            Projectile projectile = other.GetComponent<Projectile>();
            projectile.Launch(target.position, shootPoint.position);
        }
    }
}
