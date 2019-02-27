using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TriggerType
{
    public class Playcard : Attribute { }
    public class Discard : Attribute { }
    public class Deploy : Attribute { }
    public class Dead : Attribute { }
    public class TurnStart : Attribute { }
    public class CountDown : Attribute { }
}

