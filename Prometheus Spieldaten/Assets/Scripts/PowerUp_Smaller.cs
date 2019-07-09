using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Prometheus
{

    public class PowerUp_Smaller : MonoBehaviour
    {
        public GameObject Player;
        public SpriteRenderer spriteRenderer;
        public BoxCollider2D boxCollider2D;
        public PowerUp_Big PoUpBi;
        public float smallMultiplier = 2 / 3;
        public float smallMultiplierReverse;
        public int timeLeft = 10;
        public int counter;
        public bool small = false;

        public void Start()
        {
            counter = timeLeft;
            smallMultiplierReverse = Mathf.Pow(smallMultiplier, -1f);
        }
        public void Update()
        {
            if (counter == 0)
            {
                small = false;
                counter = timeLeft;
                Player.transform.localScale = new Vector3(Player.transform.localScale.x * smallMultiplierReverse, Player.transform.localScale.y * smallMultiplierReverse, Player.transform.localScale.z);
                spriteRenderer.enabled = true;
                boxCollider2D.enabled = true;
            }
        }
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player" && !PoUpBi.big && !small)
            {
                small = true;
                StartCoroutine(Countdown());

                spriteRenderer.enabled = false;
                boxCollider2D.enabled = false;
                other.gameObject.transform.localScale = new Vector3(other.gameObject.transform.localScale.x * smallMultiplier, other.gameObject.transform.localScale.y * smallMultiplier, other.gameObject.transform.localScale.z);
            }
        }

        public IEnumerator Countdown()
        {
            while (counter > 0)
            {
                yield return new WaitForSeconds(1);
                counter--;
            }
        }
    }
}
