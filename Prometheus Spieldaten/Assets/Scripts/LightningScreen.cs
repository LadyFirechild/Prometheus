using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningScreen : MonoBehaviour
{
    public GameObject lightning;
    public bool fireCollected;
    public float timeElapsed;
    public float Interval;
    public ChaliceCheck chaliceCheck;

    public void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= Interval && chaliceCheck.bigChalice)
        {
            PlaceLightning();
            PlaceLightning();
            timeElapsed -= Interval;
        }


    }

    public void PlaceLightning()
    {
        {
            float horizontal = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
            float vertical = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);

            Vector2 randomSpawn = new Vector2(horizontal, vertical);
            GameObject LightningClone = (Instantiate(lightning, randomSpawn, Quaternion.identity));

            Destroy(LightningClone, 5f);
        }

    }
}
