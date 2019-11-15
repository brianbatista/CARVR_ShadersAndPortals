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

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _anim.SetTrigger("Beckon");
        }
    }
}
