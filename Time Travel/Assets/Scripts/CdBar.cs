using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CdBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image Carga;

    public void SetMaxCharge(float Charge)
    {
        slider.maxValue = Charge;
        slider.value = Charge;

        Carga.color = gradient.Evaluate(1f);

    }
    public void SetCharge(float Charge)
    {
        slider.value = Charge;

        Carga.color = gradient.Evaluate(slider.normalizedValue);
    }

}
