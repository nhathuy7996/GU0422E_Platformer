using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using System;

public class UnityAnimationController : AnimationControllerBase
{
    public override void SetShootState(bool isShoot)
    {
        _animator.SetFloat("isShoot", isShoot ? 1: 0);
    }

    public override void UpdateAnim(PlayerState playerState) {
        for (int i = 0; i<= (int)PlayerState.Jump; i++) {
            if((int)playerState == i) {
                _animator.SetTrigger(playerState.ToString());
            }
           
        }

    }
}
