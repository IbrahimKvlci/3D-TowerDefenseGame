using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineVisual : MonoBehaviour
{
    [SerializeField] private GameObject mineParticle;
    [SerializeField] private Mine mine;
    [SerializeField] private Animator animator;

    enum MineAnimatorEnum
    {
        IsMining,
        Off
    }

    private void Start()
    {
        ((MineMiningState)(mine.MineMiningState)).OnMiningStarted += MineVisual_OnMiningStarted;
        ((MineMiningState)(mine.MineMiningState)).OnMiningFinished += MineVisual_OnMiningFinished;

        HideMineParticle();
    }

    private void MineVisual_OnMiningFinished(object sender, System.EventArgs e)
    {
        HideMineParticle();

        SetMineBoolAnimator(MineAnimatorEnum.IsMining, false);
        TriggerMineAnimator(MineAnimatorEnum.Off);
    }

    private void MineVisual_OnMiningStarted(object sender, System.EventArgs e)
    {
        ShowMineParticle();

        SetMineBoolAnimator(MineAnimatorEnum.IsMining, true);
    }

    private void ShowMineParticle()
    {
        mineParticle.SetActive(true);
    }

    private void HideMineParticle()
    {
        mineParticle.SetActive(false);
    }

    private void SetMineBoolAnimator(MineAnimatorEnum mineAnimatorEnum,bool value)
    {
        animator.SetBool(mineAnimatorEnum.ToString(),value);
    }

    private void TriggerMineAnimator(MineAnimatorEnum mineAnimatorEnum)
    {
        animator.SetTrigger(mineAnimatorEnum.ToString());
    }
}
