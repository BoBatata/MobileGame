using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] Text Pumpkins;
    [SerializeField] Text Timer;

    static public int AbóborasColetadas;

    public float contagem;
    float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = contagem;
        AbóborasColetadas = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Text();
        CountDown();
    }

    private void Text()
    {
        Pumpkins.text = AbóborasColetadas + "/20".ToString();
        if(AbóborasColetadas >= 20)
        {
            Pumpkins.text = "20/20".ToString();
            SceneManager.LoadScene("Win");
        }
    }

    void CountDown ()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            TimeSpan timeSpan = TimeSpan.FromSeconds(currentTime);
            Timer.text = string.Format("{0:00}:{1:00}", timeSpan.Minutes, timeSpan.Seconds);
        }
        else
        {
            Timer.text = "00:00";
            SceneManager.LoadScene("GameOver");
        }
    }

}
