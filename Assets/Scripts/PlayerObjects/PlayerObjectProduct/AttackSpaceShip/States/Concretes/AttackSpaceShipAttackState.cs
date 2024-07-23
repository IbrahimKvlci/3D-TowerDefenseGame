using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpaceShipAttackState : AttackSpaceShipStateBase
{
    private float timer;

    private IAttackSpaceShipAttackService _attackSpaceShipAttackService;
    private IAttackSpaceShipTriggerService _attackSpaceShipTriggerService;
    private IAttackSpaceShipMovementService _attackSpaceShipMovementService;

    public AttackSpaceShipAttackState(AttackSpaceShip attackSpaceShip, IAttackSpaceShipStateService attackSpaceShipStateService, IAttackSpaceShipAttackService attackSpaceShipAttackService,IAttackSpaceShipTriggerService attackSpaceShipTriggerService, IAttackSpaceShipMovementService attackSpaceShipMovementService) : base(attackSpaceShip, attackSpaceShipStateService)
    {
        _attackSpaceShipAttackService = attackSpaceShipAttackService;
        _attackSpaceShipTriggerService = attackSpaceShipTriggerService;
        _attackSpaceShipMovementService = attackSpaceShipMovementService;
    }

    public override void EnterState()
    {
        base.EnterState();
        _attackSpaceShip.MuzzleFlashParticleEffect.SetActive(true);
        timer = 0f;
    }

    public override void UpdateState()
    {
        base.UpdateState();
       
        _attackSpaceShipMovementService.Stop(_attackSpaceShip);

        timer += Time.deltaTime;
        if (timer > ((AttackSpaceShipSO)_attackSpaceShip.PlayerObjectSO).fireDuration)
        {
            timer = 0f;
            _attackSpaceShipAttackService.Attack(_attackSpaceShip.AttackSpaceShipTrigger.TriggeredEnemy, ((AttackSpaceShipSO)_attackSpaceShip.PlayerObjectSO).damage*_attackSpaceShip.Player.PlayerUpgrading.ObjectDamageMultiplier);
            InGameSoundManager.Instance.PlayAudioNormalized(InGameSoundManager.Instance.InGameSoundEffectsSO.laserShotFx, _attackSpaceShip.transform.position, 0.2f);

        }

        if (!_attackSpaceShipTriggerService.IsEnemyTriggeredToBeAttacked(_attackSpaceShip, _attackSpaceShip.AttackSpaceShipTrigger.TriggeredEnemy))
        {
            _attackSpaceShipStateService.SwitchState(_attackSpaceShip.AttackSpaceShipChaseState);
        }
        else
        {
            Vector3 attackVector = _attackSpaceShip.AttackSpaceShipTrigger.TriggeredEnemy.transform.position - _attackSpaceShip.transform.position;
            attackVector.Normalize();
            _attackSpaceShip.transform.forward = Vector3.Slerp(_attackSpaceShip.transform.forward, attackVector, 1);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
        _attackSpaceShip.MuzzleFlashParticleEffect.SetActive(false);
    }


}
