using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeController : MonoBehaviour
{
    public int maxPage;
    int currentPage;
    Vector3 targetPos;
    public Vector3 pageSetup;
    public RectTransform pageRect;
    public float tweenTime;
    public LeanTweenType tweenType;

    private void Start()
    {
        currentPage = 1;
    }
    public void Next()
    {
        if (currentPage < maxPage)
        {
            currentPage++;
            targetPos += pageSetup;
            MovePage();
        }
    }

    public void Previous()
    {
        if (currentPage > 1)
        {
            currentPage--;
            targetPos -= pageSetup;
            MovePage();
        }
    }

    void MovePage()
    {
        pageRect.LeanMoveLocal(targetPos, tweenTime).setEase(tweenType);
    }

}
