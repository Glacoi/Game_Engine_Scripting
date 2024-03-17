using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] Transform m_DoorTransform;
    [SerializeField] Vector3 m_PositionOpenOffset;

    private Vector3 m_PositionClose;
    private Vector3 m_PositionOpen;

    bool m_IsOpening;
    bool m_IsClosing; // Added boolean to track closing state
    float m_Alpha;

    private void Awake()
    {
        m_PositionClose = m_DoorTransform.position;
        m_PositionOpen = m_PositionOpenOffset + m_PositionClose;
    }

    private void Update()
    {
        // Lerping is replaced with while loop
        if (m_IsOpening)
        {
            m_Alpha += Time.deltaTime;
            m_Alpha = Mathf.Clamp01(m_Alpha);
            while (m_Alpha < 1f)
            {
                m_Alpha += Time.deltaTime;
                m_DoorTransform.position = Vector3.Lerp(m_PositionClose, m_PositionOpen, m_Alpha);
                return; // Exit the loop for this frame
            }
        }
        else if (m_IsClosing) // Added condition for closing
        {
            m_Alpha -= Time.deltaTime;
            m_Alpha = Mathf.Clamp01(m_Alpha);
            while (m_Alpha > 0f)
            {
                m_Alpha -= Time.deltaTime;
                m_DoorTransform.position = Vector3.Lerp(m_PositionClose, m_PositionOpen, m_Alpha);
                return; // Exit the loop for this frame
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Door Trigger has been triggered");
        m_IsOpening = true;
        m_IsClosing = false; // Ensure closing is false when opening
        DOTween.Kill(m_DoorTransform); // Remove specific ID
        m_DoorTransform.DOMove(m_PositionOpen, 1f); // Use default ID
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Door Trigger is still being triggered");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Something has left the trigger");
        m_IsOpening = false;
        m_IsClosing = true; // Set closing to true when triggered to close
        DOTween.Kill(m_DoorTransform); // Remove specific ID
        m_DoorTransform.DOMove(m_PositionClose, 1f); // Use default ID
    }
}