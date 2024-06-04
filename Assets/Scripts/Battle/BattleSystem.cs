using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enum para controlar los estados de batalla
public enum BattleState
{
    Start, PlayerAction, PlayerMove, EnemyMove, Busy
}
public class BattleSystem : MonoBehaviour
{
    [SerializeField] BattlePokemon playerPokemon;
    [SerializeField] BattlePokemon enemyPokemon;
    [SerializeField] BattleHud playerHub;
    [SerializeField] BattleHud enemyHub;

    [SerializeField] BattleDialogBox dialogBox;

    BattleState stateBattle;
    int currentAction;
    int currentMove;

    private void Start()
    {
        StartCoroutine(SetupBattle());
    }

    public IEnumerator SetupBattle()
    {
        playerPokemon.Setup();
        enemyPokemon.Setup();
        playerHub.SetData(playerPokemon.Pokemon);
        enemyHub.SetData(enemyPokemon.Pokemon);

        dialogBox.SetMoveNames(playerPokemon.Pokemon.Moves);

        yield return dialogBox.TypeDialog($"Apareció un {enemyPokemon.Pokemon.Base.name} salvaje.");  //Interpolacion, cuando se inicia con el signo $ se puede agregar variables dentor de la cadena de texto.
        yield return new WaitForSeconds(1f);

        PlayerAction();
    }

    public void PlayerAction()
    {
        stateBattle = BattleState.PlayerAction;
        StartCoroutine(dialogBox.TypeDialog("Elige una acción"));
        dialogBox.EnableActionSelector(true);
    }

    public void PlayerMove()
    {
        stateBattle = BattleState.PlayerMove;
        dialogBox.EnableActionSelector(false);
        dialogBox.EnableDialogText(false);
        dialogBox.EnableMoveSelector(true);
    }
    private void Update()
    {
        if (stateBattle == BattleState.PlayerAction)
        {
            HandleActionSelection();
        }
        else if(stateBattle == BattleState.PlayerMove)
        {
            HandleMoveSelection();
        }
    }

    void HandleActionSelection()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentAction < 1)
                ++currentAction;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentAction > 0)
                --currentAction;
        }

        dialogBox.UpdateActionSelector(currentAction);

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (currentAction == 0)
            {
                //Pelear
                PlayerMove();
            }
            else if (currentAction == 1)
            {
                //Correr
            }
        }
    }

    void HandleMoveSelection()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (currentMove < playerPokemon.Pokemon.Moves.Count - 1)
                ++currentMove;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (currentMove > 0)
                --currentMove;
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentMove < playerPokemon.Pokemon.Moves.Count - 2)
                currentMove += 2;
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(currentMove > 1)
                currentMove -= 2;
        }

        dialogBox.UpdateMoveSelector(currentMove, playerPokemon.Pokemon.Moves[currentMove]);
    }
}
