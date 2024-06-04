using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;



public class BattleDialogBox : MonoBehaviour
{
    [SerializeField] int lettersPerSecond;
    [SerializeField] Color highlightedColor;

    [SerializeField] Text dialogText;
    [SerializeField] GameObject actionSelector;
    [SerializeField] GameObject moveSelector;
    [SerializeField] GameObject moveDetails;

    [SerializeField] List<Text> actionSelectorTexts;
    [SerializeField] List<Text> moveSelectorTexts;

    [SerializeField] Text pptText;
    [SerializeField] Text typeText;




    public void SetDialog(string dialog)
    {
        dialogText.text = dialog;
    }

    public IEnumerator TypeDialog(string dialog)
    {
        dialogText.text = "";
        foreach (var letter in dialog.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }
    }

    public void EnableDialogText(bool enable)
    {
        dialogText.enabled = enable;
    }

    public void EnableActionSelector(bool enable)
    {
        actionSelector.SetActive(enable);
    }

    public void EnableMoveSelector(bool enable)
    {
        moveSelector.SetActive(enable);
        moveDetails.SetActive(enable);
    }

    public void UpdateActionSelector(int selectAction )
    {
        for (int i = 0; i < actionSelectorTexts.Count; ++i)
        {
            if (i == selectAction)
                actionSelectorTexts[i].color = highlightedColor;
            else
                actionSelectorTexts[i].color = Color.black;
        }
    }
    public void UpdateMoveSelector(int selectedMove, Move move)
    {
        for(int i = 0;i < moveSelectorTexts.Count; ++i)
        {
            if (i == selectedMove)
                moveSelectorTexts[i].color = highlightedColor;
            else
                moveSelectorTexts[i].color = Color.black;
        }
        pptText.text = $"PP {move.PP}/{move.Base.PP}";
        typeText.text = move.Base.Type.ToString();
    }

    public void SetMoveNames(List<Move> pMove)
    {
        for(int i = 0;i < moveSelectorTexts.Count; ++i)
        {
            if (i < pMove.Count)
                moveSelectorTexts[i].text = pMove[i].Base.name;
            else
                moveSelectorTexts[i].text = "-";
        }
    }

}
