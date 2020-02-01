﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Step", menuName = "ScriptableObjects/step")]
public class Step : ScriptableObject
{
    public StepObject[] stepObjects;
    public int currentStepObjectIndex;
    public bool isFinished = false;
   
}