using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MapController : MonoBehaviour
{

    [SerializeField] Button buttonUp, buttonDown, buttonLeft, buttonRight, buttonMenu;
    

    // Start is called before the first frame update
    void Start()
    {
        buttonUp.onClick.AddListener(delegate {GridMap.Instance.move(Directions.up);});
        buttonDown.onClick.AddListener(delegate {GridMap.Instance.move(Directions.down);});
        buttonLeft.onClick.AddListener(delegate {GridMap.Instance.move(Directions.left);});
        buttonRight.onClick.AddListener(delegate {GridMap.Instance.move(Directions.right);});
        buttonMenu.onClick.AddListener(delegate {SceneManager.LoadScene("MenuScene");});
    }

    // Update is called once per frame
    void Update()
    {

    }
}
