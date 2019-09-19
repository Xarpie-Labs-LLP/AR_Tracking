using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycast : MonoBehaviour
{
    private RaycastHit hit;
    public GameObject Info1;
    public GameObject Info2;
    public GameObject video_quad;
 

    // Start is called before the first frame update
    void Start()
    {
        Info1.SetActive(false);
        Info2.SetActive(false);
    }
     void Cancel1()
    {
        Info1.SetActive(false);
    }
    void Cancel2()
    {
        Info2.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out hit,100))
            {
                if (hit.collider.tag == "1_Quad")
                {
                    Info1.SetActive(true);
                }
                if (hit.collider.tag == "2_Quad")
                {
                    Info2.SetActive(true);
                }
                if (hit.collider.tag == "close")
                {
                    video_quad.SetActive(false);
                }
            }

        }

    }

}
