using UnityEngine;
using UnityEngine.UDP;

public class InitListener : IInitListener
{
    public void OnInitialized(UserInfo userInfo)
    {
        Debug.Log("I AM WORKING SO PLEASE LOG IN");
        // You can call the QueryInventory method here
        // to check whether there are purchases that haven’t be consumed.    
        GameObject gameObject = GameObject.FindGameObjectWithTag("Login");
        gameObject.SetActive(false);
    }

    public void OnInitializeFailed(string message)
    {
        Debug.Log("I AM NOT WORKING");
    }
}