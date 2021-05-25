using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkChecker : MonoBehaviour
{
    public Text textResult;
    [SerializeField] public GameObject Alert
        ;

    private void Awake()
    {
        InvokeRepeating("CheckNetworkControll", 1, 1);
    }

    private void CheckNetworkControll()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            StartCoroutine(WaitNet(true));
            

        }
        else
        {
            Debug.Log("Internet is Good");
            //alert.SetActive(true);
            //textResult.text = "You are Connected and online";

        }
    }

    public IEnumerator WaitNet(bool net)
    {
        yield return new WaitForSecondsRealtime(1f);
        if (net == true)
        {
            Alert.SetActive(true);
          

            textResult.text = "Sorry, you do not have connection. Please check your Internet.";

            Application.Quit();
        }

    }

}
