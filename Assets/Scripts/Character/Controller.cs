using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum CharacterIdentity {
    PLAYER, ENEMY
}

public class Controller : MonoBehaviour
{
    [SerializeField] private float moverSpeed = 5f;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundDist = .4f;
    [SerializeField] private Transform checkSphere = null;
    [SerializeField] private Transform shootingPoint = null;

    [SerializeField] private float jumpHeight = 2f;

    [SerializeField] private CharacterIdentity characterIdentity;

    private CharacterController controller;
    private bool isGrounded;
    private Vector3 velocity;
    private Projectile projectile;
    private Animator anim;

    public bool GetIsGrounded() => isGrounded;

    private void Start() {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        projectile = GetComponent<Projectile>();
    }
     
    private void Update() {
        velocity.z = moverSpeed;

        isGrounded = Physics.CheckSphere(checkSphere.position, groundDist, groundLayer);

        if(isGrounded && velocity.y < 0) {
            velocity.y = -1f;
            anim.SetBool("jumping", false);

            if (Input.GetKeyDown(KeyCode.Space) && characterIdentity == CharacterIdentity.PLAYER) {
               // Jump();
            }
        } else {
            velocity.y += gravity * Time.deltaTime;
        }

        controller.Move(velocity * Time.deltaTime);
    }

    private void FixedUpdate() {
        controller.Move(velocity * Time.fixedDeltaTime);
    }

    public void Jump() {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        anim.SetBool("jumping", true);
    }

    #region ShootingTest
    /*    public void Shoot() {
            if (characterIdentity == CharacterIdentity.PLAYER) {
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
    */
    #endregion

    #region Test
    /*    private void Mover() {

            Vector3 move = transform.forward;
            move *= moverSpeed * Time.deltaTime;

            transform.position += move;
        }

        private void pullToGround() {
            velocity.y += gravity * Time.deltaTime;
            transform.position += velocity * Time.deltaTime;
        }

        private void Jump() {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            transform.position += velocity;
        }
    */
    #endregion
    public Transform GetAimPoint() => shootingPoint;
}
