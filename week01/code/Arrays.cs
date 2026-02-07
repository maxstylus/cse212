public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Read in the number
        // Starting at '1', multiply the number incremently until the length is hit
        // multiplesOf(7, 5) should return {7, 14, 21, 28, 35}

        List<double> multiples = new List<double>();
        for (var i = 1; i <= length; ++i) {
            var multiple = number * i;

            // add the multiple to the array
            multiples.Add(multiple);            
        }     

        return multiples.ToArray();
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Read in the list and the amount
        // Take the last 'amount' of items and move them to the front of the list
        // RotateListRight(List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9}, 3) should modify the list to be List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}

        var count = data.Count;
        if (amount < count) 
        {
            // If the amount is less than the count, perform the rotation normally
            var rotated = new List<int>(data);
            for (var i = 0; i < count; ++i) {
                var rotatedIndex = (i + amount) % count;
                rotated[rotatedIndex] = data[i];
            }

            for (var i = 0; i < count; ++i) {
                data[i] = rotated[i];
            }
        } 
        else if (amount == count) 
        {
            // If the amount is the same as the count, then the list will be the same after rotation
            // No need to do anything
            return;
        } 
        else if (amount > count) 
        {
            // If the amount is greater than the count, then we can rotate by the amount mod the count
            RotateListRight(data, amount % count);
        }

    }
}
