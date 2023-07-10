using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeusExMachinaSkill : PlayerSkill
{
    protected override void SkillUseNormal()
    {
        StartCoroutine(NormalSkill());
    }

    protected override void SkillUsePowerUp()
    {
        StartCoroutine(PowerUpSkill());
    }

    IEnumerator NormalSkill()
    {

        yield return null;
    }

    IEnumerator PowerUpSkill()
    {

        yield return null;
    }
}