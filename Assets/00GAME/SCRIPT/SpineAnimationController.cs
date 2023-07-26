using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;
using UnityEngine.Playables;

public class SpineAnimationController : AnimationControllerBase
{
    SkeletonAnimation _animator;

    [SerializeField]
    [SpineAnimation]
    string _animRun, _animShoot, _animIdle;

    PlayerState _currentState = PlayerState.Idle;

    Spine.TrackEntry _animTrack;

    // Start is called before the first frame update
    void Start()
    {
        _animator = this.GetComponent<SkeletonAnimation>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.B)) {
            _animator.AnimationState.TimeScale = 0.5f;
        }
        else {
            _animator.AnimationState.TimeScale = 1f;
        }
    }

    public override void SetShootState(bool isShoot)
    {
        if(isShoot)
            _animator.AnimationState.SetAnimation(1, _animShoot, false);
    }

    public override void UpdateAnim(PlayerState playerState)
    {
        if (playerState == _currentState)
            return;

        _animTrack = _animator.AnimationState.SetAnimation(0, playerState.ToString().ToLower(), true);
        _currentState = playerState;

        _animTrack.Complete += _animTrack_Complete;
        _animTrack.Start += _animTrack_Start;
        _animTrack.End += _animTrack_End;

        _animTrack.Event += _animTrack_Event;

        
    }

    private void _animTrack_Event(Spine.TrackEntry trackEntry, Spine.Event e)
    {

        _eventAction?.Invoke(e.Data.Name);
    }

    private void _animTrack_End(Spine.TrackEntry trackEntry)
    {
       
    }

    private void _animTrack_Start(Spine.TrackEntry trackEntry)
    {
       
    }

    private void _animTrack_Complete(Spine.TrackEntry trackEntry)
    {
        
    }
}
