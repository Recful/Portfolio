using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayScript : MonoBehaviour
{

    public AudioSource song;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playMusic()
    {
        song.Play();
    }
}
