using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class man_AnimControl : MonoBehaviour
{
    Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public void manMove()
    {
        if(_anim.GetBool("BeckonBool") == false)
        {
            _anim.SetTrigger("Beckon");
            _anim.SetBool("BeckonBool", true);    
        }
    }
}
