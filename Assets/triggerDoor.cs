using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class triggerDoor : MonoBehaviour
{
    public BoxCollider2D door;
    private bool doorTrigger = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f")){
            if (doorTrigger){
                door.enabled = false;
            }
            else{
                door.enabled = true;
            }
            doorTrigger = !doorTrigger;
        }
    }
}