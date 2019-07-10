using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningScreen : MonoBehaviour
{
    public GameObject lightning;
    public GameObject Player;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            PlaceLightning();
        }
    }

    public void PlaceLightning()
    {
        //Vector3 position = new Vector3(Random.Range(Mathf.Sqrt(Camera.main.orthographicSize) * -1 / 2, Mathf.Sqrt(Camera.main.orthographicSize) / 2), Random.Range(Mathf.Sqrt(Camera.main.orthographicSize) * -1 / 2, Mathf.Sqrt(Camera.main.orthographicSize) / 2));

        //Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 position;
        position.x =0.95f;
        position.y = 0.95f;
        position.z = 0;
        Camera.main.ViewportToWorldPoint(position);
        position.z = 0;
        Debug.Log(position +"<- DA!");
        GameObject gO = Instantiate(lightning, position, Quaternion.identity, this.transform);
    }
}
