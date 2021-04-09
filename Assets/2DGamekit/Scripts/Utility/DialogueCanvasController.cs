using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Gamekit2D
{
    public class DialogueCanvasController : MonoBehaviour
    {
        public Animator animator;
        public TextMeshProUGUI textMeshProUGUI;

        protected Coroutine m_DeactivationCoroutine;
    
        protected readonly int m_HashActivePara = Animator.StringToHash ("Active");

        IEnumerator SetAnimatorParameterWithDelay (float delay)
        {
            yield return new WaitForSeconds (delay);
            animator.SetBool(m_HashActivePara, false);
        }

        IEnumerator DisplayDialogueCoroutine (Dialogue dialogue)
        {
            Line[] lines = dialogue.lines;

            foreach (Line line in lines)
            {
                textMeshProUGUI.text = line.text;
                yield return new WaitForSeconds (line.displayTime);
            }
            
            animator.SetBool (m_HashActivePara, false);
        }

        public void DisplayDialogue (Dialogue dialogue)
        {
            if (m_DeactivationCoroutine != null)
            {
                StopCoroutine (m_DeactivationCoroutine);
                m_DeactivationCoroutine = null;
            }

            gameObject.SetActive (true);
            animator.SetBool (m_HashActivePara, true);
            m_DeactivationCoroutine = StartCoroutine (DisplayDialogueCoroutine (dialogue));
        }

        public void ActivateCanvasWithText (string text)
        {
            if (m_DeactivationCoroutine != null)
            {
                StopCoroutine (m_DeactivationCoroutine);
                m_DeactivationCoroutine = null;
            }

            gameObject.SetActive (true);
            animator.SetBool (m_HashActivePara, true);
            textMeshProUGUI.text = text;
        }

        public void ActivateCanvasWithTranslatedText (string phraseKey)
        {
            if (m_DeactivationCoroutine != null)
            {
                StopCoroutine(m_DeactivationCoroutine);
                m_DeactivationCoroutine = null;
            }

            gameObject.SetActive(true);
            animator.SetBool(m_HashActivePara, true);
            textMeshProUGUI.text = Translator.Instance[phraseKey];
        }

        public void DeactivateCanvasWithDelay (float delay)
        {
            m_DeactivationCoroutine = StartCoroutine (SetAnimatorParameterWithDelay (delay));
        }
    }
}
