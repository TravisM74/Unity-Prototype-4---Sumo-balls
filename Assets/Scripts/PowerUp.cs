using System.Collections;
using System.Collections.Generic;
using UnityEngine;

   public enum PowerUpType {
    none,
    PushBack,
    Rockets
   }

   public class PowerUp: MonoBehaviour{

      public PowerUpType powerUpType;
   }

