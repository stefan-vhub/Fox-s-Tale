using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPoint : MonoBehaviour
{
    public MapPoint up, right, down, left;
    public bool isLevel, isLocked;
    public string LevelToLoad, levelToCheck, levelName;
    public int gemsCollected, totalGems;
    public float bestTime, targetTime;
    public GameObject gemBadge, timeBadge;

    // Start is called before the first frame update
    void Start()
    {

        if(isLevel && LevelToLoad != null)
        {
            if(PlayerPrefs.HasKey(LevelToLoad + "_gems"))
            {
                gemsCollected = PlayerPrefs.GetInt(LevelToLoad + "_gems");
            }
            if (PlayerPrefs.HasKey(LevelToLoad + "_time"))
            {
                bestTime = PlayerPrefs.GetFloat(LevelToLoad + "_time");
            }

            if (gemsCollected >= totalGems)
            {
                gemBadge.SetActive(true);
            }

            if(bestTime <= targetTime && bestTime != 0)
            {
                timeBadge.SetActive(true);
            }

            isLocked = true;
            
            if(levelToCheck != null)
            {
                if (PlayerPrefs.HasKey(levelToCheck + "_unlocked"))
                {
                    if(PlayerPrefs.GetInt(levelToCheck + "_unlocked") == 1)
                    {
                        isLocked = false;
                    }
                }
            }

            if(LevelToLoad == levelToCheck)
            {
                isLocked = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
