using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Prometheus
{

    public class Audio_InGame : MonoBehaviour
    {
        public Player_Movement playerMovement;
        public Player_Input playerInput;
        public AudioClip[] jumpClips;
        public AudioClip[] walkClipArray;
        public AudioSource[] allWalkSources;
        public float deltaSoundWalk;
        public float TimeBetweenSteps;
        [SerializeField] bool movementBlocked = false;

        void Awake()
        {
            allWalkSources = GetComponents<AudioSource>();
            allWalkSources[0].clip = walkClipArray[0];
            allWalkSources[1].clip = walkClipArray[1];
            allWalkSources[2].clip = walkClipArray[2];
            allWalkSources[3].clip = walkClipArray[3];
            allWalkSources[4].clip = walkClipArray[4];
            allWalkSources[5].clip = walkClipArray[5];
            allWalkSources[6].clip = walkClipArray[6];
            allWalkSources[7].clip = walkClipArray[7];
            allWalkSources[8].clip = walkClipArray[8];
            allWalkSources[9].clip = walkClipArray[9];
            allWalkSources[10].clip = jumpClips[0];
            allWalkSources[11].clip = jumpClips[1];
        }
        void Start()
        {
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

            if (playerInput.jump && playerMovement.grounded)
            {
                allWalkSources[Random.Range(walkClipArray.Length, walkClipArray.Length + jumpClips.Length)].Play();
            }

            if (playerMovement.grounded && (playerInput.right || playerInput.left))
            {

                deltaSoundWalk += Time.deltaTime;
                if (deltaSoundWalk >= TimeBetweenSteps)
                {
                    allWalkSources[Random.Range(0, walkClipArray.Length)].Play();
                    deltaSoundWalk -= TimeBetweenSteps;
                }
            }
            if (!playerMovement.grounded)
            {
                allWalkSources[Random.Range(0, walkClipArray.Length)].Stop();
                deltaSoundWalk = 0;
            }
        }

        public void UnlockMovement(bool allowed)
        {
            movementBlocked = !allowed;
        }
    }
}
