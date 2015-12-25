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

    public string redValueNameP1 = "Red Value P1";
    public string redValueNameP2 = "Red Value P2";
    public string greenValueNameP1 = "Green Value P1";
    public string greenValueNameP2 = "Green Value P2";
    public string blueValueNameP1 = "Blue Value P1";
    public string blueValueNameP2 = "Blue Value P2";

    public Material playerOneMaterial;
    public Material playerTwoMaterial;

    private float redValueP1;
    private float redValueP2;
    private float greenValueP1;
    private float greenValueP2;
    private float blueValueP1;
    private float blueValueP2;

    protected override void Start() {
        base.Start();
        // redValueP1 = GetColorRatio(GetSlider(redSlider));
        // redValueP2 = GetColorRatio(GetSlider(redSliderP2));

        // greenValueP1 = GetColorRatio(GetSlider(greenSlider));
        // greenValueP2 = GetColorRatio(GetSlider(greenSliderP2));

        // blueValueP1 = GetColorRatio(GetSlider(blueSlider));
        // blueValueP2 = GetColorRatio(GetSlider(blueSliderP2));
        
        SetSliderFill(redSlider, 255f);
        SetSliderFill(blueSliderP2, 255f);
        
    }


    // Update is called once per frame
    void Update() {

        redValueP1 = GetColorRatio(GetSlider(redSlider));
        SetText(redValueNameP1, GetSlider(redSlider).value.ToString());

        redValueP2 = GetColorRatio(GetSlider(redSliderP2));
        SetText(redValueNameP2, GetSlider(redSliderP2).value.ToString());

        greenValueP1 = GetColorRatio(GetSlider(greenSlider));
        SetText(greenValueNameP1, GetSlider(greenSlider).value.ToString());

        greenValueP2 = GetColorRatio(GetSlider(greenSliderP2));
        SetText(greenValueNameP2, GetSlider(greenSliderP2).value.ToString());

        blueValueP1 = GetColorRatio(GetSlider(blueSlider));
        SetText(blueValueNameP1, GetSlider(blueSlider).value.ToString());
        blueValueP2 = GetColorRatio(GetSlider(blueSliderP2));
        SetText(blueValueNameP2, GetSlider(blueSliderP2).value.ToString());

        SetImageColor(imagePreview, redValueP1, greenValueP1, blueValueP1, 1);
        SetImageColor(imagePreviewP2, redValueP2, greenValueP2, blueValueP2, 1);
        playerOneMaterial.color = GetImage(imagePreview).color;
        playerTwoMaterial.color = GetImage(imagePreviewP2).color;
    }

    public float GetColorRatio(Slider slider) {
        return slider.value / 255f;
    }

}
