using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   
   public bool regularMode,buildMode;
    void Start()   // Here I start with the regular mode
    {
        regularMode = true;
        buildMode = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void selectRegularMode(){  // these buttons for switching the modes
        regularMode = true;
        buildMode = false;
    }
    
    public void selectBuildMode(){
        regularMode = false;
        buildMode = true;
    }
}
