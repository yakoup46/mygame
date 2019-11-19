﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using System;

public class StarsAnimation : MonoBehaviour
{
    public PathCreator path;
    public GameObject star;
   
    GameObject m_Star;
    Vector3[] points;

    public bool animated = false;

    void Awake()
    {
        m_Star = Instantiate(star, transform.position, Quaternion.identity);
        points = new Vector3[path.path.NumPoints];

        for (int i = 0; i < path.path.NumPoints; i++)
        {
            points[i] = path.path.GetPoint(i);
        }

        Array.Reverse(points);
    }

    public void Remove()
    {
        Destroy(m_Star);
        m_Star = Instantiate(star, transform.position, Quaternion.identity);
        animated = false;
    }

    public void Animate()
    {
        if (!animated)
        {
            iTween.ScaleTo(m_Star, iTween.Hash("scale", new Vector3(1f, 1f, 1), "time", 1f, "easetype", "easeOutElastic", "oncomplete", "ScaleBack", "oncompletetarget", gameObject));
        }

        animated = true;
    }

    void ScaleBack()
    {
        iTween.MoveTo(m_Star, iTween.Hash("path", points, "time", 1.0f, "easetype", "easeInCubic"));
        iTween.ScaleTo(m_Star, iTween.Hash("scale", new Vector3(0.25f, 0.25f, 1), "easetype", "easeInCubic", "time", 1.0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
