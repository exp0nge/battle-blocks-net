using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ColorPicker_Screen : UI_Screen {

    public string redSlider = "Red Slider";
    public string greenSlider = "Green Slider";
    public string blueSlider = "Blue Slider";
    public string imagePreview = "Image";
    public Material material;

    private float redValue;
    private float greenValue;
    private float blueValue;

    protected override void Start() {
        base.Start();
        redValue = GetColorRatio(GetSlider(redSlider));
        greenValue = GetColorRatio(GetSlider(greenSlider));
        blueValue = GetColorRatio(GetSlider(blueSlider));
    }


    // Update is called once per frame
    void Update() {
        redValue = GetColorRatio(GetSlider(redSlider));
        greenValue = GetColorRatio(GetSlider(greenSlider));
        blueValue = GetColorRatio(GetSlider(blueSlider));

        SetImageColor(imagePreview, redValue, greenValue, blueValue, 1);
        material.color = GetImage(imagePreview).color;
    }

    public float GetColorRatio(Slider slider) {
        return slider.value / 255f;
    }

}
