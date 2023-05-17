using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCardController : MonoBehaviour
{
    private int StarsCount = 2;
    public List<GameObject> Stars;

    private void Awake()
    {
        
    }

    private void Start()
    {
        LoadStars();
    }

    private void DisableAllStars()
    {
        foreach (GameObject start in Stars)
        {
            start.SetActive(false);
        }
    }

    private void SetupStars()
    {
        int i = 0;
        foreach (GameObject star in Stars)
        {
            if (i < StarsCount)
            {
                star.SetActive(true);
                i++;
            }
        }
    }

    public void LoadStars()
    {
        DisableAllStars();
        SetupStars();
    }
}
