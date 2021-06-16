using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdManager : MonoBehaviour
{
    public static AdManager instance;

    private BannerView bannerAds;
    private InterstitialAd interstitial;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
            return;
        }
    }

    private void Start() {
        MobileAds.Initialize(InitializationStatus => { });
        this.RequestBanner();
    }

    private AdRequest CreateAdRequest() {
        return new AdRequest.Builder().Build();
    }

    private void RequestBanner() {
        string adUnitId = "ca-app-pub-3940256099942544/6300978111";
        this.bannerAds = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);
        this.bannerAds.LoadAd(this.CreateAdRequest());
    }

    public void RequestInterstitial() {

        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
        // Clean up interstitial ad before creating a new one.
        if (this.interstitial != null)
            this.interstitial.Destroy();

        // Create an interstitial.
        this.interstitial = new InterstitialAd(adUnitId);

        // Load an interstitial ad.
        this.interstitial.LoadAd(this.CreateAdRequest());
    }

    public void ShowInterstistial() {
        if(this.interstitial.IsLoaded()) {
            interstitial.Show();
        } else {
            Debug.Log("Ad not loaded");
        }
    }
}
