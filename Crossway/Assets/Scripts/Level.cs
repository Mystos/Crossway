using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/Level", order = 1)]
public class Level : ScriptableObject
{
    public int nbrOfPeopleToPass;
    public int nbrOfPeopleToSpawn;
    public int nbrLimitOfRedPeople;
    [Range(0,1)]
    public float chanceForRedSpawn;


}
