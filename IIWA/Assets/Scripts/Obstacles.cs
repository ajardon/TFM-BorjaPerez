using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public int obstacles;

    public void ChooseObstacles()
    {
        PlayerPrefs.SetInt("ChosenObstacle", obstacles);
    }
}
