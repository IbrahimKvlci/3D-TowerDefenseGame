using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Mine : PlayerObject
{
    [Inject]
    public void Construct(IMineWorkingService mineWorkingService)
    {
        PlayerObjectWorkingService= mineWorkingService;
    }
}
