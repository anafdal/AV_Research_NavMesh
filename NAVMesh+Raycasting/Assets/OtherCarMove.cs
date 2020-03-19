using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OtherCarMove : MonoBehaviour
{
    private LayerMask layerMask;
    public float maxDistance = 100.0f;//max distance for ray  from car
    RaycastHit raycastHit;//hit by car
    GameObject hit;
    CarMove otherClass;
    public NavMeshAgent agent;

    private void Start()
    {
      
    }
    // Update is called once per frame
    void Update()
    {
      
    }


   public bool carRaycast()//rey cast from the car
    {
        bool value = false;
        Vector3 origin = new Vector3(transform.position.x, 0.0f, transform.position.z);//origin of raycast
        Vector3 direction = transform.forward;//direction of raycast
        Ray ray = new Ray(origin, direction);//car raycast

        if (Physics.Raycast(ray, out raycastHit, maxDistance, 9))
        { 
            value = true;
        }
        return value;
    }

    public void carStop() {

        Vector3 origin = new Vector3(transform.position.x, 0.0f, transform.position.z);//origin of raycast
        Vector3 direction = transform.forward;//direction of raycast
        Ray ray = new Ray(origin, direction);//car raycast

        if (Physics.Raycast(ray, out raycastHit, maxDistance, 9))
        {
            //Debug.Log("enter");
            hit = raycastHit.transform.gameObject;

            hit.GetComponent<Renderer>().material.color = Color.yellow;//change color
            Debug.DrawRay(origin, direction * 200.0f, Color.red);//draw it out
            Debug.Log(hit.name);
           
        }

        if (hit.transform.tag == "Car")
            {
                Debug.Log("1");

                float distance1 = Vector3.Distance(hit.transform.position, transform.position);//distance between objects

                if (distance1 < 50.0f)//stop in these units
                {
                    agent.Move(Vector3.zero);//stop moving 
                    agent.SetDestination(transform.position);//stop where car is
                    Debug.Log("car");
                  
                }


            }
        }


       
}
        

