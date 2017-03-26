﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoCandle : MonoItem
{
    /* 
        MonoCandle class will be used to contain the behavior for the candles in the game
    */

    //The states that the candle can be in
    public enum State
    {
        on,
        off
    }

    //Track the current state of the candle
    public State currentState;

    //Reference for the fire particle system
    private ParticleSystem fire;
    
    //Reference for the emission of the fire particle system
    private ParticleSystem.EmissionModule emissionModuleForFire;

    private GameManagerHandler gameManager;

    public override void CurrentBehavior()
    {
        if(gameManager.gameManagerInstance.currentGameState == GameManager.GameState.phase6)
        {
            //Check if it's on
            if (currentState == State.on)
            {
                //Turn it off
                currentState = State.off;
                gameManager.gameManagerInstance.candleCount++;
            }
        }
    }

    private void Awake()
    {
        //Set it on
        currentState = State.off;
        
        //Set the fire variable
        fire = gameObject.GetComponentInChildren<ParticleSystem>();

        //Set the emission module
        emissionModuleForFire = fire.emission;

        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerHandler>();
}

    private void Update()
    {
        //Check if it's current state is on
        if(currentState == State.on)
        {
            //Set the emission enabled bool to true
            emissionModuleForFire.enabled = true;
        }

        if(currentState == State.off)
        {
            emissionModuleForFire.enabled = false;
        }
    }
}
