using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    internal int nbrOfPeoplePassed = 0;
    internal int nbrOfRedPeoplePassed = 0;
    internal int nbrOfPeople = 0;
    public int maxNbrOfPeople = 0;


    public Level actualLevel;

    public UnityEvent levelEndGood;
    public UnityEvent levelEndBad;
    public UnityEvent levelStart;

    internal bool hasLevelStarted;
    internal bool levelIsInPause;

    // Singleton Initialization
    void Awake()
    {
        if (!GameController.instance)
        {
            GameController.instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void Start()
    {
        ResumeGame();
        levelStart.Invoke();
    }

    private void Update()
    {
        // Finished goal
        if(nbrOfPeoplePassed >= actualLevel.nbrOfPeopleToPass && !levelIsInPause)
        {
            PauseGame();
            levelEndGood.Invoke();
        }

        // Lost
        if (nbrOfRedPeoplePassed >= actualLevel.nbrLimitOfRedPeople && !levelIsInPause)
        {
            PauseGame();
            levelEndBad.Invoke();
        }

    }

    private void PauseGame()
    {
        levelIsInPause = true;
        Time.timeScale = 0f;
    }

    private void ResumeGame()
    {
        levelIsInPause = false;
        Time.timeScale = 1f;
    }

    public void NextLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex + 1 <= SceneManager.sceneCount )
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    public void ReloadThisLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }












}
