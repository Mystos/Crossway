using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    public float timeView1 = 0.5f;
    public float timeScale = 0.3f;
    public GameObject cam1;
    public GameObject cam3;

    void Start()
    {
        cam3.SetActive(false);
        StartCoroutine(StartIntro());
    }

    IEnumerator StartIntro()
    {
        Time.timeScale = timeScale;
        cam1.SetActive(true);
        yield return new WaitForSeconds(timeView1);
        cam3.SetActive(true);
        Time.timeScale = 1f;
    }
}
