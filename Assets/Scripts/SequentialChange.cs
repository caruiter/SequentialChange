//Callandra Ruiter GDD410
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script changes the material used on a list of gameobjects in the order that they are put on the list at an assigned interval
//this script doesn't need to be attatched to any particular place, but does need to be assigned the objects and materials

public class SequentialChange : MonoBehaviour
{
    //list of the objects that will change materials
    [SerializeField] List<GameObject> objectsInOrder;

    //are the objects currently changing?
    private bool changing;

    //which object changed last?
    private int index;

    //how much time has elapsed since last change
    private float ct;

    //materials that the objects will switch between
    [SerializeField] Material mat1;
    [SerializeField] Material mat2;

    //how long is the interval between changes?
    [SerializeField] private float interval;

    //marker for which material is being used
    private bool firstMatUsed;

    // Start is called before the first frame update
    void Start()
    {
        changing = false;
        firstMatUsed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (changing) //check if materials are changing
        {
            ct += Time.deltaTime; //increment time
            if (ct >= interval) //if it's been the required interval between changes
            {
                if (index >= objectsInOrder.Count) // check if last object
                {
                    changing = false;
                    if(firstMatUsed) //note which material is next
                    {
                        firstMatUsed = false;
                    }
                    else
                    {
                        firstMatUsed = true;
                    }
                }
                else //if not the last object
                {
                    ct = 0;
                    if(firstMatUsed)//switch next object
                    {
                        objectsInOrder[index].GetComponent<SpriteRenderer>().material = mat2;
                    }
                    else
                    {
                        objectsInOrder[index].GetComponent<SpriteRenderer>().material = mat1;
                    }
                    index++;//increment index of list of gameobjects
                }

            }
        }
        
    }

    public void BeginChange()//this method starts the change and is called by the event Change
    {
        if (objectsInOrder.Count > 0) // check that there are objects in list
        {
            index = 0;
            changing = true;
            ct = .6f;
        }
    }
}
