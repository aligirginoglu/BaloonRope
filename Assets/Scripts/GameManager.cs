using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    [Header("Game")]
    [SerializeField] public ParticleSystem LoseParticle;
    [SerializeField] public bool loseBool = false;
    [SerializeField] public bool gameEndBool = false;
    [SerializeField] public GameObject LosePanel;
    [SerializeField] float gameTime;
    [SerializeField] TMP_Text gameTimeText;
    [SerializeField] TMP_Text gameTimeTextEnd;
    [SerializeField] GameObject tutorial;
 
    [Header("FishBaloon")]
    [SerializeField] GameObject fishBaloonParent;
    [SerializeField] int fishBaloonCounter = 0;
    [SerializeField] Material[] materialBaloon;
    [SerializeField] public int baloonCounter = 1;

    [Header("Fish")]
    [SerializeField] GameObject BigFish;
    [SerializeField] GameObject MyFish;

    private void Start()
    {
        StartCoroutine(tutorialClose());
    }

    void Update()
    {
        // End Game stopped time
        if (!gameEndBool)
        {
            gameTime += Time.deltaTime;
            gameTimeText.text = System.Convert.ToUInt32(gameTime).ToString() + " s.";
            gameTimeTextEnd.text = System.Convert.ToUInt32(gameTime).ToString() + " s.";
        }


        // MyFish approaching the ground
        if (loseBool)
        {
            MyFish.transform.position = Vector3.Lerp(MyFish.transform.position,
                                                     new Vector3(MyFish.transform.position.x,
                                                     MyFish.transform.position.y - 0.3f,
                                                     MyFish.transform.position.z), 1f * Time.deltaTime);
        }
        
        BigFish.transform.Rotate(0, 0.5f, 0);
        
    }

    public void CreateFishBaloon()
    {
        //Create Fish on Baloon
        fishBaloonCounter++;
        baloonCounter++;
        GameObject child = fishBaloonParent.gameObject.transform.GetChild(fishBaloonCounter).gameObject;
        GameObject childBaloon = child.gameObject.transform.GetChild(0).gameObject;

        int colorNum = Random.Range(0, 5);
        childBaloon.GetComponent<Renderer>().material.color = materialBaloon[colorNum].color;

        child.SetActive(true);

        if (baloonCounter > 0)
        {
            UpFish();
        }
    }
    
    public void UpFish()
    {
        loseBool = false;
    }

    public void DownFish()
    {       
        loseBool = true;
    }

    public void TryAgainButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    IEnumerator tutorialClose()
    {
        yield return new WaitForSeconds(2f);
        tutorial.SetActive(false);
    }

}
