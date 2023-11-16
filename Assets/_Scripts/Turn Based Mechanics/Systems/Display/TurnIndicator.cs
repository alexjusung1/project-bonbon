using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnIndicator : MonoBehaviour {
    private BattleStateMachine stateMachine => BattleStateMachine.Instance;
    void Start() {
        stateMachine.OnStateTransition += UpdateTurnIndicator;
    }

    private void UpdateTurnIndicator(BattleStateMachine.BattleState state, BattleStateInput input) {
        if (state is not BattleStateMachine.TurnState) return;
        TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
        text.SetText("[" + input.CurrTurn() + "] " + input.ActiveActor().Data.DisplayName);
    }
}
