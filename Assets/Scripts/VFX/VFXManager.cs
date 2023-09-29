using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VFXManager : MonoBehaviour
{
    public static event Action PlayVFXEvent;

    [SerializeField] bool playVFX = false;
    [SerializeField] float particleCount;
    public bool PlayVFX { get { return playVFX; } set { playVFX = value; } }
    private bool playVFXActive = false;


    //private VisualEffect playerCourageVFX;
    [SerializeField] private VisualEffect vfxBeam;
    [SerializeField] private GameObject vfxCircle01;
    private void Start()
    {
        StopVfx();

    }

    void Update()
    {
        if (playVFX && !playVFXActive)
        {
            playVFXActive = true;
            vfxBeam.SetFloat("Particles", particleCount);
            PlayVfx();
            Debug.Log("Play in update");
            PlayVFXEvent?.Invoke();
        }else if (!playVFX && playVFXActive)
        {
            vfxBeam.SetFloat("Particles", 0);
            StartCoroutine(StopAnimation());
            Debug.Log("Stop in update");
        }
    }

    IEnumerator StopAnimation()
    {
        vfxCircle01.SetActive(false);
        yield return new WaitForSeconds(2f);
        Debug.Log("Animation stopped!!");
        StopVfx();
        playVFXActive = false;
    }

    private void PlayVfx()
    {
        vfxBeam.Play();
        vfxCircle01.SetActive(true);
    }

    private void StopVfx()
    {
        vfxBeam.Stop();
        vfxCircle01.SetActive(false);

    }

}
