using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelNameText : MonoBehaviour
{    
    void Start()
    {
        GameObject[] levelNames = GameObject.FindGameObjectsWithTag("LevelName");
        int levelNamesLength = levelNames.Length;

        if (levelNamesLength == 0)
        {
            Debug.LogWarning("No level name found.");
            return;
        }
        else if (levelNamesLength > 1)
        {
            Debug.LogWarning("Multiple level names found.");
        }

        GetComponent<TextMeshProUGUI>().SetText(levelNames[0].name);
    }
}
