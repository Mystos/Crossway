using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
        StickmanBehavior sm = other.GetComponent<StickmanBehavior>();
        if(sm != null)
        {
            if (sm.type == StickmanType.Red)
            {
                GameController.instance.nbrOfRedPeoplePassed++;
            }
            else
            {
                GameController.instance.nbrOfPeoplePassed++;
            }
        }

        GameController.instance.nbrOfPeople--;
        Destroy(other.gameObject);
    }
}
