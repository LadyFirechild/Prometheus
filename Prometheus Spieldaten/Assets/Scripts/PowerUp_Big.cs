using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prometheus
{

    public class PowerUp_Big : MonoBehaviour
    {
        public GameObject Player;
        public SpriteRenderer spriteRenderer;
        public BoxCollider2D boxCollider2D;
        public PowerUp_Smaller PoUpSm;
        public float bigMultiplier = 4 / 3;
        public float bigMultiplierReverse;
        public int timeLeft = 10;
        public int counter;
        public bool big;

        public void Start()
        {
            counter = timeLeft;
            bigMultiplierReverse = Mathf.Pow(bigMultiplier, -1f);
        }
        public void Update()
        {
            if (counter == 0)
            {
                big = false;
                counter = timeLeft;
                Player.transform.localScale = new Vector3(Player.transform.localScale.x * bigMultiplierReverse, Player.transform.localScale.y * bigMultiplierReverse, Player.transform.localScale.z);
                spriteRenderer.enabled = true;
                boxCollider2D.enabled = true;
            }
        }
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player" && !PoUpSm.small)
            {
                big = true;
                StartCoroutine(Countdown());
                spriteRenderer.enabled = false;
                boxCollider2D.enabled = false;
                other.gameObject.transform.localScale = new Vector3(other.gameObject.transform.localScale.x * bigMultiplier, other.gameObject.transform.localScale.y * bigMultiplier, other.gameObject.transform.localScale.z);
            }
        }

        public IEnumerator Countdown()
        {
            counter = timeLeft;
            while (counter > 0)
            {
                yield return new WaitForSeconds(1);
                counter--;
            }
        }
    }
}

