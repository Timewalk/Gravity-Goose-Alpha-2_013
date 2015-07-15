using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class StaticInformation  {

    public static int score;
    public static float health;
	public static float fireGauge;
    public static bool burnout;
    public static int cash = 0;


    ///////////////////////////////////////////////////
    // HYPO's Don't Touch
    ///////////////////////////////////////////////////
    public static Vector3 raycastTargetPoint;
    public static Vector3 raycastPositionPoint;
    public static Transform playerShipTransform;
    public static int playersCurrentWaypoint;

    public static GameObject playersTarget;
    public static GameObject playersLock;

    ///////////////////////////////////////////////////

    ///HACKS
    public static int currNumEnemies = 0;

}
