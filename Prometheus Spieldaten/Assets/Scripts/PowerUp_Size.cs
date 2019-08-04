using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Prometheus
{

    public class PowerUp_Size : MonoBehaviour
    {
        public GameObject Player;
        public float SizeBigSmall;
        public float SizeSmallBig;
        public float SizeNormalBig = 4 / 3;
        public float SizeBigNormal;
        public float SizeNormalSmall = 2 / 3;
        public float SizeSmallNormal;
        public bool small;
        public bool normal;
        public bool big;


        void Start()
        {
            normal = true;
            SizeBigNormal = Mathf.Pow(SizeNormalBig, -1f);
            SizeSmallNormal = Mathf.Pow(SizeNormalSmall, -1f);
            SizeBigSmall = SizeBigNormal * SizeNormalSmall;
            SizeSmallBig = Mathf.Pow(SizeBigNormal * SizeNormalSmall, -1f);
        }

        void OnTriggerEnter2D(Collider2D trigger)
        {
            if (trigger.gameObject.tag == "SmallPU" && !small)
            {
                if (normal && !big)
                {
                    small = true;
                    normal = false;
                    big = false;
                    Player.transform.localScale = new Vector3(Player.transform.localScale.x * SizeNormalSmall, Player.transform.localScale.y * SizeNormalSmall, Player.transform.localScale.z);
                }

                if (!normal && big)
                {
                    small = true;
                    normal = false;
                    big = false;
                    Player.transform.localScale = new Vector3(Player.transform.localScale.x * SizeBigSmall, Player.transform.localScale.y * SizeBigSmall, Player.transform.localScale.z);
                }
            }
            if (trigger.gameObject.tag == "NormalPU" && !normal)
            {
                if (small && !big)
                {
                    normal = true;
                    small = false;
                    big = false;
                    Player.transform.localScale = new Vector3(Player.transform.localScale.x * SizeSmallNormal, Player.transform.localScale.y * SizeSmallNormal, Player.transform.localScale.z);
                }

                if (!small && big)
                {
                    normal = true;
                    small = false;
                    big = false;
                    Player.transform.localScale = new Vector3(Player.transform.localScale.x * SizeBigNormal, Player.transform.localScale.y * SizeBigNormal, Player.transform.localScale.z);
                }
            }
            if (trigger.gameObject.tag == "BigPU" && !big)
            {
                if (small && !normal)
                {
                    big = true;
                    normal = false;
                    small = false;
                    Player.transform.localScale = new Vector3(Player.transform.localScale.x * SizeSmallBig, Player.transform.localScale.y * SizeSmallBig, Player.transform.localScale.z);
                }

                if (!small && normal)
                {
                    big = true;
                    normal = false;
                    small = false;
                    Player.transform.localScale = new Vector3(Player.transform.localScale.x * SizeNormalBig, Player.transform.localScale.y * SizeNormalBig, Player.transform.localScale.z);
                }
            }
        }
    }
}
