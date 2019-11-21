using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour
{
    public StarsAnimation star1;
    public StarsAnimation star2;
    public StarsAnimation star3;

    public void PlayStar(int star)
    {
        switch(star)
        {
            case 1: PlayStarOne(); break;
            case 2: PlayStarTwo(); break;
            case 3: PlayStarThree(); break;
        }
    }
    public void RemoveStar(int star)
    {
        switch (star)
        {
            case 1: RemoveStarOne(); break;
            case 2: RemoveStarTwo(); break;
            case 3: RemoveStarThree(); break;
        }
    }

    public bool GetAnimated(int star)
    {
        switch (star)
        {
            case 1: return star1.animated;
            case 2: return star2.animated;
            case 3: return star3.animated;
        }

        return false;
    }

    public bool GetAnimatonDone(int star)
    {
        switch (star)
        {
            case 1: return star1.animationDone;
            case 2: return star2.animationDone;
            case 3: return star3.animationDone;
        }

        return false;
    }

    void PlayStarOne()
    {
        star1.Animate();
    }

    void PlayStarTwo()
    {
        if (star1.animationDone)
        {
            star2.Animate();
        }
        else
        {
            star2.Animate(1.25f);
        }
    }

    void PlayStarThree()
    {
        if (star1.animationDone && star2.animationDone)
        {
            star3.Animate();
        }
        else if (star1.animationDone && !star2.animationDone)
        {
            star3.Animate(1.25f);
        }
        else
        {
            star3.Animate(2.5f);
        }
    }

    void RemoveStarOne()
    {
        star1.Remove();
    }

    void RemoveStarTwo()
    {
        star2.Remove();
    }

    void RemoveStarThree()
    {
        star3.Remove();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
