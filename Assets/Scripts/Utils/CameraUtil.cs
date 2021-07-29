using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraUtil : MonoBehaviour
{    

    public static void sayHello()
    {
        Debug.Log("Hola");
    }

    public static void shakeCamera(float amplitude = 1f, float frequency = 2f, float attack = 0f, float sustainTime = 1f, float decay = 0.7f)
    {
        CinemachineImpulseSource impulseSource = Camera.main.GetComponent<CinemachineImpulseSource>();

        //Configurar shake
        impulseSource.m_ImpulseDefinition.m_AmplitudeGain = amplitude;
        impulseSource.m_ImpulseDefinition.m_FrequencyGain = frequency;
        impulseSource.m_ImpulseDefinition.m_TimeEnvelope.m_AttackTime = attack;
        impulseSource.m_ImpulseDefinition.m_TimeEnvelope.m_SustainTime = sustainTime;
        impulseSource.m_ImpulseDefinition.m_TimeEnvelope.m_DecayTime = decay;

        impulseSource.GenerateImpulse();//Call shake
    }
}
