using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : Power
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void DoStuff(Player player)
    {
        player.shield = true;
    }
}
