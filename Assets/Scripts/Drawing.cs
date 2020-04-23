using UnityEngine;

public class Drawing
{

    public static Texture2D lineTex = new Texture2D(1, 1); //Single pixel texture

    // public static void DrawLine(Rect rect) { DrawLine(rect, GUI.contentColor, 1.0f); }
    // public static void DrawLine(Rect rect, Color color) { DrawLine(rect, color, 1.0f); }
    // public static void DrawLine(Rect rect, float width) { DrawLine(rect, GUI.contentColor, width); }
    // public static void DrawLine(Rect rect, Color color, float width) { DrawLine(new Vector2(rect.x, rect.y), new Vector2(rect.x + rect.width, rect.y + rect.height), color, width); }
    // public static void DrawLine(Vector2 pointA, Vector2 pointB) { DrawLine(pointA, pointB, GUI.contentColor, 1.0f); }
    // public static void DrawLine(Vector2 pointA, Vector2 pointB, Color color) { DrawLine(pointA, pointB, color, 1.0f); }
    // public static void DrawLine(Vector2 pointA, Vector2 pointB, float width) { DrawLine(pointA, pointB, GUI.contentColor, width, 1); }
    public static void DrawLine(Vector2 pointA, Vector2 pointB, Color color, float width)
    {
        Matrix4x4 matrix = GUI.matrix; // Save current GUI matrix.
        if ((pointB - pointA).magnitude < 0.001f) // Deny if Line too small
            return;

        Color savedColor = GUI.color;// Save current GUI color,
        GUI.color = color;// and set the GUI color to the color parameter
        // pointB.y *= scaleFactor; //fixes missalignment from applying wrong angle
        float angle = Vector3.Angle(pointB - pointA, Vector2.right);// Determine the angle of the line.


        // Vector3.Angle always returns a positive number.
        // If pointB is above pointA, then angle needs to be negative.
        if (pointA.y > pointB.y) { angle = -angle; }


        Vector3 pivot = pointA;//new Vector2(pointA.x, pointA.y + width / 2); //Pivot is on pointA and shifted to the middle with + 0.5f
        GUIUtility.RotateAroundPivot(angle, pivot);// Set the rotation for the line with pointA as the origin
        GUI.DrawTexture(new Rect(pointA.x, pointA.y, (pointB - pointA).magnitude, width), lineTex); //Draws and scales the line

        GUI.matrix = matrix; // Restore the GUI matrix...
        GUI.color = savedColor; // ...and GUI color to previous values
    }
}