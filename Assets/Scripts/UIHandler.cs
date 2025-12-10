using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI distanceTravelledText;

    CarHandler playerCarHandler;


    private void Awake()
    {
        playerCarHandler = GameObject.FindGameObjectWithTag("Player").GetComponent<CarHandler>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distanceTravelledText.text = playerCarHandler.DistanceTravelled.ToString("00000");
    }
}
