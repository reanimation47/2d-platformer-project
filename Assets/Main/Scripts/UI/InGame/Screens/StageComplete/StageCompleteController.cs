using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCompleteController : InGameScreenBase
{
    public override void SetTexts()
    {
        this._title_text = "STAGE CLEAR!";
        this._body_text = "Proceed to next stage?";
    }
}
