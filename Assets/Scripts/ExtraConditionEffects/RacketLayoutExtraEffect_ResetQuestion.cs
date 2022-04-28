using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketLayoutExtraEffect_ResetQuestion : RacketLayoutExtraEffect
{
    public override void OnClickEffect()
    {
        targetQuestion.ResetQuestion();
    }
}
