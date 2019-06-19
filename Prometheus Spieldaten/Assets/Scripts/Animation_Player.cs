using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class Animation_Player : MonoBehaviour

{
    public UnityArmatureComponent walkAnim;


    // Start is called before the first frame update


    // Update is called once per frame
    public void Start()
    {
        UnityFactory.factory.LoadDragonBonesData("Animation/Enemy_Rolling_ske");
        UnityFactory.factory.LoadDragonBonesData("Animation/Enemy_Rolling_tex");
        UnityArmatureComponent walkAnim = GetComponent<UnityArmatureComponent>();



    }

    public void Activate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            walkAnim.animation.Play("animtion0");
            walkAnim.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }
}
