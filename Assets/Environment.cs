using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    const float cameraSize = 5;

    // Start is called before the first frame update
    void Start()
    {
        var width = (Camera.main.orthographicSize / 2880) * 1440;
        Camera.main.orthographicSize = (width / Screen.width) * Screen.height;

        SetupWalls();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetupWalls()
    {
        float actualCameraSize = Camera.main.orthographicSize;

        GameObject walls = new GameObject();
        walls.name = "Walls";

        PhysicsMaterial2D mat = new PhysicsMaterial2D
        {
            friction = 0.0f,
            bounciness = 0.5f,
        };

        // ceiling
        BoxCollider2D collider0 = walls.AddComponent<BoxCollider2D>();
        collider0.size = new Vector2(cameraSize, 0.25f);
        collider0.offset = new Vector2(0, actualCameraSize + (0.25f/2));
        collider0.sharedMaterial = mat;

        // floor
        BoxCollider2D collider1 = walls.AddComponent<BoxCollider2D>();
        collider1.size = new Vector2(cameraSize, 0.25f);
        collider1.offset = new Vector2(0, -actualCameraSize - (0.25f/2));

        // left
        BoxCollider2D collider2 = walls.AddComponent<BoxCollider2D>();
        collider2.size = new Vector2(0.25f, actualCameraSize * 2);
        collider2.offset = new Vector2(-cameraSize / 2 - (0.25f/2), 0);
        collider2.sharedMaterial = mat;

        // right
        BoxCollider2D collider3 = walls.AddComponent<BoxCollider2D>();
        collider3.size = new Vector2(0.25f, actualCameraSize * 2);
        collider3.offset = new Vector2(cameraSize / 2 + (0.25f/2), 0);
        collider3.sharedMaterial = mat;
    }
}
