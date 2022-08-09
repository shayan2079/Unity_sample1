using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResizing : MonoBehaviour
{
    [SerializeField] float initialWidth = 5f;
    [SerializeField] float initialHeight = 13f;
    [SerializeField] float resizingSpeed = 20f;
    [SerializeField] float minHeight = 1.7f;
    [SerializeField] float maxHeight = 15f;

    float area;
    float touchStartPos;
    float touchStartPlayerHeight;

    private void Start()
    {
        area = initialHeight * initialWidth;
        ResizePlayer(initialHeight, initialWidth);
    }

    void Update()
    {
        float newHeight = transform.localScale.y;

        #if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBPLAYER
        float verticalInput = Input.GetAxis("Vertical");
        newHeight += verticalInput * Time.deltaTime * resizingSpeed;
        #endif

        #if UNITY_IOS || UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];
            if (touch.phase == TouchPhase.Began)
            {
                touchStartPlayerHeight = transform.localScale.y;
                touchStartPos = touch.position.y;
            }
            else
            {
                newHeight = touchStartPlayerHeight + (touch.position.y - touchStartPos) / 50f;
            }
        }
        #endif

        float newWidth = area / newHeight;

        if (newHeight > minHeight && newHeight < maxHeight)
        {
            ResizePlayer(newHeight, newWidth);
        }
    }

    void ResizePlayer(float height, float width)
    {
        transform.localScale = new Vector3(width, height, transform.localScale.z);
        Vector3 newPos = transform.position;
        newPos.y = height / 2;
        transform.position = newPos;
    }
}
