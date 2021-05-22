using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineScript : MonoBehaviour
{
    public GameObject AnimatedGameObject;
    public GameObject PhysicsGameObject;
    public CinemachineBrain cinemachineBrain;

    private PlayableDirector _playableDirector;


    // Start is called before the first frame update
    void Start()
    {
        _playableDirector = GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_playableDirector.time >= _playableDirector.duration)
        {
            SwapArms();
        }
    }

    void SwapArms()
    {
        AnimatedGameObject.SetActive(false);
        PhysicsGameObject.SetActive(true);
        cinemachineBrain.enabled = false;
    }
}
