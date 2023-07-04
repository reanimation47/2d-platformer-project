using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CommonInfo.CharacterSelect;

public class CharacterSpawner : MonoBehaviour
{
    public List<GameObject> Characters;
    private int CharacterIndex;
    private void Awake()
    {
        CharacterIndex = PlayerPrefs.GetInt(CharacterSelectInfo.CharacterSelected_PlayerPrefs_Key);
        Instantiate(Characters[CharacterIndex], transform.position, Quaternion.identity);
        //Characters[CharacterIndex].SetActive(true);
        //Activating just the right character caused a "data race" issue which isn't worth to fix rn

        //for (int i = 0; i < Characters.Count; i ++) //Enable all at default and deactivate all the wrong characters instead.
        //{
        //    if (i != CharacterIndex)
        //    {
        //        Characters[i].SetActive(false);
        //    }
        //}
    }
}
