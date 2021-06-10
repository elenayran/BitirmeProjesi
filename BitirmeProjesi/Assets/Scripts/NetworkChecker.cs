using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkChecker : MonoBehaviour
{
    public Text textResult;
    [SerializeField] public GameObject Alert;

    public void Awake()
    {
        InvokeRepeating("CheckNetworkControll", 1, 10);
    }

    public void CheckNetworkControll()
    {
        StartCoroutine(WaitNet(true));
    }

    public IEnumerator WaitNet(bool net)
    {

        WWW www = new WWW("http://www.google.com.");
        yield return www;
        if (net == true)
        {
            if (www.error != null)
            {
                Alert.SetActive(true);
                textResult.text = "Sorry, you do not have connection. Please check your Internet.";
                yield return new WaitForSeconds(1f);
                Application.Quit();
            }
            else
            {
                Debug.Log("Internet baðlantýn var!");
            }
            
        }

    }

}
