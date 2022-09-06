using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObject : MonoBehaviour
{   
    [Header("Baloons")]
    [SerializeField] GameObject baloon;
    private float currentInstantiateBaloon;

    [Header("Shuriken")]
    [SerializeField] GameObject shuriken;
    private float currentInstantiateShuriken;
    private float InstantiateShurikenTime;

    void Update()
    {
        currentInstantiateBaloon += Time.deltaTime;     
        //Create Baloon
        if (currentInstantiateBaloon >= 2)
        {
            float randomPosX;
            randomPosX = Random.Range(-6, 7);
            Instantiate(baloon, new Vector3(randomPosX, baloon.transform.position.y, baloon.transform.position.z), Quaternion.identity);
            currentInstantiateBaloon = 0;
        }
        InstantiateShurikenTime += (Time.deltaTime / 1000);
        currentInstantiateShuriken += Time.deltaTime;
        currentInstantiateShuriken += InstantiateShurikenTime;
        //Create Shuriken
        if (currentInstantiateShuriken >= 3)
        {
            float randomPosX;
            randomPosX = Random.Range(-5, 6);
            Instantiate(shuriken, new Vector3(randomPosX, shuriken.transform.position.y +3, shuriken.transform.position.z), Quaternion.identity);
            currentInstantiateShuriken = 0;
        }
       
    }
}
