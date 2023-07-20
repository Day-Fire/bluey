using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class TintPass : ScriptableRenderPass
{
    private TintRenderFeature.CustomPassSettings settings;

    private RenderTargetIdentifier colorBuffer, tintBuffer;
    private int tintBufferID = Shader.PropertyToID("_TintBuffer");

    private Material material;
    private Color tintColor;
    private float blurDistance;
    private float cutoffDistance;
    private float blurStrength;
    [Range(2, 20)]
    public int kernelSize;
    [Range(1.0f, 18.0f)]
    public float sharpness;
    [Range(1.0f, 100.0f)]
    public float hardness;
    [Range(0.01f, 2.0f)]
    public float zeroCrossing;

    public bool useZeta;
    [Range(0.01f, 3.0f)]
    public float zeta;

    public TintPass(TintRenderFeature.CustomPassSettings settings)
    {
        this.settings = settings;
        this.renderPassEvent = settings.renderPassEvent;
        if (material == null) material = CoreUtils.CreateEngineMaterial("Hidden/Tint");
    }

    public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
    {
        colorBuffer = renderingData.cameraData.renderer.cameraColorTarget;
        RenderTextureDescriptor descriptor = renderingData.cameraData.cameraTargetDescriptor;
        renderingData.cameraData.requiresDepthTexture = true;

        blurDistance = settings.blurDistance;
        blurStrength = settings.blurStrength;
        cutoffDistance = settings.cutoffDistance;
        kernelSize = settings.kernelSize;
        sharpness = settings.sharpness;
        hardness = settings.hardness;
        zeroCrossing = settings.zeroCrossing;
        useZeta = settings.useZeta;
        zeta = settings.zeta;

    material.SetVector("_TintColor", new Vector4(tintColor.r, tintColor.g, tintColor.b, tintColor.a));
        material.SetInt("_KernelSize", kernelSize);
        material.SetInt("_N", 8);
        material.SetFloat("_Q", sharpness);
        material.SetFloat("_Hardness", hardness);
        material.SetFloat("_ZeroCrossing", zeroCrossing);
        material.SetFloat("_Zeta", useZeta ? zeta : 2.0f / (kernelSize / 2.0f));
        material.SetFloat("_Strength", blurStrength);
        material.SetFloat("_Depth", blurDistance);
        material.SetFloat("_CutoffDistance", cutoffDistance);

        tintBuffer = new RenderTargetIdentifier(tintBufferID);
        cmd.GetTemporaryRT(tintBufferID, descriptor, FilterMode.Point);
    }

    public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
    {
        CommandBuffer cmd = CommandBufferPool.Get();
        using (new ProfilingScope(cmd, new ProfilingSampler("Tint Pass")))
        {
            Blit(cmd, colorBuffer, tintBuffer, material);
            Blit(cmd, tintBuffer, colorBuffer);

        }

        context.ExecuteCommandBuffer(cmd);
        CommandBufferPool.Release(cmd);
    }

    public override void OnCameraCleanup(CommandBuffer cmd)
    {
        if (cmd == null) throw new System.ArgumentNullException("cmd");
        cmd.ReleaseTemporaryRT(tintBufferID);
    }
}
