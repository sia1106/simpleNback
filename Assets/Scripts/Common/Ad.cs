using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class Ad : MonoBehaviour
{    
    //[serialize]しとく

    void Start()
    {
        // アプリID
        string appId = "ca-app-pub-1176549398888974~3545676073";

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(appId);

        RequestBanner();
    }

    private void RequestBanner()
    {
        // 広告ユニットID テスト用        
        //string adUnitId = "ca-app-pub-3940256099942544/6300978111";
        //本番
        string adUnitId = "ca-app-pub-1176549398888974/1564232763";

        // Create a 320x50 banner at the top of the screen.
        BannerView bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();

        // Load the banner with the request.
        bannerView.LoadAd(request);

        // Create a 320x50 banner at the top of the screen.
        //bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
    }    
}