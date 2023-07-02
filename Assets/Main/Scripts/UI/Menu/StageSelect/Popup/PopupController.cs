using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Endless.CommonInfo;

public class PopupController : MonoBehaviour
{

    //Title
    public TextMeshProUGUI Title;

    //Enemy Cards
    public GameObject EnemyCardsParent;
    public List<GameObject> EnemyCards;


    //Popup positioning
    private Vector3 popup_positioner = new Vector3(0, 0, 0);
    private Vector3 popup_positioner_default = new Vector3(0, 0, 0);
    private float popup_target_x = 0;
    private bool popup_shown = false;
    RectTransform rectTransform;


    private void Awake()
    {
        IStage.LoadPopupController(this);
    }

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        TogglePopup(false);

    }

    void Update()
    {
        rectTransform.anchoredPosition = popup_positioner;
    }

    private void FixedUpdate()
    {
        popup_positioner.x = Mathf.Lerp(popup_positioner.x, popup_target_x, 0.1f);
    }

    public void TogglePopup(bool _toggle)
    {
        if (_toggle)
        {
            ReloadPopupInfo();
            popup_target_x = 0;
        }else
        {
            popup_target_x = 400;
        }
        popup_shown = _toggle;

    }

    private void ReloadPopupInfo()
    {
        SetStageTitle();
        DisableAllEnemyCards();
        SwipeCardsParent();
        EnableEnemyCards();
    }

    private void SetStageTitle()
    {
        int current_index = IStage.GetCurrentHighlightedStageIndex();
        if (current_index >999)
        {
            string highscore_key = EndlessInfo.Endless_HighScore_PlayerPrefs_Prefix + current_index;
            int current_highscore = PlayerPrefs.GetInt(highscore_key);
            Title.text = "<color=red>Endless " + (current_index/1000).ToString() + "</color>" + "\n<size=60%>High Score: " + current_highscore;
        }
        else
        {
            Title.text = "Stage " + current_index.ToString();
        }
        
    }

    private void DisableAllEnemyCards()
    {
        foreach (GameObject card in EnemyCards)
        {
            card.SetActive(false);
        }
    }

    private void SwipeCardsParent()
    {
        EnemyCardsParent.transform.localPosition = new Vector3(400, 0, 0);
    }

    private void EnableEnemyCards()
    {
        int current_index = IStage.GetCurrentHighlightedStageIndex();
        List<int> enemy_types = IStage.GetIndexedStageEnemyInfo(current_index);

        foreach (int enemy_type in enemy_types)
        {
            EnemyCards[enemy_type].SetActive(true);
        }
    }
}
