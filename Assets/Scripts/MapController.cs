using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;


public class MapController : MonoBehaviour
{

    [SerializeField] Button buttonUp, buttonDown, buttonLeft, buttonRight;
    

    // Start is called before the first frame update
    void Start()
    {
        buttonUp.onClick.AddListener(delegate {GridMap.Instance.move(Directions.up);});
        buttonDown.onClick.AddListener(delegate {GridMap.Instance.move(Directions.down);});
        buttonLeft.onClick.AddListener(delegate {GridMap.Instance.move(Directions.left);});
        buttonRight.onClick.AddListener(delegate {GridMap.Instance.move(Directions.right);});
    }

    // Update is called once per frame
    void Update()
    {

    }
}
