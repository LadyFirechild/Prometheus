using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Prometheus
{

    public class PowerUps_Disappear : MonoBehaviour
    {
        public PowerUp_Size pUSize;

        public GameObject[] bigPU;
        public GameObject[] normalPU;
        public GameObject[] smallPU;

        void Start()
        {
            bigPU = GameObject.FindGameObjectsWithTag("BigPU");
            smallPU = GameObject.FindGameObjectsWithTag("SmallPU");
            normalPU = GameObject.FindGameObjectsWithTag("NormalPU");

        }

        void Update()
        {
            Debug.Log(pUSize.small);
            Debug.Log(pUSize.normal);
            Debug.Log(pUSize.big);

            if (pUSize.big)
            {
                foreach (GameObject bigPowerUp in bigPU)
                {
                    bigPowerUp.SetActive(false);
                }
                foreach (GameObject normalPowerUp in normalPU)
                {
                    normalPowerUp.SetActive(true);
                }
                foreach (GameObject smallPowerUp in smallPU)
                {
                    smallPowerUp.SetActive(true);
                }
            }
            if (pUSize.normal)
            {
                foreach (GameObject bigPowerUp in bigPU)
                {
                    bigPowerUp.SetActive(true);
                }
                foreach (GameObject normalPowerUp in normalPU)
                {
                    normalPowerUp.SetActive(false);
                }
                foreach (GameObject smallPowerUp in smallPU)
                {
                    smallPowerUp.SetActive(true);
                }
            }
            if (pUSize.small)
            {
                foreach (GameObject bigPowerUp in bigPU)
                {
                    bigPowerUp.SetActive(true);
                }
                foreach (GameObject normalPowerUp in normalPU)
                {
                    normalPowerUp.SetActive(true);
                }
                foreach (GameObject smallPowerUp in smallPU)
                {
                    smallPowerUp.SetActive(false);
                }
            }
        }
    }
}
