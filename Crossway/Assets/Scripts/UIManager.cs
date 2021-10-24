using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textScoreRed;
    public GameObject winScreen;
    public GameObject looseScreen;
    GameController gc;


    // Start is called before the first frame update
    void Start()
    {
        gc = GameController.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(gc!= null && gc.actualLevel != null)
        {
            textScore.text = gc.nbrOfPeoplePassed + "/" + gc.actualLevel.nbrOfPeopleToPass;
            textScoreRed.text = gc.nbrOfRedPeoplePassed + "/" + gc.actualLevel.nbrLimitOfRedPeople;
        }
    }

    public void ToggleWinScreen()
    {
        winScreen.SetActive(!winScreen.activeSelf);
    }
    public void ToggleLooseScreen()
    {
        looseScreen.SetActive(!looseScreen.activeSelf);
    }
}
