using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Video_Script : MonoBehaviour
{
    public GameObject video_quad;
    public GameObject Info1;
    public GameObject Info2;

    // Start is called before the first frame update
   public void Start()
    {
        video_quad.SetActive(false);
    }

    // Update is called once per frame
    public void Video_btn()
    {
        Debug.Log("Button Pressed");
        video_quad.SetActive(true);
        Info1.SetActive(false);
        Info2.SetActive(false);
    }
}
