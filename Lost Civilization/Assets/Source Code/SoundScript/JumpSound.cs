using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSound : MonoBehaviour
{
    private AudioSource jumpsound;
    void Start()
    {
        jumpsound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void JumpSfx()
    {
        jumpsound.Play();
    }
}
