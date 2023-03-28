using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionManager : MonoBehaviour
{
    private int dimensionID;
    public bool shifting;
    public float currentShiftTime;
    public float maxShiftTime;
    // Start is called before the first frame update
    void Start()
    {
        dimensionID = 1;
        checkDimension();
        shifting = false;
        currentShiftTime = 0;
        maxShiftTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Checks for dimension shift input (See project settings/Input)
        //If true, sets the shifting boolean to true, stating that the character is in the process of shifting
        //While the player is shifting, the dimension id is given a negative value, disabling collision for both positive and negative dimensions
        if (Input.GetButtonDown("Shift"))
        {
            shifting = true;
            dimensionID *= -1;

        }

        executeShift();


    }

    public int getDimensionID()
    {
        return dimensionID;
    }

    public void executeShift()
    {
        if (shifting)
        {
            currentShiftTime += Time.deltaTime;

            if (currentShiftTime > maxShiftTime)
            {
                currentShiftTime = 0;
                shifting = false;
                dimensionID *= -1;

                dimensionID++;

                if (dimensionID > 2)
                {
                    dimensionID = 1;
                }

                checkDimension();

            }
        }
    }

    public void executeShift(float customShiftTime)
    {
        if (shifting)
        {
            currentShiftTime += Time.deltaTime;

            if (currentShiftTime > customShiftTime)
            {
                currentShiftTime = 0;
                shifting = false;
                dimensionID *= -1;

                dimensionID++;

                if (dimensionID > 2)
                {
                    dimensionID = 1;
                }

                checkDimension();

            }
        }
    }

    public void checkDimension()
    {
        switch (dimensionID)
        {
            case 1:
                Physics2D.IgnoreLayerCollision(11, 12, true);
                Physics2D.IgnoreLayerCollision(10, 12, false);
                break;

            case 2:
                Physics2D.IgnoreLayerCollision(12, 11, false);
                Physics2D.IgnoreLayerCollision(12, 10, true);
                break;

            default:
                Physics2D.IgnoreLayerCollision(12, 11, true);
                Physics2D.IgnoreLayerCollision(12, 10, true);
                break;
        }
    }


}
