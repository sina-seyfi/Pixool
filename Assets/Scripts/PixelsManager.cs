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
    private PixelsClickManager clickManager;
    // Start is called before the first frame update
    void Start()
    {
        wrapper = new EasyPixelsDataWrapper(provider);
        clickManager = new PixelsClickManager();
        spawner.Spawn(wrapper.PixelsData);
        evaluator = new PixelsDataEvaluator(wrapper);
        clickManager.selected += selectedPixelShelf;
        clickManager.deselected += deselectedPixelShelf;
        clickManager.placed += placedPixelShelf;
    }

    private void selectedPixelShelf(PixelShelf pixelShelf) {
        spawner.Reshape(
            (data) => {
                if(data is PixelEmpty) {
                    return new PixelWaiting(((PixelEmpty) data).PixelColor);
				}
                return data;
			}
            );
	}

    private void deselectedPixelShelf(PixelShelf pixelShelf) {
        spawner.Reshape(
            (data) => {
                if(data is PixelWaiting) {
                    return new PixelEmpty(((PixelWaiting) data).PixelColor);
                }
                return data;
            }
            );
    }

    private void placedPixelShelf(PixelShelf shelf, PixelWaiting color) {
        spawner.Reshape(
            (data) => {
                if(data is PixelWaiting) {
                    return new PixelEmpty(((PixelWaiting) data).PixelColor);
                }
                return data;
            }
            );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
