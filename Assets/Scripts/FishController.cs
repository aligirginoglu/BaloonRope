using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    public GameManager manager;

    [Header("Speed")]
    [SerializeField] float speed;

    [Header("Fish")]
    [SerializeField] GameObject fish;
    private float currentLerpTime;
    private float currentLerpTimeDivision;

    private void Start()
    {
        manager = GameManager.Instance;
    }
    void Update()
    {
        //Fish Left mov.  
        if (Input.GetKey(KeyCode.A))
        {
            if (gameObject.transform.position.x < -5)
            {
                speed = 0;
            }
            else
            {
                speed = 4;
            }
            FishMovement(0);
        }
        //Fish Right mov.  
        if (Input.GetKey(KeyCode.D))
        {
            if (gameObject.transform.position.x > 5)
            {
                speed = 0;
            }
            else
            {
                speed = 4;
            }
            FishMovement(-180);
        }
        
    }

    private void FishMovement(float rotateCounter)
    {
        //Fish -> Quaternion & Position
        if (!manager.gameEndBool)
        {
            transform.Translate(speed * Input.GetAxis("Horizontal") * Time.deltaTime, 0, 0);
            fish.transform.rotation = Quaternion.Lerp(fish.transform.rotation, Quaternion.Euler(0, rotateCounter, 0), currentLerpTime / (currentLerpTimeDivision * 5));
            currentLerpTime += Time.deltaTime;
            currentLerpTimeDivision += Time.deltaTime;
        }
            
        
        
    }
}
