using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanBehavior : MonoBehaviour
{
    CharacterController cc;

    public GameObject objectToRunTowards;
    public float speed = 1.0f;
    public StickmanType type = StickmanType.White;

    // Update is called once per frame
    void Update()
    {
        if(objectToRunTowards != null && transform.position != objectToRunTowards.transform.position )
        {
            MoveTowardsTarget(objectToRunTowards.transform.position);
        }
    }

    void MoveTowardsTarget(Vector3 target)
    {
        var cc = GetComponent<CharacterController>();
        var offset = target - transform.position;
        //Get the difference.
        if (offset.magnitude > .1f)
        {
            offset = offset.normalized * speed;
            cc.Move(offset * Time.deltaTime);
        }
    }
}

public enum StickmanType
{
    White,
    Red
}
