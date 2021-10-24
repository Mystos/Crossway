using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnCooldown = 1;
    private float timeUntilSpawn = 0;
    public GameObject whiteStickman;
    public GameObject redStickman;
    public GameObject objectToRunToward;

    // Update is called once per frame
    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;
        if (timeUntilSpawn <= 0)
        {
            if(whiteStickman != null && redStickman != null)
            {
                GameObject objSpawned;
                if(GameController.instance.nbrOfPeople <= GameController.instance.maxNbrOfPeople)
                {
                    GameController.instance.nbrOfPeople++;
                    if (Random.value > GameController.instance.actualLevel.chanceForRedSpawn) //percent chance for red to spawn
                    {//code here
                        objSpawned = GameObject.Instantiate(whiteStickman, transform);
                    }
                    else
                    {
                        objSpawned = GameObject.Instantiate(redStickman, transform);
                    }
                    StickmanBehavior stickmanSpawned = objSpawned.GetComponent<StickmanBehavior>();
                    if (stickmanSpawned != null)
                    {
                        stickmanSpawned.objectToRunTowards = this.objectToRunToward;
                    }
                }
            }
            else
            {
                Debug.LogError("No object to spawn");
            }

            // Reset for next spawn
            timeUntilSpawn = spawnCooldown;
        }
    }
}
