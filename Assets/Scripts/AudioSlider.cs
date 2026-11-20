using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
using System;

public class AudioSlider : MonoBehaviour
{
    // For this script to be useful you need an audio mixer, mixer group(-s)
    // as well as exposing volume parameter(-s) from said group(-s)
    [SerializeField]
    private AudioMixer mixer;
        // Hard code this instead and make students add the variable?
    [SerializeField]
    private string audioMixerParameter;
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private TextMeshProUGUI sliderValueText;

    [SerializeField]
    private bool applyLogarithmic = true;

    public enum ScaleType
    {
        Percentage,
        Decimals,
        UnlockedPercentage
    }

    public ScaleType valueScaleType = ScaleType.Percentage;

    void Awake()
    {
        mixer.GetFloat(audioMixerParameter, out float previousValue);

        // Logarithmic to linear
        if (applyLogarithmic)
            slider.value = Mathf.Pow(10, (previousValue / 20));
        else
            slider.value = previousValue;

        SetText(slider.value);
    }

    public void SetLevel(float sliderValue)
    {
        SetText(sliderValue);

        if (applyLogarithmic)
        {

            // Make sure code doesn't break by setting very low values to the minimum db manually instead of doing the math
            if (sliderValue < 0.0001f)
            {
                mixer.SetFloat(audioMixerParameter, -80f);
                return;
            }
                
            // Linear to logarithmic
            mixer.SetFloat(audioMixerParameter, Mathf.Log10(sliderValue) * 20);
        }
        else
        {
            mixer.SetFloat(audioMixerParameter, sliderValue);
        }
    }

    private void SetText(float value)
    {
        switch (valueScaleType)
        {
            case ScaleType.Percentage:
                float valuePercent = value * 100;
                sliderValueText.SetText($"{(int)valuePercent}");
                break;
            case ScaleType.Decimals: 
                sliderValueText.SetText($"{value:N2}");
                break;
        }
    }
}
