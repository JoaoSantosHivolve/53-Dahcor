using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketLayoutController : MonoBehaviour
{
    private RacketLayoutButton[] _Buttons;

    private void Start()
    {
        _Buttons = transform.GetComponentsInChildren<RacketLayoutButton>();

        // Set Button index
        for (int i = 0; i < _Buttons.Length; i++)
        {
            _Buttons[i].SetIndex(i);
        }

        // Make only first button interactable
        for (int i = 0; i < _Buttons.Length; i++)
        {
            _Buttons[i].SetInteractable(i == 0 || i == 1);
            _Buttons[i].SetAvailable(i == 0 || i == 1);
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