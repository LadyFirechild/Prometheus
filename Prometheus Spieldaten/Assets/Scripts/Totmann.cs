using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totmann : MonoBehaviour
{
    public GameObject Tür;
    public float timesPlayed;

    public AudioSource switchSource;
    public AudioClip switchClip;

    Vector3 startPosition;
    public Vector3 offSSet;

    Coroutine one;
    public float duration = 0.5f;

    public bool closeagain = false;

    public void Start()
    {
        switchSource.clip = switchClip;
        startPosition = transform.position;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject)
        {
            StartMovementDown(true);
            //Tür.SetActive(false);
            Tür.GetComponent<DoorShift>()?.StartMovementDown(true);

            if (!switchSource.isPlaying && timesPlayed == 0)
            {
                switchSource.Play();
                timesPlayed++;
            }
        }
    }

    void StartMovementDown(bool down)
    {
        if (one != null)
            StopCoroutine(one);

        StartCoroutine(Moving((down) ? startPosition + offSSet : startPosition));
    }

    IEnumerator Moving(Vector3 ziel)
    {
        float elapsed = 0;

        Vector3 start = transform.position;
        Vector3 difference = ziel - start;

        float remaining = Mathf.Abs(difference.magnitude / (offSSet.magnitude));

        while (elapsed <= remaining)
        {
            elapsed += Time.deltaTime;
            transform.position = start + Mathf.SmoothStep(0, 1, elapsed / remaining) * difference;
            yield return null;
        }
        transform.position = ziel;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StartMovementDown(false);
        if (closeagain)
            Tür.GetComponent<DoorShift>()?.StartMovementDown(false);

        //   Tür.SetActive(true);
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.gameObject)
    //    {
    //        Tür.SetActive(false);
    //        //anim.SetActive(true);
    //    }
    //}

}
