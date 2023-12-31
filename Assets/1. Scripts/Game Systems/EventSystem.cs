using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    [Header("Settings")] 
    [SerializeField] private Transform coordinatesLeftBottom ;
    [SerializeField] private Transform coordiantesRightTop;

    [Header("ScreenShake")] 
    [SerializeField] private float _shakeIntensity;
    [SerializeField] private float _screenShakeDuration;
    
    [Header("Refs")]
    [SerializeField] private ShieldSystems shield;
    [SerializeField] private EnvironmentController _environmentController;
    [SerializeField] private CinemachineVirtualCamera _camera;

    
    public void Attacked()
    {
        if (shield.shieldActive)
        {
            // GameMaster.ChangeScoreBy(scoreHitDeflected);
            SoundManager.Play(6) ;
        }
        else
        {
            float x = Random.Range(coordinatesLeftBottom.position.x, coordiantesRightTop.position.x);
            float y = Random.Range(coordinatesLeftBottom.position.y, coordiantesRightTop.position.y);
            _environmentController.ApplyEffectFrom(new Vector2(x, y));
            StartScreenShake();
        }
    }

    private void StartScreenShake(float intensity = -1)
    { 
        StopAllCoroutines();
        StartCoroutine(ScreenShakeCooldown());
        float shakeIntensity = intensity == -1 ? _shakeIntensity : intensity;
        _camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = shakeIntensity;
    }

    private void StopScreenShake()
    {
        _camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
    }
    
    private IEnumerator ScreenShakeCooldown()
    {
        yield return new WaitForSeconds(_screenShakeDuration);
        StopScreenShake();
    }
    
}