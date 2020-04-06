using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseOverExample : MonoBehaviour
{

    void OnMouseOver()
    {
        print("hello0");
        //If your mouse hovers over the GameObject with the script attached, output this message
        
        Debug.Log("Mouse is over " + gameObject.ToString());
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer on GameObject.");
    }
}
