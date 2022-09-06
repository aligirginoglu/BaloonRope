using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFish : MonoBehaviour
{
    public GameManager manager;
    private void Start()
    {
        manager = GameManager.Instance;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "LoseArea")
        {
            //Game Lose
            manager.LoseParticle.Play();
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            StartCoroutine(waitLosePanel());
            manager.gameEndBool = true;
        }
    }

    IEnumerator waitLosePanel()
    {
        yield return new WaitForSeconds(1.5f);
        manager.LosePanel.SetActive(true);
    }
}
