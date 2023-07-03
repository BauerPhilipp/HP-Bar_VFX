using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VFXManager : MonoBehaviour
{

    [SerializeField] bool playVFX = false;
    public bool PlayVFX { get { return playVFX; } set { playVFX = value; } }
    

    private VisualEffect playerCourageVFX;
    private void Start()
    {
        playerCourageVFX = GetComponent<VisualEffect>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playVFX)
        {
            playerCourageVFX.Play();
        }else if (!playVFX)
        {
            playerCourageVFX.Stop();
        }
    }
}
