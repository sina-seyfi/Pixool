using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelsManager : MonoBehaviour
{
    [SerializeField]
    private PixelsDataProvider provider;
    [SerializeField]
    private PixelsSpawner spawner;
    private PixelsDataWrapper wrapper;
    private PixelsDataEvaluator evaluator;
    // Start is called before the first frame update
    void Start()
    {
        wrapper = new EasyPixelsDataWrapper(provider);
        spawner.Spawn(wrapper.PixelsData);
        evaluator = new PixelsDataEvaluator(wrapper);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
