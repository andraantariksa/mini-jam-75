using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Image woodBookImage;
    public Image fireBookImage;

    public GameObject fireBook;
    public GameObject woodBook;

    public Transform playerPos;

    public Vector3 playerToBookOffset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateBookUI();
    }

    void UpdateBookUI()
    {
        if (GameObject.FindGameObjectWithTag("FireBook") == null)
        {
            if (GameObject.FindGameObjectWithTag("WoodBook") == null)
            {
                Instantiate(woodBook, playerPos.position + playerToBookOffset, woodBook.transform.rotation);
                woodBookImage.enabled = false;
            }

            fireBookImage.enabled = true;
        }
        else { fireBookImage.enabled = false; }



        if (GameObject.FindGameObjectWithTag("WoodBook") == null)
        {
            if (GameObject.FindGameObjectWithTag("FireBook") == null)
            {
                Instantiate(fireBook, playerPos.position + playerToBookOffset, fireBook.transform.rotation);
                fireBookImage.enabled = false;
            }
            woodBookImage.enabled = true;
        }
        else { woodBookImage.enabled = false; }
    }
}
