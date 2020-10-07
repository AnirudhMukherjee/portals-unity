using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTextureManager : MonoBehaviour
{

    public Camera camera_b;
    public Material cameraMat_b;
    public Camera camera_a;
    public Material cameraMat_a;
    // Start is called before the first frame update
    void Start()
    {
        if (camera_b.targetTexture != null)
        {
            camera_b.targetTexture.Release();
        }

        camera_b.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMat_b.mainTexture = camera_b.targetTexture;

        if (camera_a.targetTexture != null)
        {
            camera_a.targetTexture.Release();
        }

        camera_a.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMat_a.mainTexture = camera_a.targetTexture;
    }

    
}
