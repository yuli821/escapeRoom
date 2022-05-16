using System;
using System.Collections.Generic;
using UnityEngine;

// It's like a virtual method?
public interface IInteractable
{
    void Interact(DisplayImage currentDisplay);
}