using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainControlPanel : MonoBehaviour, IInteractable, ITipHandler
{
    [SerializeField] TrainController train;

    [SerializeField] GameObject trainUI;

    public List<float> speedList = new List<float>();
    [SerializeField]private int index = 0;

    private bool controllingTrainSpeed;
    bool changed;

    [SerializeField]private Transform driver;

    private float controlRadius = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (controllingTrainSpeed) {
            if (Input.GetKeyDown(KeyCode.X))
            {
                index++;
                changed = true;
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {
                index--;
                changed = true;
            }

            if (changed)
            {
                if (index > speedList.Count-1)
                {
                    index = 0;
                }
                if (index < 0)
                {
                    index = speedList.Count - 1;
                }
                train.speed = speedList[index];
                changed = false;
            }

            if (driver != null)
            {
                if (Vector2.Distance(driver.position,transform.position) > controlRadius)
                {
                    driver = null;
                    controllingTrainSpeed = false;
                }
            }

        }
    }


    public void Interact(GameObject instigator)
    {
        controllingTrainSpeed = !controllingTrainSpeed;
        if (controllingTrainSpeed)
        {
            driver = instigator.transform;
        } else
        {
            driver = null;
        }
    }

    public string GetTip(GameObject instigator)
    {
        if (!controllingTrainSpeed)
        {
            return "Press E to start or quit driving";

        }
        else
        {
            return string.Format("Current Speed: {0}, press Z to decrease or X to increase", speedList[index]);
        }
    }

}
