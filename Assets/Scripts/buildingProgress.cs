using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buildingProgress : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gm;
    public int buildingType;
    public static  int totalGold , totalWood , totalSteel  ;
    public int addGold,addWood,addSteel; 

    public Text counterText; // text on the  canvas for countdown
    public Text goldAmount,steelAmount,woodAmount;
    
    float timeLeft = 10.0f;
    GameObject temp ;
    bool openClose;  // checks the name and time bars are visible  
    public bool progressStart; // starts the progress and timer
    void Start()
    {   
        totalGold = 0 ;
        totalWood = 0;
        totalSteel = 0 ;
        progressStart = false;
        if(buildingType == 1) progressStart = true;  // Residence starts automatically
        openClose = true;
        temp = gameObject.transform.FindChild ("Canvas").gameObject;
    }

    // Update is called once per frame
    void Update()
    { 
        if(gm.regularMode==false)
        {
            temp.SetActive(false);
            openClose = true;
        }

        if(progressStart == true)
        {   
            
            timeLeft-= Time.deltaTime;
            counterText.text = (timeLeft).ToString("0");
            if(timeLeft <=0 )
            {   
                timeLeft = 10.0f;
                addToResources(addGold,addWood,addSteel); // here I am changing the amount of products on top bar
            }       
        }
       
    }


    void OnMouseDown(){
        if(gm.regularMode==true)
        {
            if(openClose == true)
            {   
            temp.SetActive(true);
            openClose = false;
            }
            else {
            
            temp.SetActive(false);
            openClose = true;
            }
        }
     
    }

    public void progressBoolSwitch(){
        progressStart = !progressStart;
    }

    public void addToResources(int addGold,int addWood, int addSteel)
    {

        totalGold += addGold;
        goldAmount.text = (totalGold).ToString("0");
        
        totalWood +=addWood;
        woodAmount.text =(totalWood).ToString("0");

        totalSteel += addSteel;
        steelAmount.text =(totalSteel).ToString("0");
       
    }
}
