using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorShift : MonoBehaviour
{
    Vector3 awakePosition;
    public Vector3 offSSet;

    public Vector3 newScaling = new Vector3(1, 1, 1);
     Vector3 oldScaling;

    Coroutine one;
    public float duration = 0.5f;
    

    public void Start()
    {
        awakePosition = transform.position;
        oldScaling = transform.localScale;
    }
    
    public void StartMovementDown(bool down)
    {
        if (one != null)
            StopCoroutine(one);

        StartCoroutine(Moving((down) ? awakePosition + offSSet : awakePosition));
    }

    IEnumerator Moving(Vector3 ziel)
    {
        float elapsed = 0;

        Vector3 start = transform.position;
        Vector3 difference = ziel - start;

        float remaining =difference.magnitude / (offSSet.magnitude);

        float smooth; 

        while (elapsed <= remaining)
        {
            elapsed += Time.deltaTime;
            smooth = Mathf.SmoothStep(0, 1, elapsed / remaining);

            transform.position = start + smooth * difference;

            transform.localScale = Vector3.Lerp(oldScaling,newScaling, (transform.position - awakePosition).magnitude / offSSet.magnitude); // UGLY!!!
            yield return null;
        }
        transform.position = ziel;
    }
}
