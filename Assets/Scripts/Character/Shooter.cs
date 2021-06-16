using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Transform shootingPoint = null;
    private Projectile projectile;
    private FinishLineTrigger finishLineTrigger;

    private void Start() {
        projectile = GetComponent<Projectile>();
        finishLineTrigger = GameObject.FindObjectOfType<FinishLineTrigger>();
    }

    private void Update() {
        if (Obstacles.GetGameStatus()) return;
        if (finishLineTrigger.GetLevelEnd()) return;
        Shoot();
    }

    public void Shoot() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
            if (Input.GetMouseButton(0)) {
                //gun.LookAt(hit.point);
                projectile.ShowTrajectory(shootingPoint.position, hit.point);
            } else {
                projectile.SetTrajectory(false);
            }

            if (Input.GetMouseButtonUp(0)) {
                projectile.Launch(hit.point, shootingPoint.position);
            }
        } else {
            projectile.SetTrajectory(false);
        }



    }
}
