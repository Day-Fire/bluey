using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
public class TintRenderFeature : ScriptableRendererFeature
{
    [System.Serializable]
    public class CustomPassSettings
    {
        public RenderPassEvent renderPassEvent = RenderPassEvent.BeforeRenderingPostProcessing;
        public float blurDistance;
        public float cutoffDistance;
        public float blurStrength;
        [Range(2, 20)]
        public int kernelSize = 20;
        [Range(1.0f, 18.0f)]
        public float sharpness = 8;
        [Range(1.0f, 100.0f)]
        public float hardness = 8;

        [Range(0.01f, 2.0f)]
        public float zeroCrossing = 0.58f;

        public bool useZeta = false;
        [Range(0.01f, 3.0f)]
        public float zeta = 1.0f;
    }

    [SerializeField] private CustomPassSettings settings;
    private TintPass customPass;

    public override void Create()
    {
        customPass = new TintPass(settings);
    }
    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        renderer.EnqueuePass(customPass);
    }

}
