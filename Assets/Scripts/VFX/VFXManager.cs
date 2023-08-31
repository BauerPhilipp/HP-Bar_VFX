using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VFXManager : MonoBehaviour
{
    public static event Action PlayVFXEvent;

    [SerializeField] bool playVFX = false;
    public bool PlayVFX { get { return playVFX; } set { playVFX = value; } }
    private bool playVFXActive = false;


    //private VisualEffect playerCourageVFX;
    [SerializeField] private ParticleSystem ps;
    private void Start()
    {
        //playerCourageVFX = GetComponent<VisualEffect>();
    }

    void Update()
    {
        if (playVFX && !playVFXActive)
        {
            playVFXActive = true;
            ps.Play();
            Debug.Log("Play in update");
            PlayVFXEvent?.Invoke();
        }else if (!playVFX && playVFXActive)
        {
            StartCoroutine(StopAnimation());
            Debug.Log("Stop in update");

        }
    }

    IEnumerator StopAnimation()
    {      
        yield return new WaitForSeconds(2f);
        Debug.Log("Animation stopped!!");
        ps.Stop();
        playVFXActive = false;
    }

}
