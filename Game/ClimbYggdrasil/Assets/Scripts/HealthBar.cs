using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Sprite hp1;
    public Sprite hp2;
    public Sprite hp3;
    public Sprite hp4;
    public Sprite hp5;
    public Sprite hp6; 
    public Sprite hp7;
    public Sprite hp8;
    public GameObject player;

    void Start()
    {
        GetComponent<Image>().sprite = hp8;
    }


    public void HealthBarUpdate(int hp)
    {
        switch (hp)
        {
            case 1:
                GetComponent<Image>().sprite = hp1;
                break;
            case 2:
                GetComponent<Image>().sprite = hp2;
                break;
            case 3:
                GetComponent<Image>().sprite = hp3;
                break;
            case 4:
                GetComponent<Image>().sprite = hp4;
                break;
            case 5:
                GetComponent<Image>().sprite = hp5;
                break;
            case 6:
                GetComponent<Image>().sprite = hp6;
                break;
            case 7:
                GetComponent<Image>().sprite = hp7;
                break;
            case 8:
                GetComponent<Image>().sprite = hp8;
                break;
            default:
                GetComponent<Image>().sprite = hp1;
                break;
        }
    }
}
