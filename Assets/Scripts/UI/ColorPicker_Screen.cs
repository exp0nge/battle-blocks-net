using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ColorPicker_Screen : UI_Screen {

    public string redSlider = "Red Slider";
    public string redSliderP2 = "Red Slider P2";
    public string greenSlider = "Green Slider";
    public string greenSliderP2 = "Green Slider P2";
    public string blueSlider = "Blue Slider";
    public string blueSliderP2 = "Blue Slider P2";
    public string imagePreview = "Color Preview P1";
    public string imagePreviewP2 = "Color Preview P2";

    public Material material;
    public Material materialP2;

    private float redValue;
    private float redValueP2;
    private float greenValue;
    private float greenValueP2;
    private float blueValue;
    private float blueValueP2;

    protected override void Start() {
        base.Start();
        redValue = GetColorRatio(GetSlider(redSlider));
        redValueP2 = GetColorRatio(GetSlider(redSliderP2));

        greenValue = GetColorRatio(GetSlider(greenSlider));
        greenValueP2 = GetColorRatio(GetSlider(greenSliderP2));

        blueValue = GetColorRatio(GetSlider(blueSlider));
        blueValueP2 = GetColorRatio(GetSlider(blueSliderP2));
    }


    // Update is called once per frame
    void Update() {
        //Debug.Log(redSlider);
        redValue = GetColorRatio(GetSlider(redSlider));
        redValueP2 = GetColorRatio(GetSlider(redSliderP2));

        greenValue = GetColorRatio(GetSlider(greenSlider));
        greenValueP2 = GetColorRatio(GetSlider(greenSliderP2));

        blueValue = GetColorRatio(GetSlider(blueSlider));
        blueValueP2 = GetColorRatio(GetSlider(blueSliderP2)); ;

        SetImageColor(imagePreview, redValue, greenValue, blueValue, 1);
        SetImageColor(imagePreviewP2, redValueP2, greenValueP2, blueValueP2, 1);
        material.color = GetImage(imagePreview).color;
        materialP2.color = GetImage(imagePreviewP2).color;
    }

    public float GetColorRatio(Slider slider) {
        return slider.value / 255f;
    }

}
