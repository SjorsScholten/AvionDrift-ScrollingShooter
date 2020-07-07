using System.Collections.Generic;
using Util.Variables;

[System.Serializable]
public class Rail {
    public List<Point> points = new List<Point>();
    private int index = 0;

    public Rail() {
    }

    public Point GetPoint() {
        return points[index];
    }

    public Point GetNextPoint() {
        if (++index > points.Count - 1) index = 0;
        return GetPoint();
    }
}