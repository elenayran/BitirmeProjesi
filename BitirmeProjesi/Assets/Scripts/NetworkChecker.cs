using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkChecker : MonoBehaviour
{
    public Text textResult;
    public GameObject alert;
    private void Awake()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("No Internet");
            alert.SetActive(true);
            textResult.text = "Sorry, you do not have connection. Please check your Internet.";

            Application.Quit();

        }
        else
        {
            Debug.Log("Internet is Good");
            alert.SetActive(true);
            textResult.text = "You are Connected and online";

        }






    }





}
