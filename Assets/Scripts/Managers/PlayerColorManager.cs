using UnityEngine;
using System.Collections;

public class PlayerColorManager : MonoBehaviour {
    
    public Material materialPlayer1;
    public Material materialPlayer2;
    
    /// <summary>
    /// Checks if the materials are the same color,
    /// if they are put default colors.
    /// </summary>
    private void Awake() {
        if (materialPlayer1.color == materialPlayer1.color) {
            materialPlayer1.color = Color.red;
            materialPlayer2.color = Color.blue;
        }
    }
}
