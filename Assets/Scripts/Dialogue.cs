﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Line
{
    [TextArea]
    public string text;

    public float displayTime;
}

public class Dialogue : MonoBehaviour
{
    public Line[] lines;
}
