using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimationControllerBase : MonoBehaviour
{
    protected Animator _animator;

    public Action<string> _eventAction = null;
    // Start is called before the first frame update
    protected void Awake()
    {
        _animator = this.GetComponent<Animator>();
    }

    public abstract void UpdateAnim(PlayerState playerState);

    public void CallEvent(string name)
    {
        _eventAction?.Invoke(name);
    }
}
