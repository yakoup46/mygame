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

    void PlayStarOne()
    {
        star1.Animate();
    }

    void PlayStarTwo()
    {
        star2.Animate();
    }

    void PlayStarThree()
    {
        star3.Animate();
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
