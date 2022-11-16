using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class LvlCounterText : MonoBehaviour
{

    public TMP_Text LVL;


    void Update()
    {
        LVL.text = "" + mover.lvlCounter;
    }
}
