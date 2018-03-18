using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CnControls;

public class Playermovement : Photon.MonoBehaviour {
        public float walk_speed = 2f;
        public float run_speed = 4f;

        private Player player;

        private Vector3 movement;
        private Animator animator;
        private Rigidbody playerRigidbody;

        // rotate
        public float turnSmoothing = 3f;
        private Transform cameraTransform;
        private bool isWalk;
        private bool isRun;
        private float h;
        private float v;

        void Awake()
        {
            DontDestroyOnLoad(gameObject.transform);
            if(!photonView.isMine)
            {
                this.enabled =false;
            }
            // Set up references.
            animator = GetComponent<Animator>();
            playerRigidbody = GetComponent<Rigidbody>();

            cameraTransform = Camera.main.transform;
            player = GetComponent<Player> ();
        }

        void Update()
        {
            h = CnInputManager.GetAxisRaw("Horizontal");
            v = CnInputManager.GetAxisRaw("Vertical");
            isWalk = Mathf.Abs(h) > 0.1 || Mathf.Abs(v) > 0.1;

            if (isWalk)
            {
                if (isRun)
                {
                    isRun = !(Mathf.Abs(h) > 0.9 || Mathf.Abs(v) > 0.9);
                    player.health++;
					player.attack++;
                }
                else
                {
                    isRun = (Mathf.Abs(h) > 0.9 || Mathf.Abs(v) > 0.9);
                }
            }
            else
            {
                isRun = false;
            }
        }

        void FixedUpdate()
        {
            // Move the player around the scene.
            Move(h, v);

            // Turn the player to face the mouse cursor.
            Rotate(h, v);

        }

        void Move(float h, float v)
        {
            float speed = isRun ? run_speed : walk_speed;

            // Set the movement vector based on the axis input.
            movement.Set(h, 0.0f, v);

            // Normalise the movement vector and make it proportional to the speed per second.
            movement = movement.normalized * speed * Time.deltaTime;

            // Move the player to it's current position plus the movement.
            playerRigidbody.MovePosition(transform.position + movement);

            // Animator
            {
                if (isRun)
                {
                    animator.SetBool("IsRun", isRun);
                }
                else
                {
                    animator.SetBool("IsRun", isRun);
                    animator.SetBool("IsWalk", isWalk);
                }
            }
        }

        Vector3 Rotate(float h, float v)
        {
            Vector3 forward = cameraTransform.TransformDirection(Vector3.forward);
            forward = forward.normalized;

            Vector3 right = new Vector3(forward.z, 0, -forward.x);

            Vector3 targetDirection;
            targetDirection = forward * v + right * h;

            if ((isWalk && targetDirection != Vector3.zero))
            {
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);

                Quaternion newRotation = Quaternion.Slerp(GetComponent<Rigidbody>().rotation, targetRotation, turnSmoothing * Time.deltaTime);

                newRotation.x = 0f;
                newRotation.z = 0f;
                GetComponent<Rigidbody>().MoveRotation(newRotation);
            }

            return targetDirection;
        }
}
