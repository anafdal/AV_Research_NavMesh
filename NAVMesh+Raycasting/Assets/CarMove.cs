using UnityEngine;
using UnityEngine.AI;

public class CarMove : MonoBehaviour
{
    public Transform car1;
    public Transform car2;
    public Camera cam;//main camera
    public NavMeshAgent agent;
    RaycastHit hit1;//create variable that holds information of what got hit

    public static Vector3 destination;//original destination/target
    public Light green;
    public Light red;
    private bool stop = false;
    public static float distance;//distance between stopping point and car
    private Vector3 stopPos;

    [SerializeField]
    private LayerMask layerMask;
    public float maxDistance = 100.0f;//max distance for ray  from car
    RaycastHit raycastHit;//hit by car
    GameObject hit;
    OtherCarMove other;
    bool value=false;

    void Start()
    {
        destination = agent.destination;

    }

    // Update is called once per frame
    void Update()
    {
        //check if player presses left mouse button
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray1 = cam.ScreenPointToRay(Input.mousePosition);//create ray that shots where we click


            if (Physics.Raycast(ray1, out hit1))//so here we shot out ray>>feed ray to shot and hit
            {//make sure we only hit something

                //move our agent here
                agent.SetDestination(hit1.point);
                destination = hit1.point;
                //agent.Move();
            }
        }
        //Car Raycast

        Vector3 origin = new Vector3(transform.position.x, 0.0f, transform.position.z);//origin of raycast
        Vector3 direction = transform.forward;//direction of raycast

        Ray ray = new Ray(origin, direction);//car raycast


        if (Physics.Raycast(ray, out raycastHit, maxDistance, layerMask))
        {
            //Debug.Log("enter");
            stop = true;
            hit = raycastHit.transform.gameObject;

            hit.GetComponent<Renderer>().material.color = Color.yellow;//change color
            Debug.DrawRay(origin, direction * 200.0f, Color.red);//draw it out
            Debug.Log(hit.name);

           /* if (hit.transform.tag == "Stop")
            {
                stopPos = hit.transform.position;
                distance = Vector3.Distance(agent.destination, stopPos);
              

                if (red.enabled == true && stop == true)//stop because it's a red light
                {
                    value = other.carRaycast();

                    //total stop
                    if (agent.destination != hit.transform.position && value==false)//if car is not yet there it goes there 
                    {
                        
                          agent.SetDestination(hit.transform.position);//stop

                    }
                    else if(agent.destination != hit.transform.position && value == true)
                    {
                        other.carStop();//if there is a car
                    }
                    else
                    {
                        agent.Move(Vector3.zero);//stop moving once in stop position
                    }

                }
                else if (green.enabled == true && stop == true)//light turns green so go to original target
                {
                    agent.SetDestination(destination);//got to target
                    stop = false;
                }
            }

        }*/



      }

        if (red.enabled == true && stop == true)//stop because it's a red light
         {


             /* distance = Vector3.Distance(hit.transform.position, transform.position);//distance between objects
              //Debug.Log(distance);

              //total stop
              if (distance<15.0f)//if car is not yet there it goes there 
              {
                  agent.Move(Vector3.zero);//stop moving once in stop position
                  agent.SetDestination(this.transform.position);//stop

              }*/

          if (hit.transform.tag == "Stop")
           {
               //total stop
               if (agent.destination != hit.transform.position)//if car is not yet there it goes there 
               {
                    agent.SetDestination(hit.transform.position);//stop
                    

               }
               else
               {
                   agent.Move(Vector3.zero);//stop moving once in stop position
               }
           }

           //test
           else if (hit.transform.tag == "Car")
       {
               Debug.Log("1");
              float distance1 = Vector3.Distance(hit.transform.position, transform.position);//distance between objects

               if (distance1 < 50.0f)//stop in these units
               {
                   agent.Move(Vector3.zero);//stop moving 
                   agent.SetDestination(this.transform.position);//stop where car is
                   Debug.Log("car");
               }
               else
               {
                   agent.SetDestination(hit.transform.position);//stop
               }
           }



       }
       else if (green.enabled == true && stop == true)//light turns green so go to original target
       {
           agent.SetDestination(destination);//got to target
           stop = false;
       }

       /* float dist = Vector3.Distance(car1.position, car2.position);

        if (dist < 50)
        {
            agent.Move(Vector3.zero);//stop moving 
            agent.SetDestination(this.transform.position);//stop where car is
        }*/

   }




    /*  private bool carRaycast()//rey cast from the car
           {
              bool value = false;
              //these need  to be here

              Vector3 origin = new Vector3(transform.position.x, -0.5f, transform.position.z);//origin of raycast
              Vector3 direction = transform.forward;//direction of raycast

              Ray ray = new Ray(origin, direction);//car raycast
              //Debug.DrawRay(origin, direction * 200.0f, Color.red);//draw it out

              // var multipleHits = Physics.RaycastAll(ray);//can raycast multiple objects

              if (Physics.Raycast(ray, out raycastHit, maxDistance, layerMask))
              {
                  //Debug.Log("enter");
                  //value = true;
                  raycastHit.collider.GetComponent<Renderer>().material.color = Color.red;//change color
                  //distance=Vector3.Distance(other.position, transform.position);
              }

              return value;
           }*/

    
}


