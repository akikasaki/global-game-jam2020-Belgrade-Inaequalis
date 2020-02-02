﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer Instance;
    private void Awake() {
        Instance=this;
    }
    public Image loading;
    public GameObject go;
    public int minutes;
    public int sec;
    bool tmp;
    int totalSeconds = 0;
    int TOTAL_SECONDS = 0;
    float fillamount;
    public bool TimerClock()
    {
        if (sec > 0)
            sec--;
        if (sec == 0 && minutes != 0)
        {
            sec = 60;
            minutes--;
        }
        fillLoading();
        return Check();
    }
    public bool Shake()
    {
        if(sec<15 && minutes==0)
        {
            if(tmp){
                go.transform.position+= new Vector3(1,0,0);
                tmp=false;
            }
            else {
                go.transform.position-= new Vector3(1,0,0);
                tmp=true;
            }
        }
        return Check();
    }
    // Start is called before the first frame update
    void Start()
    {
        tmp=true;
        if (minutes > 0)
            totalSeconds += minutes * 60;
        if (sec > 0)
            totalSeconds += sec;
        TOTAL_SECONDS = totalSeconds;
        LoopsHandler.LoopDelegate timerDelegate = TimerClock;
        LoopsHandler.Instance.Loop(1f, TimerClock);
        LoopsHandler.LoopDelegate shakerDelegate = Shake;
        LoopsHandler.Instance.Loop(0.1f, shakerDelegate);
    }
    void fillLoading()
    {
        totalSeconds--;
        float fill = (float)totalSeconds / TOTAL_SECONDS;
        loading.fillAmount= fill;
    }
    public bool Check()
    {
        if (sec == 0 && minutes == 0)
        {
            return false;
        }
        else return true;        
    }
}