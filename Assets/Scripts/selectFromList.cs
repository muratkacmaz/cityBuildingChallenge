using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectFromList : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject residencePrefab,woodPrefab,steelPrefab,benchPrefab,treePrefab;
    private Vector3 mousepos;
    private GameObject temp;
    public GameObject popUp;
    public buildingProgress bp;
    
    void Start()
    {
        mousepos =new  Vector3(130,20,0);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // These button clicks for the selecting list. If the user have enough amount of the products, We call the addToResources to pay with products
    public void resButtonClick(){    
            if(buildingProgress.totalGold >= 100)
            {
                temp = Instantiate(residencePrefab, mousepos, Quaternion.identity) as GameObject;
                bp.addToResources(-100,0,0);
            }
            else   notEnoughAmount();
    }
    public void woodButtonClick(){
         if(buildingProgress.totalGold >= 150)
            {
                temp = Instantiate(woodPrefab, mousepos, Quaternion.identity) as GameObject;
                  bp.addToResources(-150,0,0);
            }
            else   notEnoughAmount();
       }
    public void steelButtonClick(){
         if(buildingProgress.totalGold >= 150 && buildingProgress.totalWood>= 100)
            {
                temp = Instantiate(steelPrefab, mousepos, Quaternion.identity) as GameObject;
                 bp.addToResources(-150,-100,0);
            }
            else   notEnoughAmount();
          }
    public void benchButtonClick(){
         if(buildingProgress.totalGold >= 150 && buildingProgress.totalSteel >=50)
            {
                temp = Instantiate(benchPrefab, mousepos, Quaternion.identity) as GameObject;
                 bp.addToResources(-150,0,-50);
            }
            else   notEnoughAmount();
       }

    public void treeButtonClick(){
         if(buildingProgress.totalGold >= 50 && buildingProgress.totalWood >= 200)
            {
                temp = Instantiate(treePrefab, mousepos, Quaternion.identity) as GameObject;
                bp.addToResources(-50,-200,0);
            }
            else   notEnoughAmount();
       }


    void notEnoughAmount()
    {
        popUp.SetActive(true);  // pop up shows that you can not afford this building

    }
    

 
     
        
    
 
}
