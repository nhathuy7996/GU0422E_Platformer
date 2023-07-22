using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using System;

public class UnityAnimationController : MonoBehaviour
{
    Animator _animator;

    public Action<string> _eventAction = null;

    // Start is called before the first frame update
    void Start()
    {
        _animator = this.GetComponent<Animator>();

      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateAnim(PlayerState playerState) {
        for (int i = 0; i<= (int)PlayerState.Jump; i++) {
            if((int)playerState == i) {
                _animator.SetTrigger(playerState.ToString());
            }
           
        }

    }

    public void CallEvent(string name) {
        _eventAction?.Invoke(name);
    }

    public void testEventAnim() {

        Debug.LogError("Call here");
    }


}
