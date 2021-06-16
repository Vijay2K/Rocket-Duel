using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody bulletPrefab = null;
    [SerializeField] private Transform shootPoint = null;
    [SerializeField] private LineRenderer trajectoryLine = null;

    private Camera cam;

    private void Start() {
        cam = Camera.main;    
    }

    private void Update() {
       // Launch();              
    }

    public void SetTrajectory(bool active) => trajectoryLine.enabled = active;

    public void Launch(Vector3 target, Vector3 origin) {
        Vector3 velocity = CalculateVelocity(target, origin, 1f);
        Rigidbody bulletInstance = Instantiate(bulletPrefab, origin, Quaternion.identity);
        bulletInstance.velocity = velocity;
    }

    public void ShowTrajectory(Vector3 origin, Vector3 target) {
        SetTrajectory(true);
        Vector3 distance = target - origin;
        int segmentCount = 10;
        Vector3[] segements = new Vector3[segmentCount];
        segements[0] = origin;

        Vector3 segementVelocity = CalculateVelocity(target, origin, 1f);

        for(int i = 1; i <segmentCount; i++) {
            float timeCurve = (i * Time.fixedDeltaTime * 5);
            segements[i] = segements[0] + segementVelocity * timeCurve + 0.5f * Physics.gravity * Mathf.Pow(timeCurve, 2); 
        }

        trajectoryLine.positionCount = segmentCount;
        for(int j = 0; j < segmentCount; j++) {
            trajectoryLine.SetPosition(j, segements[j]);
        }
    }

    private Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time) {
        //define the distance x and y first
        Vector3 distance = target - origin;
        Vector3 distance_x_z = distance;
        distance_x_z.Normalize();
        distance_x_z.y = 0;

        //creating a float that represents our distance 
        float sy = distance.y;
        float sxz = distance.magnitude;


        //calculating initial x velocity
        //Vx = x / t
        float Vxz = sxz / time;

        ////calculating initial y velocity
        //Vy0 = y/t + 1/2 * g * t
        float Vy = sy / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;

        Vector3 result = distance_x_z * Vxz;
        result.y = Vy;



        return result;
    }
}
#region Test
/*        SetTrajectory(true);
        Vector3 diff = hit - shootPoint.position;
        int segementCount = 25;
        Vector3[] segments = new Vector3[segementCount];
        segments[0] = shootPoint.position;

        Vector3 segmentVelocity = new Vector3(diff.x, diff.y) * 5f * distance;

        for(int i = 1; i < segementCount; i++) {
            float timeCurve = (i * Time.fixedDeltaTime * 5);
            segments[i] = segments[0] + segmentVelocity * timeCurve + 0.5f * Physics.gravity * Mathf.Pow(timeCurve, 2);
        }

        trajectoryLine.positionCount = segementCount;
        for(int i = 0; i < segementCount; i++) {
            trajectoryLine.SetPosition(i, segments[i]);
        }*/
#endregion