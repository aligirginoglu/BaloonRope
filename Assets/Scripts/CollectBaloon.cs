using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectBaloon : MonoBehaviour
{
    public GameManager manager;

    private float rotationY;
    private float rotationX;
    private void Start()
    {
        manager = GameManager.Instance;

        transform.rotation = Quaternion.Euler(-62.2f, 0, 0);

        rotationY = Random.Range(-2 , 2);
        rotationX = Random.Range(-2, 2);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Create baloon
        if (other.gameObject.tag == "Fish")
        {
            manager.CreateFishBaloon();
            Destroy(this.gameObject);
        }

        //Dont use baloon destroy
        if (other.gameObject.tag == "Destroy")
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        transform.Rotate(rotationX, rotationY, 0);
    }

}
