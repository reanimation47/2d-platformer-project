using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : InGameScreenBase
{
    public override void SetTexts()
    {
        this._title_text = "YOU LOST";
        this._body_text = "Try Again?";
    }
}
