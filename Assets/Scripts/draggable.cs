using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class draggable : MonoBehaviour
{
    // Start is called before the first frame update
    private bool selected;
    public GameManager gm;
    Vector3 startPos;
    bool constructable = false;
    public GameObject loadingPage;
    public int constructedTime;
    void Start()
    {
        startPos = gameObject.transform.localPosition;
        constructedTime = 0 ;
    }

    // Update is called once per frame
    void Update()
    {   

        if(selected == true)   // while it is true , object follows the mouse position
        {
             Vector3 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(cursorPos.x-30, cursorPos.y-30,cursorPos.z+100);
            if (Input.GetMouseButtonUp(0))
            {
                if(constructable){
                     
                    selected = false;
                    constructedTime ++;
                    if(constructedTime ==1)  // if building is replaced, loading page should not be shown.
                    {
                        loadingPage.SetActive(true);
                        Invoke("closeLoadingPage",10.0f);
                    }
                    

                }
                else{
                    gameObject.transform.localPosition = startPos;  // if could not fit anywhere or put on the ground, object goes back to starting position
                    selected = false;
                }
            }
        }
    }
    void closeLoadingPage()
    {
        loadingPage.SetActive(false);
    }
    void OnMouseOver()  // If mouse is on the object and mouse clicks on it, boolean gets true 
    {
        if(gm.buildMode == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                 selected = true;
            }    
        }
        
    }

     private void OnTriggerEnter(Collider other)
    {
        if (transform.tag == "building")
        {
            if (other.gameObject.tag == "ground")  // if collision is with the ground, this means it is constructable
            {
                
                constructable = true;
            }
            else 
            {
                 
                constructable= false;
            }
        }
    }
}
