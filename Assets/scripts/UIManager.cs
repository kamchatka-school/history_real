using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class UIManager : MonoBehaviour
{
    public Button[] answerButton;
    public TextMeshProUGUI npcName;
    public TextMeshProUGUI speech;
    public Image leftImg;
    public Image rightImg;

    public Canvas canvas;

    public float delay = 0.1f;

    public Dialogue curDialogue;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (curDialogue != null)
            {
                curDialogue.NextPhrase();
                DialogueMoment();
            }
        }
    }

    
    IEnumerator ShowText(string text_to_show)
    {
        for(int i = 0; i <= text_to_show.Length; i++)
        {
            speech.text = text_to_show.Substring(0, i);
            yield return new WaitForSeconds(delay);
        }
    }


    void DialogueMoment()
    {
        Phrase curPhrase = curDialogue.GetCurPhrase();
        npcName.text = curPhrase.name;
        leftImg.sprite = curPhrase.left;
        rightImg.sprite = curPhrase.right;

        StartCoroutine(ShowText(curPhrase.text));


        for (int i = 0; i < curPhrase.answers.Length; i++)
        {
            int currentIndex = i;
            answerButton[i].gameObject.SetActive(true);


            answerButton[i].onClick.AddListener(() => SetNewDialogue(curPhrase.answers[currentIndex].nextDialogue));
            answerButton[i].GetComponentInChildren<TextMeshProUGUI>().text = curPhrase.answers[i].text;
        }
        for (int i = curDialogue.GetCurPhrase().answers.Length; i < answerButton.Length; i++)
        {
            answerButton[i].onClick.RemoveAllListeners();
            answerButton[i].gameObject.SetActive(false);
        }
    }


    public void SetNewDialogue(Dialogue nextDialogue)
    {
        curDialogue = nextDialogue;
        curDialogue.Initialize();
        DialogueMoment();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        canvas.enabled = true;
        if (collision.TryGetComponent<DialogueOwner>(out DialogueOwner dialogueOwner))
        {
            curDialogue = dialogueOwner.dialogue;
            curDialogue.Initialize();
            DialogueMoment();
        }
    }

    void OnTriggerExit2D(Collider2D collision){
        canvas.enabled = false;
    }
}
