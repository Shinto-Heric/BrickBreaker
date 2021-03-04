using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakCount;
    // Start is called before the first frame update

    SceneLoader loadScene;
    private void Start()
    {
        loadScene = FindObjectOfType<SceneLoader>();
    }
    public void IncrementBreakCount()
    {
        breakCount++;
    }
    public int BreakCount()
    {
        return breakCount;
    }
    public void BlockDestroyed()
    {
        breakCount--;
        if(breakCount <= 0)
        {
            loadScene.LoadScene();
        }
    }
}
