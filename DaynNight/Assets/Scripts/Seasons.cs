using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seasons : MonoBehaviour
{
    public int day = 0;
    private string season = "spring";
    internal static float deltaTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        setSeason();
        resetDay();
    }

    void setSeason()
    {
        if (day >= 0 && day <= 93)
        {
            season = "spring";
        }
        else if (day >= 94 && day <= 186)
        {
            season = "summer";
        }
        else if (day >= 187 && day <= 277)
        {
            season = "autumn";
        }
        else if (day >= 278 && day <= 365)
        {
            season = "winter";
        }
    }

    void resetDay()
    {
        if (day > 365)
        {
            day = 0;
        }
    }
}
