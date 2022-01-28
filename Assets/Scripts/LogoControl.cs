using System.Collections;
using UnityEngine;

public class LogoControl : MonoBehaviour
{
    public float outerDistance;
    public int framesToTarget;
    public float rotationSpeed;
    public bool canRotate;

    public RectTransform canvasRectTransform;
    public Transform blackCircle;
    public Rigidbody2D blackCircleSpriteRB2D;
    public Rigidbody2D circlesSpriteRB2D;
    public Rigidbody2D edgesRB2D;

    Vector3 centerPos;

    float circlesTargetRotation;
    float edgesTargetRotation;

    bool circlesOnClockwiseEdgePoints = true;
    bool symbolRotating = false;

    private void Update()
    {
        if (Input.GetButton("Rotate Logo Clockwise") && !symbolRotating && canRotate)
        {
            // Rotate clockwise
            symbolRotating = true;

            if (circlesOnClockwiseEdgePoints)
            {
                circlesTargetRotation -= 90f;
                edgesTargetRotation -= 90f;
            }
            else
            {
                circlesTargetRotation -= 60f;
                edgesTargetRotation = edgesRB2D.rotation;
                circlesOnClockwiseEdgePoints = true;
            }

            StopCoroutine("RotateCircles");
            StartCoroutine("RotateCircles");

            StopCoroutine("RotateEdges");
            StartCoroutine("RotateEdges");
        }

        if (Input.GetButton("Rotate Logo Counterclockwise") && !symbolRotating && canRotate)
        {
            // Rotate counterclockwise
            symbolRotating = true;

            if (circlesOnClockwiseEdgePoints)
            {
                circlesTargetRotation += 60f;
                edgesTargetRotation = edgesRB2D.rotation;
                circlesOnClockwiseEdgePoints = false;
            }
            else
            {
                circlesTargetRotation += 90f;
                edgesTargetRotation += 90f;
            }

            StopCoroutine("RotateCircles");
            StartCoroutine("RotateCircles");

            StopCoroutine("RotateEdges");
            StartCoroutine("RotateEdges");
        }
    }

    void FixedUpdate()
    {
        centerPos = blackCircle.transform.position;

        float scaledOuterDistance = outerDistance * canvasRectTransform.position.x / 960f;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 posOffset = new Vector3(horizontal, vertical);

        if (posOffset.sqrMagnitude > 1.0f)
        {
            posOffset.Normalize();
        }

        posOffset *= scaledOuterDistance;

        blackCircleSpriteRB2D.MovePosition(Vector3.MoveTowards(blackCircleSpriteRB2D.transform.position,
            centerPos + posOffset, scaledOuterDistance / framesToTarget));
    }

    IEnumerator RotateCircles()
    {
        while (!Mathf.Approximately(circlesSpriteRB2D.rotation, circlesTargetRotation))
        {
            circlesSpriteRB2D.SetRotation(Mathf.MoveTowards(circlesSpriteRB2D.rotation,
                circlesTargetRotation, rotationSpeed));
            yield return new WaitForFixedUpdate();
        }

        symbolRotating = false;
    }

    IEnumerator RotateEdges()
    {
        while (!Mathf.Approximately(edgesRB2D.rotation, edgesTargetRotation))
        {
            edgesRB2D.SetRotation(Mathf.MoveTowards(edgesRB2D.rotation, edgesTargetRotation,
                rotationSpeed));
            yield return new WaitForFixedUpdate();
        }
    }
}
