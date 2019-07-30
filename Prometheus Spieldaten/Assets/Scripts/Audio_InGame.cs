﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Prometheus
{

    public class Audio_InGame : MonoBehaviour
    {
        public Player_Movement playerMovement;
        public AudioClip jumpClip;
        public AudioSource jumpSource;
        public AudioClip walkClip;
        public AudioSource walkSource;
        public float deltaSoundWalk;
        public float TimeBetweenSteps;
        [SerializeField] bool movementBlocked = false;

        // Start is called before the first frame update
        void Start()
        {
            jumpSource.clip = jumpClip;
            walkSource.clip = walkClip;
            deltaSoundWalk = TimeBetweenSteps;
        }
        private void OnEnable()
        {
            GlobalEvent.MovementAllowed += UnlockMovement;
        }

        private void OnDisable()
        {
            GlobalEvent.MovementAllowed -= UnlockMovement;
        }

        // Update is called once per frame
        void Update()
        {
            if (movementBlocked) return;

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) && playerMovement.grounded)
            {
                jumpSource.Play();
            }
            if (playerMovement.grounded && ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)))))
            {

                deltaSoundWalk += Time.deltaTime;
                if (deltaSoundWalk >= TimeBetweenSteps)
                {
                    walkSource.Play();
                    deltaSoundWalk -= TimeBetweenSteps;
                }
            }
            if (!playerMovement.grounded)
            {
                walkSource.Stop();
                deltaSoundWalk = 0;
            }
        }

        public void UnlockMovement(bool allowed)
        {
            movementBlocked = !allowed;
        }
    }
}
