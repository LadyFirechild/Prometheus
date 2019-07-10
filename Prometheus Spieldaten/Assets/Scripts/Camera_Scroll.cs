using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Scroll : MonoBehaviour
{
    public Camera myCam;

    public float time = 5.0f;
    public float CameraDist = 200;

    public Transform startPosition;
    public Transform endPosition;

    // Start is called before the first frame update
    void Start()
    {
        if (myCam == null)
            myCam = Camera.main;
        if (endPosition == null)
            endPosition = GameObject.FindWithTag("Player").transform;
        StartCoroutine(CameraPan());    
    }


    IEnumerator CameraPan()
    {
        GlobalEvent.MovementAllowed?.Invoke(false);
        myCam.transform.position = startPosition.position;
        float elapsed = Time.deltaTime;
        float smooth;

        Vector3 nextPos;

        while (elapsed <= time)
        {
            smooth = elapsed / time;
            smooth = smooth * smooth * (3 - 2 * smooth);

            nextPos = Vector3.Lerp(startPosition.position, endPosition.position, smooth);
            nextPos.z = -CameraDist;
            myCam.transform.position = nextPos;

            elapsed += Time.deltaTime;
        yield return null;
        }

        nextPos = endPosition.position;
        nextPos.z = -CameraDist;
        myCam.transform.position = nextPos;
        GlobalEvent.MovementAllowed?.Invoke(true);
        Debug.Log("Movement allowed");
    }
}
