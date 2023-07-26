using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class SpineAnimationController : MonoBehaviour
{
    SkeletonAnimation _animator;

    [SerializeField] [SpineAnimation]
    string _animRun, _animShoot;

    // Start is called before the first frame update
    void Start()
    {
        _animator = this.GetComponent<SkeletonAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != 0) {
            _animator.AnimationState.SetAnimation(0,_animRun,true);
            _animator.AnimationState.AddAnimation(0,"idle",true,0);
            _animator.AnimationState.AddAnimation(0, "shoot", true,0);

            
        }

        Debug.Log(_animator.AnimationState.GetCurrent(0).Animation.Name);
    }
}
