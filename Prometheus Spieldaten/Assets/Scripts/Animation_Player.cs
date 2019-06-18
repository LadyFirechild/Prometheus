using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class Animation_Player : MonoBehaviour

{
    public UnityArmatureComponent armatureComponent;


    // Start is called before the first frame update


    // Update is called once per frame
    public void Start()
    {
        armatureComponent = GetComponent<UnityArmatureComponent>();
    }

    public void Activate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            armatureComponent.animation.FadeIn("animtion0", 0, -4);
        }
    }
}
