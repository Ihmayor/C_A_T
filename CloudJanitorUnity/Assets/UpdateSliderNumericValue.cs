using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSliderNumericValue : MonoBehaviour
{
    [SerializeField]
    private Text TextToUpdate;

    [SerializeField]
    private IntVariable intVarToUpdate;

    [SerializeField]
    private FloatVariable floatVarToUpdate;

    [SerializeField]
    private NumericType type;

    private enum NumericType
    {
        FloatVar,
        IntVar
    }

    public void Start()
    {
        if (type is NumericType.FloatVar)
        {
            GetComponent<Slider>().value = floatVarToUpdate.Value;
        }
        else if (type is NumericType.IntVar)
        {
            GetComponent<Slider>().value = intVarToUpdate.Value;
        }
    }


    public void UpdateIntVariable()
    {
        intVarToUpdate.Value = (int)GetComponent<Slider>().value;
    }

    public void UpdateFloatVariable()
    {
        floatVarToUpdate.Value = GetComponent<Slider>().value;
    }

    void Update()
    {
        if (type is NumericType.FloatVar)
        {
            TextToUpdate.text = "" + floatVarToUpdate.Value;
        }
        else if (type is NumericType.IntVar)
        {
            TextToUpdate.text = "" + intVarToUpdate.Value;
        }
    }
}
