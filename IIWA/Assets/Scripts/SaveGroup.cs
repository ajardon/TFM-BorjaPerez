using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGroup : MonoBehaviour
{
    public int group;

    public void ChooseGroup()
    {
        PlayerPrefs.SetInt("SavedGroup", group);
    }
}
