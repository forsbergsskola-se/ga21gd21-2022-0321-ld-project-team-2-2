using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBox : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            _animator.SetBool("moveBox", true);
           // _animator.SetBool("moveBox", false);
        }
    }
}
