using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningScreen : MonoBehaviour
{
    public GameObject lightning;
    public bool fireCollected;

    public void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            PlaceLightning();
        }
    }

    public void PlaceLightning()
    {
        //if (fireCollected)
        {
            float horizontal = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
            float vertical = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);

            Vector2 randomSpawn = new Vector2(vertical, horizontal);
            GameObject LightningClone = (Instantiate(lightning, randomSpawn, Quaternion.identity));

            Destroy(LightningClone, 5f);
        }

    }
}
