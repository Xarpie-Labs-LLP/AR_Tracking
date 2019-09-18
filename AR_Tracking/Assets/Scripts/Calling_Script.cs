using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calling_Script : MonoBehaviour
{
    private Video_Script video_S;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
   public void OnPressed()
    {
        video_S = FindObjectOfType<Video_Script>();
        video_S.Video_btn();
    }
}
