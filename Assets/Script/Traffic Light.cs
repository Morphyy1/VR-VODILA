using System.Collections;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    public Renderer[] Materials;

    public Color[] Colors;

    void Start()
    {
        StartCoroutine(ColorsReturn());
    }

    private IEnumerator ColorsReturn()
    {
        while (true)
        {
            var counter = 1;

            foreach (var value in Materials)
            {
                var valueMaterial = value.GetComponent<Renderer>().material;
                var valueLight = value.GetComponent<Light>();

                valueMaterial.color = Colors[counter];
                valueLight.enabled = true;
                
                if (counter == 2)
                    yield return new WaitForSeconds(2);
                else 
                    yield return new WaitForSeconds(6);

                valueMaterial.color = Colors[0];
                valueLight.enabled = false;
                counter++;
            }
            
        }
    }

}
