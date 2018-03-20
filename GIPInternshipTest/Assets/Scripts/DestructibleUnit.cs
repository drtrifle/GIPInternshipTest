using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDestructibleUnit {

    //Destroys the unit and may update scoreboard
    void Die(int score);

}
