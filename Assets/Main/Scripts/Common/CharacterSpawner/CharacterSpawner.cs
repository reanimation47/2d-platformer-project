using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommonInfo.CharacterSelect;

public class CharacterSpawner : MonoBehaviour
{
    public List<GameObject> Characters;
    private int CharacterIndex;
    private void Start()
    {
        CharacterIndex = PlayerPrefs.GetInt(CharacterSelectInfo.CharacterSelected_PlayerPrefs_Key);
        Characters[CharacterIndex].SetActive(true);
    }
}
