using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class pickup : MonoBehaviour
{
    public string textToShow;
    public void PickedUp()
    {
        Destroy(gameObject);
    }

    private void Start()
    {
       
    }

}
