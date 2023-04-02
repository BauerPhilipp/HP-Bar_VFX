using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HealthSlider : MonoBehaviour
{

    VisualElement root;
    static Slider healthSlider;

    static int sliderValue;

    public static int SliderValue
    {
        get { return sliderValue; }
        private set { sliderValue = value; }
    }

    public static void SetMaxValue(int value)
    {
        healthSlider.highValue = value;
    }

    // Start is called before the first frame update
    void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        healthSlider = root.Q<Slider>("HealthSlider");
        healthSlider.RegisterCallback<ChangeEvent<float>>(OnHealthSliderValueChange);
        SliderValue = Mathf.RoundToInt(healthSlider.value);
    }

    void OnHealthSliderValueChange(ChangeEvent<float> e)
    {
        SliderValue = Mathf.RoundToInt(e.newValue);
    }
}
