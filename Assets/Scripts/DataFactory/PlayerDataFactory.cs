using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerDataFactory
{
    internal static IPlayerInput GetInputOne()
    {
        return new PlayerOneInputs();
    }

    internal static IPlayerInput GetInputTwo()
    {
        return new PlayerTwoInputs();
    }
}
