using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendshapeModifier : MonoBehaviour
{

    ParticleSystem ps;
    ParticleSystem.ShapeModule shapeModule;
    [Header ("Base settings 46, 97, 1")]
    [SerializeField] Vector3 particleScaleBar;
    [SerializeField] Vector3 particleScaleCircle;
    [SerializeField] Vector3 particlePositionBar;
    [SerializeField] Vector3 particlePositionCircle;


    [SerializeField] int blendShapeIndex = 0;
    [Range(0f, 100f)]
    [SerializeField] float blendShapeValue;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        shapeModule = ps.shape;
    }

    // Update is called once per frame
    void Update()
    {
        ps.shape.skinnedMeshRenderer.SetBlendShapeWeight(blendShapeIndex, blendShapeValue);
        if(blendShapeValue > 50f) 
        {
            shapeModule.scale = particleScaleCircle;
            shapeModule.position = particlePositionCircle;
        }
        else
        {
            shapeModule.scale = particleScaleBar;
            shapeModule.position = particlePositionBar;
        }
    }
}
