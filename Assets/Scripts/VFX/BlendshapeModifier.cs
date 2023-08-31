using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendshapeModifier : MonoBehaviour
{

    ParticleSystem ps;
    ParticleSystem.ShapeModule shapeModule;
    [SerializeField] Transform playerTransform;

    [Header ("Base settings 46, 97, 1")]
    [SerializeField] Vector3 particleScaleBar;
    [SerializeField] Vector3 particleScaleCircle;
    [SerializeField] Vector3 particlePositionBar;
    [SerializeField] Vector3 particlePositionCircle;


    [SerializeField] int blendShapeIndex = 0;
    [Range(0f, 100f)]
    [SerializeField] float blendShapeValue = 0;

    [SerializeField] float particleTransformationSpeed = 0.1f;

    


    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        VFXManager.PlayVFXEvent += TransformParticles;
        shapeModule = ps.shape;
    }

    // Update is called once per frame
    void Update()
    {
        //ps.shape.skinnedMeshRenderer.SetBlendShapeWeight(blendShapeIndex, blendShapeValue);
        if(blendShapeValue > 5f) 
        {
            shapeModule.scale = particleScaleCircle;
            shapeModule.position = particlePositionCircle;
            UpdateVFXPosition();
        }
        else
        {
            shapeModule.scale = particleScaleBar;
            shapeModule.position = particlePositionBar;
            UpdateVFXPosition();
        }
    }

    void UpdateVFXPosition()
    {
        shapeModule.position = new Vector3(playerTransform.position.x + shapeModule.position.x, playerTransform.position.y + shapeModule.position.y, playerTransform.position.z + shapeModule.position.z + 5.44f);

    }

    private void TransformParticles()
    {
        Debug.Log("Event aufgerufen");
        StartCoroutine(StartTransformation());
    }

    IEnumerator StartTransformation()
    {
        ps.shape.skinnedMeshRenderer.SetBlendShapeWeight(blendShapeIndex, 0);
        yield return new WaitForSeconds(2);
        while (blendShapeValue <= 100)
        {
            ps.shape.skinnedMeshRenderer.SetBlendShapeWeight(blendShapeIndex, blendShapeValue++);
            yield return new WaitForSeconds(particleTransformationSpeed);
        }
        yield return new WaitForSeconds(5);
        blendShapeValue = 0;

    }

}
