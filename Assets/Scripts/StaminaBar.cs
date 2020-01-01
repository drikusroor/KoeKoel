using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaBar : MonoBehaviour
{
    private Player player;

    public GUIStyle progress_empty;
    public GUIStyle progress_full;

    //current progress
    public float barDisplay;

    public GameObject bar;
    private RectTransform barTransform;
    public float fullWidth = 250;

    void Start()
    {
        player = FindObjectOfType<Player>();
        barTransform = bar.GetComponent<RectTransform>();

    }

    void Update()
    {
        //the player's health
        float newWidth = fullWidth * player.stamina / player.staminaTotal;
        barTransform.sizeDelta = new Vector2(newWidth, barTransform.rect.height);
    }

}
