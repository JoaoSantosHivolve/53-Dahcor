using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketLayoutController : MonoBehaviour
{
    private RacketLayoutButton[] _Buttons;
    private RacketViewController _ViewController;

    private void Awake()
    {
        _Buttons = transform.GetComponentsInChildren<RacketLayoutButton>();
        _ViewController = GameObject.Find("[RACKET CONTROLLER]").GetComponent<RacketViewController>();
    }

    private void Start()
    {

        // Set Button index
        for (int i = 0; i < _Buttons.Length; i++)
        {
            _Buttons[i].SetIndex(i);
            _Buttons[i].SetController(_ViewController);
        }

        // Make only first button interactable
        //for (int i = 0; i < _Buttons.Length; i++)
        //{
        //    _Buttons[i].SetInteractable(i == 0 || i == 1);
        //    _Buttons[i].SetAvailable(i == 0 || i == 1);
        //}
        foreach (var item in _Buttons)
        {
            item.SetInteractable(true);
            item.SetAvailable(true);
        }
    }

    public void OpenButton(int index)
    {
        for (int i = 0; i < _Buttons.Length; i++)
        {
            if (index == i) 
                _Buttons[i].OpenLayout();
            else 
                _Buttons[i].CloseLayout();
        }
    }
}