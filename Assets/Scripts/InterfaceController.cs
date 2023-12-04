using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour
{
    private PlayerController playerController;
    public Slider SliderPlayerLife;
    void Start()
    {
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        SliderPlayerLife.maxValue = playerController.health;
        UpdateLife();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateLife()
    {
        SliderPlayerLife.value = playerController.health;
    }
}
