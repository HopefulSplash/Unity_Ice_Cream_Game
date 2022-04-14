using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class UnityAdManager : MonoBehaviour, IUnityAdsListener
{
    // Start is called before the first frame update

    public static UnityAdManager instance;
    Action onFinishSuccess;
    public string gameId = "4260125";
    public string myPlacementIdB = "Banner_Android";
    public string myPlacementIdR = "Rewarded_Android";
    public string myPlacementIdI = "Interstitial_Android";
    public Shop shop;
    public string option;
    public bool stop = false;
    public string adSource;

    void Start()
    {
        Destroy(instance);
        if (instance == null)
        {
            instance = this;
        }

        if (!Advertisement.isInitialized)
        {
            Advertisement.Initialize(gameId);
            instance = this;
            Advertisement.AddListener(this);
        }
        else
        {
            //not make a new one
        }
        
        if (option == "Main")
        {
            ShowBannerAD();
        }
        else if (option == "Rewarded")
        {
        }
       

    }
 
    public void ShowBannerAD()
    {
        if (Advertisement.IsReady(myPlacementIdB))
        {
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Show(myPlacementIdB);

        }
        else
        {
            StartCoroutine(RepeatShowBanner());
        }
    }

    public void HideBannerAD()
    {
        Advertisement.Banner.Hide();
        Destroy(instance);
    }
    IEnumerator RepeatShowBanner()
    {
        yield return new WaitForSeconds(1f);
        ShowBannerAD();
    }
    Action onFinishSuccessGameOver;
    public void PlayGameOverAD(Action onFinish)
    {
        onFinishSuccessGameOver = onFinish;
        if (Advertisement.IsReady(myPlacementIdI))
        {
            stop = false;
            Advertisement.Show(myPlacementIdI);
        }
    }
    Action onFinishSuccessPause;
    public void PlayPauseAD(Action onFinish)
    {
        onFinishSuccessPause = onFinish;
        if (Advertisement.IsReady(myPlacementIdI))
        {
            stop = false;
            Advertisement.Show(myPlacementIdI);
        }
    }
    public void PlayRewardedAD(Action onFinish)
    {
        onFinishSuccess = onFinish;
        
        if (Advertisement.IsReady(myPlacementIdR))
        {
            stop = false;
            Advertisement.Show(myPlacementIdR);
        }
        else
        {
            // not loaded
        }
    }

    void IUnityAdsListener.OnUnityAdsReady(string placementId)
    {
       
    }

    void IUnityAdsListener.OnUnityAdsDidError(string message)
    {
       
    }

    void IUnityAdsListener.OnUnityAdsDidStart(string placementId)
    {
        
    }
    
    void IUnityAdsListener.OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        //gameover ad
        if (placementId == myPlacementIdI && instance.adSource == "Null") 
        {
            instance.onFinishSuccessGameOver.Invoke();
            stop = true;
        }

        //pause ad
        if (placementId == myPlacementIdI && instance.adSource == "Pause")
        {
            instance.onFinishSuccessPause.Invoke();
            stop = true;
        }

        if (showResult == ShowResult.Finished && placementId == myPlacementIdR)
        {      
            instance.onFinishSuccess.Invoke();
            stop = true;


        }
        else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
        }
        else if (showResult == ShowResult.Failed)
        {
        }
    }
}
