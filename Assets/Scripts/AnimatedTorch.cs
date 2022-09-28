using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedTorch : MonoBehaviour {

    Transform mainLight;
    Transform flickerLight;
    Light mainLightComponent;
    Light flickerLightComponent;

    void Start()
    {
        mainLight = this.transform.GetChild(0);
        flickerLight = this.transform.GetChild(1);
        mainLightComponent = mainLight.GetComponent<Light>();
        flickerLightComponent = flickerLight.GetComponent<Light>();

        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        for (; ; ) //while(true)
        {
            float randomIntensity = Random.Range(0.3f, 0.6f);
            flickerLightComponent.intensity = randomIntensity;


            float randomTime = Random.Range(0f, 0.1f);
            yield return new WaitForSeconds(randomTime);
        }
    }
}
