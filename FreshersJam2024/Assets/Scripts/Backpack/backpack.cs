using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backpack : MonoBehaviour
{
    public LayerMask m_DragLayers;

    [Range(0.0f, 100.0f)]
    public float m_Damping = 1.0f;

    [Range(0.0f, 100.0f)]
    public float m_Frequency = 5.0f;

    Vector3 worldPos;

    public bool m_DrawDragLine = true;
    public Color m_Color = Color.cyan;

    TargetJoint2D m_TargetJoint;
    bool jointed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            setJoint();
        }
        else if (Input.GetMouseButtonUp(0) && jointed)
        {
            Destroy(m_TargetJoint);
            Debug.Log("joint destroyed");
            m_TargetJoint = null;
            jointed = false;
            return;
        }

        // Update the joint target.
        if (m_TargetJoint)
        {
            m_TargetJoint.target = worldPos;

            // Draw the line between the target and the joint anchor.
            if (m_DrawDragLine)
                Debug.DrawLine(m_TargetJoint.transform.TransformPoint(m_TargetJoint.anchor), worldPos, m_Color);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hiit");
    }

    private void OnMouseDrag()
    {

    }

    void setJoint()
    {
        // Fetch the first collider.
        // NOTE: We could do this for multiple colliders
        //var collider = Physics2D.OverlapPoint(worldPos, m_DragLayers);

        RaycastHit2D hit = Physics2D.Raycast(worldPos, -Vector2.up);
        if (hit.collider == null)
        {
            Debug.Log("collider not hit");
            return;
        }
        else
        {
            Debug.Log("collider hit");
        }

        //if (!collider)
        //    return;

        // Fetch the collider body.
        var body = hit.collider.attachedRigidbody;
        if (!body)
        {
            Debug.Log("rigid body not hit");
            return;
        }
        else
        {
            Debug.Log("rigid body hit");
        }

        // Add a target joint to the Rigidbody2D GameObject.
        m_TargetJoint = body.gameObject.AddComponent<TargetJoint2D>();
        m_TargetJoint.dampingRatio = m_Damping;
        m_TargetJoint.frequency = m_Frequency;

        jointed = true;

        // Attach the anchor to the local-point where we clicked.
        m_TargetJoint.anchor = m_TargetJoint.transform.InverseTransformPoint(worldPos);
    }
}
