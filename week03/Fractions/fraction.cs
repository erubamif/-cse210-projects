using System;

public class Fraction
{
    // Private attributes (encapsulation)
    private int _top;
    private int _bottom;

    // Constructor 1: No parameters (1/1)
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // Constructor 2: One parameter (top, bottom = 1)
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    // Constructor 3: Two parameters
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // Getter for top
    public int GetTop()
    {
        return _top;
    }

    // Setter for top
    public void SetTop(int top)
    {
        _top = top;
    }

    // Getter for bottom
    public int GetBottom()
    {
        return _bottom;
    }

    // Setter for bottom
    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    // Method to return fraction string (e.g., 3/4)
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    // Method to return decimal value
    public double GetDecimalValue()
    {
        return (double)_top / _bottom;
    }
}