using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< Updated upstream
public class GlobalEvent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
=======
public class GlobalEvent 
{
    /// <summary>
    /// given GameObject is reference to activated
    /// </summary>
    public static System.Action<GameObject> ActivatedFire;
>>>>>>> Stashed changes
}
