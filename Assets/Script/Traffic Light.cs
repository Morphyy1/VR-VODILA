using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    public Renderer[] Materials;
    public Color[] Colors;

    private int _colorCounter;

    void Start()
    {
        StartCoroutine(ColorsReturn());
    }

    private IEnumerator ColorsReturn()
    {
        while (true)
        {
            _colorCounter = 1;

            foreach (var value in Materials)
            {
                var valueMaterial = value.GetComponent<Renderer>().material;
                var valueLight = value.GetComponent<Light>();

                LightOn(valueMaterial, valueLight);
                
                if (_colorCounter == 2)
                    yield return new WaitForSeconds(2);
                else 
                    yield return new WaitForSeconds(6);

                if (_colorCounter != 2)
                    yield return BlinkLight(valueMaterial, valueLight);

                LightOff(valueMaterial, valueLight);
                _colorCounter++;
            }
            
        }
    }

    private IEnumerator BlinkLight(Material valueMaterial, Light valueLight)
    {
        for (var i = 0; i < 3; i++)
        {
            LightOff(valueMaterial, valueLight);
            yield return new WaitForSeconds(0.6f);

            LightOn(valueMaterial, valueLight);
            yield return new WaitForSeconds(0.6f);
        }
    }

    private void LightOn(Material valueMaterial, Light valueLight)
    {
        valueMaterial.color = Colors[_colorCounter];
        valueLight.enabled = true;
    }

    private void LightOff(Material valueMaterial, Light valueLight)
    {
        valueMaterial.color = Colors[0];
        valueLight.enabled = false;
    }

}
