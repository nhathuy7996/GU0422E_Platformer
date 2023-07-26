using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimationControllerBase : MonoBehaviour
{
    

    public Action<string> _eventAction = null;
    // Start is called before the first frame update
    

    public abstract void UpdateAnim(PlayerState playerState);


    public abstract void SetShootState(bool isShoot);

    public void CallEvent(string name)
    {
        _eventAction?.Invoke(name);
    }
}
