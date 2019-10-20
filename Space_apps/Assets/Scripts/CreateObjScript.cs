using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

using System;
using System.Globalization;

public class CreateObjScript : MonoBehaviour
{

    GameObject[] go;
    GameObject sun;
    public GameObject planet;
    public GameObject Blue;
    public GameObject White;
    public GameObject Yellow;
    public GameObject Orange;
    public GameObject Red;


    public InputField massField;
    public InputField tempField;
    public InputField radioField;

    public Text text;

    private bool hasStar=false;
    private int orbit = 100;

    int numPlanets=0;

    private string smass, stemp, sradio;
    private int mass, temp, radio;

    private string smassP, stempP, sradioP;
    private int massP, tempP;
    
    [Range(0.1f, 40F)]
    private float radioP;

    const int MAXN_PLANETS = 5;


    void Start ()
    { 
        go = new GameObject[MAXN_PLANETS];
    }

    void update()
    {
        //print(transform.position);
    }


    public bool parameterStarOK(int M, int T, float R)
    {
        // make sure it's ok
        if ((M > 0) && (T >= 2000) && (R > 0) && (T <= 25000))
            return true;

        return false;
    }

    public bool parameterPlanetOk(int M, int T, float R)
    {

        // make sure it's ok
        if ((M > 0) && (T > 0) && (R > 0) && (R<20) && (T <= 25000))
            return true;

        return false;
    }

    public int RandomNumber(int min, int max)
    {
        System.Random random = new System.Random();
        return random.Next(min, max);
    }

    public GameObject corChoose(int T)
    {
        Debug.Log("Choose what planet?");


        //5 colors
        // > 10k blue
        // >7.5k white
        // >5k   yellow
        // > 3.5k orange
        // > 2k red


        if (T >= 10000) return Blue;
        if (T >= 7500)  return White;
        if (T >= 5000)   return Yellow;
        if (T >= 3500)   return Orange;
        if (T >= 2000)   return Red;

        return null;
    }
    public void onClick ()
    {
        smass = massField.text;
        stemp = tempField.text;
        sradio = radioField.text;

        mass = int.Parse(smass);
        temp = int.Parse(stemp);
        radio = int.Parse(sradio);

        if (!hasStar || (!parameterStarOK(mass, temp, radio)))
        {

            Debug.Log("Entrou if1");

            if (!parameterStarOK(mass, temp, radio) || numPlanets >= MAXN_PLANETS)
            {

                
                text.text = "Planets can have a surface with low temperature." +
                    " Interesting notice that they can have their nucleo with" +
                    " higher temperatures.For exemple, here in our Solar System" +
                    " there is Neptune with - 218 ºC in his atmosphere, but has a" +
                    " much hotter nucleo around 7000ºC";
            }

            else 
            {

                //start value of SUN

                //sun.GetComponent<BehaviourScript>().mass = mass;
                //sun.GetComponent<BehaviourScript>().temp = temp;
                //sun.GetComponent<BehaviourScript>().radio = radio;


                text.text = "\n\nStar Created!";
                

                // create new SUN


                sun = Instantiate(corChoose(temp), new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 100));
                sun.transform.localScale = (new Vector3(1, 1, 1)) * radio;
                sun.AddComponent<HeavenlyBody>();

                //Instantiate(go[0], new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 100));
                hasStar = true;

                GameObject.Find("CreateButton").GetComponentInChildren<Text>().text = "Create Planet!";
            }

            
            // GameObject.Find("CreateStar").SetActive(false);

            
        }
        else
        {
            //there is a star and we know parameters is ok
            
            
            smassP = massField.text;
            stempP = tempField.text;
            
            sradioP = radioField.text;



            massP = int.Parse(smassP);
            tempP = int.Parse(stempP);
            
            
            radioP = int.Parse(sradioP);

           
            if (parameterPlanetOk(massP, tempP, radioP))
            {
                // create this new planet

                go[numPlanets] = Instantiate(planet, new Vector3(orbit, 0, orbit), new Quaternion(0, 0, 0, 0));
                orbit += 50;

                // set values of my new planet

                go[numPlanets].transform.localScale = (new Vector3(1, 1, 1))*radioP;
                go[numPlanets].AddComponent<HeavenlyBody>();
                OrbitMotion temp = go[numPlanets].AddComponent<OrbitMotion>();
                temp.orbitPath = new Ellipse(go[numPlanets].transform.position.x, go[numPlanets].transform.position.z);


                numPlanets++;
                text.text = "Planet Created!";
            }
            else
            {
                text.text = "Impossible! Heaven is our limit";
            }
         

        }

        

    }

    public void resetScene()
    {
        for(int i = 0; i < MAXN_PLANETS; i++)
        {
            GameObject.Destroy(go[i]);
        }
        GameObject.Destroy(sun);
        hasStar = false;
        numPlanets = 0;
        GameObject.Find("CreateButton").GetComponentInChildren<Text>().text = "Create Star!";
    }




}
