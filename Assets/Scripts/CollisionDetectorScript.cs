using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class CollisionDetectorScript : MonoBehaviour {
    
    private Planet CurrentPlanet { get; set; }
    private int PlanetsAttached = 0;
    private int errorMessageTimer = 0;

    private Component errorMessage;

    public GameObject errorCanvas;

    // Use this for initialization
    void Start()
    {
        errorMessage = GetComponent("WrongMessagePanel");
    }

    // Update is called once per frame
    void Update() {
        if (errorMessageTimer > 0)
        {
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ontrigger --------------------------------------------------------------------------------------------------------------------------------------");
        var intruder = other.gameObject;

        Planet nextPlanet = GetNextPlanet();
        Debug.Log("Next planet: "+nextPlanet);
        var canBeAttached = CanBeAttached(intruder, nextPlanet);

        Debug.Log("canBeAttached: " + canBeAttached);
        if (canBeAttached)
        {
            AttachPlanet(intruder);
        }
        else
        {
            ShowErrorMessage();
        }

    }

    private void ShowErrorMessage()
    {
        GameObject canvas = Instantiate(Resources.Load("Canvas")) as GameObject;
        Destroy(canvas, 2);
    }

    private void ShowPositiveFeedback()
    {
        GameObject canvas = Instantiate(Resources.Load("RightPanel")) as GameObject;
        Destroy(canvas, 0.5f);
    }

    private bool CanBeAttached(GameObject intruder, Planet nextPlanet)
    {
        var tag = intruder.tag;
        Debug.Log("collision enter with tag: " + tag);        
        return nextPlanet.ToString().Equals(tag, StringComparison.InvariantCultureIgnoreCase);
    }

    private void AttachPlanet(GameObject planet)
    {
        var sun = transform.Find("Sun");
        var tag = planet.gameObject.tag;

        var child = sun.Find(tag);
        if (child != null)
        {
            Debug.Log("activating gameobject: " + tag);
            child.gameObject.SetActive(true);
            child.GetComponent<OrbitBehavior>().enabled = true;
            planet.SetActive(false);
            PlanetsAttached++;
            CurrentPlanet = GetPlanetFromTag(tag);
            Debug.Log("current planet: " + CurrentPlanet.ToString());
            ShowPositiveFeedback();
            if (CurrentPlanet == Planet.NEPTUNE)
            {
                GameObject canvas = Instantiate(Resources.Load("DonePanel")) as GameObject;
            }

        }
    }

    private Planet GetNextPlanet()
    {
        if (CurrentPlanet == Planet.EMPTY)
        {
            return Planet.MERCURY;
        }
        else if (CurrentPlanet == Planet.MERCURY)
        {
            return Planet.VENUS;
        }
        else if (CurrentPlanet == Planet.VENUS)
        {
            return Planet.EARTH;
        }
        else if (CurrentPlanet == Planet.EARTH)
        {
            return Planet.MARS;
        }
        else if (CurrentPlanet == Planet.MARS)
        {
            return Planet.JUPITER;
        }
        else if (CurrentPlanet == Planet.JUPITER)
        {
            return Planet.SATURN;
        }
        else if (CurrentPlanet == Planet.SATURN)
        {
            return Planet.URANUS;
        }
        else if (CurrentPlanet == Planet.URANUS)
        {
            return Planet.NEPTUNE;
        }
        else if (CurrentPlanet == Planet.NEPTUNE)
        {
            return Planet.EMPTY;
        }

        return Planet.EMPTY;
    }

    private Planet GetPlanetFromTag(string tag)
    {
        if (tag.ToLower() == Planet.EMPTY.ToString().ToLower())
        {
            return Planet.EMPTY;
        }
        else if (tag.ToLower() == Planet.MERCURY.ToString().ToLower())
        {
            return Planet.MERCURY;
        }
        else if (tag.ToLower() == Planet.VENUS.ToString().ToLower())
        {
            return Planet.VENUS;
        }
        else if (tag.ToLower() == Planet.EARTH.ToString().ToLower())
        {
            return Planet.EARTH;
        }
        else if (tag.ToLower() == Planet.MARS.ToString().ToLower())
        {
            return Planet.MARS;
        }
        else if (tag.ToLower() == Planet.JUPITER.ToString().ToLower())
        {
            return Planet.JUPITER;
        }
        else if (tag.ToLower() == Planet.SATURN.ToString().ToLower())
        {
            return Planet.SATURN;
        }
        else if (tag.ToLower() == Planet.URANUS.ToString().ToLower())
        {
            return Planet.URANUS;
        }
        else if (tag.ToLower() == Planet.NEPTUNE.ToString().ToLower())
        {
            return Planet.NEPTUNE;
        }

        return Planet.EMPTY;
    }
    
}
