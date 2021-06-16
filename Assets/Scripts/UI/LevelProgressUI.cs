using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressUI : MonoBehaviour
{
    [SerializeField] private Image uiFillImage = null;

    [SerializeField] private Transform playerTransform = null;
    [SerializeField] private Transform endLineTransform = null;

    private Vector3 endLinePosition;
    private float fullDistance;

    private void Start() {
        endLinePosition = endLineTransform.position;
        fullDistance = GetFullDistance();
    }

    private void Update() {
        float newDistance = GetFullDistance();
        float fillAmount = Mathf.InverseLerp(fullDistance, 0f, newDistance);
        UpdateProgress(fillAmount);
    }

    
    private void UpdateProgress(float value) {
        uiFillImage.fillAmount = value;
    }

    private float GetFullDistance() {
        return Vector3.Distance(playerTransform.position, endLinePosition);
    }
}
