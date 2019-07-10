using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningScreen : MonoBehaviour
{
    public GameObject lightning;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlaceLightning();
        }
    }

    public void PlaceLightning()
    {
        float horizontal = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
        float vertical = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);

        Vector2 randomSpawn = new Vector2(vertical, horizontal);
        Instantiate(lightning, randomSpawn, Quaternion.identity);

    }
}
