using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Transform target;
    private Controller controller;

    private void Start() {
        target = GetTarget();
        controller = target.GetComponent<Controller>();
    }

    private void LateUpdate() {
        if (target != null) transform.position = target.position;

        if (!controller.GetIsGrounded()) {
            target = null;
        }
    }

    private Transform GetTarget() {
        GameObject player = GameObject.FindWithTag("Player");
        return player.transform;
    }
}
