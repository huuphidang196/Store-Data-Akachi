using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHealthy : MonoBehaviour
{
    public Slider slHealthy;
    public GameObject Boss;
    private float currentHealthy;
    // Start is called before the first frame update
    void Start()
    {
        currentHealthy = Boss.GetComponent<Boss>().currentHealthy;
        slHealthy.maxValue = Boss.GetComponent<Boss>().maxHealthy;
        slHealthy.minValue = 0;
        slHealthy.value = slHealthy.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealthy = Boss.GetComponent<Boss>().currentHealthy;
        slHealthy.value = currentHealthy;
    }
}
