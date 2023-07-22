using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityAnimationController : MonoBehaviour
{
    Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = this.GetComponent<Animator>();

        Invoke("ChangeAnim",3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeAnim() {
        _animator.SetTrigger("Run");
    }
}
