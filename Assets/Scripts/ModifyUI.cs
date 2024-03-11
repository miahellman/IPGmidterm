using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ModifyUI : MonoBehaviour
{
    public CarController carController;

    [SerializeField] TextMeshProUGUI mphText;
    [SerializeField] TextMeshProUGUI timeText;

    private float timeElapsed = 0f;
    private float speed = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If car speed is positive add to speed until reaching car speed, if car speed is negative, subtract until reaching car speed
        if (speed < carController.carSpeed)
        {
            speed += 0.5f;
        }
        else if (speed > carController.carSpeed)
        {
            speed -= 1f;
        }
        else
        {
            speed = carController.carSpeed; // If car speed is 0, set speed to 0
        }


        mphText.text = speed.ToString("F0") + " MPH";

        timeElapsed += Time.deltaTime / 60f;

        timeText.text = "LAP TIME: " + timeElapsed.ToString("F2");
        
    }
}
