using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    public GameManager manager;

    [SerializeField] GameObject ParticleBoom;
    void Start()
    {
        manager = GameManager.Instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Destroy")
        {
            //Destory Shuriken on ground
            Destroy(this.gameObject.transform.parent.gameObject.transform.parent.gameObject);
        }
        
        if (other.gameObject.tag == "Baloon")
        {
            
            manager.baloonCounter--;
            Debug.Log(manager.baloonCounter);
            ParticleBoom.transform.parent.gameObject.SetActive(true);

            //Explosion effect in the color of the balloon
            Color c;
            c = other.GetComponent<Renderer>().material.color;       
            ParticleSystem ps = ParticleBoom.GetComponent<ParticleSystem>();
            var main = ps.main;
            main.startColor = new Color(c.r, c.g, c.b);
            ParticleBoom.GetComponent<ParticleSystem>().Play();

            //Inactive baloon
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            other.gameObject.GetComponent<ConstantForce>().enabled = false;
            other.gameObject.GetComponent<CapsuleCollider>().enabled = false;

            if (manager.baloonCounter<=0)
            {      
                manager.DownFish();
            }
            
        }
    }

    void Update()
    {
       
    }
}
